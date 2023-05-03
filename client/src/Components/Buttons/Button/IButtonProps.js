export interface IButtonProps
{
    id: number | string
    size: "xs" | "s" | "m" | "L";
    text: string;
    theme: "Red" | "Success" | "Success_outline" | "White" | "Grey" | "Disable",
    isDisplay: boolean,
    onClick() : () => {};
}