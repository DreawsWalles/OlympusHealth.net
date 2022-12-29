import {Api, Controllers} from "../Constants";

export async function GetAll(){
    let result;
    await fetch(`${Api}${Controllers["Gender"]}GetAll`,{
        method: "Get",
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

export async function GetById(id){
    let result;
    await fetch(`${Api}${Controllers["Gender"]}GetById?id=${id}`,{
        method:"Post",
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