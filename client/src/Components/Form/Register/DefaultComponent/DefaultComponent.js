import "../../style.css"
import {useEffect} from "react";

export default function DefaultComponent(props){
    return(
        <div className={"content-default"}>
            <div className={"row title-text"}>
                <div id={"text-one"} className={"col"}>Регистрация</div>
            </div>
            <div className={"row title-text"}>
                <div id={"text-two"} className={"col"}>Выберите вид пользователя</div>
            </div>
        </div>
    )
}