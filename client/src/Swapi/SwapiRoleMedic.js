import {Api, Controllers} from "../Constants";

export async function GetIdByName(name){
    let result;
    debugger
    await fetch(`${Api}${Controllers["RoleMedic"]}GetRole?name=${name}`,{
        method: "Post",
        headers:{
            'Accept': 'text/plain'
        }
    })
        .then(function (response){
            return response.json()
        })
        .then(function (json){
            result = json;
        });
    return result;
}