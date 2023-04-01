import classes from "./ButtonCancel.module.css";
import ButtonGlobal from "../ButtonGlobal/ButtonGlobal";

export default function ButtonCancel(props){
    return(
        <div className={classes.content}>
            <ButtonGlobal onClick={props.onClick} text={props.text} type={"cancel"} size={classes.size}/>
        </div>
    )
}