import {AddressToken, Api, Controllers} from "../../Constants";

async function getCountryByNameByServer(country: string): Promise<string[]>{
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
        return [];
    }
    let result = [];
    for(let i = 0; i < tmp.length; i++){
        result[result.length] = tmp[i].name;
    }
    return result;
}

async function getCountryByNameByApi(country: string): Promise<string[]>{
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
    let result = [];
    for(let i = 0; i < tmp.suggestions.length; i++){
        result[result.length] = tmp.suggestions[i].value;
    }
    return result;
}
// eslint-disable-next-line no-extend-native
Array.prototype.unique = function (){
    let a = this.concat();
    for(let i=0; i < a.length; ++i) {
        for(let j=i+1; j<a.length; ++j) {
            if(a[i] === a[j])
                a.splice(j--, 1);
        }
    }
    return a;
}

export async function GetCountryMatchName(country: string): Promise<[]>{
    let serverData: string[] = await getCountryByNameByServer(country);
    let apiData: string[] = await getCountryByNameByApi(country);
    let result = new Set();
    apiData.forEach(element => serverData.push(element));
    serverData.forEach(element => {
        if (!result.has(element)){
            result.add(element);
    }});
    return Array.from(result);

}