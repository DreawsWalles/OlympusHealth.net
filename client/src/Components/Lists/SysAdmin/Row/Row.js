import classes from "./Row.module.css";
import Checkbox from "../../../../Checkboxes/Checkbox/Checkbox";
import iconHistory from "../../../../../Images/Icons/IconHistoryUser/iconHistory.svg";
import iconHistoryHover from "../../../../../Images/Icons/IconHistoryUser/iconHistoryHover.png";
import iconInformationUser from "../../../../../Images/Icons/IconUserInformation/iconActive.svg";
import iconInformationUserHover from "../../../../../Images/Icons/IconUserInformation/iconHover.png";
import iconFail from "../../../../../Images/Icons/IconAccept/iconFail.svg";
import {useEffect, useState} from "react";
import MessageBox from "../../../../MessageBox/MessageBox";
import iconActive from "../../../../../Images/Icons/IconCross/BlackVersion/CrossActive.svg";
import iconHover from "../../../../../Images/Icons/IconCross/BlackVersion/CrossHover.png";
import ButtonWithHintAndIcon from "../../../../Buttons/ButtonWithHintAndIcon/ButtonWithHintAndIcon";
import {AttributeIcon} from "../../../../Buttons/ButtonWithHintAndIcon/IButtonWithHintAndIconProps";
import {AttributeHint} from "../../../../Hint/AttributeHint";
import type {IRowProps} from "./IRowProps";

