import classes from "./Logo.module.css";
import type {ILogoProps} from "./ILogoProps";
import icon from '../../../src/Images/logo.svg';

export function Logo(props: ILogoProps)
{
    return(
        <img src={icon} style={{width: props.width === "auto" ? `auto` : `${props.width}px`,
                                height: props.height === "auto" ? `auto` : `${props.height}px`}} alt={""}/>
    )
}