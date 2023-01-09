import {useEffect, useState} from "react";
import classes from './Autorize.module.css';
import Logo from '../../Images/logo.svg';
import {GetRole, Login} from "../../../Swapi/SwapiAccount";
import LoginForm from "../../../Components/Form/Login/LoginForm";
import {useCookies} from "react-cookie";
import classesLoader from "../../../Components/Loader/Loader.module.css";
import Loader from "../../../Components/Loader/Loader";
import {Navigate} from "react-router-dom";




export default function Authorization(props) {
    const [autorize, setAutorize] = useState(false);
    const [role, setRole] = useState();
    const [cookie, setCookie] = useCookies("user");
    useEffect(() =>
    {
        (async () => {
            let tmp = cookie;
            let t = await GetRole(tmp.user);
            setRole(t);
        })();
    },[autorize]);


    const [isLoaded, setIsLoaded] = useState(true);
    useEffect(() => {
        (() => {
            debugger
            let load = document.getElementById("load");
            let content = document.getElementById("loginForm");
            if(isLoaded){
                debugger
                load.classList.add(classesLoader.none);
                content.classList.remove(classes.none);
            }
            else {
                load.classList.remove(classesLoader.none);
                content.classList.add(classes.none);
            }
        })();
    }, [isLoaded]);
    if(autorize)
    {
        switch (role)
        {
            case "Patient":
                return (<Navigate replace to={"/Patient"} /> );
            case "Medic":
                return (<Navigate replace to={"/Medic"} />);
            case "SysAdmin":
                return (<Navigate replace to={"/SysAdmin"} /> );
        }
    }
    else
    {
        return(
            <div className={classes.content}>
                <img className={classes.imageLogin} width={"400"} height={"140"} src={Logo} />
                <Loader />
                <LoginForm handleSubmit={Login} setAutorize={setAutorize} setIsLoaded={setIsLoaded}/>
            </div>
        )
    }

}
