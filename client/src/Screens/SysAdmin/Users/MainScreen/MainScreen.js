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

export default function MainScreen(props){
    document.title = "Пользователи";
    const [currentUsers, setCurrentUsers] = useState(undefined);
    const [oldUsers, setOldUsers] = useState(undefined);
    const [cookie, setCookie] = useCookies("user");
    const [list, settList] =useState();
    const [countUsers, setCountUsers] = useState(0);
    const [page, setPage] = useState(1);
    const [globalClick, setGlobalClick] = useState(false);
    const [buttonCross, setButtonCross] = useState(<ButtonCross id={"global-cross"} isActive={"unable"}/>);

    useEffect(() => {
        (async () => {
            props.setIsLoaded(false);
            let users = await GetAllUsers(cookie.user);
            setCurrentUsers(users);
            let count = users.chiefsOfMedicine.length + users.doctors.length + users.headOfDepartments.length + users.medicRegistrators.length
            count += users.patients.length + users.sysAdmins.length;
            setCountUsers(count);
        })();
    }, []);

    useEffect(() => {
        (() => {
            if(currentUsers !== undefined){
                props.setIsLoaded(true);
                settList(<UsersList onClickCheckBox={clickCheckBox} data={currentUsers}
                                    oldList={oldUsers} setPage={setPage} page={page}
                                    sizeCheckbox={classes.sizeCheckBox} blurPageNone={classes.none} setMessageBox={props.setMessageBox}/>)
            }
        })();
    }, [currentUsers]);
    useEffect(() =>{
        (async () =>{
            let newUsers = await GetAllUsers(cookie.user);
            let newCount = newUsers.chiefsOfMedicine.length + newUsers.doctors.length + newUsers.headOfDepartments.length + newUsers.medicRegistrators.length
            newCount += newUsers.patients.length + newUsers.sysAdmins.length;
            if(countUsers !== newCount){
                setCountUsers(newCount);
                setOldUsers(currentUsers);
                setCurrentUsers(newUsers);
            }else{
                setOldUsers(undefined);
            }
        })();
    },[props.count]);
    useEffect(() => {
        (() => {
            setButtonCross(globalClick ? <ButtonCross id={"global-cross"} isActive={"active"}
                                                      toolText={"Удалить всех пользователей"} attributeHint={classes.attributeHintCross}
                                                      onClick={clickRemoveAllUsers} classNone={classes.none} /> :
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
    }
    function clickRemoveAllUsers(){
        localStorage.setItem("action", JSON.stringify({
            name: "RemoveAll",
            attribute: null,
            body: null
        }));
        console.log(localStorage.getItem("action"));
        props.setMessageBox(<MessageBox title={"Уведомление"} text={"Вы действительно хотите удалить всех пользователей?"}
                                        buttons={"YesNo"} onShow={props.onShowMsgBox} onHide={props.onHideMsgBox}
                                        isNeedConfirm={true} onShowConfirm={props.onShowConfirm}/>);
        props.onShowMsgBox();

    }
    return(
        <div id={props.id} className={`${classes.content}`}>
            <div className={`row`}>
                <div className={`col-3`}>
                    <ButtonFastAction text={"добавить пользователя"} icon={iconAddPerson}/>
                </div>
                <div className={`col-8`}></div>
            </div>
            <div className={`row ${classes.row}`}>
                <div className={`col-1 ${classes.align_center} ${classes.flex_end} ${classes.padding_right_null}`}>
                    <GlobalCheckbox id={"global"} size={classes.sizeCheckBox}
                                    setGlobalClick={setGlobalClick} />
                </div>
                <div className={`col-11 ${classes.title}`}>
                    <div className={`row`}>
                        <div className={`col ${classes.flex_start}`}>
                            Логин
                        </div>
                        <div className={`col ${classes.flex_center}`}>
                            Роль
                        </div>
                        <div className={`col ${classes.flex_end}`}>
                            {buttonCross}
                        </div>
                    </div>
                </div>
            </div>
            <div className={`row ${classes.line}`}></div>
            {list}
        </div>
    )
}