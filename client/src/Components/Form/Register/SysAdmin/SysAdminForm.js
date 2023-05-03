import {useEffect, useState} from "react";
import GenerateLogin from "../../../../Generators/GenerateLogin";
import GeneratePassword from "../../../../Generators/GeneratePassword";
import {CheckLogin} from "../../../../Swapi/SwapiAccount/SwapiAccount";
import classes from "./SysAdmin.module.css"
import {clickOnButtonAuto, clickOnButtonRefresh} from "../functionsButtons";
import classesBtn from "../../../Buttons/Button/Button.module.css";
import Button from "../../../Buttons/Button/Button";
import {Input} from "../../../Inputs/Input/Input";
import {ErrorAttribute, ToggleSwitchAttributes} from "../../../Inputs/Input/IInputProps";
import {Hint} from "../../../Functions";
import {RegisterModelSysAdmin} from "../../../../Entities/AutorizeModel/RegisterModelSysAdmin";
import {ISysAdminFormProps} from "./ISysAdminFormProps";
import {check, checkOnLength} from "../../FunctionValidates";

const ids = {
    login: {
        input: "login",
        error: "error-login",
        buttons: {
            auto: "btn-login",
            refresh: "btn-login-refresh"
        }
    } ,
    password: {
        input: "password",
        error: "error-password",
        buttons: {
            auto: "btn-password",
            refresh: "btn-password-refresh"
        }
    },
    button: "btn-submit-registration-sysAdmin"
}

