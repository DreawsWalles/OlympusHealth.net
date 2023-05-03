import type {ActionConfirm} from "../../Confirm/ActionConfirm";
import type {ActionMessageBox} from "../../MessageBox/ActionMessageBox";

export interface IMenuProps{
    id: string,
    choice: number,
    idContent: string,
    setChoice(): () => {},
    actionConfirm: ActionConfirm,
    actionMessageBox: ActionMessageBox
}