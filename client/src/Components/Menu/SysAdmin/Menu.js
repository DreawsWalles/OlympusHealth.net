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
import Button from "../Buttons/Button/Button";
import ButtonFoldingMenu from "../Buttons/ButtonFoldingMenu/ButtonFoldingMenu";
import {useEffect, useState} from "react";
import MainScreen from "../../../Screens/SysAdmin/Users/MainScreen/MainScreen";
import {ButtonNotificationMenu} from "../Buttons/ButtonNotificationMenu/ButtonNotificationMenu";
import {GetCount} from "../../../Swapi/SwapiNotification";
import type {IMenuProps} from "./IMenuProps";
export default function Menu(props: IMenuProps){
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
        props.setContent(<MainScreen id={props.idContent}
                                     changeIsLoaded={props.setIsLoaded}
                                     countNotification={countNotification}
                                     actionConfirm={props.actionConfirm}
                                     actionMessageBox={props.actionMessageBox}
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
        debugger
        props.setContent(<div>А вот тут уведомления</div>)
        props.setChoice(4);
    }
    return(
        <div id={classes.content} className={classes.content}>
            <div className={`${classes.menu}`}>
                <div className={`${classes.icon_margin}`}>
                    <Button Icon={iconPerson}
                            HoverIcon={iconPersonHover}
                            State={isChoicePerson ? "Select" : "NotSelect"}
                            Text={"пользователи"} onClick={() => {clickOnPerson() }}/>
                </div>
                <div className={`${classes.icon_margin}`}>
                    <Button Icon={iconResearch}
                            HoverIcon={iconResearchHover}
                            Text={"исследования"}
                            State={isChoiceResearch ? "Select" : "NotSelect"}
                            MarginTopText={6}
                            onClick={() => {clickOnResearch(); }} />
                </div>
                <div className={"row"}>
                    <ButtonFoldingMenu IconFolding={iconArrowUp}
                                       IconUnFolding={iconArrowDown}
                                       classMenu={classes.content}
                                       classMenuOpen={classes.is_nav_open} />
                </div>
                <div className={`${classes.icon_margin}`}>
                    <Button Icon={iconInstitutions}
                            HoverIcon={iconInstitutionsHover}
                            Text={"учреждения"}
                            State={isChoiceInstitution ? "Select" : "NotSelect"}
                            MarginTopText={2}
                            onClick={() => {clickOnInstitution();}} />
                </div>
                <div className={`${classes.icon_margin} ${classes.margin_notification}`}>
                    <ButtonNotificationMenu Icon={iconNotifications}
                                            HoverIcon={iconNotificationsHover}
                                            State={isChoiceNotification ? "Select" : "NotSelect"}
                                            onClick={() => {clickOnNotification();}}
                                            value={countNotification}
                                            setValue={setCountNotification} getValue={GetCount}/>
                </div>
            </div>
        </div>
    )}