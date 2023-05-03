
export class ToggleSwitchAttributes
{
    text: string;
    constructor(text: string) {
        this.text = text;
    }
}
export class ErrorAttribute
{
    id: string;
    text: string | null;
    constructor(id: string, text?: string) {
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
    type: "text" | "password" | "email" | "tel" | "date",
    setValue(): () => {},

    toggleSwitchAttribute: ToggleSwitchAttributes | null,

    errorAttribute: ErrorAttribute | null,

    labelAttribute: LabelAttribute | null
}