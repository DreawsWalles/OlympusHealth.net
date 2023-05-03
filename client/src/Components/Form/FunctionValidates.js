import {Hint} from "../Functions";

export function validEmail(e: string) {
    let filter = /^\s*[\w\-\+_]+(\.[\w\-\+_]+)*\@[\w\-\+_]+\.[\w\-\+_]+(\.[\w\-\+_]+)*\s*$/;
    return String(e).search (filter) === -1;
}
export function validPhone(e: string): boolean{
    let filter = /^\+?\d{1,4}?[-.\s]?\(?\d{1,3}?\)?[-.\s]?\d{1,4}[-.\s]?\d{1,4}[-.\s]?\d{1,9}$/;
    return String(e).search(filter) === -1;
}
export function validDate(e: string): boolean{
    let date = new Date(e);
    return date > new Date();
}
export function checkOnLength(value: string): boolean{
    return value.trim().length === 0;
}
export type funcValidator = () => boolean
export async function check(value: string, idError: string, messages: string[], validators: funcValidator[], role? : "patient" | "medic"): Promise<boolean>{
    for(let func of validators){
        if(await func(value, role)){
            let a = messages[validators.indexOf(func)];
            Hint(idError, messages[validators.indexOf(func)]);
            return false;
        }
    }
    return true;
}