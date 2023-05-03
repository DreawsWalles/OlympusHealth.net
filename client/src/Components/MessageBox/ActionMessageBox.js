
export class ActionMessageBox
{
    idBox: string;
    idBlur: string;
    styleNone: string;
    set: () => void;

    constructor(idBox: string, idBlur: string, styleNone: string, set: () => void) {
        this.idBox = idBox;
        this.idBlur = idBlur;
        this.styleNone = styleNone;
        this.set = set;
    }
    onShow(){
        let box = document.getElementById(this.idBox);
        let blur = document.getElementById(this.idBlur);
        blur.classList.remove(this.styleNone);
        box.classList.remove(this.styleNone);
    }
    onHide(){
        debugger
        let box = document.getElementById(this.idBox);
        let blur = document.getElementById(this.idBlur);
        blur.classList.add(this.styleNone);
        box.classList.add(this.styleNone);
    }
}