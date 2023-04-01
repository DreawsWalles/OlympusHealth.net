import classes from "./ButtonPersonalArea.module.css";
import iconNotSelect from "../../../Images/Icons/PersonalArea/iconPersonalArea.svg"
import iconSelect from "../../../Images/Icons/PersonalArea/iconPersonalAreaHover.svg";
import {useEffect, useState} from "react";
export default function ButtonPersonalArea(props){
    const [icon, setIcon] = useState();
    const [fill, setFill] = useState();
    useEffect(() =>{
        (()=> {
            setIcon(props.isSelect ? iconSelect : iconNotSelect);
            setFill(props.isSelect ? classes.text_select : "");
        })()
    }, []);
    useEffect(() =>{
        (()=> {
            setIcon(props.isSelect ? iconSelect : iconNotSelect);
            setFill(props.isSelect ? classes.text_select : "");
        })()
    }, [props.isSelect]);
    return(
        <div className={`row ${classes.content}`}>
            <div className={`col-3 ${classes.icon}`}>
                <img src={icon}/>
            </div>
            <div className={`col-9 ${classes.text} ${fill}`}>
                <div>Мой профиль</div>
            </div>
        </div>
    )
}