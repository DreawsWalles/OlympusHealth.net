import classes from "./ButtonGlobal.module.css";
import {useState} from "react";
export default function ButtonGlobal(props){
    switch (props.type)
    {
        case "usually":
            return(
                <div onClick={props.onClick} className={`${classes.content} ${classes.colorWhite}`}>
                    <div className={classes.text}>{props.text}</div>
                </div>
            )
    }

}