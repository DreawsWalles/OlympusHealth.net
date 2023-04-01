import classes from "./ButtonIconMenu.module.css";
import {useEffect, useState} from "react";

export default function ButtonIconMenu(props){
    const [icon, setIcon] = useState(props.icon);

    useEffect(() => {
        (() => {
            if(props.isChoice){
                setIcon(props.iconHover);
            }
            else{
                setIcon(props.icon);
            }
        })();
    }, [props.isChoice]);
    function hoverEffect(){
        if(!props.isChoice) {
            setIcon(props.iconHover)
        }
    }
    function leaveEffect(){
        if(!props.isChoice) {
            setIcon(props.icon);
        }
    }
    return(
        <div className={`${classes.component}`}>
            <div className={"row"}>
                <img onMouseEnter={hoverEffect} onMouseLeave={leaveEffect} src={icon}/>
            </div>
            <div className={`row ${props.positionText}`}>
                <span>{props.text}</span>
            </div>
        </div>
    )
}