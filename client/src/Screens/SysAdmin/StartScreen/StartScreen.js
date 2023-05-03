import iconAddPerson from "../../../Images/MenuIcons/AddPerson/iconAddPerson.svg";
import iconAddResearch from "../../../Images/MenuIcons/AddResearch/iconAddResearch.svg";
import iconAddInstitution from "../../../Images/MenuIcons/AddInstitutions/iconAddInstitution.svg";
import classes from "./StartScreen.module.css";
import {TwoComponentButton} from "../../../Components/Buttons/TwoComponentButton/TwoComponentButton";
import {IStartScreenProps} from "./IStartScreenProps";

export default function StartScreen(props: IStartScreenProps){
    function clickOnAddUsers(){
        debugger
        props.subScreenParameters.functions.Add();
    }
    function clickOnAddPattern(){

    }
    function clickOnAddInstitution(){

    }
    document.title = "Стартовый экран";
    return(
        <div id={props.id} className={`${classes.content}`}>
            <div className={`row ${classes.element}`}>
                <TwoComponentButton size={"L"}
                                    icon={iconAddPerson}
                                    text={"добавить пользователя"}
                                    theme={"Red"}
                                    onClick={clickOnAddUsers}/>
            </div>
            <div className={`row ${classes.element}`}>
                <TwoComponentButton size={"L"}
                                    icon={iconAddResearch}
                                    text={"добавить шаблон"}
                                    theme={"Red"}
                                    onClick={clickOnAddPattern}/>
            </div>
            <div className={`row ${classes.element}`}>
                <TwoComponentButton size={"L"}
                                    icon={iconAddInstitution}
                                    text={"добавить учреждение"}
                                    theme={"Red"}
                                    onClick={clickOnAddInstitution}/>
            </div>
        </div>
    )
}