export default function SysAdminForm(props: ISysAdminFormProps){
    debugger
    const [login: string, setLogin] = useState("");
    const [isAutoLogin: boolean, setIsAutoLogin] = useState(false);
    const [password, setPassword] = useState("");
    const [isAutoPassword, setIsAutoPassword] = useState(false);
    const [autoLogin: string, setAutoLogin] = useState();
    const [autoPassword: boolean, setAutoPassword] = useState();
    const [refreshLogin: boolean, setRefreshLogin] = useState();

    useEffect(() => {
        (async () => {
            let element = document.getElementById(ids.login.input);
            if(isAutoLogin) {
                element.setAttribute("disabled", true);
                let btn = document.getElementById(ids.login.buttons.auto);
                btn.setAttribute("disabled", true);
                element.value = await GenerateLogin();
                setLogin(element.value);
                btn.removeAttribute("disabled");
            }
            else{
                element.removeAttribute("disabled");
            }
        })();
    }, [isAutoLogin]);
    useEffect(() => {
        (async () => {
            let element = document.getElementById(ids.password.input);
            if(isAutoPassword) {
                element.setAttribute("disabled", true);
                let btn = document.getElementById(ids.password.buttons.auto);
                btn.setAttribute("disabled", true);
                element.value = await GeneratePassword(10);
                setPassword(element.value);
                btn.removeAttribute("disabled");
            }
            else{
                element.removeAttribute("disabled");
            }
        })();
    }, [isAutoPassword]);
    useEffect(() => {
        (async () => {
            let element = document.getElementById(ids.login.input);
            if(isAutoLogin) {
                element.setAttribute("disabled", true);
                let btn = document.getElementById(ids.login.buttons.auto);
                btn.setAttribute("disabled", true);
                element.value = await GenerateLogin();
                setLogin(element.value);
                btn.removeAttribute("disabled");
            }
            else{
                element.removeAttribute("disabled");
            }
        })();
    }, [refreshLogin]);
    const [refreshPassword, setRefreshPassword] = useState();
    useEffect(() => {
        (async () => {
            let element = document.getElementById(ids.password.input);
            if(isAutoPassword) {
                element.setAttribute("disabled", true);
                let btn = document.getElementById(ids.password.buttons.auto);
                btn.setAttribute("disabled", true);
                element.value = await GeneratePassword(10);
                setPassword(element.value);
                btn.removeAttribute("disabled");
            }
            else{
                element.removeAttribute("disabled");
            }
        })();
    }, [refreshPassword]);

    async function submitForms(){
        debugger
        let isCorrect = new Set();
        if(!isAutoLogin){
            isCorrect.add(await check(login,
                ids.login.error,
                ["Это поле обязательное для заполнения",
                    "Пользователь с таким логином уже сущетсвует"],
                [checkOnLength, CheckLogin]));
        }
        if(!isAutoPassword){
            isCorrect.add(await check(password,
                ids.password.error,
                "Это поле обязательно для заполнения", [checkOnLength]));
        }
        if(isCorrect.has(false))
            return;
        let result = await props.onSubmit(new RegisterModelSysAdmin(login, password));
        if(!result) {
            Hint(ids.password.error, "Невозможно зарегистрировать аккаунт. Попробуйте позже");
        }
    }
    return(
        <div className={classes.content}>
            <div className={`row ${classes.row}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>Логин:</div>
                </div>
                <div className={"col-6"}>
                    <Input id={ids.login.input}
                           placeholder={"Введите логин..."}
                           type={"text"}
                           setValue={setLogin}
                           toggleSwitchAttribute={null}
                           errorAttribute={new ErrorAttribute(ids.login.error)}
                           labelAttribute={null} />
                </div>
                <div className={`col-3 ${classes.btnAuto}`}>
                    <div className={`row`}>
                        <div className={`col-3`}>
                            <Button id={ids.login.buttons.auto}
                                    size={"xs"}
                                    text={"auto"}
                                    theme={"Success_outline"}
                                    isDisplay={true}
                                    onClick={() => {clickOnButtonAuto(ids.login.buttons.auto,
                                        ids.login.input,
                                        ids.login.buttons.refresh,
                                        autoLogin,
                                        setAutoLogin,
                                        classesBtn.none,
                                        setIsAutoLogin)}} />
                        </div>
                        <div className={`col-8`}>
                            <Button id={ids.login.buttons.refresh}
                                    size={"xs"}
                                    text={"↺"}
                                    theme={"Success"}
                                    isDisplay={false}
                                    onClick={() => {clickOnButtonRefresh(refreshLogin, setRefreshLogin)}} />
                        </div>
                        <div className={`col-1`}></div>
                    </div>
                </div>
            </div>
            <div className={`row ${classes.row}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>Пароль:</div>
                </div>
                <div className={"col-6"}>
                    <Input id={ids.password.input}
                           placeholder={"Введите пароль..."}
                           type={"password"}
                           setValue={setPassword}
                           toggleSwitchAttribute={new ToggleSwitchAttributes("Показать пароль")}
                           errorAttribute={new ErrorAttribute(ids.password.error)}
                           labelAttribute={null} />
                </div>
                <div className={`col-3 ${classes.btnAuto}`}>
                    <div className={`row`}>
                        <div className={`col-3`}>
                            <Button id={ids.password.buttons.auto}
                                    size={"xs"}
                                    text={"auto"}
                                    theme={"Success_outline"}
                                    isDisplay={true}
                                    onClick={() => {clickOnButtonAuto(ids.password.buttons.auto,
                                        ids.password.input,
                                        ids.password.buttons.refresh,
                                        autoPassword,
                                        setAutoPassword,
                                        classesBtn.none,
                                        setIsAutoPassword)}} />
                        </div>
                        <div className={`col-8`}>
                            <Button id={ids.password.buttons.refresh}
                                    size={"xs"}
                                    text={"↺"}
                                    theme={"Success"}
                                    isDisplay={false}
                                    onClick={() => {clickOnButtonRefresh(refreshPassword, setRefreshPassword)}} />
                        </div>
                        <div className={`col-1`}></div>
                    </div>
                </div>
            </div>
            <div className={`row ${classes.rowBtn}`}>
                <div className={`col-3`}></div>
                <div className={`col-6`}>
                    <Button id={ids.button}
                            size={"L"}
                            text={props.textButton}
                            theme={"Red"}
                            isDisplay={true}
                            onClick={async () => {await submitForms();}} />
                    </div>
                <div className={`col-3`}></div>
            </div>
        </div>
    )
}