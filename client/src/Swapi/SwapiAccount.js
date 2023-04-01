import {Api, Controllers} from "../Constants";

export async function Login(data, answer){
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
    if(status === 200){
        return answer;
    }
    return answer;
}

export async function CheckLogin(login){
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
    if(answer !== 200)
        return false;
    return true;
}

export async function CheckEmail(email, role){
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
    if(answer !== 200)
        return false;
    return true;
}

export async function CheckPhoneNumber(phoneNumber, role){
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
    if(answer !== 200)
        return false;
    return true;
}

export async function RegisterUser(data, answer){
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
    if(status === 200){
        return answer;
    }
    return answer;
}
export async function GetRole(token){
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

export async function IsAccept(token){
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
    if(answer === 200)
        return true;
    return false;
}

export async function RegisterSysAdmin(data, answer)
{
    answer = undefined;
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
    if(status === 200){
        return answer;
    }
    return answer;
}
export async function CheckToken(token){
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
    if(status === 200)
        return true;
    return false;
}
export async function ConfirmAction(token, password){
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
    if(status === 200){
        return true;
    }
    return false;
}