import classes from "./Menu.module.css";
import iconPerson from "../../Images/MenuIcons/Person/iconPerson.svg"
import iconPersonHover from "../../Images/MenuIcons/Person/iconPersonHover.svg"
import iconResearch from "../../Images/MenuIcons/Research/iconResearch.svg";
import iconResearchHover from "../../Images/MenuIcons/Research/iconResearchHover.svg"
import iconInstitutions from "../../Images/MenuIcons/Institutions/iconInstitutions.svg";
import iconInstitutionsHover from "../../Images/MenuIcons/Institutions/iconInstitutionsHover.svg";
import iconNotifications from "../../Images/MenuIcons/Notifications/iconNotifications.svg";
import iconNotificationsHover from "../../Images/MenuIcons/Notifications/iconNotificationsHover.svg";
import ButtonMenu from "../../../Components/Buttons/ButtonMenu/ButtonMenu";
export default function Menu(props){

    return(<div className={classes.content}>
        <ButtonMenu icon={iconPerson} iconHover={iconPersonHover} text={"пользователи"}/>
        <ButtonMenu icon={iconResearch} iconHover={iconResearchHover} text={"исследования"} />
        <ButtonMenu icon={iconInstitutions} iconHover={iconInstitutionsHover} text={"учреждения"} />
        <ButtonMenu icon={iconNotifications} iconHover={iconNotificationsHover} text={"уведомления"} />
    </div>)
}