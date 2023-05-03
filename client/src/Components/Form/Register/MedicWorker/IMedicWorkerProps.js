export interface IMedicWorkerProps{
    textButton: string,
    choice: string,
    onSubmit(): () => {},
    isLoaded(): () => {}
}