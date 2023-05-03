import {useEffect, useState} from "react";
import {CheckEmail, CheckLogin, CheckPhoneNumber} from "../../../../Swapi/SwapiAccount/SwapiAccount";
import {GetAll, GetById} from "../../../../Swapi/SwapiGender";
import {GetIdByName} from "../../../../Swapi/SwapiRoleMedic";
import {Hint} from "../../../Functions";
import {check, checkOnLength, validDate, validEmail, validPhone} from "../../FunctionValidates";
import {GenderModel} from "../../../../Entities/PersonalModel/GenderModel";
import {RegistrationModelPerson} from "../../../../Entities/AutorizeModel/RegistrationModelPerson";
import {StreetModel} from "../../../../Entities/AddressModel/StreetModel";
import {CityModel} from "../../../../Entities/AddressModel/CityModel";
import {RegionModel} from "../../../../Entities/AddressModel/RegionModel";
import {CountryModel} from "../../../../Entities/AddressModel/CountryModel";
import {RoleModel} from "../../../../Entities/PersonalModel/RoleModel";
import type {IMedicWorkerProps} from "./IMedicWorkerProps";
import GenerateLogin from "../../../../Generators/GenerateLogin";
import GeneratePassword from "../../../../Generators/GeneratePassword";
import {ItemProps} from "../../../Selects/Select/ISelectProps";
import Select from "../../../Selects/Select/Select";
import classes from "./MedicForm.module.css";
import Button from "../../../Buttons/Button/Button";
import {clickOnButtonAuto, clickOnButtonRefresh} from "../functionsButtons";
import classesBtn from "../../../Buttons/Button/Button.module.css";
import {GetCountryMatchName} from "../../../../Swapi/SwapiAddress/Country";
import {GetRegionMatchName} from "../../../../Swapi/SwapiAddress/Region";
import {GetCityMatchName} from "../../../../Swapi/SwapiAddress/City";
import {GetStreetMatchName} from "../../../../Swapi/SwapiAddress/Street";
import {GetNumberHouseMatchName} from "../../../../Swapi/SwapiAddress/NumberHouse";
import {Input} from "../../../Inputs/Input/Input";
import {ErrorAttribute, ToggleSwitchAttributes} from "../../../Inputs/Input/IInputProps";
import {InputWithSelect} from "../../../Inputs/InputWithSelect/InputWithSelect";


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
        select: "select-gender-medic",
        error: "error-gender"
    },
    address: {
        country: {
            input: "input-country",
            error: "error-country"
        },
        region: {
            input: "input-region",
            error: "error-region"
        },
        city: {
            input: "input-city",
            error: "error-city"
        },
        street: {
            input: "input-street",
            error: "error-street"
        },
        numberHouse: {
            input: "input-numberHouse",
            error: "error-numberHouse"
        }
    },
    buttonSubmit: "btn-submit-registration-medic"
}

