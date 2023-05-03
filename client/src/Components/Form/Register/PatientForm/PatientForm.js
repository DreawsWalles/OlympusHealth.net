import {useEffect, useState} from "react";
import {GetAll, GetById} from "../../../../Swapi/SwapiGender";
import GenerateLogin from "../../../../Generators/GenerateLogin";
import GeneratePassword from "../../../../Generators/GeneratePassword";
import {CheckEmail, CheckLogin, CheckPhoneNumber} from "../../../../Swapi/SwapiAccount/SwapiAccount";
import classes from "./PatientForm.module.css"
import classesBtn from "../../../../Components/Buttons/Button/Button.module.css"
import Button from "../../../Buttons/Button/Button";
import {clickOnButtonAuto, clickOnButtonRefresh} from "../functionsButtons";
import {GenderModel} from "../../../../Entities/PersonalModel/GenderModel";
import {Hint} from "../../../Functions";
import Select from "../../../Selects/Select/Select";
import {ErrorAttribute, ToggleSwitchAttributes} from "../../../Inputs/Input/IInputProps";
import {ItemProps} from "../../../Selects/Select/ISelectProps";
import {Input} from "../../../Inputs/Input/Input";
import {check, checkOnLength, validDate, validEmail, validPhone} from "../../FunctionValidates";
import {RegistrationModelPerson} from "../../../../Entities/AutorizeModel/RegistrationModelPerson";
import {IPatientFormProps} from "./IPatientFormProps";

const ids = {
    login:{
        input: "login",
        error: "error-login",
        buttons:{
            auto: "btn-login",
            refresh: "btn-login-refresh"
        }
    },
    password:{
        input: "password",
        error: "error-password",
        buttons: {
            auto: "btn-password",
            refresh: "btn-password-refresh"
        }
    },
    name:{
        input: "name",
        error: "error-name"
    },
    surname:{
        input: "surname",
        error: "error-surname"
    },
    patronymic:{
        input: "patronymic",
        error: "error-patronymic",
    },
    email: {
        input: "email",
        error: "error-email"
    },
    phoneNumber: {
        input: "phoneNumber",
        error: "error-phoneNumber"
    },
    dateBirthday: {
        input: "dateBirthday",
        error: "error-dateBirthday"
    },
    gender: {
        select: "select-gender-patient",
        error: "error-gender"
    },
    buttonSubmit: "btn-submit-registration-patient"
}

