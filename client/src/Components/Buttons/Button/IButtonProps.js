export interface IButtonProps
{
    id: number | string
    size: "xs" | "s" | "m";
    text: string;
    theme: "Red" | "Success" | "Success_outline" | "White",
    isDisplay: boolean,
    onClick();
}