import classes from "./SubScreen.module.css";
import ButtonClose from "../Buttons/ButtonClose/ButtonClose";
import ButtonGoBack from "../Buttons/ButtonGoBack/ButtonGoBack";
import ButtonGoUp from "../Buttons/ButtonsGoUp/ButtonGoUp";
import {useEffect, useState} from "react";
import Scrollbar from "react-scrollbars-custom";

export default function SubScreen(props){
    const [btnClose, setBtnClose] = useState();
    const [btnGoBack, setBtnGoBack] = useState();
    const [btnGoUp, setBtnGoUp] = useState();
    useEffect(() =>
    {
        (() =>{
            if(props.parameters.canBack){
                setBtnGoBack(<ButtonGoBack />);
            }
            setBtnClose(<ButtonClose onClick={props.parameters.functions.Close}/>);
            setBtnGoUp(<ButtonGoUp onClick={scrollToTop} none={classes.none}/>);
            let scrollsThumb = document.getElementsByClassName("ScrollbarsCustom-Thumb");
            let scrollsTrack = document.getElementsByClassName("ScrollbarsCustom-Track");
            for(let i = 0; i < 2; i++){
                scrollsThumb[i].classList.add(classes.scrollThumb);
                scrollsTrack[i].classList.add(classes.scrollTrack);
            }
        })()
    }, []);
    useEffect(() =>
    {
        (() =>{
            if(props.parameters.canBack){
                setBtnGoBack(<ButtonGoBack />);
            }
            setBtnClose(<ButtonClose onClick={props.parameters.functions.Close}/>);
            setBtnGoUp(<ButtonGoUp onClick={scrollToTop} none={classes.none}/>);
        })()
    }, [props.parameters.functions.canBack]);

    function scrollToTop(){
        let element = document.getElementsByClassName("ScrollbarsCustom-Scroller")[0];
        element.scrollTo({
            top: 0,
            behavior : 'smooth'
        });
    }
    function onScroll(e){
        let btn = document.getElementById("btnGoUp");
        if(e.scrollTop > 50){
            btn.classList.remove(classes.none);
            btn.classList.add(classes.showGoUpOn);
            btn.classList.remove(classes.showGoUpOff);
        }else {
            btn.classList.remove(classes.showGoUpOn);
            btn.classList.add(classes.showGoUpOff)
        }
    }
    return(
        <div className={`${classes.subScreen}`}>
            <div className={`${classes.buttons_close}`}>
                {btnClose}
            </div>
            <div className={`${classes.buttons_GoBack}`}>
                {btnGoBack}
            </div>
            <div className={`${classes.buttons_GoUp}`}>
                {btnGoUp}
            </div>
            <Scrollbar id={"scroll-content"} onScroll={onScroll} className={classes.content} style={{ width: 250, height: 250 }}>

            </Scrollbar>
        </div>
    )
}