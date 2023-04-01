import {useState} from "react";
import classes from "./ButtonActive.module.css"
import classesTip from "../../Hint/Hint.module.css"
import Hint from "../../Hint/Hint";
export default function ButtonActive(props){
    const [icon, setIcon] = useState(props.icon);
    function mouseEnter(){
        setIcon(props.iconHover)
    }
    function mouseLeave(){
        setIcon(props.icon)
    }
    return(
        <div onMouseEnter={mouseEnter} onMouseLeave={mouseLeave} className={`${classes.content} ${classesTip.tooltip}`}>
            <img className={`${props.attribute} ${classes.icon}` } src={icon}/>
            <Hint text={props.toolText} attribute={props.attributeHint}/>
        </div>);
}