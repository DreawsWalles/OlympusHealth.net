import {useEffect, useState} from "react";
import LoginInput from "../../Inputs/LoginInput.css/LoginInput";
import PasswordInput from "../../Inputs/PasswordInput/PasswordInput";
import classes from "./LoginForm.module.css"
import {useCookies} from "react-cookie";


export default function LoginForm(props){
    const [loginValue, setLogin] = useState("");
    const [passwordValue, setPassword] = useState("");
    const [cookie, setCookie] = useCookies("user")

    function Hint(name, message){
        let element = document.getElementById(name);
        element.innerText = message;
    };

    async function handleSubmit(event){
        props.setIsLoaded(false);
        let isCorrect = true;
        if(loginValue.trim().length === 0){
            Hint("error-login", "Данное поле обязательно для заполнения");
            isCorrect = false;
        }
        if(passwordValue.trim().length === 0){
            Hint("error-password", "Данное поле обязательно для заполнения");
            isCorrect = false;
        }
        if(!isCorrect)
            return;
        let data;
        const status = await props.handleSubmit(JSON.stringify({login: loginValue, password:passwordValue, role:"Admin"}), data);
        props.setIsLoaded(true);
        if(status !== undefined){
            props.setRole(status.role);
            setCookie("user",`${status.access_token}`);
            props.setAutorize(true);
        }
        else{
            event.preventDefault();
            if(loginValue.trim().length !== 0 && passwordValue.trim().length !== 0)
                Hint("error-password", "Неверный логин и/или пароль");
        }
    }
    return(
        <div id={"loginForm"} className={classes.form}>
            <LoginInput
                id={"login"}
                type={"text"}
                placeholder={"Введите ваш логин, email или номер телефона..."}
                labelText={"Логин, email или номер телефона"}
                onChange={setLogin}
                idSpan={"error-login"}
                required
            />
            <PasswordInput
                id={"password"}
                placeholder={"Введите пароль..."}
                idSpan={"error-password"}
                onChange={setPassword}
                required
            />
            <div className={classes.button}>
                <button onClick={handleSubmit} className={classes.btnIn}>Войти</button>
                <a href={"/Registration"} className={classes.btnReg}>Регистрация</a>
            </div>
        </div>
    );
}