import classes from "./ButtonPersonalArea.module.css";
import iconNotSelect from "../../../Images/Icons/PersonalArea/iconPersonalArea.svg"
import iconSelect from "../../../Images/Icons/PersonalArea/iconPersonalAreaHover.svg";
import {useEffect, useState} from "react";
import type {IButtonPersonalAreaProps} from "./IButtonPersonalAreaProps";
export default function ButtonPersonalArea(props : IButtonPersonalAreaProps){
    const [icon, setIcon] = useState();
    const [fill, setFill] = useState();
    useEffect(() =>{
        (()=> {
            setIcon(props.state === "Select" ? iconSelect : iconNotSelect);
            setFill(props.state === "Select" ? classes.text_select : "");
        })()
    }, []);
    useEffect(() =>{
        (()=> {
            setIcon(props.state === "Select" ? iconSelect : iconNotSelect);
            setFill(props.state === "Select" ? classes.text_select : "");
        })()
    }, [props.state]);
    return(
        <button className={`row ${classes.content}`} onClick={props.onClick}>
            <div className={`col-3 ${classes.icon}`}>
                <img src={icon}/>
            </div>
            <div className={`col-9 ${classes.text} ${fill}`}>
                <div>Мой профиль</div>
            </div>
        </button>
    )
}