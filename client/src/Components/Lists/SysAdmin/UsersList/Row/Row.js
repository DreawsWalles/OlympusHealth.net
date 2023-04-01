import classes from "./Row.module.css";
import CustomCheckbox from "../../../../Checkboxes/CustomCheckbox/CustomCheckbox";
import ButtonCross from "../../../../Buttons/ButtonCross/ButtonCrossBlackVersion/ButtonCross";
import iconHistory from "../../../../../Images/Icons/IconHistoryUser/iconHistory.svg";
import iconHistoryHover from "../../../../../Images/Icons/IconHistoryUser/iconHistoryHover.png";
import iconInformationUser from "../../../../../Images/Icons/IconUserInformation/iconActive.svg";
import iconInformationUserHover from "../../../../../Images/Icons/IconUserInformation/iconHover.png";
import ButtonActive from "../../../../Buttons/ButtonActive/ButtonActive";
import {useEffect, useState} from "react";
import MessageBox from "../../../../MessageBox/MessageBox";
import ButtonAccept from "../../../../Buttons/ButtonAccept/ButtonAccept";
export default function Row(props){
    const element = props.element;
    const [btnAccept, setBtnAccept] = useState();
    const [fill, setFill] = useState();
    useEffect(() => {
        (() => {
            setFill(props.element.accept ? classes.accept : classes.not_accept);
            setBtnAccept(<ButtonAccept isAccept={props.element.accept} onClick={ClickOnAcceptUser} />);
        })()
    }, []);
    useEffect(() =>{
        (() =>{
            setFill(props.element.accept ? classes.accept : classes.not_accept);
            setBtnAccept(<ButtonAccept isAccept={props.element.accept} onClick={ClickOnAcceptUser} />);
        })()
    }, [element.login]);
    useEffect(() => {
        (() => {
            debugger
            setFill(props.element.accept ? classes.accept : classes.not_accept);
            setBtnAccept(<ButtonAccept isAccept={props.element.accept} onClick={ClickOnAcceptUser} />);
        })()
    }, [element.accept]);
    function ClickOnRemoveButton(){
        document.getElementById(element.key).checked = false;
        console.log(element);
        localStorage.setItem("action", JSON.stringify({
            name: "RemoveUser",
            attribute: null,
            body: element.key
        }));
        console.log(localStorage.getItem("action"));
        props.functionsMsgBox.set(<MessageBox title={"Уведомление"} text={`Вы действительно хотите удалить пользователя ${element.login}?`}
                                        buttons={"YesNo"} onShow={props.functionsMsgBox.show} onHide={props.functionsMsgBox.hide}
                                        isNeedConfirm={true} onShowConfirm={props.onShowConfirm}/>);
        props.functionsMsgBox.show();
    }
    function ClickOnAcceptUser(){
        localStorage.setItem("action", JSON.stringify({
            name: "AcceptUser",
            attribute: null,
            body: element.key
        }));
        console.log(localStorage.getItem("action"));
        props.setMessageBox(<MessageBox title={"Уведомление"} text={`Вы действительно хотите подтвердить пользователя ${element.login}?`}
                                        buttons={"YesNo"} onShow={props.functionsMsgBox.show} onHide={props.functionsMsgBox.hide}
                                        isNeedConfirm={true} onShowConfirm={props.onShowConfirm}/>);
        props.functionsMsgBox.show();
    }
    return(
        <div className={`row row-list ${classes.content} ${fill}`}>
            <div className={`col-1 ${classes.align_center} ${classes.flex_end} ${classes.marginTop}`}>
                <div className={`row`}>
                    <div className={`col-6 ${classes.btnAccept}`}>
                        {btnAccept}
                    </div>
                    <div className={`col-6 ${classes.checkBox}`}>
                        <CustomCheckbox onClick={props.onClickCheckbox} id={`${element.key}`} size={classes.sizeCheckbox}/>
                    </div>
                </div>
            </div>
            <div className={`col-11 ${classes.text}`}>
                <div className={`row`}>
                    <div className={`col-4 ${classes.flex_start}`}>
                        <div className={`${classes.textOverflow} ${classes.marginTop}`}>
                            {element.login}
                        </div>
                    </div>
                    <div className={`col-4 ${classes.flex_center} `}>
                        <div className={`${classes.textOverflow} ${classes.marginTop}`}>
                            {element.role}
                        </div>
                    </div>
                    <div className={`col-4 ${classes.flex_end} `}>
                        <div className={`row ${classes.content} ${classes.flex_end}`}>
                            <div className={`col-4`}>
                                <ButtonActive icon={iconHistory} iconHover={iconHistoryHover}
                                              attribute={classes.attributeHistory}
                                              toolText={"История пользователя"} attributeHint={classes.attributeHintHistory}/>
                            </div>
                            <div className={`col-4`}>
                                <ButtonActive icon={iconInformationUser} iconHover={iconInformationUserHover}
                                              attribute={classes.attributeInformation}
                                              toolText={"Информация о пользователе"} attributeHint={classes.attributeHintInformation}/>
                            </div>
                            <div className={`col-4`}>
                                <ButtonCross isActive={"active"} toolText={"Удалить пользователя"}
                                             attributeHint={classes.attributeHintCross} attribute={classes.attributeCross}
                                             classNone={props.blurNone} onClick={ClickOnRemoveButton}/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>)
}