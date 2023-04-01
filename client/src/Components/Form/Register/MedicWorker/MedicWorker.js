import GeneralMedicForm from "./GeneralMedicForm";
import {useState} from "react";
import {useCookies} from "react-cookie";
import {CheckEmail, CheckLogin, CheckPhoneNumber, RegisterUser} from "../../../../Swapi/SwapiAccount";
import {GetById} from "../../../../Swapi/SwapiGender";
import {GetIdByName} from "../../../../Swapi/SwapiRoleMedic";

export default function MedicWorker(props){
    const [login, setLogin] = useState("");
    const [password, setPassword] = useState("");
    const [name, setName] = useState(" ");
    const [surname, setSurname] = useState("");
    const [patronymic, setPatronymic] = useState("");
    const [email, setEmail] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("")
    const [dateBirthday, setDateBirthday] = useState("");
    const [gender, setGender] = useState();
    const [country, setCountry] = useState("");
    const [region, setRegion] = useState("");
    const [city, setCity] = useState("");
    const [street, setStreet] = useState("");
    const [numberHouse, setNumberHouse] = useState("")

    function hideError(element, error){
        let span = document.getElementById(element);
        span.innerText = error;
    }
    function validEmail(e) {
        let filter = /^\s*[\w\-\+_]+(\.[\w\-\+_]+)*\@[\w\-\+_]+\.[\w\-\+_]+(\.[\w\-\+_]+)*\s*$/;
        return String(e).search (filter) != -1;
    }
    function validPhone(e){
        let filter = /^(\s*)?(\+)?([- _():=+]?\d[- _():=+]?){10,14}(\s*)?$/;
        return String(e).search(filter) != -1;
    }
    function validDate(e){
        let date = new Date(e);
        return date < new Date();
    }
    async function submit(){
        props.isLoaded(false);
        let isCorrect = true;
        if(login.trim().length === 0) {
            isCorrect = false;
            hideError("error-login", "Это поле обязательное для заполнения");
        }
        else{
            let answer = await CheckLogin(login);
            if(answer) {
                isCorrect = false;
                hideError("error-login", "Пользователь с таким логином уже сущетсвует");
            }
        }
        if(password.trim().length === 0){
            isCorrect = false;
            hideError("error-password", "Это поле обязательно для заполнения");
        }
        if(name.trim().length === 0) {
            isCorrect = false;
            hideError("error-name", "Это поле обязательно для заполнения");
        }
        if(surname.trim().length === 0) {
            isCorrect = false;
            hideError("error-surname", "Это поле обязательно для заполнения");
        }
        if(email.trim().length !== 0) {
            if (!validEmail(email)) {
                isCorrect = false;
                hideError("error-email", "Некорректно введенный email");
            }
            else{
                let answer = await CheckEmail(email, "patient");
                if(answer) {
                    isCorrect = false;
                    hideError("error-email", "Пользователь с таким email уже существует");
                }
            }
        }
        if(phoneNumber.trim().length !== 0) {
            if (!validPhone(phoneNumber)) {
                isCorrect = false;
                hideError("error-numberPhone", "Некорректно введенный номер телефона");
            }
            else{
                let answer = await CheckPhoneNumber(phoneNumber, "patient");
                if(answer) {
                    isCorrect = false;
                    hideError("error-numberPhone", "Пользователь с таким номером телефона уже существует");
                }
            }
        }
        if(dateBirthday.length === 0){
            hideError("error-dateBirthday", "это поле является обязательным");
            props.isLoaded(true);
            return;
        }
        else{
            if(!validDate(dateBirthday)) {
                isCorrect = false;
                hideError("error-dateBirthday", "Некорректно введенная дата");
            }
        }
        let genderObj;
        if(gender.toString().trim().length === 0){
            isCorrect = false;
            hideError("error-gender", "Это поле обязательное для заполнения");
        }
        else{
            genderObj = await GetById(gender);
        }
        if(country.trim().length !== 0){
            if(region.trim().length === 0){
                isCorrect = false;
                hideError("error-region", "Заполните адрес полностью");
                props.isLoaded(true);
                return;
            }
            hideError("error-region", "");
            if(city.trim().length === 0){
                isCorrect = false;
                hideError("error-city", "Заполните адрес полностью");
                props.isLoaded(true);
                return;
            }
            hideError("error-city", "");
            if(street.trim().length === 0){
                isCorrect = false;
                hideError("error-street", "Заполните адрес полностью");
                props.isLoaded(true);
                return;
            }
            hideError("error-city", "");
            if(numberHouse.trim().length === 0){
                isCorrect = false;
                hideError("error-NumberHouse", "Заполните адрес полностью");
                props.isLoaded(true);
                return;
            }
            hideError("error-NumberHouse", "");
        }
        let roleKey = await GetIdByName(props.choice)
        if(!isCorrect) {
            props.isLoaded(true);
            return;
        }
        debugger
        let result = await props.registration(JSON.stringify({
            login:login,
            password:password,
            name:name,
            surname:surname,
            patronymic:patronymic,
            email:email,
            phoneNumber:phoneNumber,
            birthday:dateBirthday,
            gender:genderObj,
            street:{
                    name:street,
                    numberOfHouse:numberHouse
                },
            city: city,
            region: region,
            country: country,
            role:"medic",
            roleMedic:{
                id: roleKey,
                name: props.choice
            }
        }));
        props.isLoaded(true);
        if(!result) {
            hideError("error-NumberHouse", "Невозможно зарегистрировать аккаунт. Попробуйте позже");
            return;
        }
    }
    return(<GeneralMedicForm isLoaded={props.isLoaded} setRegistered={props.setRegistered} textButton={props.textButton}
                             login={login} password={password} setLogin={setLogin} setPassword={setPassword} setName={setName}
                             setSurname={setSurname} setPatronymic={setPatronymic} setEmail={setEmail} setPhoneNumber={setPhoneNumber}
                             setDateBirthday={setDateBirthday} setGender={setGender} setCountry={setCountry} setRegion={setRegion}
                             setCity={setCity} setStreet={setStreet} setNUmberHouse={setNumberHouse} onSubmit={submit}
                             country={country} region={region} city={city} street={street}/>)
}