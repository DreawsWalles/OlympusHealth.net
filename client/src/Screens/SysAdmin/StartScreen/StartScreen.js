import ButtonFastAction from "../../../Components/Buttons/ButtonFastAction/BigVersion/ButtonFastAction";
import iconAddPerson from "../../../Images/MenuIcons/AddPerson/iconAddPerson.svg";
import iconAddResearch from "../../../Images/MenuIcons/AddResearch/iconAddResearch.svg";
import iconAddInstitution from "../../../Images/MenuIcons/AddInstitutions/iconAddInstitution.svg";
import classes from "./StartScreen.module.css";

export default function StartScreen(props){
    function clickOnAddUsers(){
        props.subScreenParameters.functions.Add();
    }
    document.title = "Стартовый экран";
    return(
        <div id={"mainContent"} className={`${classes.content}`}>
            <div className={`row ${classes.element}`}>
                <ButtonFastAction onClick={clickOnAddUsers} text={"добавить пользователя"} icon={iconAddPerson}/>
            </div>
            <div className={`row ${classes.element}`}>
                <ButtonFastAction text={"добавить шаблон"} icon={iconAddResearch}/>
            </div>
            <div className={`row ${classes.element}`}>
                <ButtonFastAction text={"добавить учреждение"} icon={iconAddInstitution}/>
            </div>
        </div>
    )
}