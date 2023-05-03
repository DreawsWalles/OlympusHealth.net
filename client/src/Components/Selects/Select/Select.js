import type {ItemProps, ISelectProps} from "./ISelectProps";
import classes from "./Select.module.css";
import classesElement from "./SelectElement.module.css";
import {Hint} from "../../Functions";
import {useEffect, useState} from "react";

function Element(props: ItemProps){
    return(
        <div id={props.id} onClick={props.onClick}
             className={`${classesElement.content}`}>
            <span id={props.id}
                  style={{fontSize: props.fontSize === null ? '' : `${props.fontSize}px`}}
                  className={`${classesElement.text}`}>
                {props.value}
            </span>
        </div>
    )
}
export default function Select(props: ISelectProps){
    const [isOpen, setIsOpen] = useState(false);
    const list =  props.list.map((element) => <Element value={element.value}
                                                                        id={element.id}
                                                                        onClick={(e) => {onSelect(e)}}
                                                                        fontSize={props.fontSize}/>);
    function onSelect(e){
        props.onChange(e.target.id);
        Hint(props.idError, "");
        let field = document.getElementById(`${props.id}-field`);
        field.innerText = e.target.innerText;
        setIsOpen(!isOpen);
    }
    useEffect(() => {
        (() => {
            let arrow = document.getElementById(`${props.id}-svg-arrow`);
            let list = document.getElementById(`${props.id}-list`);
            if(!isOpen) {
                let a = arrow.classList.item(1);
                arrow.classList.add(classes.rotate);
                arrow.classList.remove(classes.noRotate);
                list.classList.remove(classes.listOpen);
                list.classList.add(classes.listClose);
            }else {
                arrow.classList.remove(classes.rotate);
                arrow.classList.add(classes.noRotate);
                list.classList.remove(classes.listClose);
                list.classList.add(classes.listOpen);
            }
        })()
    },[isOpen])
    function onClick(){
        setIsOpen(!isOpen);
    }
    return(
        <div style={{fontSize: `12px`}} id={props.id} className={classes.content}>
            <div onClick={onClick} className={classes.select}>
                <div id={`${props.id}-field`}
                     style={{height: `${props.height}px`,
                         paddingRight: `${props.height * 0.3}px`,
                         paddingLeft: `${props.height * 0.3}px`,
                         justifyContent: props.alignment !== "center" ? ` flex-${props.alignment}` : props.alignment,
                         fontSize: props.fontSize === null ? '' : `${props.fontSize}px`}}
                     className={`col-11 ${classes.field}`}>
                    {props.title}
                </div>
                <div style={{width: `${props.height}px`}}
                     className={`col-1 ${classes.btn}`}>
                    <svg id={`${props.id}-svg-arrow`} className={`${classes.arrow} ${classes.rotate}`} width="31" height="17" viewBox="0 0 31 17" fill="none" xmlns="http://www.w3.org/2000/svg">
                        <path className={`${classes.icon}`} d="M3.6425 0L15.5 10.5074L27.3575 0L31 3.23482L15.5 17L0 3.23482L3.6425 0Z" fill="#A72036"/>
                    </svg>
                </div>
            </div>
            {props.idError !== null &&
                <span id={props.idError} className={classes.error}></span>}
            <div id={`${props.id}-list`} style={{top: `${props.height + 10}px`}}
                 className={`${classes.list} ${classes.listClose}`}>
                {list}
            </div>
        </div>
    )
}