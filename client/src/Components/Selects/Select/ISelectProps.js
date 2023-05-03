export class ItemProps
{
    value: string;
    id: number | string;
    fontSize: number | null;
    constructor(id: string, value: string, fontSize: number | null) {
        this.id = id;
        this.value = value;
        this.fontSize = fontSize;
    }
    onClick(func:(e) => {}){
        func(e);
    }
}


export interface ISelectProps
{
    id: string,
    height: number,
    idError: string | null,
    alignment: "start" | "center" | "end",
    fontSize: number | null,
    list: Array<ItemProps>,
    title: string,
    onChange(): () => {}
}