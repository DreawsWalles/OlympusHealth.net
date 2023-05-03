import classes from "./Checkbox.module.css";
import type {ICheckBoxProps} from "./ICheckBoxProps";
export default function Checkbox(props : ICheckBoxProps){
    const onClick = (e) => {
        let input = document.getElementById(props.id);
        props.onClick(input);
    }
    return(
        <div style={{fontSize: props.size === "auto" ? "auto" : `${props.size}px`}}
             className={`${classes.content}`}>
            <input id={`${props.id}`} type="checkbox" className={`${classes.checkbox}`} value="yes" />
            <label onClick={onClick} htmlFor={`${props.id}-label-checkbox`}></label>
        </div>
    )
}