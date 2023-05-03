import {Navigate} from "react-router-dom";
import {useEffect, useState} from "react";
import {CheckToken} from "../Swapi/SwapiAccount/SwapiAccount";

export default function Token(){
    const [cookie, setCookie] = useState(document.cookie.toString().substring(5));
    const [content, setContent] = useState();
    setInterval(() => {
        let tmp = document.cookie.toString().substring(5);
        setCookie(tmp);
    }, 1000);
    setInterval(async () => {
        let result = await CheckToken(cookie);
        if(!result){
            setCookie("");
        }

    }, 1000);
    useEffect(() => {
        (async () =>{
            if(cookie === ""){
                setContent(<Navigate replace to={"/Authorization"} />);
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