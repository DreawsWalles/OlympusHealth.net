import {AddressToken, Api, Controllers} from "../../Constants";

async function getStreetByServer(country, region, city, street){
    let tmp;
    await fetch(`${Api}${Controllers["Address"]}Street?name=${street}&country=${country}&region=${region}&city=${city}`, {
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

async function getStreetByApi(country, region, city, street){
    let result = new Array();
    debugger
    let locations = [{region: region.toString().split(' ')[0], city: city.toString().split(' ')[1]}];
    let tmp;
    await fetch("https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/address", {
        method: "Post",
        mode:"cors",
        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json",
            "Authorization": "Token " + AddressToken
        },
        body: JSON.stringify({query: street,locations:locations, count: 20})
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
    for(let i = 0; i < tmp.suggestions.length; i++) {
        if (tmp.suggestions[i].data.country === country && tmp.suggestions[i].data.region_with_type === region
            && tmp.suggestions[i].data.area_type === null && tmp.suggestions[i].data.city_with_type === city) {
            result[result.length] = tmp.suggestions[i].data.street_with_type;
        }
    }
    return result;
}
export async function GetStreetMatchName(street, props){
    let serverData = await getStreetByServer(props.country, props.region, props.city, street);
    let apiData = await getStreetByApi(props.country, props.region, props.city, street);
    return serverData.concat(apiData).unique();
}