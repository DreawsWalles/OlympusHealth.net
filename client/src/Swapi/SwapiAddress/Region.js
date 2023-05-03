import {AddressToken, Api, Controllers} from "../../Constants";

async function getRegionsByServer(region: string, country: string): Promise<string[]>{
    let tmp;
    await fetch(`${Api}${Controllers["Address"]}Region?name=${region}&country=${country}`, {
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

async function getRegionByApi(region: string, country: string): Promise<string[]>{
    let tmp;
    let locations = [{country: country}]
    await fetch("https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/address", {
        method: "Post",
        mode:"cors",
        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json",
            "Authorization": "Token " + AddressToken
        },
        body: JSON.stringify({query: region, locations: locations})
    })
        .then(function (response){
            return response.json()
        })
        .then(function (json){
            tmp = json;
        })
        .catch(e => {
            console.error(e);
        });
    let result = [];
    for(let i = 0; i < tmp.suggestions.length; i++){
        if(tmp.suggestions[i].data.country === country && tmp.suggestions[i].data.city_type_full === null && tmp.suggestions[i].data.area_type === null) {
            result[result.length] = tmp.suggestions[i].value;
        }
    }
    return result;
}
export async function GetRegionMatchName(region: string, country: string): Promise<[]>{
    let serverData = await getRegionsByServer(region, country);
    let apiData = await getRegionByApi(region, country);
    let result = new Set();
    apiData.forEach(element => serverData.push(element));
    serverData.forEach(element => {
        if (!result.has(element)){
            result.add(element);
        }});
    return Array.from(result);
}
