import {IChoiceElementProps} from "./IChoiceElementProps";
import classes from "./ChoiceElement.module.css";
import ButtonWithHintAndIcon from "../../../Buttons/ButtonWithHintAndIcon/ButtonWithHintAndIcon";
import icon from "../../../../Images/Icons/IconCross/BlackVersion/CrossActive.svg";
import iconHover from "../../../../Images/Icons/IconCross/BlackVersion/CrossHover.png";
import {AttributeIcon} from "../../../Buttons/ButtonWithHintAndIcon/IButtonWithHintAndIconProps";
import {AttributeHint} from "../../../Hint/AttributeHint";

export function ChoiceElement(props: IChoiceElementProps ){
    return (
        <div id={`${props.id}-choice-element`}
             style={{fontSize: props.fontSize === null ? ``: `${props.fontSize}px`,
                 width: props.width === "100%" ? '100%' : ''}}
             className={`${props.width !== "100%" ? props.width : ''} ${classes.content}`} >
            <div style={{maxWidth:props.width === "100%" ? '100%' : ''}}
                 className={`row ${classes.row}`}>
                <div id={`${props.id}-choice-element-text`} className={`col-10 ${classes.text}`}>
                    {props.text}
                </div>
                <div style={{padding: `0`}} className={`col-2 ${classes.buttons}`}>
                    <ButtonWithHintAndIcon width={15}
                                           iconEnable={icon}
                                           iconHover={iconHover}
                                           attributeIcon={new AttributeIcon(15, "auto")}
                                           attributeHint={new AttributeHint(70, -35, "Удалить")}
                                           status={"Active"}
                                           isNeedHint={true} onClick={() => {props.onClick(`${props.id}-choice-element-text`);}} />
                </div>
            </div>
        </div>
    )
}