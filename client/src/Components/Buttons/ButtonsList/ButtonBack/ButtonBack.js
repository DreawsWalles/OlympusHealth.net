import icon from "../../../../Images/Icons/iconBack.svg";
import classes from "./ButtonBack.module.css";
export default function ButtonBack(props){
    return(
        <div onClick={props.onClick} id={props.id} className={`${classes.content} ${classes.non_active}`}>
            <img src={icon} />
        </div>)
}