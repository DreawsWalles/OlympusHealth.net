import classes from "./MessageBox.module.css";
import Button from "../Buttons/Button/Button";
import ButtonWithHintAndIcon from "../Buttons/ButtonWithHintAndIcon/ButtonWithHintAndIcon";
import iconActive from "../../Images/Icons/IconCross/BlackVersion/CrossActive.svg";
import iconHover from "../../Images/Icons/IconCross/BlackVersion/CrossHover.png";
import {AttributeIcon} from "../Buttons/ButtonWithHintAndIcon/IButtonWithHintAndIconProps";
import {AttributeHint} from "../Hint/AttributeHint";
import type {IMessageBoxProps} from "./IMessageBoxProps";

const ids = {
    btnCross: "btnCross-MessageBox",
    btnAccept: "btn-accept-messageBox",
    btnCancel: "btn-cancel-messageBox"
}
export default function MessageBox(props: IMessageBoxProps){
    function clickOnAccept(){
        debugger
        props.actions.onHide();
        if(props.actionConfirm !== null){
            props.actionConfirm.onShow();
        }
    }
    function clickOnCancel(){
        debugger
        props.actions.onHide();
    }
    switch (props.buttons)
    {
        case "Ok":
            return (
                <div id={props.id} className={`${classes.content}`}>
                    <div className={`row`}>
                        <div className={`col ${classes.positionBtnTitle} ${classes.title}`}>
                            {props.title}
                        </div>
                        <div className={`col ${classes.positionBtnCross}`}>
                            <ButtonWithHintAndIcon id={ids.btnCross}
                                                   width={15}
                                                   iconEnable={iconActive}
                                                   iconHover={iconHover}
                                                   attributeIcon={new AttributeIcon(19, "auto")}
                                                   status={"Active"}
                                                   isNeedHint={true}
                                                   attributeHint={new AttributeHint(65, -32, "Закрыть")}
                                                   onClick={() => {clickOnCancel()}} />
                        </div>
                    </div>
                    <div className={`row ${classes.text} ${classes.positionText}`}>
                        {props.text}
                    </div>
                    <div className={`row ${classes.btn} ${classes.positionBtn}`}>
                        <Button id={ids.btnAccept}
                                size={"s"}
                                text={"Ок"}
                                theme={"White"}
                                isDisplay={true}
                                onClick={() => {}}/>
                    </div>
                </div>)
        case "YesNo":
            return (
                <div id={props.id} className={`${classes.content}`}>
                    <div className={`row`}>
                        <div className={`col ${classes.positionBtnTitle} ${classes.title}`}>
                            {props.title}
                        </div>
                        <div className={`col ${classes.positionBtnCross}`}>
                            <ButtonWithHintAndIcon id={ids.btnCross}
                                                   width={15}
                                                   iconEnable={iconActive}
                                                   iconHover={iconHover}
                                                   attributeIcon={new AttributeIcon(19, "auto")}
                                                   status={"Active"}
                                                   isNeedHint={true}
                                                   attributeHint={new AttributeHint(65, -32, "Закрыть")}
                                                   onClick={() => {clickOnCancel()}} />
                        </div>
                    </div>
                    <div className={`row ${classes.text} ${classes.positionText}`}>
                        {props.text}
                    </div>
                    <div className={`row ${classes.positionBtn}`}>
                        <div className={`col-5 ${classes.btnOne}`}>
                            <Button id={ids.btnAccept}
                                    size={"s"}
                                    text={"Подтвердить"}
                                    theme={"Success"}
                                    isDisplay={true}
                                    onClick={() => {clickOnAccept()}} />
                        </div>
                        <div className={`col-2`}></div>
                        <div className={`col-5 ${classes.btnTwo}`}>
                            <Button id={ids.btnCancel}
                                    size={"s"}
                                    text={"Отменить"}
                                    theme={"Red"}
                                    isDisplay={true}
                                    onClick={() => {clickOnCancel()}}/>
                        </div>
                    </div>
                </div>
            )
    }

}