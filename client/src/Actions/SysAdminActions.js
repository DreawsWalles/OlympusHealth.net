import {AcceptUser, RemoveAllUsers, RemoveUser, RemoveUsers} from "../Swapi/SwapiSysAdmin/SwapiSysAdmin";

export async function Actions(action)
{
    let result;
    let resultMsg;
    debugger
    switch (action.name)
    {
        case "RemoveAllUsers":
            result = await removeAll();
            resultMsg = result ? "Все пользователи успешно удалены" : "Не удалось удалить всех пользователей";
            break;
        case "RemoveUsers":
            result = await removeUsers(action.body);
            resultMsg = result ? "Выбранные вами пользователи успешно удалены" : "Не удалось удалить всех выбранных пользователей";
            break;
        case "RemoveUser":
            result = await removeUser(action.body);
            resultMsg = result ? "Пользователь успешно удален" : "Не удалось удалить пользователя";
            break;
        case "AcceptUser":
            result = await acceptUser(action.body);
            resultMsg = result ? "Пользователь успешно подтвержден" : "Не удалось подтвердить пользователя";
            break;
    }
    return {
        result: result,
        Message: resultMsg
    };
}

export async function acceptUser(key){
    let result = await AcceptUser(document.cookie.toString().substring(5), key);
    return result;
}
export async function removeUser(key){
    let result = await RemoveUser(document.cookie.toString().substring(5), key);
    return result;
}
export async function removeAll()
{
    let result = await RemoveAllUsers(document.cookie.toString().substring(5));
    if(result){
        document.cookie = "user=";
    }
    return result;
}
export async function removeUsers(keys){
    let result = await RemoveUsers(document.cookie.toString().substring(5), keys);
    return result;
}