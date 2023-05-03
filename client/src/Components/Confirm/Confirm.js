import classes from "./Confirm.module.css";
import {useState} from "react";
import {ConfirmAction} from "../../Swapi/SwapiAccount/SwapiAccount"
import {useCookies} from "react-cookie";
import Button from "../Buttons/Button/Button";
import ButtonWithHintAndIcon from "../Buttons/ButtonWithHintAndIcon/ButtonWithHintAndIcon";
import iconActive from "../../Images/Icons/IconCross/BlackVersion/CrossActive.svg";
import iconHover from "../../Images/Icons/IconCross/BlackVersion/CrossHover.png";
import {AttributeIcon} from "../Buttons/ButtonWithHintAndIcon/IButtonWithHintAndIconProps";
import {AttributeHint} from "../Hint/AttributeHint";
import type {IConfirmProps} from "./IConfirmProps";
import {Input} from "../Inputs/Input/Input";
import {ErrorAttribute, LabelAttribute, ToggleSwitchAttributes} from "../Inputs/Input/IInputProps";

const ids = {
    password: {
        input: "confirm-password",
        error: "confirm-error-password"
    },
    buttons: {
        accept: "btn-accept-confirm",
        cancel: "btn-cancel-confirm"
    }
}

export default function Confirm(props: IConfirmProps){
    const [password, setPassword] = useState("");
    const cookie = useCookies("user");
    async function clickOnAccept(){
        let el = document.getElementById(ids.password.input);
        el.value = "";
        let result = await ConfirmAction(cookie[0].user, password);
        if(result){
            props.action.onHide();
            await props.action.onAccept();
        }
        else{
            props.action.onFail();
        }
    }
    function clickOnCancel(){
        let el = document.getElementById(ids.password.input);
        el.value = "";
        props.action.onHide();
    }
    return(
        <div id={props.id} className={`${props.action.styleNone} ${classes.content}`}>
            <div className={`row`}>
                <div className={`col ${classes.positionBtnTitle} ${classes.title}`}>
                    Подтверждение
                </div>
                <div className={`col ${classes.positionBtnCross}`}>
                    <ButtonWithHintAndIcon width={15}
                                           iconEnable={iconActive}
                                           iconHover={iconHover}
                                           attributeIcon={new AttributeIcon(19, "auto")}
                                           status={"Active"}
                                           isNeedHint={true}
                                           attributeHint={new AttributeHint(65, -32, "Закрыть")}
                                           onClick={clickOnCancel} />
                </div>
            </div>
            <div className={`row ${classes.text} ${classes.positionText}`}>
                <Input id={ids.password.input}
                       placeholder={"Введите пароль..."}
                       type={"password"}
                       setValue={setPassword}
                       toggleSwitchAttribute={new ToggleSwitchAttributes("Показать пароль")}
                       errorAttribute={new ErrorAttribute(ids.password.error)}
                       labelAttribute={new LabelAttribute("Пароль")}/>
            </div>
            <div className={`row ${classes.positionBtn}`}>
                <div className={`col-5 ${classes.btnOne}`}>
                    <Button id={ids.buttons.accept}
                            size={"s"}
                            text={"Подтвердить"}
                            theme={"Success"}
                            isDisplay={true}
                            onClick={async () => { await clickOnAccept();}} />
                </div>
                <div className={`col-2`}></div>
                <div className={`col-5 ${classes.btnTwo}`}>
                    <Button id={ids.buttons.cancel}
                            size={"s"}
                            text={"Отменить"}
                            theme={"Red"}
                            isDisplay={true}
                            onClick={() => {clickOnCancel();}} />
                </div>
            </div>
        </div>)
}