import Logo from "../../Images/logo.svg";
import {useEffect, useState} from "react";
import DefaultComponent from "../../../Components/Form/Register/DefaultComponent/DefaultComponent";
import PatientForm from "../../../Components/Form/Register/PatientForm/PatientForm";
import MedicWorker from "../../../Components/Form/Register/MedicWorker/MedicWorker";
import Loader from "../../../Components/Loader/Loader";
import {Navigate} from "react-router-dom";
import classes from "./Registration.module.css"

export default function Registration(props){
    const [registered, setRegistered] = useState(false);
    const [type, setType] = useState(<DefaultComponent />);
    const [isLoaded, setIsLoaded] = useState(true);

    useEffect(() => {
        (() => {
            let load = document.getElementById("load");
            let content = document.getElementById("content");
            if(isLoaded){
                load.classList.add("none");
                content.classList.remove("none");
            }
            else {
                load.classList.remove("none");
                content.classList.add("none");
            }
        })();
    }, [isLoaded]);
    function handleOnChangeSelect(e){
        console.log(e.target.value);
        switch (e.target.value)
        {
            case '1':
                setType(<PatientForm isLoaded={setIsLoaded} setRegistered={setRegistered} textButton={"Добавить"}  />)
                break;
            case '2':
                setType(<MedicWorker choice={'doctor'} isLoaded={setIsLoaded} setRegistered={setRegistered} textButton={"Добавить"}/>)
                break;
            default:
                setIsLoaded(true);
                setType(<DefaultComponent isLoaded={setIsLoaded} />)
        }
    }
    if(!registered) {
        return (
            <div className={classes.content}>
                <div className={classes.head}>
                    <img src={Logo}/>
                    <select onChange={handleOnChangeSelect} className={classes.selectType}>
                        <option>Выберите вид пользователя</option>
                        <option value={1}>Пациент</option>
                        <option value={2}>Врач</option>
                        <option value={3}>Главврач</option>
                        <option value={4}>Заведующий отделением</option>
                        <option value={5}>Медицинский регистратор</option>
                        <option value={6}>Системный администратор</option>
                    </select>
                </div>
                <Loader/>
                <div id={"content"} className={classes.container}>
                    {type}
                </div>
            </div>
        )
    }
    else{
        return <Navigate replace to={"/"} />
    }
}