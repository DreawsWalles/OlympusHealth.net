import classes from "./ButtonClose.module.css";
import icon from "../../../../Images/Icons/IconCross/WhiteVersion/CrossActive.svg"
export default function ButtonClose(props){
    function onClick(){
        props.onClick();
    }
    return(
        <div onClick={onClick} className={classes.content}>
            <img src={icon}/>
        </div>)
}