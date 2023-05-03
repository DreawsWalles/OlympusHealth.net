export interface IPatientFormProps {
    textButton: string,
    onSubmit(): () => {},
    isLoaded(): () => {}
}