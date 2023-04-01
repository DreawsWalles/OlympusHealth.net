import classes from "./ButtonFastAction.module.css"
export default function ButtonFastAction(props){
    return (
        <div className={classes.content}>
                <div className={`col-11 ${classes.element} ${classes.flex_start}`}>{props.text}</div>
                <div className={`col-1 ${classes.element} ${classes.flex_end}`}>
                    <img src={props.icon}/>
                </div>
        </div>
    )
}