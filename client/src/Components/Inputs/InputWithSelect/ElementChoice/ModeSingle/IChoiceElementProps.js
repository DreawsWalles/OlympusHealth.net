export interface IChoiceElementProps{
    id: string,
    height: number,
    text: string,
    fontSize: number | null,
    onClick(): () => {}
}