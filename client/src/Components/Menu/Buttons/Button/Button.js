import classes from "./Button.module.css";
import {useEffect, useState} from "react";
import type {IButtonProps} from "./IButtonProps";

export default function Button(props:IButtonProps){
    const [icon, setIcon] = useState(props.Icon);

    useEffect(() => {
        (() => {
            if(props.State === "Select"){
                setIcon(props.HoverIcon);
            }
            else{
                setIcon(props.Icon);
            }
        })();
    }, [props.State]);
    function hoverEffect(){
        if(props.State !== "Select") {
            setIcon(props.HoverIcon)
        }
    }
    function leaveEffect(){
        if(props.State !== "Select") {
            setIcon(props.Icon);
        }
    }
    return(
        <button className={`${classes.component}`}>
            <div className={"row"}>
                <img onClick={props.onClick} onMouseEnter={hoverEffect} onMouseLeave={leaveEffect} src={icon}/>
            </div>
            <div style={{marginTop: `${props.MarginTopText}px`}} className={`row`}>
                <span onClick={props.onClick} onMouseEnter={hoverEffect} onMouseLeave={leaveEffect}>{props.Text}</span>
            </div>
        </button>
    )
}