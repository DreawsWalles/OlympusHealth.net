import type {IInputProps} from "./IInputProps";
import classes from "./Input.module.css";
import {Hint} from "../Functions";
import {ToggleSwitch} from "../../ToggleSwitch/ToggleSwitch";
import {useEffect} from "react";
export function Input(props: IInputProps){
    function onChange(e){
        props.setValue(e.target.value);
        Hint(props.errorAttribute.id, "")
    }
    function clickOnSwitch(e){
        debugger
        if(e.target.checked) {
            let element = document.getElementById(props.id);
            element.type = "text";
        }
        else{
            let element = document.getElementById(props.id);
            element.type = "password";
        }
    }
    return(
        <div className={classes.formGroup}>
            {props.labelAttribute !== null &&
                <label className={classes.labelTitle}>{props.labelAttribute.text}</label>}
            <input id={props.id}
                   onChange={onChange}
                   type={props.type}
                   className={`form-control ${classes.textInput}`}
                   placeholder={props.placeholder}
            />
            {props.toggleSwitchAttribute !== null &&
                <ToggleSwitch id={`switch-${props.id}`}
                              onChange={(e) => {clickOnSwitch(e)}}
                              text={props.toggleSwitchAttribute.text}
                              marginTop={5}/> }
            {props.errorAttribute !== null &&
                <span className={classes.errorInput} id={props.errorAttribute.id}>{props.errorAttribute.text}</span>
            }
        </div>
    )
}