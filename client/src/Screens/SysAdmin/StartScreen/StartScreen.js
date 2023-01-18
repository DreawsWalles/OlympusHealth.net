import ButtonFastAction from "../../../Components/Buttons/ButtonFastAction/ButtonFastAction";
import iconAddPerson from "../../Images/MenuIcons/AddPerson/iconAddPerson.svg";
import iconAddResearch from "../../Images/MenuIcons/AddResearch/iconAddResearch.svg";
import iconAddInstitution from "../../Images/MenuIcons/AddInstitutions/iconAddInstitution.svg";

export default function StartScreen(props){
    document.title = "Стартовый экран";
    return(
        <div>
            <div className={`row`}>
                <ButtonFastAction text={"добавить пользователя"} icon={iconAddPerson}/>
            </div>
            <div className={`row`}>
                <ButtonFastAction text={"добавить шаблон"} icon={iconAddResearch}/>
            </div>
            <div className={`row`}>
                <ButtonFastAction text={"добавить учреждение"} icon={iconAddInstitution}/>
            </div>
        </div>
    )
}