import type {ActionMessageBox} from "./ActionMessageBox";
import type {ActionConfirm} from "../Confirm/ActionConfirm";

export interface IMessageBoxProps{
    id: string,
    title: string,
    text: string,
    buttons: "YesNo" | "Ok",
    actionConfirm: ActionConfirm,
    actions: ActionMessageBox
}