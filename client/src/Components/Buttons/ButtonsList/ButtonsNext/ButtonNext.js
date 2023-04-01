import icon from "../../../../Images/Icons/iconNext.svg";
import classes from "./ButtonNext.module.css";
export default function ButtonNext(props){
    return(
        <div onClick={props.onClick} id={props.id} className={`${classes.content} ${classes.non_active}`}>
            <img src={icon} />
        </div>)
}