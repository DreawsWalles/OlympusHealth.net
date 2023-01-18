import {useEffect, useState} from "react";
import GenerateLogin from "../../../../Generators/GenerateLogin";
import GeneratePassword from "../../../../Generators/GeneratePassword";
import {GetAll} from "../../../../Swapi/SwapiGender";
import CustomSelect from "../../../Selects/CustomSelect/CustomSelect";
import TextInput from "../../../Inputs/TextInput/TextInput";
import ButtonAuto from "../../../Buttons/ButtonAuto/ButtonAuto";
import ButtonSymbol from "../../../Buttons/ButtonSymbol/ButtonSymbol";
import PasswordInput from "../../../Inputs/PasswordInput/PasswordInput";
import InputWithDynamicDataList from "../../../Inputs/InputWithDynamicDataList/InputWithDynamicDataList";
import {GetCountryMatchName} from "../../../../Swapi/SwapiAddress/Country";
import {GetRegionMatchName} from "../../../../Swapi/SwapiAddress/Region";
import {GetCityMatchName} from "../../../../Swapi/SwapiAddress/City";
import {GetNumberHouseMatchName} from "../../../../Swapi/SwapiAddress/NumberHouse";
import classes from "./GeneralMedicForm.module.css"
import {GetStreetMatchName} from "../../../../Swapi/SwapiAddress/Street";

