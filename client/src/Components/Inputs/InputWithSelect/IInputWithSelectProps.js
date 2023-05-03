export interface IInputWithSelectProps{
    id: string,
    idError: string,
    height: number,
    placeholder: string,
    funcGetData() : () => Promise<[]>,
    fontSize: number | null,
    setValue() : () => {},
    actionAfterInput() : () => {},
    onInput() : () => {},
    mode: "Multi" | "Single"
}