import classes from "../../Screens/SysAdmin/SysAdminLayout/SysAdminLayout.module.css";
import {Actions} from "../../Actions/SysAdminActions";

export class ActionConfirm
{
    id: string;
    blurId : string;
    styleNone: string;
    actionSuccess: () => void;
    actionFail: () => void;
    constructor(id: string, blurId: string, styleNone: string, actionSuccess: () => void, actionFail: () => void) {
        this.id = id;
        this.blurId = blurId;
        this.styleNone = styleNone;
        this.actionSuccess = actionSuccess;
        this.actionFail = actionFail;
    }
    onShow(){
        let element = document.getElementById(this.id);
        let blur = document.getElementById(this.blurId);
        blur.classList.remove(this.styleNone);
        element.classList.remove(this.styleNone);
    }
    onHide(){
        let element = document.getElementById(this.id);
        let blur = document.getElementById(this.blurId);
        blur.classList.add(classes.none);
        element.classList.add(classes.none);
    }
    async onAccept() {
        let result = await Actions(JSON.parse(localStorage.getItem("action")));
        if(result.result){
            this.actionSuccess(result.Message, "success");
        }else {
            this.actionFail(result.Message, "fail");
        }
    }
    onFail(){
        this.actionFail("Введен некорректный пароль", "fail");
    }
}