export default function GeneralMedicForm(props){
    const [autoLogin, setAutoLogin] = useState();
    const [autoPassword, setAutoPassword] = useState();

    const [isAutoLogin, setIsAutoLogin] = useState(false);
    useEffect(() => {
        (async () => {
            let element = document.getElementById("login");
            if(isAutoLogin) {
                element.setAttribute("disabled", true);
                element.value = await GenerateLogin();
                props.setLogin(element.value);
            }
            else{
                element.removeAttribute("disabled");
                element.value = props.login;
            }
        })();
    }, [isAutoLogin]);

    const [isAutoPassword, setIsAutoPassword] = useState(false);
    useEffect(() => {
        (() => {
            let element = document.getElementById("password");
            if(isAutoPassword) {
                element.setAttribute("disabled", true);
                element.value = GeneratePassword(10);
                props.setPassword(element.value);
            }
            else{
                element.removeAttribute("disabled");
                element.value = props.password;
            }
        })();
    }, [isAutoPassword]);

    const [refreshLogin, setRefreshLogin] = useState();
    useEffect(() => {
        (async () => {
            if(isAutoLogin) {
                let element = document.getElementById("login");
                element.value = await GenerateLogin();
                props.setLogin(element.value);
            }
        })();
    }, [refreshLogin]);

    const [refreshPassword, setRefreshPassword] = useState();
    useEffect(() => {
        (() => {
            if(isAutoPassword) {
                let element = document.getElementById("password");
                element.value = GeneratePassword(10);
                props.setPassword(element.value);
            }
        })();
    }, [refreshPassword]);

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
        })();
    }, []);
    const [gendersElement, setGendersElement] = useState();
    useEffect(() => {
        (() => {
            if(genders !== undefined) {
                props.isLoaded(true);
                setGendersElement(<CustomSelect idSpan={"error-gender"} genders={genders} onChange ={props.setGender} />);
            }
        })();
    }, [genders]);
    function handleInputCountry(e){
        let elCountry = document.getElementById("countryInput");
        let elReg = document.getElementById("regionInput");
        if(elCountry.value === "") {
            elReg.setAttribute("disabled", true)
        }
        else{
            elReg.removeAttribute("disabled");
        }
    }
    function handleInputRegion(e){
        let elReg = document.getElementById("regionInput");
        let elCity = document.getElementById("cityInput");
        if(elReg.value === ""){
            elCity.setAttribute("disabled", true);
        }
        else{
            elCity.removeAttribute("disabled");
        }
    }
    function handleInputCity(e){
        let elCity = document.getElementById("cityInput");
        let elStreet = document.getElementById("streetInput");
        if(elCity.value === ""){
            elStreet.setAttribute("disabled", true);
        }
        else{
            elStreet.removeAttribute("disabled");
        }
    }
    function handleInputStreet(e){
        let elStreet = document.getElementById('streetInput');
        let elHouse = document.getElementById('NumberHouseInput');
        if(elStreet.value === ""){
            elHouse.setAttribute("disabled", true);
        }
        else{
            elHouse.removeAttribute("disabled");
        }
    }
    return(
        <div className={classes.containerDoctor}>
            <div className={`row ${classes.rowDoctor}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>Логин:</div>
                </div>
                <div className={"col-7 input"}>
                    <TextInput
                        id={"login"}
                        type={"text"}
                        placeholder={"Введите логин..."}
                        idSpan={"error-login"}
                        onChange={props.setLogin}
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
                        onClick={props.setLogin}
                        Symbol={"↺"}
                        id={"btn-login-refresh"} />
                </div>
            </div>
            <div className={`row ${classes.rowDoctor}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>Пароль:</div>
                </div>
                <div className={"col-7 input"}>
                    <PasswordInput
                        id={"password"}
                        className={"form-control textInput"}
                        placeholder={"Введите пароль..."}
                        idSpan={"error-password"}
                        onChange={props.setPassword}
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
                        onClick={props.setPassword}
                        Symbol={"↺"}
                        id={"btn-password-refresh"} />
                </div>
            </div>
            <div className={`row ${classes.rowDoctor}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>Имя:</div>
                </div>
                <div className={"col-7 input"}>
                    <TextInput
                        id={"name"}
                        type={"text"}
                        className={"form-control textInput"}
                        placeholder={"Введите ваше имя"}
                        idSpan={"error-name"}
                        onChange={props.setName}
                        required
                    />
                </div>
            </div>
            <div className={`row ${classes.rowDoctor}`}>
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
                        onChange={props.setSurname}
                        required
                    />
                </div>
            </div>
            <div className={`row ${classes.rowDoctor}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>Отчество:</div>
                </div>
                <div className={"col-7 input"}>
                    <TextInput
                        id={"patronymic"}
                        type={"text"}
                        className={"form-control textInput"}
                        placeholder={"Введите ваше отчество..."}
                        idSpan={"error-patronymic"}
                        onChange={props.setPatronymic}
                    />
                </div>
            </div>
            <div className={`row ${classes.rowDoctor}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>Email:</div>
                </div>
                <div className={"col-7 input"}>
                    <TextInput
                        id={"email"}
                        type={"email"}
                        className={"form-control textInput"}
                        placeholder={"Введите ваш email"}
                        idSpan={"error-email"}
                        onChange={props.setEmail}
                    />
                </div>
            </div>
            <div className={`row ${classes.rowDoctor}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>Номер телефона:</div>
                </div>
                <div className={"col-7 input"}>
                    <TextInput
                        id={"phoneNumber"}
                        type={"tel"}
                        className={"form-control textInput"}
                        placeholder={"Введите номер телефона..."}
                        idSpan={"error-numberPhone"}
                        onChange={props.setPhoneNumber}
                    />
                </div>
            </div>
            <div className={`row ${classes.rowDoctor}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>Дата рождения:</div>
                </div>
                <div className={"col-7 input"}>
                    <TextInput
                        id={"dateBirthday"}
                        type={"date"}
                        className={"form-control textInput"}
                        placeholder={"Введите дату рождения..."}
                        idSpan={"error-dateBirthday"}
                        onChange={props.setDateBirthday}
                    />
                </div>
            </div>
            <div className={`row ${classes.rowDoctor}`}>
                <div className={`col-3 ${classes.text}`}>
                    <div>Пол:</div>
                </div>
                <div className={"col-7 input"}>
                    {gendersElement}
                </div>
            </div>
            <div className={`row ${classes.rowDoctor}`}>
                <div className={`col-3 ${classes.text} ${classes.textSubtitle}`}>
                    Адрес проживания
                </div>
                <div className={classes.borderUnderText}>
                    <hr />
                </div>
                <div className={`row ${classes.rowDoctor}`}>
                    <div className={`col-3 ${classes.text}`}>
                        Страна:
                    </div>
                    <InputWithDynamicDataList
                        list={"country"}
                        className={"form-control textInput"}
                        id={"countryInput"}
                        placeholder={"Введите страну..."}
                        idSpan={"error-country"}
                        api={GetCountryMatchName}
                        setValue={props.setCountry}
                        disable={false}
                        onInput={handleInputCountry}
                    />
                </div>
                <div className={`row ${classes.rowDoctor}`}>
                    <div className={`col-3 ${classes.text}`}>
                        Регион:
                    </div>
                    <InputWithDynamicDataList
                        list={"region"}
                        className={"form-control textInput"}
                        id={"regionInput"}
                        placeholder={"Введите регион..."}
                        idSpan={"error-region"}
                        api={GetRegionMatchName}
                        country={props.country}
                        setValue={props.setRegion}
                        disable={true}
                        onInput={handleInputRegion}
                    />
                </div>
                <div className={`row ${classes.rowDoctor}`}>
                    <div className={`col-3 ${classes.text}`}>
                        Город:
                    </div>
                    <InputWithDynamicDataList
                        list={"city"}
                        className={"form-control textInput"}
                        id={"cityInput"}
                        placeholder={"Введите город..."}
                        idSpan={"error-city"}
                        api={GetCityMatchName}
                        setValue={props.setCity}
                        country={props.country}
                        region={props.region}
                        disable={true}
                        onInput={handleInputCity}
                    />
                </div>
                <div className={`row ${classes.rowDoctor}`}>
                    <div className={`col-3 ${classes.text}`}>
                        Улица:
                    </div>
                    <InputWithDynamicDataList
                        list={"street"}
                        className={"form-control textInput"}
                        id={"streetInput"}
                        placeholder={"Введите улицу..."}
                        idSpan={"error-street"}
                        api={GetStreetMatchName}
                        setValue={props.setStreet}
                        country={props.country}
                        region={props.region}
                        city={props.city}
                        disable={true}
                        onInput={handleInputStreet}
                    />
                </div>
                <div className={`row ${classes.rowDoctor}`}>
                    <div className={`col-3 ${classes.text}`}>
                        Номер дома:
                    </div>
                    <InputWithDynamicDataList
                        list={"numberHouse"}
                        className={"form-control textInput"}
                        id={"NumberHouseInput"}
                        placeholder={"Введите номер дома..."}
                        idSpan={"error-NumberHouse"}
                        api={GetNumberHouseMatchName}
                        setValue={props.setNUmberHouse}
                        country={props.country}
                        region={props.region}
                        city={props.city}
                        street={props.street}
                        disable={true}
                    />
                </div>
            </div>
            <div className={`row ${classes.rowBtn}`}>
                <button onClick={props.onSubmit} className={classes.btnRegister}>{props.textButton}</button>
            </div>
        </div>
    )
}