export default function MedicWorker(props: IMedicWorkerProps){
    const [login: string, setLogin] = useState("");
    const [password: string, setPassword] = useState("");
    const [name: string, setName] = useState(" ");
    const [surname: string, setSurname] = useState("");
    const [patronymic: string, setPatronymic] = useState("");
    const [email: string, setEmail] = useState("");
    const [phoneNumber: string, setPhoneNumber] = useState("")
    const [dateBirthday: string, setDateBirthday] = useState("");
    const [gender: string, setGender] = useState("");
    const [country: string, setCountry] = useState("");
    const [region: string, setRegion] = useState("");
    const [city: string, setCity] = useState("");
    const [street: string, setStreet] = useState("");
    const [numberHouse: string, setNumberHouse] = useState("")

    const [autoLogin, setAutoLogin] = useState();
    const [autoPassword, setAutoPassword] = useState();

    const [isAutoLogin, setIsAutoLogin] = useState(false);
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

    const [isAutoPassword, setIsAutoPassword] = useState(false);
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

    const [genders: Array<GenderModel>, setGenders] = useState();
    useEffect(() => {
        (async () => {
            props.isLoaded(false);
            let genders: Array<GenderModel> = await GetAll();
            setGenders(genders.map((item, index) => {
                return {
                    key: index.toString(),
                    ...item
                };
            }));
            let input = document.getElementById(ids.address.region);
            input.setAttribute("disabled", true);
            input = document.getElementById(ids.address.city);
            input.setAttribute("disabled", true);
            input = document.getElementById(ids.address.street);
            input.setAttribute("disabled", true);
            input = document.getElementById(ids.address.numberHouse);
            input.setAttribute("disabled", true);
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
    async function submit(){
        props.isLoaded(false);
        let isCorrect = new Set();
        if(!isAutoLogin){
            isCorrect.add(await check(login,
                ids.login.error,
                ["Это поле обязательное для заполнения",
                    "Пользователь с таким логином уже сущетсвует"],
                [checkOnLength, CheckLogin]));
        }
        if(!isAutoPassword){
            isCorrect.add(await check(password,
                ids.password.error,
                ["Это поле обязательно для заполнения"], [checkOnLength]));
        }
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
                [CheckEmail, validEmail],
                "medic" ));
        }
        if(phoneNumber.trim().length !== 0) {
            isCorrect.add(await check(phoneNumber,
                ids.phoneNumber.error,
                ["Некорректно введенный номер телефона", "Пользователь с таким номером телефона уже существует"],
                [CheckPhoneNumber, validPhone ],"medic"));
        }
        isCorrect.add(await check(dateBirthday,
            ids.dateBirthday.error,
            ["Некорректно введенная дата", "Это поле является обязательным"],
            [validDate, checkOnLength]));
        let genderObj: GenderModel;
        isCorrect.add(await check(gender,
            ids.gender.error,
            ["Это поле обязательное для заполнения"],
            [checkOnLength]));
        genderObj = await GetById(gender);
        if(genderObj === null){
            isCorrect.add(false);
            Hint(ids.gender.error, "Это поле обязательное для заполнения");
        }
        let isCorrectAddress = true;
        if(country.trim().length !== 0){
            isCorrectAddress = await check(region,
                ids.address.region.error,
                ["Заполните адрес полностью"],
                [checkOnLength]);
            if(!isCorrectAddress){
                props.isLoaded(true);
                return;
            }
            Hint(ids.address.region.error, "");
            isCorrectAddress = await check(city,
                ids.address.city.error,
                ["Заполните адрес полностью"],
                [checkOnLength]);
            if(!isCorrectAddress){
                props.isLoaded(true);
                return;
            }
            Hint(ids.address.city.error, "");
            isCorrectAddress = await check(street,
                ids.address.street.error,
                ["Заполните адрес полностью"],
                [checkOnLength]);
            if(!isCorrectAddress){
                props.isLoaded(true);
                return;
            }
            Hint(ids.address.street.error, "");
            isCorrectAddress = await check(numberHouse,
                ids.address.numberHouse.error,
                ["Заполните адрес полностью"],
                [checkOnLength]);
            if(!isCorrectAddress){
                props.isLoaded(true);
                return;
            }
            Hint(ids.address.numberHouse.error, "");
        }
        let roleKey = await GetIdByName(props.choice);
        if(roleKey === null){
            isCorrectAddress = false;
            Hint(ids.address.numberHouse.error, "Регистрация в данный момент невозможна");
        }
        if(!isCorrectAddress && isCorrect.has(false)) {
            props.isLoaded(true);
            return;
        }
        let result = await props.onSubmit(new RegistrationModelPerson(login, password, name, surname,patronymic, email,
            phoneNumber, dateBirthday, genderObj, "medic",
            new StreetModel(null, street, numberHouse),
            new CityModel(null, city),
            new RegionModel(null, region),
            new CountryModel(null, country),
            new RoleModel(roleKey   , props.choice)));

        props.isLoaded(true);
        if(!result) {
            Hint(ids.address.numberHouse.error, "Невозможно зарегистрировать аккаунт. Попробуйте позже");
        }
    }

    function handleInputCountry(e){
        let elReg = document.getElementById(ids.address.region.input);
        if(e === "") {
            elReg.setAttribute("disabled", true)
        }
        else{
            elReg.removeAttribute("disabled");
        }
    }
    function handleInputRegion(e){
        let elCity = document.getElementById(ids.address.city.input);
        if(e === ""){
            elCity.setAttribute("disabled", true);
        }
        else{
            elCity.removeAttribute("disabled");
        }
    }
    function handleInputCity(e){
        let elStreet = document.getElementById(ids.address.street.input);
        if(e === ""){
            elStreet.setAttribute("disabled", true);
        }
        else{
            elStreet.removeAttribute("disabled");
        }
    }
    function handleInputStreet(e){
        let elHouse = document.getElementById(ids.address.numberHouse.input);
        if(e === ""){
            elHouse.setAttribute("disabled", true);
        }
        else{
            elHouse.removeAttribute("disabled");
        }
    }
    return(
        <div className={classes.content}>
            <div className={`row ${classes.row}`}>
                <div className={`col-3 ${classes.text}`}>
                    Логин:
                </div>
                <div className={"col-6"}>
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
                <div className={"col-6"}>
                    <Input id={ids.name.input}
                           placeholder={"Введите ваше имя..."}
                           type={"text"}
                           setValue={setName}
                           toggleSwitchAttribute={null}
                           errorAttribute={new ErrorAttribute(ids.name.error)}
                           labelAttribute={null} />
                </div>
                <div className={`col-3`}></div>
            </div>
            <div className={`row ${classes.row}`}>
                <div className={`col-3 ${classes.text}`}>
                    Фамилия:
                </div>
                <div className={"col-6"}>
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
            <div className={`row ${classes.row}`}>
                <div className={`col-3 ${classes.text} ${classes.textSubtitle}`}>
                    Адрес проживания
                </div>
                <div className={classes.borderUnderText}>
                    <hr />
                </div>
            </div>
                <div className={`row ${classes.row}`}>
                    <div className={`col-3 ${classes.text}`}>
                        Страна:
                    </div>
                    <div className={`col-7 ${classes.input}`}>
                        <InputWithSelect id={ids.address.country.input}
                                         idError={ids.address.country.error}
                                         fontSize={16}
                                         height={40}
                                         placeholder={"Введите страну..."}
                                         funcGetData={async (e) => {return await GetCountryMatchName(e); }}
                                         setValue={(e) => {
                                             setCountry(e);
                                         }}
                                         onInput={null}
                                         mode={"Single"}
                                         actionAfterInput={handleInputCountry}/>
                    </div>
                    <div className={`col-2`}></div>
                </div>
                <div className={`row ${classes.row} ${classes.margin_input_top}`}>
                    <div className={`col-3 ${classes.text}`}>
                        Регион:
                    </div>
                    <div className={`col-7 ${classes.input}`}>
                        <InputWithSelect id={ids.address.region.input}
                                         idError={ids.address.region.error}
                                         fontSize={16}
                                         height={40}
                                         placeholder={"Введите регион..."}
                                         funcGetData={async (e) => {
                                             return await GetRegionMatchName(e, country);
                                         }}
                                         setValue={(e) => {setRegion(e)}}
                                         actionAfterInput={handleInputRegion}
                                         onInput={null}
                                         mode={"Single"}/>
                    </div>
                    <div className={`col-2`}></div>
                </div>
                <div className={`row ${classes.row} ${classes.margin_input_top}`}>
                    <div className={`col-3 ${classes.text}`}>
                        Город:
                    </div>
                    <div className={`col-7 ${classes.input}`}>
                        <InputWithSelect id={ids.address.city.input}
                                         idError={ids.address.city.error}
                                         height={40}
                                         placeholder={"Введите город..."}
                                         funcGetData={async (e) => {
                                             return await GetCityMatchName(e, country, region);
                                         }}
                                         fontSize={16}
                                         setValue={(e) => {setCity(e)}}
                                         actionAfterInput={handleInputCity}
                                         onInput={null}
                                         mode={"Single"}/>
                    </div>
                    <div className={`col-2`}></div>
                </div>
                <div className={`row ${classes.row} ${classes.margin_input_top}`}>
                    <div className={`col-3 ${classes.text}`}>
                        Улица:
                    </div>
                    <div className={`col-7 ${classes.input}`}>
                        <InputWithSelect id={ids.address.street.input}
                                         idError={ids.address.street.error}
                                         height={40} placeholder={"Введите улицу..."}
                                         funcGetData={async (e) => {
                                             return await GetStreetMatchName(e, country, region, city);
                                         }}
                                         fontSize={16}
                                         setValue={(e) => {setStreet(e)}}
                                         actionAfterInput={handleInputStreet}
                                         onInput={null}
                                         mode={"Single"} />
                    </div>
                    <div className={`col-2`}></div>
                </div>
                <div className={`row ${classes.row} ${classes.margin_input_top}`}>
                    <div className={`col-3 ${classes.text}`}>
                        Номер дома:
                    </div>
                    <div className={`col-7 ${classes.input}`}>
                        <InputWithSelect id={ids.address.numberHouse.input}
                                         idError={ids.address.numberHouse.error}
                                         height={40}
                                         placeholder={"Введите номер дома"}
                                         funcGetData={async (e) => {
                                             return await GetNumberHouseMatchName(e, country, region, city, street)
                                         }}
                                         fontSize={16}
                                         setValue={(e) => {setNumberHouse(e)}}
                                         actionAfterInput={null}
                                         onInput={null}
                                         mode={"Single"}/>
                    </div>
                    <div className={`col-2`}></div>
                </div>
            <div className={`row ${classes.rowBtn}`}>
                <div className={`col-3`}></div>
                <div className={`col-6`}>
                    <Button id={ids.buttonSubmit}
                            size={"L"}
                            text={props.textButton}
                            theme={"Red"} isDisplay={true}
                            onClick={async () => {await submit();}}/>
                </div>
                <div className={`col-3`}></div>
            </div>
        </div>
    )
}