import React, {useEffect, useState} from "react";
import classes from "./SysAdminLayout.module.css";
import classesActionNotification from "../../../Components/Notifications/ActionNotification/ActionNotification.module.css"
import Menu from "../../../Components/Menu/SysAdmin/Menu";
import StartScreen from "../StartScreen/StartScreen";
import Loader from "../../../Components/Loader/Loader";
import Confirm from "../../../Components/Confirm/Confirm";
import ActionNotification from "../../../Components/Notifications/ActionNotification/ActionNotification";
import {Actions} from "../../../Actions/SysAdminActions";
import Token from "../../../Components/Token";
import ButtonPersonalArea from "../../../Components/Buttons/ButtonPersonalArea/ButtonPersonalArea";
import SubScreen from "../../../Components/SubScreen/Component/SubScreen";
import {Logo} from "../../../Components/Logo/Logo";
import {ActionConfirm} from "../../../Components/Confirm/ActionConfirm";
import {ActionMessageBox} from "../../../Components/MessageBox/ActionMessageBox";

const ids = {
    mainScreen: "mainScreen",
    blur: "blur",
    loader: "load",
    confirm: "confirm",
    mainMenu: "mainMenu",
    messageBox: "message-box",
    actionNotification: "notification"
}

export default function SysAdminLayout(){
    const [choice, setChoice] = useState(0)
    const [isLoaded, setIsLoaded] = useState(true);
    const [messageBox,setMessageBox] = useState();
    const checkToken = <Token />;
    const [actionNotification, setActionNotification] = useState(null);
    const confirm = <Confirm id={ids.confirm}
                                     none={classes.none}
                                     action={new ActionConfirm(ids.confirm,
                                         ids.blur,
                                         classes.none,
                                         onShowActionNotification,
                                         onShowActionNotification)}/>;
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
    const [content, setContent] = useState(<StartScreen id={ids.mainScreen}
                                                        subScreenParameters={SubScreenParameters}/>);
    useEffect(() =>{
        (() =>{
            document.getElementById(ids.loader).classList.add(classes.none);
        })();
    }, []);
    useEffect(() => {
        (() => {
            let loader = document.getElementById(ids.loader);
            let content = document.getElementById(ids.mainScreen);
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
        debugger
        setContent(<StartScreen id={ids.mainScreen}
                                subScreenParameters={SubScreenParameters}/>);
        setChoice(0);
    }
    function onShowActionNotification(text, type){
        let el = document.getElementById(ids.actionNotification);
        setActionNotification(<ActionNotification id={ids.actionNotification}
                                                  text={text}
                                                  type={type}/>);
        el.classList.remove(classesActionNotification.none);
        el.classList.add(classesActionNotification.show);
        el.classList.add(classesActionNotification.hide);
    }
    function ViewSubScreens(){
        let blur = document.getElementById(ids.blur);
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
                <Logo height={"auto"}
                      width={"auto"}/>
            </div>
            <div>
                <ButtonPersonalArea state={"NotSelect"}
                                    onClick={() => {}}/>
            </div>
            <Menu id={ids.mainMenu}
                  idContent={ids.mainScreen}
                  setContent={setContent}
                  choice={choice}
                  actionConfirm={new ActionConfirm(ids.confirm, ids.blur, classes.none, null, null)}
                  actionMessageBox={new ActionMessageBox(ids.messageBox, ids.blur, classes.none, setMessageBox)}
                  setChoice={setChoice} setIsLoaded={setIsLoaded}
                  SubScreenParameters={SubScreenParameters}/>
            <Loader id={ids.loader}/>
            {content}
            <div id={ids.blur} className={`${classes.blur} ${classes.none}`}></div>
            {messageBox}
            {confirm}
            {actionNotification}
            {checkToken}
            {subScreen}
        </div>
    )
}