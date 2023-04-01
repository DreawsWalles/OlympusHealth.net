import classes from "./ButtonFastAction.module.css"
export default function ButtonFastAction(props){
    return (
        <div onClick={props.onClick} className={classes.content}>
                <div className={`col-10 ${classes.element} ${classes.flex_start}`}>{props.text}</div>
                <div className={`col-2 ${classes.element} ${classes.flex_end}`}>
                    <img src={props.icon}/>
                </div>
        </div>
    )
}