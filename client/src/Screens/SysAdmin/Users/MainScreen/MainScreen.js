import ButtonFastAction from "../../../../Components/Buttons/ButtonFastAction/SmallVersion/ButtonFastAction";
import iconAddPerson from "../../../../Images/MenuIcons/AddPerson/iconAddPerson.svg";
import classes from "./MainScreen.module.css";
import ButtonCross from "../../../../Components/Buttons/ButtonCross/ButtonCrossBlackVersion/ButtonCross";
import GlobalCheckbox from "../../../../Components/Checkboxes/GlobalCheckbox/GlobalCheckbox";
import {useEffect, useState} from "react";
import {GetAllUsers} from "../../../../Swapi/SwapiSysAdmin";
import {useCookies} from "react-cookie";
import UsersList from "../../../../Components/Lists/SysAdmin/UsersList/List/UsersList";
import MessageBox from "../../../../Components/MessageBox/MessageBox";
import Search from "../../../../Components/Lists/Search/Search";
import SearchUsersList from "../../../../Components/Lists/SysAdmin/SearchUsersList/List/SearchUsersList";
import SubScreen from "../../../../Components/SubScreen/Component/SubScreen";

export default function MainScreen(props){
    document.title = "Пользователи";
    const [currentUsers, setCurrentUsers] = useState(undefined);
    const [oldUsers, setOldUsers] = useState(undefined);
    const [cookie, setCookie] = useCookies("user");
    const [list, setList] =useState();
    const [countUsers, setCountUsers] = useState(0);
    const [globalClick, setGlobalClick] = useState(false);
    const [buttonCross, setButtonCross] = useState(<ButtonCross id={"global-cross"} isActive={"unable"}/>);
    const [filter, setFilter] = useState("");

    useEffect(() => {
        (async () => {
            debugger
            props.setIsLoaded(false);
            let users = await GetAllUsers(cookie.user);
            setCurrentUsers(users);
            let count = users.chiefsOfMedicine.length + users.doctors.length + users.headOfDepartments.length + users.medicRegistrations.length
            count += users.patients.length + users.sysAdmins.length;
            setCountUsers(count);
        })();
    }, []);

    function CheckOnAccept(oldUsers, newUsers){
        for(let i = 0; i < newUsers.sysAdmins.length; i++){
            if(oldUsers.sysAdmins[i].Accept === newUsers.sysAdmins[i].Accept){
                return true;
            }
        }
        for(let i = 0; i < newUsers.chiefsOfMedicine.length; i++){
            if(oldUsers.chiefsOfMedicine[i].Accept === newUsers.chiefsOfMedicine[i].Accept){
                return true;
            }
        }
        for(let i = 0; i < newUsers.doctors.length; i++){
            if(oldUsers.doctors[i].Accept === newUsers.doctors[i].Accept){
                return true;
            }
        }
        for(let i = 0; i < newUsers.headOfDepartments.length; i++){
            if(oldUsers.headOfDepartments[i].Accept === newUsers.headOfDepartments[i].Accept){
                return true;
            }
        }
        for(let i = 0; i < newUsers.medicRegistrations.length; i++){
            if(oldUsers.medicRegistrations[i].Accept === newUsers.medicRegistrations[i].Accept){
                return true;
            }
        }
        for(let i = 0; i < newUsers.patients.length; i++){
            if(oldUsers.patients[i].Accept === newUsers.patients[i].Accept){
                return true;
            }
        }
        return false;
    }
    function SearchUsers(list, filter){
        let sysAdmins = list.sysAdmins.filter(element => element.login.search(filter) === 0);
        let chiefsOfMedicine = list.chiefsOfMedicine.filter(element => element.login.search(filter) === 0);
        let doctors = list.doctors.filter(element => element.login.search(filter) === 0);
        let headOfDepartments = list.headOfDepartments.filter(element => element.login.search(filter) === 0);
        let medicRegistrations = list.medicRegistrations.filter(element => element.login.search(filter) === 0);
        let patients = list.patients.filter(element => element.login.search(filter) === 0);
        return {
            sysAdmins: sysAdmins,
            chiefsOfMedicine: chiefsOfMedicine,
            doctors: doctors,
            headOfDepartments: headOfDepartments,
            medicRegistrations: medicRegistrations,
            patients: patients
        };

    }
    useEffect(() => {
        (() => {
            if(currentUsers !== undefined){
                props.setIsLoaded(true);
                if(filter !== undefined && filter !== ""){
                    let searchList = SearchUsers(currentUsers,  filter);
                    setList(<SearchUsersList onClickCheckBox={clickCheckBox}
                                             data={searchList}
                                             styleProperties={{
                                                 blurNone: classes.none
                                             }}
                                             functionsMsgBox={props.functionsMsgBox}
                                             onShowConfirm={props.functionsConfirm.show} />);
                }else {
                    setList(<UsersList onClickCheckBox={clickCheckBox}
                                       data={currentUsers}
                                       oldList={oldUsers}
                                       styleProperties={{
                                           blurNone: classes.none
                                       }}
                                       functionsMsgBox={props.functionsMsgBox}
                                       onShowConfirm={props.functionsConfirm.show} />)
                }
            }
        })();
    }, [currentUsers, filter]);
    useEffect(() =>{
        (async () =>{
            let newUsers = await GetAllUsers(cookie.user);
            let newCount = newUsers.chiefsOfMedicine.length + newUsers.doctors.length + newUsers.headOfDepartments.length + newUsers.medicRegistrations.length
            newCount += newUsers.patients.length + newUsers.sysAdmins.length;
            debugger
            if(countUsers !== newCount){
                setCountUsers(newCount);
                setOldUsers(currentUsers);
                setCurrentUsers(newUsers);
                checkCheckBoxes(countUsers < newCount);
            }else{
                debugger
                if(CheckOnAccept(currentUsers, newUsers)){
                    setCurrentUsers(newUsers);
                }
                setOldUsers(currentUsers);
            }
        })();
    },[props.count]);
    function checkCheckBoxes(isMore){
        let checkBoxes = document.querySelectorAll('input[type=checkbox]');
        if(checkBoxes.length < 2){
            return;
        }
        let count = 2;
        for(let i = 0; i < checkBoxes.length; i++){
            if(checkBoxes.item(i).attributes[0].nodeValue !== "global" && checkBoxes[i].checked){
                count++;
            }
        }
        debugger
        if(checkBoxes.length !== 2) {
            if (isMore) {
                checkBoxes.item(0).checked = checkBoxes.length === count;
            } else {
                checkBoxes.item(0).checked = checkBoxes.length - 1 === count;
            }
            setButtonCross(checkBoxes.item(0).checked ? <ButtonCross id={"global-cross"} isActive={"active"}
                                                                     toolText={"Удалить всех пользователей"} attributeHint={classes.attributeHintCross}
                                                                     onClick={clickRemoveUsers} classNone={classes.none}/> :
                                                                    <ButtonCross id={"global-cross"} isActive={"unable"}/>);
        }
    }
    useEffect(() => {
        (() => {
            debugger
            setButtonCross(globalClick ? <ButtonCross id={"global-cross"} isActive={"active"}
                                                      toolText={"Удалить всех пользователей"} attributeHint={classes.attributeHintCross}
                                                      onClick={clickRemoveUsers} classNone={classes.none}/> :
                                                <ButtonCross id={"global-cross"} isActive={"unable"}/>);
            let checkboxes = document.querySelectorAll('input[type=checkbox]');
            let count = 2;
            for(let i = 0; i < checkboxes.length; i++){
                if(checkboxes.item(i).attributes[0].nodeValue !== "global" && checkboxes[i].checked){
                    count++;
                }
            }
            setButtonCross(count > 2 ? <ButtonCross id={"global-cross"} isActive={"active"}
                                                    toolText={"Удалить всех пользователей"} attributeHint={classes.attributeHintCross}
                                                    onClick={clickRemoveUsers} classNone={classes.none}/> :
                                            <ButtonCross id={"global-cross"} isActive={"unable"}/>);
        })();
    },[globalClick]);

    function clickCheckBox(){
        let checkboxes = document.querySelectorAll('input[type=checkbox]');
        let count = 2;
        for(let i = 0; i < checkboxes.length; i++){
            if(checkboxes.item(i).attributes[0].nodeValue !== "global" && checkboxes[i].checked){
               count++;
            }
        }
        if(checkboxes.length === count) {
            setGlobalClick(true);
            document.getElementById("global").checked = true;
        }else{
            setGlobalClick(false);
            document.getElementById("global").checked = false;
        }
        setButtonCross(count > 2 ? <ButtonCross id={"global-cross"} isActive={"active"}
                                                toolText={"Удалить всех пользователей"} attributeHint={classes.attributeHintCross}
                                                onClick={clickRemoveUsers} classNone={classes.none}/> :
                                        <ButtonCross id={"global-cross"} isActive={"unable"}/>);
    }
    function clickRemoveUsers(){
        let keys = [];
        let checkboxes = document.querySelectorAll('input[type=checkbox]');
        for(let i = 0; i < checkboxes.length - 1; i++){
            if(checkboxes.item(i).attributes[0].nodeValue !== "global" && checkboxes.item(i).checked){
                checkboxes.item(i).checked = false;
                keys[keys.length] = checkboxes[i].attributes.id.nodeValue;
            }
        }
        localStorage.setItem("action", JSON.stringify({
            name: "RemoveUsers",
            attribute: null,
            body: keys
        }));
        console.log(localStorage.getItem("action"));
        props.functionsMsgBox.set(<MessageBox title={"Уведомление"} text={"Вы действительно хотите удалить всех пользователей?"}
                                        buttons={"YesNo"} onShow={props.functionsMsgBox.show} onHide={props.functionsMsgBox.hide}
                                        isNeedConfirm={true} onShowConfirm={props.onShowConfirm}/>);
        props.functionsMsgBox.show();

    }
    return(
        <div id={props.id} className={`${classes.content}`}>
            <div className={`row ${classes.margin_btn_fastAction}`}>
                <div className={`col-3 `}>
                    <ButtonFastAction text={"добавить пользователя"} icon={iconAddPerson}/>
                </div>
            </div>
            <div className={`row ${classes.row}`}>
                <div className={`col-1 ${classes.align_center} ${classes.flex_end} ${classes.padding_right_null}`}>
                    <GlobalCheckbox id={"global"} size={classes.sizeCheckBox}
                                    setGlobalClick={setGlobalClick} />
                </div>
                <div className={`col-11 ${classes.title}`}>
                    <div className={`row`}>
                        <div className={`col-4 ${classes.flex_start}`}>
                            Логин
                        </div>
                        <div className={`col-4 ${classes.flex_center}`}>
                            Роль
                        </div>
                        <div className={`col-4 ${classes.flex_end}`}>
                            <div className={`row`}>
                                <div className={`col-11`}>
                                    <Search onChange={setFilter}/>
                                </div>
                                <div className={`col-1`}>
                                    {buttonCross}
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div className={`row ${classes.line}`}></div>
            {list}
        </div>
    )
}