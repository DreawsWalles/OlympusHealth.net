import classes from "./Confirm.module.css";
import ButtonCross from "../Buttons/ButtonCross/ButtonCrossBlackVersion/ButtonCross";
import PasswordInput from "../Inputs/PasswordInput/PasswordInput";
import {useEffect, useState} from "react";
import ButtonAccept from "../Buttons/ButtonsDialog/ButtonAccept/ButtonAccept";
import ButtonCancel from "../Buttons/ButtonsDialog/ButtonCancel/ButtonCancel";
import {ConfirmAction} from "../../Swapi/SwapiAccount"
import {useCookies} from "react-cookie";
export default function Confirm(props){
    const [result, setResult] = useState("disable")
    const [password, setPassword] = useState("");
    const cookie = useCookies("user");
    async function clickOnAccept(){
        let el = document.getElementById("confirm-password");
        el.value = "";
        let result = await ConfirmAction(cookie[0].user, password);
        if(result){
            props.onHide();
            await props.onSuccess();
        }
        else{
            props.onFail();
        }
    }
    function clickOnCancel(){
        let el = document.getElementById("confirm-password");
        el.value = "";
        props.onHide();
    }
    return(
        <div id={"confirm"} className={`${`${props.className} ${classes.content}`}`}>
            <div className={`row`}>
                <div className={`col ${classes.positionBtnTitle} ${classes.title}`}>
                    Подтверждение
                </div>
                <div className={`col ${classes.positionBtnCross}`}>
                    <ButtonCross btnCrossActive={"active"} toolText={"Закрыть"} attribute={classes.attribute} attributeHint={classes.attributeHintCross}
                                 onClick={clickOnCancel}/>
                </div>
            </div>
            <div className={`row ${classes.text} ${classes.positionText}`}>
                <PasswordInput id={"confirm-password"} placeholder={"Введите пароль..."} onChange={setPassword}/>
            </div>
            <div className={`row ${classes.positionBtn}`}>
                <div className={`col-5 ${classes.btnOne}`}>
                    <ButtonAccept onClick={clickOnAccept} text={"Подтвердить"}/>
                </div>
                <div className={`col-2`}></div>
                <div className={`col-5 ${classes.btnTwo}`}>
                    <ButtonCancel onClick={clickOnCancel} text={"Отменить"}/>
                </div>
            </div>
        </div>)
}