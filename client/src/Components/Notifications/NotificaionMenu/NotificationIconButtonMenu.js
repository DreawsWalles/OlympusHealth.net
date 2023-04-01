import classes from "./NotificationIconButtonMenu.module.css";
import {useEffect, useMemo, useState} from "react";
import {GetCount} from "../../../Swapi/SwapiNotification";
import {useCookies} from "react-cookie";


export default function ButtonMenu(props){
    const [icon, setIcon] = useState(props.icon);
    const [cookie, setCookie] = useCookies("user");
    useEffect(() => {
        (() => {
            if(props.isChoice){
                setIcon(props.iconHover);
                document.getElementById(classes.countNotification).classList.add(classes.shadow);
            }
            else{
                setIcon(props.icon);
                let element = document.getElementById(classes.countNotification);
                if(element !== null && element.classList.contains(classes.shadow)){
                    element.classList.remove(classes.shadow);
                }
            }
        })();
    }, [props.isChoice]);
    function hoverEffect(){
        if(!props.isChoice) {
            setIcon(props.iconHover)
            document.getElementById(classes.countNotification).classList.add(classes.shadow);
        }
    }
    function leaveEffect(){
        if(!props.isChoice) {
            setIcon(props.icon);
            document.getElementById(classes.countNotification).classList.remove(classes.shadow);
        }
    }

    useEffect(() => {
        (async () => {
            await countNotification();
        })();
    }, []);
    async function countNotification(){
        let tmp = await GetCount(cookie.user);
        props.setCount(tmp);
    }
    setInterval(() => {
        countNotification();
        console.log(props.count)
    }, 5000);

    if(props.count === 0){
    return(
        <div className={`${classes.component}`}>
            <div className={`row`}>
                <img onMouseEnter={hoverEffect} onMouseLeave={leaveEffect} src={icon}/>
            </div>
            <div className={"row"}>
                <span>{props.text}</span>
            </div>
        </div>)
    }else{
        return(
            <div className={`${classes.component}`}>
                <div className={`row`}>
                    <img onMouseEnter={hoverEffect} onMouseLeave={leaveEffect} src={icon}/>
                </div>
                <div className={`row ${props.positionText}`}>
                    <span>{props.text}</span>
                </div>
                <div id={classes.countNotification} className={`row ${classes.countNotification}`}>
                    <div >{props.count}</div>
                </div>
            </div>)
    }
}