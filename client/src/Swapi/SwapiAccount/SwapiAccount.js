import {Api, Controllers} from "../Constants";
import {AnswerAutorize} from "./SwapiAccount/Entities";



export async function Login(data): AnswerAutorize{
    let answer;
    let status = 200;
    await fetch(`${Api}${Controllers["Account"]}Login`, {
        method: 'Post',
        headers: {
            'Accept': 'text/plain',
            'Content-Type': 'application/json'
        },
        body:data
    })
        .then(function(response) {
            status = response.status;
            return response.json();
        })
        .then(function (json){
            answer = json;
        })
        .catch(e => {
                console.error(e);
            }
        );
    debugger
    return  status === 200 ?
        new AnswerAutorize(answer.username, answer.role, answer.access_token, status) :
        new AnswerAutorize("", "","",  status);
}

export async function CheckLogin(login: string): boolean{
    let answer;
    await fetch(`${Api}${Controllers["Account"]}CheckLogin?login=${login}`,{
        method: 'Post',
        headers: {
            'Accept': 'text/plain'
        }
    })
        .then(function (response){
            answer = response.status;
        })
        .catch(e => {
            console.error(e);
        })
    return answer === 200;
}

export async function CheckEmail(email: string, role: string): boolean{
    let answer;
    await fetch(`${Api}${Controllers["Account"]}CheckEmail?email=${email}&role=${role}`,{
        method:'Post',
        headers: {
            'Accept': 'text/plain'
        }
    })
        .then(function (response){
            answer = response.status;
        })
        .catch(e => {
            console.error(e);
        })
    return answer === 200;
}

export async function CheckPhoneNumber(phoneNumber: string, role: string): boolean{
    let answer;
    await fetch(`${Api}${Controllers["Account"]}CheckPhoneNumber?login=${phoneNumber}&role=${role}`,{
        method:'Post',
        headers: {
            'Accept': 'text/plain'
        }
    })
        .then(function (response){
            answer = response.status;
        })
        .catch(e => {
            console.error(e);
        })
    return answer === 200;
}

export async function RegisterUser(data, answer): AnswerAutorize{
    answer = undefined;
    let status = 200;
    await fetch(`${Api}${Controllers["Account"]}RegisterUser`, {
        method:"Post",
        headers:{
            'Accept': 'text/plain',
            'Content-Type': 'application/json'
        },
        body:data
    })
        .then(function(response) {
            status = response.status;
            return response.json();
        })
        .then(function (json){
            answer = json;
        })
        .catch(e => {
                console.error(e);
            }
        )
    return  status === 200 ?
        new AnswerAutorize(answer.username, answer.role, answer.access_token, status) :
        new AnswerAutorize("", "","",  status);
}
export async function GetRole(token: string): string{
    let answer = undefined;
    await fetch(`${Api}${Controllers["Account"]}GetRole?token=${token}`, {
        method: "Post",
        headers:{
            'Accept': 'text/plain',
        },
    })
        .then(function (response){
            return response.json()
        })
        .then(function (json){
            answer = json
        })
        .catch(e => {
            console.error(e);
        });
    return answer.message;
}

export async function IsAccept(token: string): boolean{
    let answer = undefined;
    await fetch(`${Api}${Controllers["Account"]}IsAccept?token=${token}`, {
        method: "Post",
        headers:{
            'Accept': 'text/plain',
        },
    })
        .then(function (response){
            debugger
            answer = response.status;
        });
    return answer === 200;

}
export async function RegisterSysAdmin(data): AnswerAutorize
{
    let answer = undefined;
    let status = 200;
    await fetch(`${Api}${Controllers["Account"]}RegisterSysAdmin`, {
        method:"Post",
        headers:{
            'Accept': 'text/plain',
            'Content-Type': 'application/json'
        },
        body:data
    })
        .then(function(response) {
            status = response.status;
            return response.json();
        })
        .then(function (json){
            answer = json;
        })
        .catch(e => {
                console.error(e);
            }
        )
    debugger
    return  status === 200 ?
        new AnswerAutorize(answer.username, answer.role, answer.access_token, status) :
        new AnswerAutorize("", "","",  status);
}
export async function CheckToken(token: string) : boolean{
    let status = 200;
    await fetch(`${Api}${Controllers["Account"]}CheckToken?token=${token}`, {
        method:"Post",
        headers:{
            'Accept': 'text/plain',
        },
    })
        .then(function (response) {
            status = response.status;
        })
        .catch(e => {
            console.error(e);
        })
    return status === 200;

}
export async function ConfirmAction(token: string, password: string): boolean{
    let status = 200;
    await fetch(`${Api}${Controllers["Account"]}Confirm?token=${token}&password=${password}`, {
        method:"Post",
        headers:{
            'Accept': 'text/plain',
        },
    })
        .then(function(response) {
            status = response.status;
            return response.json();
        })
        .catch(e => {
                console.error(e);
            }
        )
    return status === 200;
}