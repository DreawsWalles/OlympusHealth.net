import classes from "./ButtonAccept.module.css";
import classesTip from "../Hint/Hint.module.css";
import {useEffect, useState} from "react";
import iconFail from "../../Images/Icons/IconAccept/iconFail.svg";
import Hint from "../Hint/Hint";
export default function ButtonAccept(props){
    const [icon, setIcon] = useState();
    const [hint, setHint] = useState();
    useEffect(() => {
        (() =>{
            setIcon(props.isAccept ? null : iconFail);
            setHint(props.isAccept ? null : <Hint text={"Нажмите, для подтверждения пользователя"} attribute={classes.attributeHint}/>)
        })()
    }, []);
    useEffect(() => {
        (() =>{
            setIcon(props.isAccept ? null : iconFail);
            setHint(props.isAccept ? null : <Hint text={"Нажмите, для подтверждения пользователя"} attribute={classes.attributeHint}/>)
        })()
    }, [props.isAccept])
    return(
        <div className={`${classes.content} ${classesTip.tooltip}`}>
            <img onClick={props.onClick} src={icon}/>
            {hint}
        </div>
    )
}