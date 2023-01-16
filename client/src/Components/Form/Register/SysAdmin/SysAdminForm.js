import TextInput from "../../../Inputs/TextInput/TextInput";
import {useEffect, useState} from "react";
import ButtonAuto from "../../../Buttons/ButtonAuto/ButtonAuto";
import ButtonSymbol from "../../../Buttons/ButtonSymbol/ButtonSymbol";
import PasswordInput from "../../../Inputs/PasswordInput/PasswordInput";
import GenerateLogin from "../../../../Generators/GenerateLogin";
import GeneratePassword from "../../../../Generators/GeneratePassword";
import {CheckLogin, RegisterSysAdmin} from "../../../../Swapi/SwapiAccount";
import {useCookies} from "react-cookie";
import classes from "./SysAdmin.module.css"

export default function SysAdminForm(props){
    const [login, setLogin] = useState("");
    const [isAutoLogin, setIsAutoLogin] = useState(false);
    const [autoLogin, setAutoLogin] = useState();
    const [autoPassword, setAutoPassword] = useState();

    useEffect(() => {
        (async () => {
            let element = document.getElementById("login");
            if(isAutoLogin) {
                element.setAttribute("disabled", true);
                element.value = await GenerateLogin();
                setLogin(element.value);
            }
            else{
                element.removeAttribute("disabled");
            }
        })();
    }, [isAutoLogin]);

    const [password, setPassword] = useState("");
    const [isAutoPassword, setIsAutoPassword] = useState(false);

    useEffect(() => {
        (() => {
            let element = document.getElementById("password");
            if(isAutoPassword) {
                element.setAttribute("disabled", true);
                element.value = GeneratePassword(10);
                setPassword(element.value);
            }
            else{
                element.removeAttribute("disabled");
                element.value = password;
            }
        })();
    }, [isAutoPassword]);

    const [refreshLogin, setRefreshLogin] = useState();
    useEffect(() => {
        (async () => {
            if(isAutoLogin) {
                let element = document.getElementById("login");
                element.value = await GenerateLogin();
                setLogin(element.value);
            }
        })();
    }, [refreshLogin]);

    const [refreshPassword, setRefreshPassword] = useState();
    useEffect(() => {
        (() => {
            if(isAutoPassword) {
                let element = document.getElementById("password");
                element.value = GeneratePassword(10);
                setPassword(element.value);
            }
        })();
    }, [refreshPassword]);


    function hideError(element, error){
        let span = document.getElementById(element);
        span.innerText = error;
    }
    const [cookie, setCookie] = useCookies(["user"]);
    async function submitForms(){
        let isCorrect = true;
        if(!isAutoLogin){
            if(login.trim().length === 0) {
                isCorrect = false;
                hideError("error-login", "Это поле обязательное для заполнения");
            }
            else{
                let answer = await CheckLogin(login);
                if(answer) {
                    isCorrect = false;
                    hideError("error-login", "Пользователь с таким логином уже сущетсвует");
                }
            }
        }
        if(!isAutoPassword){
            if(password.trim().length === 0){
                isCorrect = false;
                hideError("error-password", "Это поле обязательно для заполнения");
            }
        }
        if(!isCorrect)
            return;
        let answer;
        let resultFetch = await RegisterSysAdmin(JSON.stringify({
            login:login,
            password:password,
        }), answer);
        if(resultFetch === undefined) {
            hideError("error-gender", "Невозможно зарегистрировать аккаунт. Попробуйте позже");
            return;
        }
        debugger
        let tmp = resultFetch.access_token;
        setCookie("user",`${resultFetch.access_token}`);
        props.setRegistered(true);

    }
    return(
        <div className={classes.containerSysAdmin}>
            <div className={`row ${classes.rowSysAdmin}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>Логин:</div>
                </div>
                <div className={"col-6 input"}>
                    <TextInput
                        id={"login"}
                        type={"text"}
                        className={"form-control textInput"}
                        placeholder={"Введите логин..."}
                        idSpan={"error-login"}
                        onChange={setLogin}
                        required
                    />
                </div>
                <div className={`col-1 ${classes.btnAuto}`}>
                    <ButtonAuto
                        idInput={"login"}
                        oldDataSet={setAutoLogin}
                        oldData={autoLogin}
                        onClick={setIsAutoLogin}
                        id={"btn-login"}
                        btnRefresh={"btn-login-refresh"}/>
                </div>
                <div className={`col-1 ${classes.btnAuto}`}>
                    <ButtonSymbol
                        refresh={refreshLogin}
                        setRefresh={setRefreshLogin}
                        onClick={setLogin}
                        Symbol={"↺"}
                        id={"btn-login-refresh"} />
                </div>
            </div>
            <div className={`row ${classes.rowSysAdmin}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>Пароль:</div>
                </div>
                <div className={"col-6 input"}>
                    <PasswordInput
                        id={"password"}
                        placeholder={"Введите пароль..."}
                        idSpan={"error-password"}
                        onChange={setPassword}
                        required
                    />
                </div>
                <div className={`col-1 ${classes.btnAuto}`}>
                    <ButtonAuto
                        idInput={"password"}
                        oldDataSet={setAutoPassword}
                        oldData={autoPassword}
                        onClick={setIsAutoPassword}
                        id={"btn-password"}
                        btnRefresh={"btn-password-refresh"}/>
                </div>
                <div className={"col-1 btn-auto"}>
                    <ButtonSymbol
                        refresh={refreshPassword}
                        setRefresh={setRefreshPassword}
                        onClick={setPassword}
                        Symbol={"↺"}
                        id={"btn-password-refresh"} />
                </div>
            </div>
            <div className={`row ${classes.rowBtn}`}>
                <button onClick={submitForms} className={classes.btnRegister}>{props.textButton}</button>
            </div>
        </div>
    )
}