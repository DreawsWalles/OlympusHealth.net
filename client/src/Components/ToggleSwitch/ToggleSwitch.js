import classes from "./ToggleSwitch.module.css";
import type {IToggleSwitchProps} from "./IToggleSwitchProps";
export function ToggleSwitch(props: IToggleSwitchProps){
    return (
        <div style={{marginTop: `${props.marginTop === null ? 0 : props.marginTop}px`}} className={`${classes.content}`}>
            <div className={`${classes.elemSwitch}`}>
                <label id={props.id} className={`${classes.toggleSwitch}`}>
                    <input type="checkbox" disabled={props.disabled} onChange={props.onChange} />
                    <span className={`${classes.switch}`} />
                </label>
            </div>
            <div className={`${classes.elemLabel}`}>
                <label>{props.text}</label>
            </div>
        </div>
    );
}