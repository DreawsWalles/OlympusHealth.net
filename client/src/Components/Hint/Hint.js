import classes from "./Hint.module.css";
import type {AttributeHint} from "./AttributeHint";

export default function Hint(props: AttributeHint){
    return(
        <span style={{width: `${props.attributes.width}px`, marginLeft: `${props.attributes.marginLeft}px`}} className={`${classes.tip} ${classes.tooltip}`}>
            {props.attributes.text}
        </span>)
}