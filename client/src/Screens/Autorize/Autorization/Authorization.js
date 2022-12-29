import {useState} from "react";
import './Autorize.css';
import Logo from '../Images/logo.svg';
import {Login} from "../../Swapi/SwapiAccount";
import ValidationForm from "../../Components/Form/Login/ValidationForm";




export default function Authorization(props) {
    const [inputValues, setInputValues] = useState({
        login: '',
        password: ''
    });
    return(
    <div className={"content"}>
        <img className={"image-login"} width={"400"} height={"140"} src={Logo} />
        <ValidationForm handleSubmit={Login}/>
    </div>
        )
}
