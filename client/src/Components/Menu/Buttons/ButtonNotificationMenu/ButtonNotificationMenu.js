import type {IButtonNotificationMenuProps} from "./IButtonNotificationMenuProps";
import {useEffect, useState} from "react";
import {useCookies} from "react-cookie";
import classes from "./ButtonNotificationMenu.module.css";
import {GetCount} from "../../../../Swapi/SwapiNotification";

export function ButtonNotificationMenu(props: IButtonNotificationMenuProps){
    const [icon, setIcon] = useState(props.Icon);
    const [cookie, setCookie] = useCookies("user");
    useEffect(() => {
        (() => {
            let element = document.getElementById(classes.countNotification);
            if(props.State === "Select"){
                setIcon(props.HoverIcon);
                if(element === null){
                    return;
                }
                element.classList.add(classes.shadow);
            }
            else{
                setIcon(props.Icon);
                if(element !== null && element.classList.contains(classes.shadow)){
                    element.classList.remove(classes.shadow);
                }
            }
        })();
    }, [props.State]);
    function hoverEffect(){
        if(props.State === "NotSelect") {
            setIcon(props.HoverIcon)
            document.getElementById(classes.countNotification).classList.add(classes.shadow);
        }
    }
    function leaveEffect(){
        if(props.State === "NotSelect") {
            setIcon(props.Icon);
            document.getElementById(classes.countNotification).classList.remove(classes.shadow);
        }
    }

    useEffect(() => {
        (async () => {
            await countNotification();
        })();
    }, []);
    async function countNotification(){
        let tmp = await props.getValue(cookie.user);
        props.setValue(tmp);
    }
    setInterval(async () => {
        await countNotification();
        console.log(props.value)
    }, 5000);

    if(props.value === 0){
        return(
            <div className={`${classes.component}`}>
                <div className={`row`}>
                    <img onMouseEnter={hoverEffect} onMouseLeave={leaveEffect} src={icon}/>
                </div>
                <div className={"row"}>
                    <span>уведомления</span>
                </div>
            </div>)
    }else{
        return(
            <div className={`${classes.component}`}>
                <div className={`row`}>
                    <img onClick={props.onClick} onMouseEnter={hoverEffect} onMouseLeave={leaveEffect} src={icon}/>
                </div>
                <div className={`row ${classes.positionText}`}>
                    <span onClick={props.onClick} onMouseEnter={hoverEffect} onMouseLeave={leaveEffect}>уведомления</span>
                </div>
                <div id={classes.countNotification} className={`row ${classes.countNotification}`}>
                    <div >{props.value}</div>
                </div>
            </div>)
    }
}