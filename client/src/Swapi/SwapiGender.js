import {Api, Controllers} from "../Constants";
import {GenderModel} from "../Entities/PersonalModel/GenderModel";

export async function GetAll(): Promise<Array<GenderModel>> | Promise<null>{
    let result: Array<GenderModel> = [];
    let answer;
    let status: number;
    await fetch(`${Api}${Controllers["Gender"]}GetAll`,{
        method: "Get",
        headers:{
            'Accept': 'text/plain'
        }
    })
        .then(function (response){
            status = response.status;
            return response.json()
        })
        .then(function (json){
            answer = json;
        });
    if(status === 200) {
         answer.forEach(element => result.push(new GenderModel(element.id, element.name)));
    }else{
         result = [];
    }
    return result;
}

export async function GetById(id): Promise<GenderModel>{
    let answer;
    let status: number;
    await fetch(`${Api}${Controllers["Gender"]}GetById?id=${id}`,{
        method:"Post",
        headers:{
            'Accept': 'text/plain'
        }
    })
        .then(function (response){
            status = response.status;
            return response.json()
        })
        .then(function (json){
            answer = json;
        });
    return status === 200 ?  new GenderModel(answer.id, answer.name) : null;
}