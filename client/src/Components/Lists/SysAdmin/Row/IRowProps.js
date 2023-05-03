import {ActionMessageBox} from "../../../../MessageBox/ActionMessageBox";
import {ActionConfirm} from "../../../../Confirm/ActionConfirm";
import {EntityRow} from "../EntityRow";

export interface IRowProps
{
    actionMessageBox: ActionMessageBox,
    actionConfirm: ActionConfirm,
    data: EntityRow,
    clickOnCheckBox() : () => void
}