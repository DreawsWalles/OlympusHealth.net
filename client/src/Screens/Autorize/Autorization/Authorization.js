import {useState} from "react";
import classes from './Autorize.module.css';
import Logo from '../../Images/logo.svg';
import {Login} from "../../../Swapi/SwapiAccount";
import LoginForm from "../../../Components/Form/Login/LoginForm";




export default function Authorization(props) {
    const [inputValues, setInputValues] = useState({
        login: '',
        password: ''
    });
    return(
    <div className={classes.content}>
        <img className={classes.imageLogin} width={"400"} height={"140"} src={Logo} />
        <LoginForm handleSubmit={Login}/>
    </div>
        )
}
