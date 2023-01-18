import classes from "./ButtonFastAction.module.css"
export default function ButtonFastAction(props){
    return (
        <div className={classes.content}>
            <div className={`row`}>
                <div className={`col`}>{props.text}</div>
                <div className={`col`}>
                    <img src={props.icon}/>
                </div>
            </div>
        </div>
    )
}