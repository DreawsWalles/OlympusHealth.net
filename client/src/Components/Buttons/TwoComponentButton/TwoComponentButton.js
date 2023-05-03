import type {ITwoComponentButtonProps} from "./ITwoComponentButtonProps";
import {useEffect, useState} from "react";
import classes from "./TwoComponentButton.module.css";
export function TwoComponentButton(props: ITwoComponentButtonProps){
    const [size, setSize] = useState();
    const [theme, setTheme] = useState();
    useEffect(() =>
    {
        (() => {
            switch (props.size)
            {
                case "m":
                    setSize(classes.m);
                    break;
                case "L":
                    setSize(classes.L);
                    break;
            }
            switch (props.theme)
            {
                case "Red":
                    setTheme(classes.Red);
                    break;
            }
        })()
    }, [classes])
    return(
        <button onClick={props.onClick} className={`${classes.content} ${size} ${theme}`}>
            <div className={`col-10 ${classes.element} ${classes.flex_start}`}>
                {props.text}
            </div>
            <div className={`col-2 ${classes.element} ${classes.flex_end}`}>
                <img src={props.icon}/>
            </div>
        </button>
    )
}