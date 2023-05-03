import {Api, Controllers} from "../Constants";
import {json} from "react-router-dom";
import {ChiefOfMedicineModel} from "../Entities/PersonalModel/ChiefOfMedicineModel";
import type {DoctorModel} from "../Entities/PersonalModel/DoctorModel";
import type {HeadOfDepartmentModel} from "../Entities/PersonalModel/HeadOfDepartmentModel";
import type {MedicRegistrationModel} from "../Entities/PersonalModel/MedicRegistratorModel";
import type {PatientModel} from "../Entities/PersonalModel/PatientModel";
import type {SysAdminModel} from "../Entities/PersonalModel/SysAdminModel";

export class AllUsers {
    chiefsOfMedicine: ChiefOfMedicineModel[];
    doctors: DoctorModel[];
    headOfDepartments: HeadOfDepartmentModel[];
    medicRegistrations: MedicRegistrationModel[];
    patients: PatientModel[];
    sysAdmins: SysAdminModel[];

    constructor() {
    }
}
export async function GetAllUsers(token): Promise<AllUsers>{
    let result: AllUsers;
    await fetch(`${Api}${Controllers["SysAdmin"]}GetUsers?token=${token}`, {
        method:"Post",
        headers:{
            'Accept': 'text/plain'
        }
    })
        .then(function (response){
            return response.json()
        })
        .then(function (json){
            result = json;
        })
        .catch(e => {
            console.error(e);
        });
    debugger

    return result;
}
export async function RemoveAllUsers(token){
    let status = 200;
    await fetch(`${Api}${Controllers["SysAdmin"]}RemoveAllUsers?token=${token}`, {
        method:"Post",
        headers:{
            'Accept' : 'text/plain'
        }
    })
        .then(function (response){
            status = response.status
        })
        .catch(e => {
            console.error(e);
        });
    if(status === 200){
        return true;
    }
    return false;
}
export async function RemoveUsers(token, keys){
    let status = 200;
    await fetch(`${Api}${Controllers["SysAdmin"]}RemoveUsers?token=${token}`, {
        method:"Post",
        headers:{
            'Accept': ' */*',
            'Content-Type': 'application/json'
        },
        body:JSON.stringify(keys)
    })
        .then(function (response){
            status = response.status
        })
        .catch(e => {
            console.error(e);
        });
    debugger
    if(status === 200) {
        return true;
    }
    return false;
}
export async function RemoveUser(token, key){
    let status = 200;
    await fetch(`${Api}${Controllers["SysAdmin"]}RemoveUserById?token=${token}&id=${key}`, {
        method:"Post",
        headers:{
            'Accept': ' */*'
        }
    })
        .then(function (response){
            status = response.status
        })
        .catch(e => {
            console.error(e);
        })
    if(status === 200) {
        return true;
    }
    return false;
}
export async function AcceptUser(token, key){
    let status = 200;
    await fetch(`${Api}${Controllers["SysAdmin"]}AcceptUser?token=${token}&id=${key}`, {
        method:"Post",
        headers:{
            'Accept': ' */*'
        }
    })
        .then(function (response){
            status = response.status
        })
        .catch(e => {
            console.error(e);
        })
    if(status === 200) {
        return true;
    }
    return false;
}