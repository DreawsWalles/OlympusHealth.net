import {useEffect, useState} from "react";
import DefaultComponent from "../../../Components/Form/Register/DefaultComponent/DefaultComponent";
import PatientForm from "../../../Components/Form/Register/PatientForm/PatientForm";
import MedicWorker from "../../../Components/Form/Register/MedicWorker/MedicWorker";
import Loader from "../../../Components/Loader/Loader";
import {Navigate} from "react-router-dom";
import classesContent from "./Registration.module.css"
import classesLoader from "../../../Components/Loader/Loader.module.css"
import SysAdminForm from "../../../Components/Form/Register/SysAdmin/SysAdminForm";
import {RegisterSysAdmin, RegisterUser} from "../../../Swapi/SwapiAccount/SwapiAccount";
import {useCookies} from "react-cookie";
import type {IRegistrationProps} from "./IRegistrationProps";
import {Logo} from "../../../Components/Logo/Logo";
import Select from "../../../Components/Selects/Select/Select";
import {ItemProps} from "../../../Components/Selects/Select/ISelectProps";
import {RegisterModelSysAdmin} from "../../../Entities/AutorizeModel/RegisterModelSysAdmin";
import {RegistrationModelPerson} from "../../../Entities/AutorizeModel/RegistrationModelPerson";


const ids = {
    loader: "load",
    content: "content",
    select: "main-select"
}

export default function Registration(props: IRegistrationProps){
    document.title = "Регистрация";
    const [registered, setRegistered] = useState(false);
    const [type, setType] = useState(<DefaultComponent />);
    const [isLoaded, setIsLoaded] = useState(true);
    const [cookie, setCookie] = useCookies(["user"]);

    useEffect(() => {
        (() => {
            let load = document.getElementById(ids.loader);
            let content = document.getElementById(ids.content);
            if(load !== null && content !== null) {
                if (isLoaded) {
                    load.classList.add(classesLoader.none);
                    content.classList.remove(classesContent.none);
                } else {
                    load.classList.remove(classesLoader.none);
                    content.classList.add(classesContent.none);
                }
            }
        })();
    }, [isLoaded]);
    function getEntity(entity: RegistrationModelPerson | RegisterModelSysAdmin): {fetch: string, role: "patient" | "medic" | "sysAdmin"} | null
    {
        let role = entity.GetRole();
        switch (entity.GetRole())
        {
            case "sysAdmin":
                return {
                    fetch: JSON.stringify({login: entity.login, password: entity.password}),
                    role: role};
            case "patient":
                return {
                    fetch: JSON.stringify({
                        login: entity.login,
                        password: entity.password,
                        name: entity.name,
                        surname: entity.surname,
                        patronymic: entity.patronymic,
                        email: entity.email,
                        phoneNumber: entity.phoneNumber,
                        birthday: entity.birthday,
                        gender: entity.gender,
                        role: entity.role
                    }), role: role
                }
            case "medic":
                return {
                    fetch: JSON.stringify({
                        login: entity.login,
                        password: entity.password,
                        name: entity.name,
                        surname: entity.surname,
                        patronymic: entity.patronymic,
                        email: entity.email,
                        phoneNumber: entity.phoneNumber,
                        birthday: entity.birthday,
                        gender: entity.gender,
                        street: {
                            name: entity.street.name,
                            numberOfHouse: entity.street.numberOfHouse
                        },
                        city: entity.city.name,
                        region: entity.region.name,
                        country: entity.country.name,
                        role: entity.role,
                        roleMedic: entity.roleMedic
                    }), role: role
                }
            default:
                return null;
        }
    }
    async function registrationUser(entity: RegisterModelSysAdmin){
        debugger
        let fetchEntity = getEntity(entity);
        if(fetchEntity === null){
            return false;
        }
        let resultFetch = fetchEntity.role === "sysAdmin" ?
            await RegisterSysAdmin(fetchEntity.fetch) :
            await  RegisterUser(fetchEntity.fetch);
        if(resultFetch.status !== 200){
            return false;
        }
        setCookie("user",`${resultFetch.token}`);
        setRegistered(true);
    }
    function handleOnChangeSelect(e){
        let choice = Number(e);
        let role: string;
        switch (choice)
        {
            case 2:
                role = "Doctor";
                break;
            case 3:
                role = "Chief of medical";
                break
            case 4:
                role = "HeadOfDepartment";
                break;
            case 5:
                role = "MedicRegistrator";
                break;
        }
        switch (choice)
        {
            case 1:
                setType(<PatientForm textButton={"Зарегистрироваться"}
                                     isLoaded={setIsLoaded}
                                     onSubmit={async(e) => {await registrationUser(e); }}   />)
                break;
            case 2:
            case 3:
            case 4:
            case 5:
                setType(<MedicWorker textButton={"Зарегистрироваться"}
                                     choice={role}
                                     onSubmit={async(e) => {await registrationUser(e); }}
                                     isLoaded={setIsLoaded} />)
                break;
            case 6:
                setType(<SysAdminForm textButton={"Зарегистрироваться"}
                                      onSubmit={async(e) => {await registrationUser(e); }} />)
                break;
            default:
                setIsLoaded(true);
                setType(<DefaultComponent isLoaded={setIsLoaded} />);
                break;

        }
    }
    if(!registered) {
        return (
            <div className={classesContent.content}>
                <div className={classesContent.logo}>
                    <Logo width={"auto"} height={"auto"} />
                </div>
                <div className={`row ${classesContent.select}`}>
                    <div style={{ padding: 0}} className={`col-3`}></div>
                    <div className={`col-6`}>
                        <Select id={ids.select}
                                height={50}
                                alignment={"end"}
                                idError={"Error-main-choice"}
                                title={"Выберите тип пользователя"}
                                list={[
                                    new ItemProps(1, "Пациент"),
                                    new ItemProps(2, "Врач"),
                                    new ItemProps(3, "Главврач"),
                                    new ItemProps(4, "Заведующий отделением"),
                                    new ItemProps(5, "Медицинский регистратор"),
                                    new ItemProps(6, "Системный администратор")]}
                                onChange={handleOnChangeSelect}
                                fontSize={null}/>
                    </div>
                    <div className={`col-3`}></div>
                </div>
                <Loader id={ids.loader}/>
                <div id={ids.content} className={classesContent.container}>
                    {type}
                </div>
            </div>
        )
    }
    else{
        return <Navigate replace to={"/"} />
    }
}