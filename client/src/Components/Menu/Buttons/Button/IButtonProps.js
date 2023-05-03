export interface IButtonProps {
    Icon : string,
    HoverIcon : string,
    Text : string,
    State: "Select" | "NotSelect",
    MarginTopText?:number,
    onClick() : () => {}
}