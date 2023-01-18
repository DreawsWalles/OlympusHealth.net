import classes from "./ButtonFolding.module.css"
import {useState} from "react";

export default function ButtonFolding(props){
    const [icon, setIcon] = useState(props.iconFolding);
    const [isMenuOpen, setIsMenuOpen] = useState(false);
    function click(){
        let menu = document.getElementById(props.classNameMenu);
        let arrow = document.getElementById(classes.icon);
        if(!isMenuOpen){
            menu.classList.add(props.classNameNavOpen);
            setIsMenuOpen(true);
            setIcon(props.iconUnFolding);
            arrow.classList.remove(classes.up);
            arrow.classList.add(classes.down);
        }else{
            menu.classList.remove(props.classNameNavOpen);
            setIsMenuOpen(false);
            setIcon(props.iconFolding);
            arrow.classList.remove(classes.down);
            arrow.classList.add(classes.up);
        }
    }
    return(
        <div className={`${classes.component}`}>
            <div  className={`${classes.icon}`}>
                <img id={classes.icon} className={`${classes.up}`} onClick={click} src={icon}/>
            </div>
            <div className={"row"}>
                <span>{props.text}</span>
            </div>
        </div>
    )
}