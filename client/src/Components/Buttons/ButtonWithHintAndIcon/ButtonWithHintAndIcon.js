import type {IButtonWithHintAndIconProps} from "./IButtonWithHintAndIconProps";
import classes from "./ButtonWithHintAndIcon.module.css";
import classesHint from "../../Hint/Hint.module.css";
import {useEffect, useState} from "react";
import Hint from "../../Hint/Hint";

export default function ButtonWithHintAndIcon(props:IButtonWithHintAndIconProps){
    const [icon: string, setIcon] = useState(props.iconEnable);
    const [hint, setHint] = useState(props.isNeedHint ? <Hint attributes={props.attributeHint} /> : null)
    const [size: string, setSize] = useState();
    const [theme: string, setTheme] = useState()
    const [color: string, setColor] = useState();
    function onMouseLeave(){
        if(props.status === "Active") {
            setIcon(props.iconEnable)
        }
    }
    function onMouseEnter(e){
        if(props.status === "Active") {
            setIcon(props.iconHover);
        }
    }
    useEffect(() => {
        (() => {
            switch (props.size)
            {
                case "xs":
                    setSize(classes.xs);
                    break;
                case "s":
                    setSize(classes.s);
                    break;
                case "m":
                    setSize(classes.m);
                    break;
                case "L":
                    setSize(classes.L);
                    break;
                case "XL":
                    setSize(classes.XL);
                    break;
            }
            switch (props.theme)
            {
                case "Circle":
                    setTheme(classes.circle);
                    break;
                case "Square":
                    setTheme(classes.square);
                    break;
            }
            switch (props.color)
            {
                case "Red":
                    setColor(classes.red);
            }
        })()
    }, [classes])
    return(
        <button id={props.id} onClick={props.onClick}
                onMouseLeave={onMouseLeave}
                onMouseEnter={onMouseEnter}
                className={`${classes.content} ${classesHint.tooltip} ${size} ${theme} ${color}`}>
            <img style={{width: `${props.attributeIcon.width}px`,
                        height: props.attributeIcon.height === "auto" ? `auto` : `${props.attributeIcon.height}px`,
                        marginLeft: `${props.attributeIcon.marginLeft}px`,
                        marginRight: `${props.attributeIcon.marginRight}px`}}
                 src={props.status === "Active" ? icon : props.iconDisable} className={`${classes.icon}`} alt={""}/>
            {props.isNeedHint ? <Hint attributes={props.attributeHint} /> : null}
        </button>
    )
}