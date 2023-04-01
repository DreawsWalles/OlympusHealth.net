import {Navigate} from "react-router-dom";
import {useEffect, useState} from "react";
import {CheckToken} from "../Swapi/SwapiAccount";

export default function CheckToken(){
    const [cookie, setCookie] = useState(document.cookie.toString().substring(5));
    const [content, setContent] = useState();
    setInterval(() => {
        let tmp = document.cookie.toString().substring(5);
        setCookie(tmp);
    }, 1000);
    useEffect(() => {
        (async () =>{
            debugger
            if(cookie === ""){
                setContent(<Navigate replace to={"/Authorization"} />)
            }else{
                let result = await CheckToken(cookie);
                if(!result){
                    setCookie("");
                }
            }
        })()
    }, [cookie]);
    return(
        <div>
            {content}
        </div>)
}