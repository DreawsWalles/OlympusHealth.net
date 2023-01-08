import {AddressToken, Api, Controllers} from "../../Constants";

async function getCountryByNameByServer(country){
    let tmp;
    await fetch(`${Api}${Controllers["Address"]}Country?name=${country}`, {
        method:"Post",
        headers:{
            'Accept': 'text/plain'
        }
    })
        .then(function (response){
            return response.json();
        })
        .then(function (json){
            tmp = json;
        })
        .catch(e => {
            console.error(e);
            tmp = undefined
        });
    if(tmp === undefined) {
        return new Array();
    }
    let result = new Array();
    for(let i = 0; i < tmp.length; i++){
        result[result.length] = tmp[i].name;
    }
    return result;
}

async function getCountryByNameByApi(country){
    let tmp;
    await fetch(`https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/country`, {
        method: "Post",
        mode:"cors",
        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json",
            "Authorization": "Token " + AddressToken
        },
        body: JSON.stringify({query: country})
    })
        .then(function (response){
            return response.json()
        })
        .then(function (json){
            tmp = json;
        });
    let result = new Array();
    for(let i = 0; i < tmp.suggestions.length; i++){
        result[result.length] = tmp.suggestions[i].value;
    }
    return result;
}
Array.prototype.unique = function (){
    let a = this.concat();
    for(let i=0; i<a.length; ++i) {
        for(let j=i+1; j<a.length; ++j) {
            if(a[i] === a[j])
                a.splice(j--, 1);
        }
    }
    return a;
}

export async function GetCountryMatchName(country){
    let serverData = await getCountryByNameByServer(country);
    let apiData = await getCountryByNameByApi(country);
    return serverData.concat(apiData).unique();
}