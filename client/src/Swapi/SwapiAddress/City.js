import {AddressToken, Api, Controllers} from "../../Constants";

async function getCityByServer(country, region, city){
    let tmp;
    await fetch(`${Api}${Controllers["Address"]}City?name=${city}&country=${country}&region=${region}`, {
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

async function getCityByApi(city, country, region){
    let tmp;
    let locations = [{country: country, region: region.toString().split(' ')[0], street_type_full: null}];
    await fetch("https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/address", {
        method: "Post",
        mode:"cors",
        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json",
            "Authorization": "Token " + AddressToken
        },
        body: JSON.stringify({query: city, locations: locations})
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
        if(tmp.suggestions[i].data.country === country && tmp.suggestions[i].data.region_with_type === region && tmp.suggestions[i].data.area_type === null
            && tmp.suggestions[i].data.city !== null && tmp.suggestions[i].data.street_type_full === null) {
            result[result.length] = tmp.suggestions[i].data.city_with_type;
        }
    }
    return result;
}
export async function GetCityMatchName(city, props){
    let serverData = await getCityByServer(props.country, props.region, city);
    let apiData = await getCityByApi(city, props.country, props.region);
    return serverData.concat(apiData).unique();
}