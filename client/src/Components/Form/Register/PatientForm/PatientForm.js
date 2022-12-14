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
        return date < new Date();
    }
    const [cookie, setCookie] = useCookies(["user"]);
    async function submitForms(){
        debugger
        props.isLoaded(false);
        let isCorrect = true;
        if(!isAutoLogin){
            if(login.trim().length === 0) {
                isCorrect = false;
                hideError("error-login", "?????? ???????? ???????????????????????? ?????? ????????????????????");
            }
            else{
                let answer = await CheckLogin(login);
                if(answer) {
                    isCorrect = false;
                    hideError("error-login", "???????????????????????? ?? ?????????? ?????????????? ?????? ????????????????????");
                }
            }
        }
        if(!isAutoPassword){
            if(password.trim().length === 0){
                isCorrect = false;
                hideError("error-password", "?????? ???????? ?????????????????????? ?????? ????????????????????");
            }
        }
        if(name.trim().length === 0) {
            isCorrect = false;
            hideError("error-name", "?????? ???????? ?????????????????????? ?????? ????????????????????");
        }
        if(surname.trim().length === 0) {
            isCorrect = false;
            hideError("error-surname", "?????? ???????? ?????????????????????? ?????? ????????????????????");
        }
        if(email.trim().length !== 0) {
            if (!validEmail(email)) {
                isCorrect = false;
                hideError("error-email", "?????????????????????? ?????????????????? email");
            }
            else{
                let answer = await CheckEmail(email, "patient");
                if(answer) {
                    isCorrect = false;
                    hideError("error-email", "???????????????????????? ?? ?????????? email ?????? ????????????????????");
                }
            }
        }
        if(phoneNumber.trim().length !== 0) {
            if (!validPhone(phoneNumber)) {
                isCorrect = false;
                hideError("error-numberPhone", "?????????????????????? ?????????????????? ?????????? ????????????????");
            }
            else{
                let answer = await CheckPhoneNumber(phoneNumber, "patient");
                if(answer) {
                    isCorrect = false;
                    hideError("error-numberPhone", "???????????????????????? ?? ?????????? ?????????????? ???????????????? ?????? ????????????????????");
                }
            }
        }
        if(dateBirthday.length === 0){
            hideError("error-dateBirthday", "?????? ???????? ???????????????? ????????????????????????");
            props.isLoaded(true);
            return;
        }else{
            if(!validDate(dateBirthday)) {
                isCorrect = false;
                hideError("error-dateBirthday", "?????????????????????? ?????????????????? ????????");
            }
        }
        let genderObj;
        if(gender.toString().trim().length === 0){
            isCorrect = false;
            hideError("error-gender", "?????? ???????? ???????????????????????? ?????? ????????????????????");
        }
        else{
            genderObj = await GetById(gender);
        }
        if(!isCorrect) {
            props.isLoaded(true);
            return;
        }
        let answer;
        let resultFetch = await RegisterUser(JSON.stringify({
            login:login,
            password:password,
            name:name,
            surname:surname,
            patronymic:patronymic,
            email:email,
            phoneNumber:phoneNumber,
            birthday:dateBirthday,
            gender:genderObj,
            role:"patient"
        }), answer);
        props.isLoaded(true);
        if(resultFetch === undefined) {
            hideError("error-gender", "???????????????????? ???????????????????????????????? ??????????????. ???????????????????? ??????????");
            return;
        }
        let tmp = resultFetch.access_token;
        setCookie("user",`${resultFetch.access_token}`);
        props.setRegistered(true);

    }
    return(
        <div className={classes.containerPatient}>
            <div className={`row ${classes.rowPatient}`}>
               <div className={`col-3 ${classes.text}`}>
                   <div>??????????:</div>
               </div>
               <div className={"col-7 input"}>
                   <TextInput
                        id={"login"}
                        type={"text"}
                        className={"form-control textInput"}
                        placeholder={"?????????????? ??????????..."}
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
                        Symbol={"???"}
                        id={"btn-login-refresh"} />
                </div>
            </div>
            <div className={`row ${classes.rowPatient}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>????????????:</div>
                </div>
                <div className={"col-7 input"}>
                    <PasswordInput
                        id={"password"}
                        placeholder={"?????????????? ????????????..."}
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
                        Symbol={"???"}
                        id={"btn-password-refresh"} />
                </div>
            </div>
            <div className={`row ${classes.rowPatient}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>??????:</div>
                </div>
                <div className={"col-7 input"}>
                    <TextInput
                        id={"name"}
                        type={"text"}
                        placeholder={"?????????????? ???????? ??????"}
                        idSpan={"error-name"}
                        onChange={setName}
                        required
                    />
                </div>
            </div>
            <div className={`row ${classes.rowPatient}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>??????????????:</div>
                </div>
                <div className={"col-7 input"}>
                    <TextInput
                        id={"surname"}
                        type={"text"}
                        className={"form-control textInput"}
                        placeholder={"?????????????? ???????? ??????????????..."}
                        idSpan={"error-surname"}
                        onChange={setSurname}
                        required
                    />
                </div>
            </div>
            <div className={`row ${classes.rowPatient}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>????????????????:</div>
                </div>
                <div className={"col-7 input"}>
                    <TextInput
                        id={"patronymic"}
                        type={"text"}
                        placeholder={"?????????????? ???????? ????????????????..."}
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
                        placeholder={"?????????????? ?????? email"}
                        idSpan={"error-email"}
                        onChange={setEmail}
                    />
                </div>
            </div>
            <div className={`row ${classes.rowPatient}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>?????????? ????????????????:</div>
                </div>
                <div className={"col-7 input"}>
                    <TextInput
                        id={"phoneNumber"}
                        type={"tel"}
                        placeholder={"?????????????? ?????????? ????????????????..."}
                        idSpan={"error-numberPhone"}
                        onChange={setPhoneNumber}
                    />
                </div>
            </div>
            <div className={`row ${classes.rowPatient}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>???????? ????????????????:</div>
                </div>
                <div className={"col-7 input"}>
                    <TextInput
                        id={"dateBirthday"}
                        type={"date"}
                        placeholder={"?????????????? ???????? ????????????????..."}
                        idSpan={"error-dateBirthday"}
                        onChange={setDateBirthday}
                    />
                </div>
            </div>
            <div className={`row ${classes.rowPatient}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>??????:</div>
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