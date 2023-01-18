import {Api, Controllers} from "../Constants";

export async function GetCount(token){
    let result;
    await fetch(`${Api}${Controllers["Notifications"]}Count?token=${token}`,{
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
        })
        .catch(e => {
            console.error(e);
        });
    return result;
}