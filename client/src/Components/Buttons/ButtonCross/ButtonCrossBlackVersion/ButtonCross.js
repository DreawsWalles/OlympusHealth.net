import classes from "./ButtonCross.module.css";
import classesTip from "../../Hint/Hint.module.css";
import iconUnable from "../../../Images/Icons/IconCross/CrossUnable.svg";
import iconActive from "../../../Images/Icons/IconCross/CrossActive.svg";
import iconHover from "../../../Images/Icons/IconCross/CrossHover.png";
import {useEffect, useState} from "react";
import Hint from "../../Hint/Hint";
export default function ButtonCross(props){
    const [icon, setIcon] = useState(iconActive);
    function mouseEnter(){
        setIcon(iconHover);
    }
    function mouseLeave(){
        setIcon(iconActive);
    }
    function onClick(){
        if(props.isNeedBlur) {
            props.onClick();
            props.setStateMsgBox("active");
        }
        else{
            props.setStateMsgBox("disabled");
        }
    }
    useEffect(() =>{
        (() => {

        })()
    }, []);
    if(props.isActive === "unable"){
        return (
            <div id={props.id} className={`${classes.content}`}>
                <img className={`${props.attribute} ${classes.icon}` } src={iconUnable}/>
            </div>
        )
    }else{
        return (
            <div onMouseEnter={mouseEnter} onMouseLeave={mouseLeave}  className={`${classes.content} ${classesTip.tooltip}`}>
                <img onClick={onClick} className={`${props.attribute} ${classes.icon} 
                     ${classes.iconActive}`} src={icon}/>
                <Hint text={props.toolText} attribute={props.attributeHint}/>
            </div>
        )
    }
}