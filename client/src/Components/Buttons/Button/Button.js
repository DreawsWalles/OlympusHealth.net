import type {IButtonProps} from "./IButtonProps";
import classes from "./Button.module.css";
import {useEffect, useState} from "react";
export default function Button(props : IButtonProps){
    const [size : string, setSize] = useState();
    const [theme: string, setTheme] = useState();
    const [display: string, setDisplay] = useState();
    useEffect(() =>{
        (()=>{
            switch (props.size){
                case "m":
                    setSize(classes.size_m);
                    break;
                case "s":
                    setSize(classes.size_s);
                    break;
                case "xs":
                    setSize(classes.size_xs);
                    break;
                case "L":
                    setSize(classes.size_L);
                    break;
                default:
                    throw new Error("Не корректный размер");
            }
            switch (props.theme)
            {
                case "Success":
                    setTheme("btn-success");
                    break;
                case "Success_outline":
                    setTheme("btn-outline-success");
                    break;
                case "White":
                    setTheme(classes.white);
                    break;
                case "Red":
                    setTheme(classes.red);
                    break;
                case "Grey":
                    setTheme(classes.grey);
                    break;
                case "Disable":
                    setTheme(classes.disable);
                    break;

                default:
                    throw new Error("Не корректная тема");
            }
            setDisplay(props.isDisplay ? "" : classes.none);
        })()
    }, [classes]);
    useEffect(() =>{
        (() => {
            switch (props.theme)
            {
                case "Success":
                    setTheme("btn-success");
                    break;
                case "Success_outline":
                    setTheme("btn-outline-success");
                    break;
                case "White":
                    setTheme(classes.white);
                    break;
                case "Red":
                    setTheme(classes.red);
                    break;
                case "Grey":
                    setTheme(classes.grey);
                    break;
                case "Disable":
                    setTheme(classes.disable);
                    break;
                default:
                    throw new Error("Не корректная тема");
            }
        })()
    }, [props.theme])
    return(
        <button id={props.id}
                onClick={props.onClick}
                className={`btn ${size} ${theme} ${classes.content} ${display}`}>
            {props.text}
        </button>
    );
}