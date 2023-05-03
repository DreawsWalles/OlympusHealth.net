import type {ActionConfirm} from "../../../../Components/Confirm/ActionConfirm";
import type {ActionMessageBox} from "../../../../Components/MessageBox/ActionMessageBox";

export interface IMainScreenProps{
    id: string,
    countNotification: number,
    actionConfirm: ActionConfirm,
    actionMessageBox: ActionMessageBox,
    changeIsLoaded() : () => void,
}