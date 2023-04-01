import classes from "./ActionNotification.module.css";
import iconFail from "../../../Images/Icons/IconResult/iconFail.png";
import iconSuccess from "../../../Images/Icons/IconResult/iconSuccess.svg";
import ButtonCross from "../../Buttons/ButtonCross/ButtonCrossWhiteVersion/ButtonCross";
import {useEffect, useState} from "react";
export default function ActionNotification(props){
    const [title, setTitle] = useState("");
    const [classColor, setClassColor] = useState();
    const [icon, setIcon] = useState();
    useEffect(() => {
        (()=> {
           switch (props.type)
           {
               case "success":
                   setTitle("Успешно");
                   setClassColor(classes.success)
                   setIcon(iconSuccess);
                   break;
               case "fail":
                   setTitle("Ошибка")
                   setClassColor(classes.error);
                   setIcon(iconFail)
                   break;
           }
        })()
    }, [])
    useEffect(() => {
        (() => {
            switch (props.type)
            {
                case "success":
                    setTitle("Успешно");
                    setClassColor(classes.success)
                    setIcon(iconSuccess);
                    break;
                case "fail":
                    setTitle("Ошибка")
                    setClassColor(classes.error);
                    setIcon(iconFail)
                    break;
            }
        })()
    }, [props.type])
    function onMouseHover(e){
        let el = document.getElementById("notification");
        if(!el.classList.contains(classes.none)) {
            el.classList.remove(classes.hide);
            el.classList.remove(classes.show);
            el.classList.add(classes.fastShow);
        }
    }
    function onMouseLeave(){
        let el = document.getElementById("notification");
        if(!el.classList.contains(classes.none)) {
            el.classList.remove(classes.fastShow);
            el.classList.add(classes.hide);
        }
    }
    function animationEnd(e){
        let el = document.getElementById("notification");
        if(el.classList.contains(classes.show) && e.animationName === classes.hide){
            el.classList.add(classes.none);
            el.classList.remove(classes.show);
            el.classList.remove(classes.hide);
            return;
        }
        if(el.classList.contains(classes.hide) && (!el.classList.contains(classes.show) || el.classList.contains(classes.fastShow))) {
            el.classList.add(classes.none);
            el.classList.remove(classes.hide);
        }
    }
    function onClose(){
        let el = document.getElementById("notification");
        el.classList.add(classes.none);
        if(el.classList.contains(classes.hide)){
            el.classList.remove(classes.hide);
        }
        if(el.classList.contains(classes.show)){
            el.classList.remove(classes.show);
        }
        if(el.classList.contains(classes.fastShow)){
            el.classList.remove(classes.fastShow);
        }
    }
    return(
        <div id={"notification"} onMouseEnter={onMouseHover} onMouseLeave={onMouseLeave} onAnimationEnd={animationEnd}
                                                                        className={`row ${classes.content} ${classColor} 
                                                                        ${classes.show} ${classes.hide}`}>
            <div className={`col-2 ${classes.icon}`}>
                <img src={icon}/>
            </div>
            <div className={`col-9 ${classes.text}`}>
                <div className={`${classes.text} `}>
                    <div className={`row ${classes.title}`}>
                        {title}
                    </div>
                    <div className={`row ${classes.message}`}>
                        {props.text}
                    </div>
                </div>
            </div>
            <div className={`col-1 ${classes.btnCross}`}>
                <ButtonCross isActive={"active"} toolText={"Закрыть"}
                             attributeHint={classes.attributeHintCross} attribute={classes.attributeCross}
                             classNone={props.blurNone} isNeedBlur={false} onClick={onClose}/>
            </div>
        </div>)
}