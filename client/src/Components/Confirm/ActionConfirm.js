
export class VisualAction
{
    public id: string;
    public blurId : string;
    public styleNone: string;
    constructor(id: string, blurId: string, styleNone: string) {
        this.id = id;
        this.blurId = blurId;
        this.styleNone = styleNone;
    }
    onShow(){
        let element = document.getElementById(this.id);
        let blur = document.getElementById(this.blurId);
        blur.classList.remove(this.styleNone);
        element.classList.remove(this.styleNone);
    }
    onHide(){

    }
}