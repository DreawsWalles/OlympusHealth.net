import classes from "./CustomCheckbox.module.css";
export default function CustomCheckbox(props){
    return(
        <div className={`${classes.content} ${props.size}`}>
            <input onChange={props.onClick} id={`${props.id}`} type="checkbox" className={`${classes.checkbox}`} value="yes" />
            <label htmlFor={`${props.id}`}></label>
        </div>
    )
}