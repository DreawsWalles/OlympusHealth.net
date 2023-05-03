
export class ToggleSwitchAttributes
{
    text: string;
    constructor(text: string) {
        this.text = text;
    }
}
export class ErrorAttribute
{
    id: number;
    text: string | null;
    constructor(id: number, text?: string) {
        this.id = id;
        this.text = text;
    }
}
export class LabelAttribute
{
    text: string
    constructor(text: string) {
        this.text = text;
    }
}
export interface IInputProps {
    id: string,
    placeholder: string,
    type: "text" | "password",
    setValue(): () => {},

    toggleSwitchAttribute: ToggleSwitchAttributes | null,

    errorAttribute: ErrorAttribute | null,

    labelAttribute: LabelAttribute | null
}