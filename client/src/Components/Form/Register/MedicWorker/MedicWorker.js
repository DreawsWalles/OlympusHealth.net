import GeneralMedicForm from "./GeneralMedicForm";
import {useState} from "react";

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

    function submit(){
        debugger
    }
    switch (props.choice)
    {
        case "doctor":
            return(<GeneralMedicForm isLoaded={props.isLoaded} setRegistered={props.setRegistered} textButton={props.textButton}
                    login={login} password={password} setLogin={setLogin} setPassword={setPassword} setName={setName}
                    setSurname={setSurname} setPatronymic={setPatronymic} setEmail={setEmail} setPhoneNumber={setPhoneNumber}
                    setDateBirthday={setDateBirthday} setGender={setGender} setCountry={setCountry} setRegion={setRegion}
                    setCity={setCity} setStreet={setStreet} setNUmberHouse={setNumberHouse} onSubmit={submit}/>)
    }
}