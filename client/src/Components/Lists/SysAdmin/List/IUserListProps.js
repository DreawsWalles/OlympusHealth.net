import type {AllUsers} from "../../../../../Swapi/SwapiSysAdmin/Entities";
import type {ActionMessageBox} from "../../../../MessageBox/ActionMessageBox";
import type {ActionConfirm} from "../../../../Confirm/ActionConfirm";
export interface IUserListProps
{
    id: string,
    currentData: AllUsers,
    idGlobalCheckBox: string,
    actionGlobalClick(): () => void,
    actionMessageBox: ActionMessageBox,
    actionConfirm: ActionConfirm
}