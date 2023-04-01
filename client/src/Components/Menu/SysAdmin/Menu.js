import classes from "./Menu.module.css";
import iconPerson from "../../../Images/MenuIcons/Person/iconPerson.svg"
import iconPersonHover from "../../../Images/MenuIcons/Person/iconPersonHover.svg"
import iconResearch from "../../../Images/MenuIcons/Research/iconResearch.svg";
import iconResearchHover from "../../../Images/MenuIcons/Research/iconResearchHover.svg"
import iconInstitutions from "../../../Images/MenuIcons/Institutions/iconInstitutions.svg";
import iconInstitutionsHover from "../../../Images/MenuIcons/Institutions/iconInstitutionsHover.svg";
import iconNotifications from "../../../Images/MenuIcons/Notifications/iconNotifications.svg";
import iconNotificationsHover from "../../../Images/MenuIcons/Notifications/iconNotificationsHover.svg";
import iconArrowUp from "../../../Images/MenuIcons/Arrow/ArrowUp.svg";
import iconArrowDown from "../../../Images/MenuIcons/Arrow/ArrowDown.svg";
import ButtonIconMenu from "../../Buttons/ButtonMenu/ButtonIconMenu";
import NotificationMenu from "../../Notifications/NotificaionMenu/NotificationIconButtonMenu"
import ButtonFolding from "../../Buttons/ButtonFolding/ButtonFolding";
import {useEffect, useRef, useState} from "react";
import MainScreen from "../../../Screens/SysAdmin/Users/MainScreen/MainScreen";
export default function Menu(props){
    const [countNotification, setCountNotification] = useState(0);
    const [isChoicePerson, setIsChoicePerson] = useState(false);
    const [isChoiceResearch, setIsChoiceResearch] = useState(false);
    const [isChoiceInstitution, setIsChoiceInstitution] = useState(false);
    const [isChoiceNotification, setIsChoiceNotification] = useState(false);

    useEffect(() => {
        (()=> {
            switch (props.choice)
            {
                case 0:
                    break;
                case 1:
                    clickOnPerson();
                    break;
                case 2:
                    clickOnResearch();
                    break;
                case 3:
                    clickOnInstitution();
                    break;
                case 4:
                    clickOnNotification();
                    break;

            }
        })()
    }, [countNotification])
    useEffect(() => {
        (() => {
        switch (props.choice)
        {
            case 0:
                setIsChoicePerson(false);
                setIsChoiceNotification(false);
                setIsChoiceInstitution(false);
                setIsChoiceResearch(false);
                break;
            case 1:
                setIsChoicePerson(true);
                setIsChoiceNotification(false);
                setIsChoiceInstitution(false);
                setIsChoiceResearch(false);
                clickOnPerson();
                break;
            case 2:
                setIsChoiceResearch(true);
                setIsChoicePerson(false);
                setIsChoiceInstitution(false);
                setIsChoiceNotification(false);
                break;
            case 3:
                setIsChoiceInstitution(true);
                setIsChoicePerson(false);
                setIsChoiceNotification(false);
                setIsChoiceResearch(false);
                break;
            case 4:
                setIsChoiceNotification(true);
                setIsChoicePerson(false);
                setIsChoiceResearch(false);
                setIsChoiceInstitution(false);
                break;
        }
        })();
    }, [props.choice]);
    function clickOnPerson(){
        props.setContent(<MainScreen id={"mainContent"} setIsLoaded={props.setIsLoaded}
                                     count={countNotification}
                                     functionsConfirm={props.functionsConfirm}
                                     functionsMsgBox={props.functionsMsgBox}
                                     SubScreenParameters={props.SubScreenParameters}/>);
        props.setChoice(1);
    }
    function clickOnResearch(){
        props.setContent(<div>Это пиздец нахуй блять</div>);
        props.setChoice(2);
    }
    function clickOnInstitution(){
        props.setContent(<div>Вот тут учреждения</div>);
        props.setChoice(3);
    }
    function clickOnNotification(){
        props.setContent(<div>А вот тут уведомления</div>)
        props.setChoice(4);
    }
    return(<div id={classes.content} className={classes.content}>
        <div className={`${classes.menu}`}>
            <div onClick={clickOnPerson} className={`${classes.icon_margin}`}>
                <ButtonIconMenu icon={iconPerson} iconHover={iconPersonHover} text={"пользователи"} isChoice={isChoicePerson}/>
            </div>
            <div onClick={clickOnResearch} className={`${classes.icon_margin}`}>
                <ButtonIconMenu positionText={classes.position_Research_text} icon={iconResearch} iconHover={iconResearchHover} text={"исследования"} isChoice={isChoiceResearch}/>
            </div>
            <div className={"row"}>
                <ButtonFolding classNameMenu={classes.content} classNameNavOpen={classes.is_nav_open} iconFolding={iconArrowUp} iconUnFolding={iconArrowDown}/>
            </div>
            <div onClick={clickOnInstitution} className={`${classes.icon_margin}`}>
                <ButtonIconMenu positionText={classes.position_Institutions_text} icon={iconInstitutions} iconHover={iconInstitutionsHover} text={"учреждения"} isChoice={isChoiceInstitution}/>
            </div>
            <div onClick={clickOnNotification} className={`${classes.icon_margin} ${classes.margin_notification}`}>
                <NotificationMenu count={countNotification}
                                  setCount={setCountNotification}
                                  icon={iconNotifications}
                                  iconHover={iconNotificationsHover}
                                  text={"уведомления"}
                                  isChoice={isChoiceNotification} positionText={classes.position_Notifications_text}/>
            </div>
        </div>
    </div>)
}