import {useEffect, useState} from "react";
import GenerateLogin from "../../../../../Generators/GenerateLogin";
import GeneratePassword from "../../../../../Generators/GeneratePassword";
import {GetAll} from "../../../../../Swapi/SwapiGender";
import CustomSelect from "../../../CustomSelect";

export default function DoctorForm(props){
    const [login, setLogin] = useState("");
    const [autoLogin, setAutoLogin] = useState();
    const [autoPassword, setAutoPassword] = useState();

    const [isAutoLogin, setIsAutoLogin] = useState(false);
    useEffect(() => {
        (async () => {
            let element = document.getElementById("login");
            if(isAutoLogin) {
                element.setAttribute("disabled", true);
                element.value = await GenerateLogin();
                setLogin(element.value);
            }
            else{
                element.removeAttribute("disabled");
            }
        })();
    }, [isAutoLogin]);

    const [password, setPassword] = useState("");
    const [isAutoPassword, setIsAutoPassword] = useState(false);
    useEffect(() => {
        (() => {
            let element = document.getElementById("password");
            if(isAutoPassword) {
                element.setAttribute("disabled", true);
                element.value = GeneratePassword(10);
                setPassword(element.value);
            }
            else{
                element.removeAttribute("disabled");
                element.value = password;
            }
        })();
    }, [isAutoPassword]);

    const [refreshLogin, setRefreshLogin] = useState();
    useEffect(() => {
        (async () => {
            if(isAutoLogin) {
                let element = document.getElementById("login");
                element.value = await GenerateLogin();
                setLogin(element.value);
            }
        })();
    }, [refreshLogin]);

    const [refreshPassword, setRefreshPassword] = useState();
    useEffect(() => {
        (() => {
            if(isAutoPassword) {
                let element = document.getElementById("password");
                element.value = GeneratePassword(10);
                setPassword(element.value);
            }
        })();
    }, [refreshPassword]);

    const [genders, setGenders] = useState();
    useEffect(() => {
        (async () => {
            let genders = await GetAll();
            setGenders(genders.map((item, index) => {
                return {
                    key: index.toString(),
                    ...item
                };
            }));
            if(genders === undefined) {
                props.isLoaded(false);
            }
        })();
    }, []);
    const [gendersElement, setGendersElement] = useState();
    useEffect(() => {
        (() => {
            if(genders !== undefined) {
                props.isLoaded(true);
                setGendersElement(<CustomSelect idSpan={"error-gender"} genders={genders} onChange ={setGender} />);
            }
        })();
    }, [genders]);

    const [name, setName] = useState(" ");
    const [surname, setSurname] = useState("");
    const [patronymic, setPatronymic] = useState("");
    const [email, setEmail] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("")
    const [dateBirthday, setDateBirthday] = useState("");
    const [gender, setGender] = useState();
}