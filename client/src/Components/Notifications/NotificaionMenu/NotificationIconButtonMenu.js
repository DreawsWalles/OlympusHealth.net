import classes from "./NotificationIconButtonMenu.module.css";
import {useEffect, useState} from "react";
import {GetCount} from "../../../Swapi/SwapiNotification";
import {useCookies} from "react-cookie";


export default function ButtonMenu(props){
    const [icon, setIcon] = useState(props.icon);
    const [cookie, setCookie] = useCookies("user");
    function hoverEffect(){
        setIcon(props.iconHover)
        document.getElementById(classes.countNotification).classList.add(classes.shadow);
    }
    function leaveEffect(){
        setIcon(props.icon);
        document.getElementById(classes.countNotification).classList.remove(classes.shadow);
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
    setTimeout(countNotification, 1000);
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
                <div className={"row"}>
                    <span>{props.text}</span>
                </div>
                <div id={classes.countNotification} className={`row ${classes.countNotification}`}>
                    <div>{props.count}</div>
                </div>
            </div>)
    }
}