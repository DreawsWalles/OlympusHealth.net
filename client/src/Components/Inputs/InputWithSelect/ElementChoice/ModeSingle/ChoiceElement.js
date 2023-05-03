import {IChoiceElementProps} from "./IChoiceElementProps";
import classes from "./ChoiceElement.module.css";

export function ChoiceElement(props: IChoiceElementProps){
    return(
        <div style={{width: '100%', height: `${props.height}px`}}
            className={classes.content}
             onClick={() => {props.onClick(props.text)}}>
            <span style={{fontSize: props.fontSize === null ? '' : `${props.fontSize}px`}}
                  className={classes.text}>
                {props.text}
            </span>
        </div>
    )
}