import {Api, Controllers} from "../../Constants";
import {AllUsers} from "./Entities";
import {ChiefOfMedicineModel} from "../../Entities/PersonalModel/ChiefOfMedicineModel";
import {DoctorModel} from "../../Entities/PersonalModel/DoctorModel";
import {HeadOfDepartmentModel} from "../../Entities/PersonalModel/HeadOfDepartmentModel";
import {MedicRegistrationModel} from "../../Entities/PersonalModel/MedicRegistratorModel";
import {PatientModel} from "../../Entities/PersonalModel/PatientModel";
import {SysAdminModel} from "../../Entities/PersonalModel/SysAdminModel";



export async function GetAllUsers(token): Promise<AllUsers>{
    let answer;
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
            answer = json;
        })
        .catch(e => {
            console.error(e);
        });
    let chiefsOfMedicine: ChiefOfMedicineModel[] = [];
    answer.chiefsOfMedicine.forEach(element => {chiefsOfMedicine.push(
        new ChiefOfMedicineModel(
            element.id, element.login, element.name,
            element.surname, element.patronymic, element.email,
            element.dateEmployment, element.dateDismissal,
            element.phoneNumber, element.dateBirthday, element.gender,
            element.Address, element.files, element.placeOfStudies,
            element.descriptionHeadOfDepartment, element.accessRights, element.Accept ))});
    let doctors: DoctorModel[] = [];
    answer.doctors.forEach(element => {doctors.push(
        new DoctorModel(element.id, element.login, element.name,
            element.surname, element.patronymic, element.email,
            element.dateEmployment, element.dateDismissal,
            element.phoneNumber, element.dateBirthday, element.department, element.gender,
            element.Address, element.files, element.placeOfStudies,
            element.descriptionHeadOfDepartment, element.accessRights, element.Accept ))});
    let headOfDepartments: HeadOfDepartmentModel[] = [];
    answer.headOfDepartments.forEach(element => {headOfDepartments.push(
        new HeadOfDepartmentModel(
            element.id, element.login, element.name,
            element.surname, element.patronymic, element.email,
            element.dateEmployment, element.dateDismissal,
            element.phoneNumber, element.dateBirthday, element.doctors, element.gender,
            element.Address, element.files, element.placeOfStudies,
            element.descriptionHeadOfDepartment, element.accessRights, element.Accept
        ))})
    let medicRegistrations: MedicRegistrationModel[] = [];
    answer.medicRegistrations.forEach(element => {medicRegistrations.push(
        new MedicRegistrationModel(
            element.id, element.login, element.name,
            element.surname, element.patronymic, element.email,
            element.dateEmployment, element.dateDismissal,
            element.phoneNumber, element.dateBirthday, element.doctors, element.gender,
            element.Address, element.files, element.placeOfStudies, element.accessRights, element.Accept
        ))})
    let patients: PatientModel[] = [];
    answer.patients.forEach(element => {patients.push(
        new PatientModel(
            element.id, element.login, element.name,
            element.surname, element.birthday, element.accept,
            element.gender, element.patronymic, element.email,
            element.phoneNumber, element.outpatientCards, element.researchAreas
        ))});
    let sysAdmins: SysAdminModel[] = [];
    answer.sysAdmins.forEach(element => {sysAdmins.push(
        new SysAdminModel(
            element.id, element.login, element.accept
        ))})
    result = new AllUsers(chiefsOfMedicine, doctors, headOfDepartments, medicRegistrations, patients, sysAdmins);
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