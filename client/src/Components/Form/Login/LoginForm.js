import {useState} from "react";
import classes from "./LoginForm.module.css"
import type {ILoginFormProps} from "./ILoginFormProps";
import {LoginModel} from "../../../Entities/AutorizeModel/LoginModel";
import {Input} from "../../Inputs/Input/Input";
import {ErrorAttribute, LabelAttribute, ToggleSwitchAttributes} from "../../Inputs/Input/IInputProps";
import Button from "../../Buttons/Button/Button";
import {check, checkOnLength} from "../FunctionValidates";
import {Hint} from "../../Functions";


const ids = {
    login:{
        input: "login",
        error: "error-login",
    },
    password:{
        input: "password",
        error: "error-password"
    },
    buttons:{
        autorize:"btn-autorize",
        registration: "btn-registration"
    }
}
export default function LoginForm(props: ILoginFormProps){
    const [loginValue, setLogin] = useState("");
    const [passwordValue, setPassword] = useState("");



    async function handleSubmit(event){
        props.setIsLoaded(false);
        let isCorrect = new Set();
        isCorrect.add(await check(
            loginValue,
            ids.login.error,
            ["Данное поле обязательно для заполнения"],
            [checkOnLength]));
        isCorrect.add(await check(
            passwordValue,
            ids.password.error,
            ["Данное поле обязательно для заполнения"],
            [checkOnLength]));
        if(isCorrect.has(false)) {
            props.setIsLoaded(true);
            return;
        }
        let answer = props.submit(new LoginModel(loginValue, passwordValue));
        if(!answer){
            event.preventDefault();
            Hint(ids.password.error, "Неверный логин и/или пароль");
        }
    }
    return(
        <div id={props.id} className={classes.form}>
            <Input id={ids.login.input}
                   placeholder={"Введите ваш логин, email или номер телефона..."}
                   type={"text"}
                   setValue={setLogin}
                   toggleSwitchAttribute={null}
                   errorAttribute={new ErrorAttribute(ids.login.error)}
                   labelAttribute={new LabelAttribute("Логин, email или номер телефона")} />
            <Input id={ids.password.input}
                   placeholder={"Введите пароль..."}
                   type={"password"}
                   setValue={setPassword}
                   toggleSwitchAttribute={new ToggleSwitchAttributes("Показать пароль")}
                   errorAttribute={new ErrorAttribute(ids.password.error)}
                   labelAttribute={new LabelAttribute("Пароль")}/>
            <div className={classes.button}>
                <div className={`col-7 ${classes.btn}`}>
                    <Button id={ids.buttons.autorize}
                            size={"m"}
                            text={"Войти"}
                            theme={"Red"}
                            isDisplay={true}
                            onClick={async () =>{await handleSubmit();}} />
                </div>
                <div className={`col-1`}></div>
                <div className={`col-4 ${classes.btn}`}>
                    <Button id={ids.buttons.registration}
                            size={"m"}
                            text={"Регистрация"}
                            theme={"Grey"}
                            isDisplay={true}
                            onClick={() => {document.location='/Registration'}} />
                </div>

            </div>
        </div>
    );
}