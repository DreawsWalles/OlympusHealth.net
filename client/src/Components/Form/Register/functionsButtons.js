
export function clickOnButtonAuto(
    idButton: string,
    idInput: string,
    idRefresh: string,
    oldData:string,
    setOldDate: (value: string) => void,
    styleNone: string,
    setOnClick: (value: boolean) => void){
    let element = document.getElementById(idButton);
    if(element === null){
        return;
    }
    if(element.classList.contains("btn-outline-success")){
        element.classList.add("btn-success");
        element.classList.remove("btn-outline-success");
        let input = document.getElementById(idInput);
        if(input === null){
            return;
        }
        setOldDate(input.value);
        let refresh = document.getElementById(idRefresh);
        if(refresh === null){
            return;
        }
        refresh.classList.remove(styleNone);
        setOnClick(true);

    }
    else{
        element.classList.remove("btn-success");
        element.classList.add("btn-outline-success");
        let input = document.getElementById(idInput);
        if(input === null){
            return;
        }
        input.value = oldData;
        let refresh = document.getElementById(idRefresh);
        if(refresh === null){
            return;
        }
        refresh.classList.add(styleNone);
        setOnClick(false);
    }
}
export function clickOnButtonRefresh(
    value: boolean,
    setValue: (value: boolean) => {}
){
    setValue(!value);
}
