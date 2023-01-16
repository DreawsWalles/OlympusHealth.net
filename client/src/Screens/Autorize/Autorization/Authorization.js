import {useEffect, useState} from "react";
import classes from './Autorize.module.css';
import Logo from '../../Images/logo.svg';
import {Login} from "../../../Swapi/SwapiAccount";
import LoginForm from "../../../Components/Form/Login/LoginForm";
import classesLoader from "../../../Components/Loader/Loader.module.css";
import Loader from "../../../Components/Loader/Loader";




export default function Authorization(props) {
    const [autorize, setAutorize] = useState(false);
    const [role, setRole] = useState();


    const [isLoaded, setIsLoaded] = useState(true);
    useEffect(() => {
        (() => {
            let load = document.getElementById("load");
            let content = document.getElementById("loginForm");
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

    }
    else
    {
        return(
            <div className={classes.content}>
                <img className={classes.imageLogin} width={"400"} height={"140"} src={Logo} />
                <Loader />
                <LoginForm handleSubmit={Login} setAutorize={setAutorize} setIsLoaded={setIsLoaded} setRole={setRole}/>
            </div>
        )
    }

}
