import {Api, Controllers} from "../Constants";

export async function GetIdByName(name: string): Promise<string | null>{
    let result;
    let status;
    await fetch(`${Api}${Controllers["RoleMedic"]}GetRole?name=${name}`,{
        method: "Post",
        headers:{
            'Accept': 'text/plain'
        }
    })
        .then(function (response){
            status = response.status;
            return response.json()
        })
        .then(function (json){
            result = json;
        });
    return status === 200 ?  result : null;
}