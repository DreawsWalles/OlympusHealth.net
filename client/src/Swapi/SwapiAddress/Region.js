import {AddressToken, Api, Controllers} from "../../Constants";

async function getRegionsByServer(region, country){
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
        return new Array();
    }
    let result = new Array();
    for(let i = 0; i < tmp.length; i++){
        result[result.length] = tmp[i].name;
    }
    return result;
}

async function getRegionByApi(region, country){
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
    let result = new Array();
    for(let i = 0; i < tmp.suggestions.length; i++){
        if(tmp.suggestions[i].data.country === country && tmp.suggestions[i].data.city_type_full === null && tmp.suggestions[i].data.area_type === null) {
            result[result.length] = tmp.suggestions[i].value;
        }
    }
    return result;
}
export async function GetRegionMatchName(region, props){
    let serverData = await getRegionsByServer(region, props.country);
    let apiData = await getRegionByApi(region, props.country);
    return serverData.concat(apiData).unique();
}