export default function Row(props : IRowProps){
    const ids = {
        idRow: props.data.key,
        idBtnHistory: `${props.data.key}-btn-history`,
        idBtnInformationUser: `${props.data.key}-btn-information-user`,
        idBtnRemoveUser: `${props.data.key}-btn-remove-user`,
        idBtnAccept: `${props.data.key}-btn-accept-user`
    }
    const [btnAccept, setBtnAccept] = useState();
    const [fill, setFill] = useState();
    useEffect(() => {
        (() => {
            setFill(props.data.accept ? classes.accept : classes.not_accept);
            setBtnAccept(props.data.accept ? null :
                <ButtonWithHintAndIcon id={ids.idBtnAccept}
                                       width={21}
                                       iconEnable={iconFail}
                                       iconHover={iconFail}
                                       attributeIcon={new AttributeIcon(21, "auto")}
                                       status={"Active"}
                                       isNeedHint={true}
                                       attributeHint={new AttributeHint(280, -140, "Нажмите, для подтверждения пользователя")}
                                       onClick={ClickOnAcceptUser} />)
        })()
    }, []);
    useEffect(() =>{
        (() =>{
            setFill(props.data.accept ? classes.accept : classes.not_accept);
            setBtnAccept(props.data.accept ? null :
                         <ButtonWithHintAndIcon id={ids.idBtnAccept}
                                                width={21}
                                                iconEnable={iconFail}
                                                iconHover={iconFail}
                                                attributeIcon={new AttributeIcon(21, "auto")}
                                                status={"Active"}
                                                isNeedHint={true}
                                                attributeHint={new AttributeHint(280, -140, "Нажмите, для подтверждения пользователя")}
                                                onClick={ClickOnAcceptUser} />)
        })()
    }, [props.data.login]);
    useEffect(() => {
        (() => {
            setFill(props.data.accept ? classes.accept : classes.not_accept);
            setBtnAccept(props.data.accept ? null :
                <ButtonWithHintAndIcon id={ids.idBtnAccept}
                                       width={21}
                                       iconEnable={iconFail}
                                       iconHover={iconFail}
                                       attributeIcon={new AttributeIcon(21, "auto")}
                                       status={"Active"}
                                       isNeedHint={true}
                                       attributeHint={new AttributeHint(280, -140, "Нажмите, для подтверждения пользователя")}
                                       onClick={ClickOnAcceptUser} />)
        })()
    }, [props.data.accept]);
    function ClickOnRemoveButton(){
        debugger
        document.getElementById(ids.idRow).checked = false;
        localStorage.setItem("action", JSON.stringify({
            name: "RemoveUser",
            attribute: null,
            body: props.data.key
        }));
        console.log(localStorage.getItem("action"));
        props.actionMessageBox.set(<MessageBox id={props.actionMessageBox.idBox}
                                              title={"Уведомление"}
                                              text={`Вы действительно хотите удалить пользователя ${props.data.login}?`}
                                              buttons={"YesNo"}
                                              actions={props.actionMessageBox}
                                              actionConfirm={props.actionConfirm} />);
        props.actionMessageBox.onShow();
    }
    function ClickOnAcceptUser(){
        localStorage.setItem("action", JSON.stringify({
            name: "AcceptUser",
            attribute: null,
            body: props.data.key
        }));
        console.log(localStorage.getItem("action"));
        props.actionMessageBox.set(<MessageBox id={props.actionMessageBox.idBox}
                                              title={"Уведомление"}
                                              text={`Вы действительно хотите подтвердить пользователя ${props.data.login}?`}
                                              buttons={"YesNo"}
                                              actions={props.actionMessageBox}
                                              actionConfirm={props.actionConfirm} />);
        props.actionMessageBox.onShow();
    }
    return(
        <div className={`row row-list ${classes.content} ${fill}`}>
            <div className={`col-1`}>
                <div className={`row ${classes.rowBtnAndCheckBox}`}>
                    <div className={`col-6`}>
                        {btnAccept}
                    </div>
                    <div className={`col-6`}>
                        <Checkbox id={ids.idRow}
                                  size={"auto"}
                                  onClick={props.clickOnCheckBox} />
                    </div>
                </div>
            </div>
            <div className={`col-11 ${classes.text}`}>
                <div className={`row`}>
                    <div className={`col-4 ${classes.flex_start}`}>
                        <div className={`${classes.textOverflow} ${classes.marginTop}`}>
                            {props.data.login}
                        </div>
                    </div>
                    <div className={`col-4 ${classes.flex_center} `}>
                        <div className={`${classes.textOverflow} ${classes.marginTop}`}>
                            {props.data.role}
                        </div>
                    </div>
                    <div className={`col-4 ${classes.flex_end} `}>
                        <div className={`row ${classes.content} ${classes.flex_end}`}>
                            <div className={`col-4`}>
                                <ButtonWithHintAndIcon id={ids.idBtnHistory}
                                                       width={15}
                                                       iconEnable={iconHistory}
                                                       iconHover={iconHistoryHover}
                                                       attributeIcon={new AttributeIcon(30, "auto")}
                                                       status={"Active"}
                                                       isNeedHint={true}
                                                       attributeHint={new AttributeHint(145, -72, "История пользователя")}
                                                       onClick={() => {}} />
                            </div>
                            <div className={`col-4`}>
                                <ButtonWithHintAndIcon id={ids.idBtnInformationUser}
                                                       width={15}
                                                       iconEnable={iconInformationUser}
                                                       iconHover={iconInformationUserHover}
                                                       attributeIcon={new AttributeIcon(25, "auto",  2, 5)}
                                                       status={"Active"}
                                                       isNeedHint={true}
                                                       attributeHint={new AttributeHint(190, -97, "Информация о пользователе")}
                                                       onClick={() => {}} />
                            </div>
                            <div className={`col-4`}>
                                <ButtonWithHintAndIcon id={ids.idBtnRemoveUser}
                                                       width={15}
                                                       iconEnable={iconActive}
                                                       iconHover={iconHover}
                                                       status={"Active"}
                                                       attributeIcon={new AttributeIcon(19, "auto")}
                                                       isNeedHint={true}
                                                       attributeHint={new AttributeHint(145, -72, "Удалить пользователя")}
                                                       onClick={ClickOnRemoveButton}/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>)
}