import Logo from "../../../Images/logo.svg";
import {useEffect, useState} from "react";
import DefaultComponent from "../../../Components/Form/Register/DefaultComponent/DefaultComponent";
import PatientForm from "../../../Components/Form/Register/PatientForm/PatientForm";
import MedicWorker from "../../../Components/Form/Register/MedicWorker/MedicWorker";
import Loader from "../../../Components/Loader/Loader";
import {Navigate} from "react-router-dom";
import classesContent from "./Registration.module.css"
import classesLoader from "../../../Components/Loader/Loader.module.css"
import SysAdminForm from "../../../Components/Form/Register/SysAdmin/SysAdminForm";
import {RegisterUser} from "../../../Swapi/SwapiAccount";
import {useCookies} from "react-cookie";
import CustomSelect from "../../../Components/Selects/CustomSelect/CustomSelect";

export default function Registration(props){
    document.title = "Регистрация";
    const [registered, setRegistered] = useState(false);
    const [type, setType] = useState(<DefaultComponent />);
    const [isLoaded, setIsLoaded] = useState(true);
    const [cookie, setCookie] = useCookies(["user"]);
    useEffect(() => {
        (() => {
            debugger
            let load = document.getElementById("load");
            let content = document.getElementById("content");
            if(load !== null && content !== null) {
                if (isLoaded) {
                    debugger
                    load.classList.add(classesLoader.none);
                    content.classList.remove(classesContent.none);
                } else {
                    load.classList.remove(classesLoader.none);
                    content.classList.add(classesContent.none);
                }
            }
        })();
    }, [isLoaded]);
    async function registrationUser(body){
        debugger
        let resultFetch = await RegisterUser(body);
        if(resultFetch === undefined){
            return false;
        }
        setCookie("user",`${resultFetch.access_token}`);
        setRegistered(true);
    }
    function handleOnChangeSelect(e){
        console.log(e.target.value);
        debugger
        switch (e.target.value)
        {
            case '1':
                setType(<PatientForm isLoaded={setIsLoaded} registration={registrationUser} textButton={"Зарегестрироваться"}  />)
                break;
            case '2':
                setType(<MedicWorker choice={'Doctor'} isLoaded={setIsLoaded} registration={registrationUser} textButton={"Зарегестрироваться"}/>)
                break;
            case '3':
                setType(<MedicWorker choice={'Chief of medical'} isLoaded={setIsLoaded} registration={registrationUser} textButton={"Зарегестрироваться"}/>)
                break;
            case '4':
                setType(<MedicWorker choice={'HeadOfDepartment'} isLoaded={setIsLoaded} registration={registrationUser} textButton={"Зарегестрироваться"}/>)
                break;
            case '5':
                setType(<MedicWorker choice={'MedicRegistrator'} isLoaded={setIsLoaded} registration={registrationUser} textButton={"Зарегестрироваться"}/>)
                break;
            case '6':
                setType(<SysAdminForm choice={"SysAdmin"} registration={registrationUser} textButton={"Зарегестрироваться"} />)
                break;
            default:
                setIsLoaded(true);
                setType(<DefaultComponent isLoaded={setIsLoaded} />)
        }
    }
    if(!registered) {
        return (
            <div className={classesContent.content}>
                <div className={classesContent.head}>
                    <img src={Logo}/>
                    <select onChange={handleOnChangeSelect} className={classesContent.selectType}>
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
                <div id={"content"} className={classesContent.container}>
                    {type}
                </div>
            </div>
        )
    }
    else{
        return <Navigate replace to={"/"} />
    }
}