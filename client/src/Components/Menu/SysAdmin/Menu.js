import classes from "./Menu.module.css";
import iconPerson from "../../../Screens/Images/MenuIcons/Person/iconPerson.svg"
import iconPersonHover from "../../../Screens/Images/MenuIcons/Person/iconPersonHover.svg"
import iconResearch from "../../../Screens/Images/MenuIcons/Research/iconResearch.svg";
import iconResearchHover from "../../../Screens/Images/MenuIcons/Research/iconResearchHover.svg"
import iconInstitutions from "../../../Screens/Images/MenuIcons/Institutions/iconInstitutions.svg";
import iconInstitutionsHover from "../../../Screens/Images/MenuIcons/Institutions/iconInstitutionsHover.svg";
import iconNotifications from "../../../Screens/Images/MenuIcons/Notifications/iconNotifications.svg";
import iconNotificationsHover from "../../../Screens/Images/MenuIcons/Notifications/iconNotificationsHover.svg";
import iconArrowUp from "../../../Screens/Images/MenuIcons/Arrow/ArrowUp.svg";
import iconArrowDown from "../../../Screens/Images/MenuIcons/Arrow/ArrowDown.svg";
import ButtonIconMenu from "../../Buttons/ButtonMenu/ButtonIconMenu";
import NotificationMenu from "../../Notifications/NotificaionMenu/NotificationIconButtonMenu"
import ButtonFolding from "../../Buttons/ButtonFolding/ButtonFolding";
import {useState} from "react";
export default function Menu(props){
    function clickOnPerson(){
        props.setContent(<div>А вот здесь персональные данные</div>)
    }
    function clickOnResearch(){
        props.setContent(<div>А вот здесь исследования</div>)
    }
    function clickOnInstitution(){
        props.setContent(<div>Вот тут учреждения</div>)
    }
    function clickOnNotification(){
        props.setContent(<div>А вот тут уведомления</div>)
    }
    return(<div id={classes.content} className={classes.content}>
        <div className={`${classes.menu}`}>
            <div onClick={clickOnPerson} className={`${classes.icon_margin}`}>
                <ButtonIconMenu icon={iconPerson} iconHover={iconPersonHover} text={"пользователи"}/>
            </div>
            <div onClick={clickOnResearch} className={`${classes.icon_margin}`}>
                <ButtonIconMenu icon={iconResearch} iconHover={iconResearchHover} text={"исследования"} />
            </div>
            <div className={"row"}>
                <ButtonFolding classNameMenu={classes.content} classNameNavOpen={classes.is_nav_open} iconFolding={iconArrowUp} iconUnFolding={iconArrowDown}/>
            </div>
            <div onClick={clickOnInstitution} className={`${classes.icon_margin}`}>
                <ButtonIconMenu icon={iconInstitutions} iconHover={iconInstitutionsHover} text={"учреждения"} />
            </div>
            <div onClick={clickOnNotification} className={`${classes.icon_margin}`}>
                <NotificationMenu count={props.countNotification}
                              setCount={props.setCountNotification}
                              icon={iconNotifications}
                              iconHover={iconNotificationsHover}
                              text={"уведомления"} />
            </div>
        </div>
    </div>)
}