export default function PatientForm(props: IPatientFormProps){
    const [login: string, setLogin] = useState("");
    const [isAutoLogin: boolean, setIsAutoLogin] = useState(false);
    const [autoLogin: boolean, setAutoLogin] = useState();
    const [autoPassword: boolean, setAutoPassword] = useState();
    const [password: string, setPassword] = useState("");
    const [isAutoPassword: boolean, setIsAutoPassword] = useState(false);
    const [genders: Array<GenderModel>, setGenders] = useState();

    const [name: string, setName] = useState(" ");
    const [surname: string, setSurname] = useState("");
    const [patronymic: string, setPatronymic] = useState("");
    const [email: string, setEmail] = useState("");
    const [phoneNumber: string, setPhoneNumber] = useState("")
    const [dateBirthday: string, setDateBirthday] = useState("");
    const [gender: string, setGender] = useState("");
    useEffect(() => {
        (async () => {
            props.isLoaded(false);
            let genders:Array<GenderModel> = await GetAll();
            setGenders(genders.map((item, index) => {
                return {
                    key: index.toString(),
                    ...item
                };
            }));
        })();
    }, []);

    const [gendersElement, setGendersElement] = useState();
    useEffect(() => {
        (() => {
            if(genders !== undefined) {
                props.isLoaded(true);
                let tmp = [];
                genders.forEach(element => tmp.push(new ItemProps(element.id, element.name)));
                setGendersElement(<Select id={ids.gender.select}
                                          alignment={"start"}
                                          fontSize={"16"}
                                          height={45}
                                          idError={ids.gender.error}
                                          list={tmp}
                                          title={"Выберите пол"}
                                          onChange={setGender}/>);
            }
        })();
    }, [genders]);

    useEffect(() => {
        (async () => {
            let element = document.getElementById(ids.login.input);
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


    useEffect(() => {
        (() => {
            let element = document.getElementById(ids.password.input);
            if(isAutoPassword) {
                element.setAttribute("disabled", true);
                element.value = GeneratePassword(10);
                setPassword(element.value);
            }
            else{
                element.removeAttribute("disabled");
            }
        })();
    }, [isAutoPassword]);

    const [refreshLogin, setRefreshLogin] = useState();
    useEffect(() => {
        (async () => {
            if(isAutoLogin) {
                let element = document.getElementById(ids.login.input);
                element.value = await GenerateLogin();
                setLogin(element.value);
            }
        })();
    }, [refreshLogin]);

    const [refreshPassword, setRefreshPassword] = useState();
    useEffect(() => {
        (() => {
            if(isAutoPassword) {
                let element = document.getElementById(ids.password.input);
                element.value = GeneratePassword(10);
                setPassword(element.value);
            }
        })();
    }, [refreshPassword]);


    async function submitForms(){
        props.isLoaded(false);
        let isCorrect = new Set();
        if(!isAutoLogin){
            isCorrect.add(await check(login,
                ids.login.error,
                ["Это поле обязательное для заполнения", "Пользователь с таким логином уже сущетсвует"],
                [checkOnLength, CheckLogin]));
        }
        if(!isAutoPassword){
            isCorrect.add(await check(password,
                ids.password.error,
                ["Это поле обязательно для заполнения"], [checkOnLength]));
        }
        debugger
        isCorrect.add(await check(name,
            ids.name.error,
            ["Это поле обязательно для заполнения"], [checkOnLength]));
        isCorrect.add(await check(surname,
            ids.surname.error,
            ["Это поле обязательно для заполнения"], [checkOnLength]));
        if(email.trim().length !== 0) {
            isCorrect.add(await check(email,
                ids.email.error,
                ["Некорректно введенный email", "Пользователь с таким email уже существует"],
                [validEmail, CheckEmail],
                "patient" ));
        }
        if(phoneNumber.trim().length !== 0) {
            isCorrect.add(await check(phoneNumber,
                ids.phoneNumber.error,
                ["Некорректно введенный номер телефона", "Пользователь с таким номером телефона уже существует"],
                [validPhone, CheckPhoneNumber ],"patient"));
        }
        isCorrect.add(await check(dateBirthday,
            ids.dateBirthday.error,
            ["Это поле является обязательным", "Некорректно введенная дата"],
            [checkOnLength, validDate]));

        let genderObj: GenderModel;
        isCorrect.add(await check(gender,
            ids.gender.error,
            ["Это поле обязательное для заполнения"],
            [checkOnLength]));
        genderObj = await GetById(gender);
        if(genderObj === null){
            isCorrect = false;
            Hint(ids.gender.error, "Это поле обязательное для заполнения");
        }
        if(isCorrect.has(false)) {
            props.isLoaded(true);
            return;
        }
        let result = await props.onSubmit(new RegistrationModelPerson(login, password, name, surname, patronymic, email,
                                                                            phoneNumber, dateBirthday, genderObj, "patient"));
        props.isLoaded(true);
        if(!result) {
            Hint(ids.gender.error, "Невозможно зарегистрировать аккаунт. Попробуйте позже");
        }
    }
    return(
        <div className={classes.content}>
            <div className={`row ${classes.row}`}>
               <div className={`col-3 ${classes.text}`}>
                   Логин:
               </div>
               <div className={`col-6 ${classes.input}`}>
                   <Input id={ids.login.input}
                          placeholder={"Введите логин..."}
                          type={"text"}
                          setValue={setLogin}
                          toggleSwitchAttribute={null}
                          errorAttribute={new ErrorAttribute(ids.login.error)}
                          labelAttribute={null} />
               </div>
               <div className={`col-3 ${classes.btnAuto}`}>
                   <div className={`row`}>
                       <div className={`col-3`}>
                           <Button id={ids.login.buttons.auto}
                                   size={"xs"}
                                   text={"auto"}
                                   theme={"Success_outline"}
                                   isDisplay={true}
                                   onClick={() => {clickOnButtonAuto(ids.login.buttons.auto,
                                       ids.login.input,
                                       ids.login.buttons.refresh,
                                       autoLogin,
                                       setAutoLogin,
                                       classesBtn.none,
                                       setIsAutoLogin)}} />
                       </div>
                       <div className={`col-8`}>
                           <Button id={ids.login.buttons.refresh}
                                   size={"xs"}
                                   text={"↺"}
                                   theme={"Success"}
                                   isDisplay={false}
                                   onClick={() => {clickOnButtonRefresh(refreshLogin, setRefreshLogin)}} />
                       </div>
                       <div className={`col-1`}></div>
                   </div>
               </div>
            </div>
            <div className={`row ${classes.row}`}>
                <div className={`col-3 ${classes.text}`}>
                    Пароль:
                </div>
                <div className={"col-6"}>
                    <Input id={ids.password.input}
                           placeholder={"Введите пароль..."}
                           type={"password"}
                           setValue={setPassword}
                           toggleSwitchAttribute={new ToggleSwitchAttributes("Показать пароль")}
                           errorAttribute={new ErrorAttribute(ids.password.error)}
                           labelAttribute={null} />
                </div>
                <div className={`col-3 ${classes.btnAuto}`}>
                    <div className={`row`}>
                        <div className={`col-3`}>
                            <Button id={ids.password.buttons.auto}
                                    size={"xs"}
                                    text={"auto"}
                                    theme={"Success_outline"}
                                    isDisplay={true}
                                    onClick={() => {clickOnButtonAuto(ids.password.buttons.auto,
                                        ids.password.input,
                                        ids.password.buttons.refresh,
                                        autoPassword,
                                        setAutoPassword,
                                        classesBtn.none,
                                        setIsAutoPassword)}} />
                        </div>
                        <div className={`col-8`}>
                           <Button id={ids.password.buttons.refresh}
                                   size={"xs"}
                                   text={"↺"}
                                   theme={"Success"}
                                   isDisplay={false}
                                   onClick={() => {clickOnButtonRefresh(refreshPassword, setRefreshPassword)}} />
                        </div>
                        <div className={`col-1`}></div>
                    </div>
                </div>
            </div>
            <div className={`row ${classes.row}`}>
                <div className={`col-3 ${classes.text}`}>
                    Имя:
                </div>
                <div className={`col-6 ${classes.input}` }>
                    <Input id={ids.name.input}
                           placeholder={"Введите ваше имя..."}
                           type={"text"}
                           setValue={setName}
                           toggleSwitchAttribute={null}
                           errorAttribute={new ErrorAttribute(ids.name.error)}
                           labelAttribute={null}/>
                </div>
                <div className={`col-3`}></div>
            </div>
            <div className={`row ${classes.row}`}>
                <div className={`col-3 ${classes.text}`}>
                    Фамилия:
                </div>
                <div className={"col-6 input"}>
                    <Input id={ids.surname.input}
                           placeholder={"Введите вашу фамилию..."}
                           type={"text"}
                           setValue={setSurname}
                           toggleSwitchAttribute={null}
                           errorAttribute={new ErrorAttribute(ids.surname.error)}
                           labelAttribute={null} />
                </div>
                <div className={`col-3`}></div>
            </div>
            <div className={`row ${classes.row}`}>
                <div className={`col-3 ${classes.text}`}>
                    Отчество:
                </div>
                <div className={"col-6"}>
                    <Input id={ids.patronymic.input}
                           placeholder={"Введите ваше отчетсво..."}
                           type={"text"} setValue={setPatronymic}
                           toggleSwitchAttribute={null}
                           errorAttribute={new ErrorAttribute(ids.patronymic.error)}
                           labelAttribute={null} />
                </div>
                <div className={`col-3`}></div>
            </div>
            <div className={`row ${classes.row}`}>
                <div className={`col-3 ${classes.text}`}>
                    Email:
                </div>
                <div className={"col-6"}>
                    <Input id={ids.email.input}
                           placeholder={"Введите ваш email..."}
                           type={"email"}
                           setValue={setEmail}
                           toggleSwitchAttribute={null}
                           errorAttribute={new ErrorAttribute(ids.email.error)}
                           labelAttribute={null} />
                </div>
                <div className={`col-3`}></div>
            </div>
            <div className={`row ${classes.row}`}>
                <div className={`col-3 ${classes.text}`}>
                    Номер телефона:
                </div>
                <div className={"col-6"}>
                    <Input id={ids.phoneNumber.input}
                           placeholder={"Введите ваш номер телефона..."}
                           type={"tel"}
                           setValue={setPhoneNumber}
                           toggleSwitchAttribute={null}
                           errorAttribute={new ErrorAttribute(ids.phoneNumber.error)}
                           labelAttribute={null}/>
                </div>
                <div className={`col-3`}></div>
            </div>
            <div className={`row ${classes.row}`}>
                <div className={`col-3 ${classes.text}`}>
                    Дата рождения:
                </div>
                <div className={"col-6"}>
                    <Input id={ids.dateBirthday.input}
                           placeholder={"Введите дату рождения..."}
                           type={"date"}
                           setValue={setDateBirthday}
                           toggleSwitchAttribute={null}
                           errorAttribute={new ErrorAttribute(ids.dateBirthday.error)}
                           labelAttribute={null} />
                </div>
                <div className={`col-3`}></div>
            </div>
            <div className={`row ${classes.row}`}>
                <div className={`col-3 ${classes.text}`}>
                    Пол:
                </div>
                <div className={"col-6"}>
                    {gendersElement}
                </div>
                <div className={`col-3`}></div>
            </div>
            <div className={`row ${classes.rowBtn}`}>
                <div className={`col-3`}></div>
                <div className={`col-6`}>
                    <Button id={ids.buttonSubmit}
                            size={"L"}
                            text={props.textButton}
                            theme={"Red"} isDisplay={true} onClick={async () => {await submitForms();}}/>
                </div>
                <div className={`col-3`}></div>
            </div>
        </div>
    )
}