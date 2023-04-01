import classes from "./Hint.module.css";
export default function Hint(props){
    return(<span className={`${props.attribute} ${classes.tip}`}>{props.text}</span>)
}