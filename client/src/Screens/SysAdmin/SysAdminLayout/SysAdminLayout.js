import React, {useEffect, useState} from "react";
import classes from "./SysAdminLayout.module.css";
import classesActionNotification from "../../../Components/Notifications/ActionNotification/ActionNotification.module.css"
import Logo from "../../../Images/logo.svg";
import Menu from "../../../Components/Menu/SysAdmin/Menu";
import StartScreen from "../StartScreen/StartScreen";
import Loader from "../../../Components/Loader/Loader";
import Confirm from "../../../Components/Confirm/Confirm";
import ActionNotification from "../../../Components/Notifications/ActionNotification/ActionNotification";
import {Actions} from "../../../Actions/SysAdminActions";
import Token from "../../../Components/Token";
import ButtonPersonalArea from "../../../Components/Buttons/ButtonPersonalArea/ButtonPersonalArea";
import SubScreen from "../../../Components/SubScreen/Component/SubScreen";



export default function SysAdminLayout(){
    const [content, setContent] = useState(<StartScreen />);
    const [choice, setChoice] = useState(0)
    const [isLoaded, setIsLoaded] = useState(true);
    const [messageBox,setMessageBox] = useState();
    const [checkToken, setCheckToken] = useState(<Token />);
    const [actionNotification, setActionNotification] = useState(null);
    const [confirm, setConfirm] = useState(<Confirm className={classes.none} onFail={onFailConfirm} onSuccess={onAcceptConfirm}
                                                    onShow={onShowConfirm} onHide={onHideConfirm}/>);
    let subScreens = [];
    const [subScreen, setSubScreen] = useState();
    const SubScreenParameters = {
        canBack: false,
        functions:
            {
                Close: CloseAllSubScreen,
                Add: AddSubScreen
            }
    };
    useEffect(() =>{
        (() =>{
            document.getElementById('load').classList.add(classes.none);
        })();
    }, []);
    useEffect(() => {
        (() => {
            let loader = document.getElementById('load');
            let content = document.getElementById('mainContent');
            if(loader !== null && content !== null) {
                if (isLoaded) {
                    loader.classList.add(classes.none);
                    content.classList.remove(classes.none);
                }else{
                    loader.classList.remove(classes.none);
                    content.classList.add(classes.none);
                }
            }
        })();
    }, [isLoaded]);
    function clickOnLogo(){
        setIsLoaded(true);
        setContent(<StartScreen setContent={setContent} subScreenParameters={SubScreenParameters}/>);
        setChoice(0);
    }
    function onShowMessageBox(){
        let box = document.getElementById("message-box");
        let blur = document.getElementById("blur");
        blur.classList.remove(classes.none);
        box.classList.remove(classes.none);
    }
    function onHideMessageBox(){
        let box = document.getElementById("message-box");
        let blur = document.getElementById("blur");
        blur.classList.add(classes.none);
        box.classList.add(classes.none);
    }
    function onShowConfirm(){
        let confirm = document.getElementById("confirm");
        let blur = document.getElementById("blur");
        blur.classList.remove(classes.none);
        confirm.classList.remove(classes.none);
    }
    function onHideConfirm(){
        let confirm = document.getElementById("confirm");
        let blur = document.getElementById("blur");
        blur.classList.add(classes.none);
        confirm.classList.add(classes.none);
    }
    function onFailConfirm(){
        onShowActionNotification("Введен некорректный пароль", "fail");
    }
    async function onAcceptConfirm(){
        let result = await Actions(JSON.parse(localStorage.getItem("action")));
        if(result.result){
            onShowActionNotification(result.Message, "success");
        }else {
            onShowActionNotification(result.Message, "fail");
        }
    }
    function onShowActionNotification(text, type){
        let el = document.getElementById("notification");
        setActionNotification(<ActionNotification text={text} type={type}/>);
        el.classList.remove(classesActionNotification.none);
        el.classList.add(classesActionNotification.show);
        el.classList.add(classesActionNotification.hide);
    }
    function ViewSubScreens(){
        let blur = document.getElementById("blur");
        if(subScreens.length === 0) {
            setSubScreen(null);
            blur.classList.add(classes.none);
        }else{
            blur.classList.remove(classes.none);
            if(subScreens.length > 1) {
                subScreens[subScreens.length - 1].props.parameters.canBack = true;
            }
            let a = subScreens[subScreens.length - 1]
            setSubScreen(subScreens.map((element) => <SubScreen parameters={SubScreenParameters} />));
        }
    }
    function AddSubScreen(content){
        subScreens[subScreens.length] = content;
        ViewSubScreens();
    }
    function CloseAllSubScreen(){
        subScreens = [];
        ViewSubScreens();
    }
    return (
        <div className={classes.content}>
            <div onClick={clickOnLogo} className={classes.head}>
                <img src={Logo}/>
            </div>
            <div>
                <ButtonPersonalArea isSelect={false}/>
            </div>
            <Menu setContent={setContent} choice={choice}
                  functionsMsgBox={{
                    set: setMessageBox,
                    show: onShowMessageBox,
                    hide: onHideMessageBox }}
                  functionsConfirm={{
                      show: onShowConfirm,
                      hide: onHideConfirm
                  }}
                  setChoice={setChoice} setIsLoaded={setIsLoaded}
                  SubScreenParameters={SubScreenParameters}/>
            <Loader />
            {content}
            <div id={"blur"} className={`${classes.blur} ${classes.none}`}></div>
            {messageBox}
            {confirm}
            {actionNotification}
            {checkToken}
            {subScreen}
        </div>
    )
}