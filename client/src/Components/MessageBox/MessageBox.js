import classes from "./MessageBox.module.css";
import ButtonCross from "../Buttons/ButtonCross/ButtonCrossBlackVersion/ButtonCross";
import ButtonOk from "../Buttons/ButtonsDialog/ButtonOk/ButtonOk";
import {useEffect, useState} from "react";
import ButtonAccept from "../Buttons/ButtonsDialog/ButtonAccept/ButtonAccept";
import ButtonCancel from "../Buttons/ButtonsDialog/ButtonCancel/ButtonCancel";
export default function MessageBox(props){
    const [result, setResult] = useState("disable");
    function clickOnAccept(){
        props.onHide();
        if(props.isNeedConfirm) {
            props.onShowConfirm();
        }
    }
    function clickOnCancel(){
        props.onHide();
    }
    switch (props.buttons)
    {
        case "Ok":
            return (
                <div id={"message-box"} className={`${classes.content}`}>
                    <div className={`row`}>
                        <div className={`col ${classes.positionBtnTitle} ${classes.title}`}>
                            {props.title}
                        </div>
                        <div className={`col ${classes.positionBtnCross}`}>
                            <ButtonCross btnCrossActive={"active"} toolText={"Закрыть"} attribute={classes.attribute} attributeHint={classes.attributeHintCross}
                                         onClick={clickOnCancel}/>
                        </div>
                    </div>
                    <div className={`row ${classes.text} ${classes.positionText}`}>
                        {props.text}
                    </div>
                    <div className={`row ${classes.btn} ${classes.positionBtn}`}>
                       <ButtonOk setResult={setResult}/>
                    </div>
                </div>)
        case "YesNo":
            return (
                <div id={"message-box"} className={`${classes.content}`}>
                    <div className={`row`}>
                        <div className={`col ${classes.positionBtnTitle} ${classes.title}`}>
                            {props.title}
                        </div>
                        <div className={`col ${classes.positionBtnCross}`}>
                            <ButtonCross btnCrossActive={"active"} toolText={"Закрыть"} attribute={classes.attribute} attributeHint={classes.attributeHintCross}
                                         onClick={clickOnCancel}/>
                        </div>
                    </div>
                    <div className={`row ${classes.text} ${classes.positionText}`}>
                        {props.text}
                    </div>
                    <div className={`row ${classes.positionBtn}`}>
                        <div className={`col-5 ${classes.btnOne}`}>
                            <ButtonAccept onClick={clickOnAccept} text={"Подтвердить"}/>
                        </div>
                        <div className={`col-2`}></div>
                        <div className={`col-5 ${classes.btnTwo}`}>
                            <ButtonCancel onClick={clickOnCancel} text={"Отменить"}/>
                        </div>
                    </div>
                </div>
            )
    }

}