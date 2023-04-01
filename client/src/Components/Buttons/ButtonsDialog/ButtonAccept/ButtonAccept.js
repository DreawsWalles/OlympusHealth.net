import classes from "./ButtonAccept.module.css";
import ButtonGlobal from "../ButtonGlobal/ButtonGlobal";

export default function ButtonAccept(props){
    return(
        <div className={classes.content}>
            <ButtonGlobal onClick={props.onClick} text={props.text} type={"accept"} size={classes.size}/>
        </div>
    )
}