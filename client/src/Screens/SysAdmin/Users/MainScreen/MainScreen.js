import iconAddPerson from "../../../../Images/MenuIcons/AddPerson/iconAddPerson.svg";
import classes from "./MainScreen.module.css";
import {useEffect, useState} from "react";
import {GetAllUsers} from "../../../../Swapi/SwapiSysAdmin/SwapiSysAdmin";
import {useCookies} from "react-cookie";
import UsersList from "../../../../Components/Lists/SysAdmin/List/UsersList";
import MessageBox from "../../../../Components/MessageBox/MessageBox";
import Search from "../../../../Components/Lists/Search/Search";
import {TwoComponentButton} from "../../../../Components/Buttons/TwoComponentButton/TwoComponentButton";
import ButtonWithHintAndIcon from "../../../../Components/Buttons/ButtonWithHintAndIcon/ButtonWithHintAndIcon";
import iconCrossActive from "../../../../Images/Icons/IconCross/BlackVersion/CrossActive.svg";
import iconCrossHover from "../../../../Images/Icons/IconCross/BlackVersion/CrossHover.png";
import iconCrossDisable from "../../../../Images/Icons/IconCross/BlackVersion/CrossDisable.svg";
import {AttributeIcon} from "../../../../Components/Buttons/ButtonWithHintAndIcon/IButtonWithHintAndIconProps";
import {AttributeHint} from "../../../../Components/Hint/AttributeHint";
import {AllUsers} from "../../../../Swapi/SwapiSysAdmin/Entities";
import type {IMainScreenProps} from "./IMainScreenProps";
import Checkbox from "../../../../Components/Checkboxes/Checkbox/Checkbox";

export default function MainScreen(props: IMainScreenProps){
    const ids = {
        globalCheckBox: "global-checkBox",
        subCheckBoxes: "list-checkBox",
        idList: "user-list",
        search: "search"
    }
    const buttonCrossDisable =  <ButtonWithHintAndIcon id={"global-cross"}
                                                       width={15}
                                                       iconEnable={iconCrossActive}
                                                       iconHover={iconCrossHover}
                                                       iconDisable={iconCrossDisable}
                                                       attributeIcon={new AttributeIcon(17, "auto")}
                                                       status={"NotActive"}
                                                       isNeedHint={false}
                                                       attributeHint={new AttributeHint(0, 0 , "")}
                                                       onClick={() => {}} />

    const buttonCrossEnable = <ButtonWithHintAndIcon id={"global-cross"}
                                                     width={15}
                                                     iconEnable={iconCrossActive}
                                                     iconDisable={iconCrossDisable}
                                                     iconHover={iconCrossHover}
                                                     attributeIcon={new AttributeIcon(17, "auto")}
                                                     status={"Active"}
                                                     isNeedHint={true}
                                                     attributeHint={new AttributeHint(180, -91, "Удалить всех пользователей")}
                                                     onClick={() => {clickRemoveUsers(); }} />;
    document.title = "Пользователи";
    const [currentUsers: AllUsers, setCurrentUsers] = useState(null);
    const [oldUsers: AllUsers, setOldUsers] = useState(null);
    const [cookie, setCookie] = useCookies("user");
    const [list, setList] = useState();
    const [countUsers, setCountUsers] = useState(0);
    const [globalCheckBox, setGlobalCheckBox] = useState(false);
    const [buttonCross, setButtonCross] = useState(buttonCrossDisable);
    const [filter, setFilter] = useState("");

    useEffect(() => {
        (async () => {
            props.changeIsLoaded(false);
            let users = await GetAllUsers(cookie.user);
            setCurrentUsers(users);
        })();
    }, []);

    useEffect(() => {
        (() => {
            if(currentUsers !== null){
                props.changeIsLoaded(true);
                if(filter !== undefined && filter !== ""){
                    let searchList = currentUsers.filter(filter);
                    setList(<UsersList id={ids.idList}
                                       idGlobalCheckBox={ids.globalCheckBox}
                                       actionGlobalClick={actionGlobalCheckBox}
                                       currentData={searchList}
                                       actionMessageBox={props.actionMessageBox}
                                       actionConfirm={props.actionConfirm}  />);
                }else {
                    setList(<UsersList id={ids.idList}
                                       idGlobalCheckBox={ids.globalCheckBox}
                                       actionGlobalClick={actionGlobalCheckBox}
                                       currentData={currentUsers}
                                       actionMessageBox={props.actionMessageBox}
                                       actionConfirm={props.actionConfirm}  />);
                }
            }
        })();
    }, [currentUsers, filter]);
    useEffect(() =>{
        (async () =>{
            let newUsers = await GetAllUsers(cookie.user);
            setCurrentUsers(newUsers);
        })();
    },[props.countNotification]);


    function clickRemoveUsers(){
        let keys = [];
        let checkboxes = document.querySelectorAll('input[type=checkbox]');
        for(let i = 0; i < checkboxes.length - 1; i++){
            if(checkboxes.item(i).attributes[0].nodeValue !== ids.globalCheckBox && checkboxes.item(i).checked){
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
        props.actionMessageBox.set(<MessageBox id={props.actionMessageBox.idBox}
                                               title={"Уведомление"}
                                               text={"Вы действительно хотите удалить всех пользователей?"}
                                               buttons={"YesNo"}
                                               actions={props.actionMessageBox}
                                               actionConfirm={props.actionConfirm}/>);
        props.actionMessageBox.onShow();
    }
    function clickOnAddUser(){

    }
    const actionGlobalCheckBox = (e) => {
        setButtonCross(e ? buttonCrossEnable : buttonCrossDisable);
    }
    const clickOnGlobalCheckBox = (e) => {
        e.checked = !e.checked;
        actionGlobalCheckBox(!e.checked);
        let checkBoxes=  document.getElementById(ids.idList).querySelectorAll('input[type=checkbox]');
        checkBoxes.forEach((element) => {
            element.checked = e.checked;
        })
    }
    return(
        <div id={props.id} className={`${classes.content}`}>
            <div className={`row ${classes.margin_btn_fastAction}`}>
                <div className={`col-3 `}>
                    <TwoComponentButton size={"m"}
                                        icon={iconAddPerson}
                                        text={"добавить пользователя"}
                                        theme={"Red"}
                                        onClick={clickOnAddUser}/>
                </div>
            </div>
            <div className={`row ${classes.row}`}>
                <div className={`col-1`}>
                    <div className={`row ${classes.rowCheckBox}`}>
                        <div className={`col-6`}>
                        </div>
                        <div className={`col-6 ${classes.checkBox}`}>
                            <Checkbox id={ids.globalCheckBox}
                                      size={"auto"}
                                      onClick={(e) => { clickOnGlobalCheckBox(e);}} />
                        </div>
                    </div>
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
                                    <Search id={ids.search}
                                            onChange={setFilter}/>
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