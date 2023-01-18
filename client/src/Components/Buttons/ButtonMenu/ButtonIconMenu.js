import classes from "./ButtonIconMenu.module.css";
import {useState} from "react";

export default function ButtonIconMenu(props){
    const [icon, setIcon] = useState(props.icon);

    function hoverEffect(){
        setIcon(props.iconHover)
    }
    function leaveEffect(){
        setIcon(props.icon);
    }
    return(
        <div className={`${classes.component}`}>
            <div className={"row"}>
                <img onMouseEnter={hoverEffect} onMouseLeave={leaveEffect} src={icon}/>
            </div>
            <div className={"row"}>
                <span>{props.text}</span>
            </div>
        </div>
    )
}