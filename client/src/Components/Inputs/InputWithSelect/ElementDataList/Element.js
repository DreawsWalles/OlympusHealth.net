import {IElementProps} from "./IElementProps";
import classesElement from "./ElementSelect.module.css";

export function Element(props: IElementProps){
    return(
        <div
            style={{fontSize: props.fontSize !== null ? `${props.fontSize}px` : ""}}
            id={props.id}
            className={`${classesElement.element} ${classesElement.open}`}>
            {props.value}
        </div>
    )
}