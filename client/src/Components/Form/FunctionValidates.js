import {Hint} from "../../Functions";

export function validEmail(e: string) {
    let filter = /^\s*[\w\-\+_]+(\.[\w\-\+_]+)*\@[\w\-\+_]+\.[\w\-\+_]+(\.[\w\-\+_]+)*\s*$/;
    return String(e).search (filter) !== -1;
}
export function validPhone(e: string): boolean{
    let filter = /^(\s*)?(\+)?([- _():=+]?\d[- _():=+]?){10,14}(\s*)?$/;
    return String(e).search(filter) !== -1;
}
export function validDate(e: string): boolean{
    let date = new Date(e);
    return date < new Date();
}
export function checkOnLength(value: string): boolean{
    return value.trim().length === 0;
}
export type funcValidator = () => boolean
export async function check(value: string, idError: string, messages: string[], validators: funcValidator[], role? : "patient" | "medic"){
    for(let func of validators){
        if(await func(value, role)){
            Hint(idError, messages[validators.indexOf(func)]);
            return false;
        }
    }
    return true;
}