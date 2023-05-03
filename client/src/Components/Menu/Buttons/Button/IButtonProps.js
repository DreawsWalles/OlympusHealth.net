export interface IButtonIconMenuProps{
    Icon : string,
    HoverIcon : string,
    Text : string,
    State: "Select" | "NotSelect",
    MarginTopText?:number,
    onClick() : () => {}
}