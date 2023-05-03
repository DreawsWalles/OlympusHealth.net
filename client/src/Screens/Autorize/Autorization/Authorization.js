import {useEffect, useState} from "react";
import classes from './Autorize.module.css';
import {Login} from "../../../Swapi/SwapiAccount/SwapiAccount";
import LoginForm from "../../../Components/Form/Login/LoginForm";
import classesLoader from "../../../Components/Loader/Loader.module.css";
import Loader from "../../../Components/Loader/Loader";
import {Navigate} from "react-router-dom";
import {Logo} from "../../../Components/Logo/Logo";
import type {IAuthorizationProps} from "./IAuthorizationProps";
import type {LoginModel} from "../../../Entities/AutorizeModel/LoginModel";
import {useCookies} from "react-cookie";
import type {AnswerAutorize} from "../../../Swapi/SwapiAccount/Entities";

const Ids = {
    loader: "load",
    form: "loginForm"
}

export default function Authorization(props: IAuthorizationProps) {
    const [autorize, setAutorize] = useState(false);
    const [role: string, setRole] = useState();
    const [cookie, setCookie] = useCookies("user")

    document.title = "Авторизация";
    const [isLoaded, setIsLoaded] = useState(true);
    useEffect(() => {
        (() => {
            let load = document.getElementById(Ids.loader);
            let content = document.getElementById(Ids.form);
            if(load !== null && content !== null){
                if(isLoaded){
                    load.classList.add(classesLoader.none);
                    content.classList.remove(classes.none);
                }
                else {
                    load.classList.remove(classesLoader.none);
                    content.classList.add(classes.none);
                }
            }})();
    }, [isLoaded]);
    if(autorize)
    {
        switch (role)
        {
            case "Patient":
                return (<Navigate replace to={"/Patient"} />);
            case "Medic":
                return (<Navigate replace to={"/Medic"} />)
            case "SysAdmin":
                return (<Navigate replace to={"/SysAdmin"} />);
            default:
                console.error("При авторизации произошла ошибка. Некорректная роль");
                return( DOMException("При авторизации произошла ошибка. Некорректная роль", "Autorize.Error.Role"));

        }
    }
    async function Autorize(entity: LoginModel) {
        let response: AnswerAutorize = await Login(JSON.stringify({login: entity.login, password: entity.password, role: "tmp"}));
        debugger
        if(response.status !== 400){
            debugger
            setRole(response.role);
            setCookie("user", `${response.token}`);
            setAutorize(true);
            return true;
        }
        return false;
    }
    return(
        <div className={classes.content}>
            <div className={classes.imageLogin}>
                <Logo width={400} height={140} />
            </div>
            <Loader id={Ids.loader}/>
            <LoginForm id={Ids.form} submit={Autorize} setIsLoaded={setIsLoaded}/>
        </div>
    )

}
