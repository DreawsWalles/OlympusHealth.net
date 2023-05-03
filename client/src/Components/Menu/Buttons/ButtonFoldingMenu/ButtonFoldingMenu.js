import classes from "./ButtonFoldingMenu.module.css"
import {useState} from "react";
import type {IButtonFoldingMenuProps} from "./IButtonFoldingMenuProps";


export default function ButtonFoldingMenu(props: IButtonFoldingMenuProps){
    const [icon, setIcon] = useState(props.IconFolding);
    const [isMenuOpen, setIsMenuOpen] = useState(false);
    function click(){
        let menu = document.getElementById(props.classMenu);
        let arrow = document.getElementById(classes.icon);
        if(!isMenuOpen){
            menu.classList.add(props.classMenuOpen);
            setIsMenuOpen(true);
            setIcon(props.IconUnFolding);
            arrow.classList.remove(classes.up);
            arrow.classList.add(classes.down);
        }else{
            menu.classList.remove(props.classMenuOpen);
            setIsMenuOpen(false);
            setIcon(props.IconFolding);
            arrow.classList.remove(classes.down);
            arrow.classList.add(classes.up);
        }
    }
    return(
        <div className={`${classes.component}`}>
            <div  className={`${classes.icon}`}>
                <img id={classes.icon} className={`${classes.up}`} onClick={click} src={icon}/>
            </div>
        </div>
    )
}