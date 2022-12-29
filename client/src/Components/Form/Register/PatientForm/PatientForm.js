import TextInput from "../../../Inputs/TextInput/TextInput";
import {useEffect, useState} from "react";
import ButtonAuto from "../../../Buttons/ButtonAuto";
import {GetAll, GetById} from "../../../../Swapi/SwapiGender";
import CustomSelect from "../../../Selects/CustomSelect/CustomSelect";
import ButtonSymbol from "../../../Buttons/ButtonSymbol";
import PasswordInput from "../../../Inputs/PasswordInput/PasswordInput";
import GenerateLogin from "../../../../Generators/GenerateLogin";
import GeneratePassword from "../../../../Generators/GeneratePassword";
import {CheckEmail, CheckLogin, CheckPhoneNumber, RegisterUser} from "../../../../Swapi/SwapiAccount";
import {useCookies} from "react-cookie";
import classes from "./PatientForm.module.css"

export default function PatientForm(props){
    const [genders, setGenders] = useState();
    useEffect(() => {
        (async () => {
            props.isLoaded(false);
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
    const [login, setLogin] = useState("");
    const [isAutoLogin, setIsAutoLogin] = useState(false);
    const [autoLogin, setAutoLogin] = useState();
    const [autoPassword, setAutoPassword] = useState();

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

    const [name, setName] = useState(" ");
    const [surname, setSurname] = useState("");
    const [patronymic, setPatronymic] = useState("");
    const [email, setEmail] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("")
    const [dateBirthday, setDateBirthday] = useState("");
    const [gender, setGender] = useState();

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
        let currentDate = new Date();
        if(date.getFullYear() > currentDate.getFullYear()) {
            return false;
        }
        if(date.getMonth() > currentDate.getMonth()) {
            return false;
        }
        if(date.getDate() >= currentDate.getDate()) {
            return false;
        }
        return true;
    }
    const [cookie, setCookie] = useCookies(["user"]);
    async function submitForms(){
        let isCorrect = true;
        if(!isAutoLogin){
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
        }
        if(!isAutoPassword){
            if(password.trim().length === 0){
                isCorrect = false;
                hideError("error-password", "Это поле обязательно для заполнения");
            }
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
        if(dateBirthday.length !== 0){
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
        if(!isCorrect)
            return;
        let answer;
        let resultFetch = await RegisterUser(JSON.stringify({
            login:login,
            password:password,
            name:name,
            surname:surname,
            patronymic:patronymic,
            email:email,
            phoneNumber:phoneNumber,
            dateBirthday:dateBirthday,
            gender:genderObj,
            role:"patient"
        }), answer);
        if(resultFetch === undefined) {
            hideError("error-gender", "Невозможно зарегистрировать аккаунт. Попробуйте позже");
            return;
        }
        debugger
        setCookie("user",`${resultFetch.access_token}`);
        props.setRegistered(true);

    }
    return(
        <div className={classes.containerPatient}>
            <div className={`row ${classes.rowPatient}`}>
               <div className={`col-3 ${classes.text}`}>
                   <div>Логин:</div>
               </div>
               <div className={"col-7 input"}>
                   <TextInput
                        id={"login"}
                        type={"text"}
                        className={"form-control textInput"}
                        placeholder={"Введите логин..."}
                        idSpan={"error-login"}
                        onChange={setLogin}
                        required
                   />
               </div>
               <div className={`col-1 ${classes.btnAuto}`}>
                   <ButtonAuto
                       idInput={"login"}
                       oldDataSet={setAutoLogin}
                       oldData={autoLogin}
                       onClick={setIsAutoLogin}
                       id={"btn-login"}
                       btnRefresh={"btn-login-refresh"}/>
               </div>
                <div className={`col-1 ${classes.btnAuto}`}>
                    <ButtonSymbol
                        refresh={refreshLogin}
                        setRefresh={setRefreshLogin}
                        onClick={setLogin}
                        Symbol={"↺"}
                        id={"btn-login-refresh"} />
                </div>
            </div>
            <div className={`row ${classes.rowPatient}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>Пароль:</div>
                </div>
                <div className={"col-7 input"}>
                    <PasswordInput
                        id={"password"}
                        placeholder={"Введите пароль..."}
                        idSpan={"error-password"}
                        onChange={setPassword}
                        required
                    />
                </div>
                <div className={`col-1 ${classes.btnAuto}`}>
                    <ButtonAuto
                        idInput={"password"}
                        oldDataSet={setAutoPassword}
                        oldData={autoPassword}
                        onClick={setIsAutoPassword}
                        id={"btn-password"}
                        btnRefresh={"btn-password-refresh"}/>
                </div>
                <div className={"col-1 btn-auto"}>
                    <ButtonSymbol
                        refresh={refreshPassword}
                        setRefresh={setRefreshPassword}
                        onClick={setPassword}
                        Symbol={"↺"}
                        id={"btn-password-refresh"} />
                </div>
            </div>
            <div className={`row ${classes.rowPatient}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>Имя:</div>
                </div>
                <div className={"col-7 input"}>
                    <TextInput
                        id={"name"}
                        type={"text"}
                        placeholder={"Введите ваше имя"}
                        idSpan={"error-name"}
                        onChange={setName}
                        required
                    />
                </div>
            </div>
            <div className={`row ${classes.rowPatient}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>Фамилия:</div>
                </div>
                <div className={"col-7 input"}>
                    <TextInput
                        id={"surname"}
                        type={"text"}
                        className={"form-control textInput"}
                        placeholder={"Введите вашу фамилию..."}
                        idSpan={"error-surname"}
                        onChange={setSurname}
                        required
                    />
                </div>
            </div>
            <div className={`row ${classes.rowPatient}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>Отчество:</div>
                </div>
                <div className={"col-7 input"}>
                    <TextInput
                        id={"patronymic"}
                        type={"text"}
                        placeholder={"Введите ваше отчество..."}
                        idSpan={"error-patronymic"}
                        onChange={setPatronymic}
                    />
                </div>
            </div>
            <div className={`row ${classes.rowPatient}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>Email:</div>
                </div>
                <div className={"col-7 input"}>
                    <TextInput
                        id={"email"}
                        type={"email"}
                        placeholder={"Введите ваш email"}
                        idSpan={"error-email"}
                        onChange={setEmail}
                    />
                </div>
            </div>
            <div className={`row ${classes.rowPatient}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>Номер телефона:</div>
                </div>
                <div className={"col-7 input"}>
                    <TextInput
                        id={"phoneNumber"}
                        type={"tel"}
                        placeholder={"Введите номер телефона..."}
                        idSpan={"error-numberPhone"}
                        onChange={setPhoneNumber}
                    />
                </div>
            </div>
            <div className={`row ${classes.rowPatient}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>Дата рождения:</div>
                </div>
                <div className={"col-7 input"}>
                    <TextInput
                        id={"dateBirthday"}
                        type={"date"}
                        placeholder={"Введите дату рождения..."}
                        idSpan={"error-dateBirthday"}
                        onChange={setDateBirthday}
                    />
                </div>
            </div>
            <div className={`row ${classes.rowPatient}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>Пол:</div>
                </div>
                <div className={"col-7 input"}>
                    {gendersElement}
                </div>
            </div>
            <div className={`row ${classes.rowBtn}`}>
                <button onClick={submitForms} className={classes.btnRegister}>{props.textButton}</button>
            </div>
        </div>
    )
}