import {useEffect, useState} from "react";
import classes from "./UsersList.module.css";

import ButtonBack from "../../../../Buttons/ButtonsList/ButtonBack/ButtonBack";
import ButtonNext from "../../../../Buttons/ButtonsList/ButtonsNext/ButtonNext";
import classesButtonNext from "../../../../Buttons/ButtonsList/ButtonsNext/ButtonNext.module.css";
import classesButtonBack from "../../../../Buttons/ButtonsList/ButtonBack/ButtonBack.module.css";
import Row from "../Row/Row";

export default function UsersList(props){
    const [elements, setElements] = useState();
    const [list, setList] = useState();
    const [maxPage, setMaxPage] = useState();
    const [countElementOnOnePage, setCountElementOnOnePage] = useState();
    const [totalCount, setTotalCount] = useState();
    const [page, setPage] = useState(1);
    useEffect(() =>{
        (() =>{
            let elements = ConvertFromCurrentList();
            setTotalCount(elements.length);
            setElements(elements);
        })();
    }, [])

    function Contains(arr, element){
        for (let i = 0; i < arr.length; i++) {
            if (arr[i].key === element) {
                return true;
            }
        }
        return false;
    }
    useEffect(() => {
        (() => {
            if(props.oldList !== undefined && props.data !== undefined) {
                let oldCount = props.oldList.chiefsOfMedicine.length + props.oldList.doctors.length + props.oldList.headOfDepartments.length;
                oldCount += props.oldList.patients.length + props.oldList.sysAdmins.length + props.oldList.medicRegistrations.length;
                let newCount = props.data.chiefsOfMedicine.length + props.data.doctors.length + props.data.headOfDepartments.length;
                newCount += props.data.patients.length + props.data.sysAdmins.length + props.data.medicRegistrations.length;
                let elements = [];
                if (newCount > oldCount) {
                    elements = ConvertFromCurrentListWithOldList();
                } else {
                    elements = ConvertFromCurrentList();
                }
                setTotalCount(elements.length);
                setElements(elements);
            }else if(props.oldList === undefined && props.data !== undefined){
                let elements = ConvertFromCurrentList();
                setElements(elements);
            }
        })();
    },[props.oldList]);
    function ConvertFromCurrentList(){
        let elements = [];
        for(let i = 0; i < props.data.sysAdmins.length; i++){
            elements[elements.length] =
                {
                    key: props.data.sysAdmins[i].id,
                    login: props.data.sysAdmins[i].login,
                    role: 'Системный администратор',
                    accept: props.data.sysAdmins[i].accept
                };
        }
        for(let i = 0; i < props.data.chiefsOfMedicine.length; i++){
            elements[elements.length] =
                {
                    key: props.data.chiefsOfMedicine[i].id,
                    login: props.data.chiefsOfMedicine[i].login,
                    role: 'Главврач',
                    accept: props.data.chiefsOfMedicine[i].accept
                };
        }
        for(let i = 0; i < props.data.medicRegistrations.length; i++){
            elements[elements.length] =
                {
                    key: props.data.medicRegistrations[i].id,
                    login: props.data.medicRegistrations[i].login,
                    role: 'Медицинский регистратор',
                    accept: props.data.medicRegistrations[i].accept
                };
        }
        for(let i = 0; i < props.data.doctors.length; i++){
            elements[elements.length] =
                {
                    key: props.data.doctors[i].id,
                    login: props.data.doctors[i].login,
                    role: 'Врач',
                    accept: props.data.doctors[i].accept
                };
        }
        for(let i = 0; i < props.data.headOfDepartments.length; i++){
            elements[elements.length] =
                {
                    key: props.data.headOfDepartments[i].id,
                    login: props.data.headOfDepartments[i].login,
                    role: 'Заведующий отделением',
                    accept: props.data.headOfDepartments[i].accept
                };
        }
        for(let i = 0; i < props.data.patients.length; i++){
            elements[elements.length] =
                {
                    key: props.data.patients[i].id,
                    login: props.data.patients[i].login,
                    role: 'Пациент',
                    accept: props.data.patients[i].accept
                };
        }
        return elements;
    }
    function ConvertFromCurrentListWithOldList(){
        let elements = [];
        for (let i = 0; i < props.oldList.sysAdmins.length; i++) {
            elements[elements.length] =
                {
                    key: props.oldList.sysAdmins[i].id,
                    login: props.oldList.sysAdmins[i].login,
                    role: 'Системный администратор',
                    accept: props.oldList.sysAdmins[i].accept
                };
        }
        for (let i = 0; i < props.data.sysAdmins.length; i++) {
            if (!Contains(elements, props.data.sysAdmins[i].id)) {
                elements[elements.length] =
                    {
                        key: props.data.sysAdmins[i].id,
                        login: props.data.sysAdmins[i].login,
                        role: 'Системный администратор',
                        accept: props.data.sysAdmins[i].accept
                    };
            }
        }
        for (let i = 0; i < props.oldList.chiefsOfMedicine.length; i++) {
            elements[elements.length] =
                {
                    key: props.oldList.chiefsOfMedicine[i].id,
                    login: props.oldList.chiefsOfMedicine[i].login,
                    role: 'Главврач',
                    accept: props.oldList.chiefsOfMedicine[i].accept
                };
        }
        for (let i = 0; i < props.data.chiefsOfMedicine.length; i++) {
            if (!Contains(elements, props.data.chiefsOfMedicine[i].id)) {
                elements[elements.length] =
                    {
                        key: props.data.chiefsOfMedicine[i].id,
                        login: props.data.chiefsOfMedicine[i].login,
                        role: 'Главврач',
                        accept: props.data.chiefsOfMedicine[i].accept
                    };

            }
        }
        for (let i = 0; i < props.oldList.medicRegistrations.length; i++) {
            elements[elements.length] =
                {
                    key: props.oldList.medicRegistrations[i].id,
                    login: props.oldList.medicRegistrations[i].login,
                    role: 'Медицинский регистратор',
                    accept: props.oldList.medicRegistrations[i].accept
                };
        }
        for (let i = 0; i < props.data.medicRegistrations.length; i++) {
            if (!Contains(elements, props.data.medicRegistrations[i].id)) {
                elements[elements.length] =
                    {
                        key: props.data.medicRegistrations[i].id,
                        login: props.data.medicRegistrations[i].login,
                        role: 'Медицинский регистратор',
                        accept: props.data.medicRegistrations[i].accept
                    };
            }
        }
        for (let i = 0; i < props.oldList.doctors.length; i++) {
            elements[elements.length] =
                {
                    key: props.oldList.doctors[i].id,
                    login: props.oldList.doctors[i].login,
                    role: 'Врач',
                    accept: props.oldList.doctors[i].accept
                };
        }
        for (let i = 0; i < props.data.doctors.length; i++) {
            if (!Contains(elements, props.data.doctors[i].id)) {
                elements[elements.length] =
                    {
                        key: props.data.doctors[i].id,
                        login: props.data.doctors[i].login,
                        role: 'Врач',
                        accept: props.data.doctors[i].accept
                    };
            }
        }
        for (let i = 0; i < props.oldList.headOfDepartments.length; i++) {
            elements[elements.length] =
                {
                    key: props.oldList.headOfDepartments[i].id,
                    login: props.oldList.headOfDepartments[i].login,
                    role: 'Заведующий отделением',
                    accept: props.oldList.headOfDepartments[i].accept
                };
        }
        for (let i = 0; i < props.data.headOfDepartments.length; i++) {
            if (!Contains(elements, props.data.headOfDepartments[i].id)) {
                elements[elements.length] =
                    {
                        key: props.data.headOfDepartments[i].id,
                        login: props.data.headOfDepartments[i].login,
                        role: 'Заведующий отделением',
                        accept: props.data.headOfDepartments[i].accept
                    };
            }
        }
        for (let i = 0; i < props.oldList.patients.length; i++) {
            elements[elements.length] =
                {
                    key: props.oldList.patients[i].id,
                    login: props.oldList.patients[i].login,
                    role: 'Пациент',
                    accept: props.oldList.patients[i].accept
                };
        }
        for (let i = 0; i < props.data.patients.length; i++) {
            if (!Contains(elements, props.data.patients[i].id)) {
                elements[elements.length] =
                    {
                        key: props.data.patients[i].id,
                        login: props.data.patients[i].login,
                        role: 'Пациент',
                        accept: props.data.patients[i].accept
                    };
            }
        }
        return elements;
    }
    useEffect(() => {
        (() =>{
            if(totalCount !== undefined){
                console.log(countElementOnOnePage);
                let tmp = undefined;
                debugger
                if(countElementOnOnePage === undefined){
                    debugger
                    let elementList = document.getElementById(`${classes.list}`);
                    let elRow = document.getElementsByClassName("row-list")[0];
                    tmp = Math.round(elementList.clientHeight / 46) - 3;
                    setCountElementOnOnePage(tmp);
                }
                debugger
                tmp = tmp === undefined ? Math.ceil(totalCount / countElementOnOnePage) : Math.ceil(totalCount / tmp);
                setMaxPage(tmp);
            }
        })()
    }, [totalCount]);
    function SubArray(array, startIndex, endIndex){
        let result = [];
        for(let i = startIndex; i <= endIndex && i < array.length; i++){
            result[result.length] = array[i];
        }
        return result
    }
    useEffect(() => {
        (() =>{
            if(countElementOnOnePage !== undefined && elements !== undefined) {
                console.log(countElementOnOnePage);
                let tmp = SubArray(elements, countElementOnOnePage * (page - 1), countElementOnOnePage * page - 1);
                setList(undefined);
                setList(tmp.map((element) => <Row onClickCheckbox={props.onClickCheckBox} element={element}
                                                  blurNone={props.styleProperties.blurNone}
                                                  functionsMsgBox={props.functionsMsgBox}
                                                  onShowConfirm={props.onShowConfirm}/>));
            }
        })()
    }, [elements, countElementOnOnePage]);
    useEffect(() => {
        (() =>{
            if(maxPage !== undefined) {
                HandleWorkButtonNext(page < maxPage);
            }
        })()
    }, [maxPage]);
    function HandleOnClickButtonNext(){
        setPage(page + 1);
        let tmp = SubArray(elements, countElementOnOnePage * page, countElementOnOnePage * (page + 1) - 1);
        setList(tmp.map((element) => <Row onClickCheckbox={props.onClickCheckBox} element={element}
                                          blurNone={props.styleProperties.blurNone}
                                          functionsMsgBox={props.functionsMsgBox}
                                          onShowConfirm={props.onShowConfirm}/>));
        if(page + 1 === maxPage){
            HandleWorkButtonNext(false);
        }
        HandleWorkButtonBack(true);
    }
    function RedrawingСheckboxes(){
        let globalCheckbox = document.getElementById("global");
        let checkboxes = document.querySelectorAll('input[type=checkbox]');
        for(let i = 0; i < checkboxes.length - 1; i++){
            if(checkboxes.item(i).attributes[0].nodeValue !== "global"){
                checkboxes[i].checked = globalCheckbox.checked;
            }
        }
    }
    function HandleOnClickButtonBack() {
        setPage(page - 1);
        let tmp = SubArray(elements, countElementOnOnePage * (page - 2), countElementOnOnePage * (page - 1) - 1);
        setList(tmp.map((element) => <Row onClickCheckbox={props.onClickCheckBox} element={element}
                                          blurNone={props.styleProperties.blurNone}
                                          functionsMsgBox={props.functionsMsgBox}
                                          onShowConfirm={props.onShowConfirm}/>));
        HandleWorkButtonNext(true);
        if(page - 1 === 1 ){
            HandleWorkButtonBack(false);
        }
    }
    function HandleWorkButtonBack(isWork){
        let btnBack = document.getElementById(`${classes.buttonBack}`);
        if(isWork){
            if(!btnBack.classList.contains(`${classesButtonBack.active}`)){
                btnBack.classList.add(classesButtonBack.active);
            }
            if(btnBack.classList.contains(`${classesButtonBack.non_active}`)){
                btnBack.classList.remove(classesButtonBack.non_active);
            }
        }else{
            if(!btnBack.classList.contains(classesButtonBack.non_active)){
                btnBack.classList.add(classesButtonBack.non_active);
            }
            if(btnBack.classList.contains(classesButtonBack.active)){
                btnBack.classList.remove(classesButtonBack.active);
            }
        }
    }
    function HandleWorkButtonNext(isWork){
        if(isWork){
            let btnNext = document.getElementById(`${classes.buttonNext}`);
            if (!btnNext.classList.contains(classesButtonNext.active)) {
                btnNext.classList.add(classesButtonNext.active);
            }
            if (btnNext.classList.contains(classesButtonNext.non_active)) {
                btnNext.classList.remove(classesButtonNext.non_active)
            }
        }else{
            let btnNext = document.getElementById(`${classes.buttonNext}`);
            if (!btnNext.classList.contains(classesButtonNext.non_active)) {
                btnNext.classList.add(classesButtonNext.non_active);
            }
            if (btnNext.classList.contains(classesButtonNext.active)) {
                btnNext.classList.remove(classesButtonNext.active);
            }
        }
    }
    useEffect(() => {
        (() => {
            RedrawingСheckboxes();
        })()
    }, [list])
    return(
        <div id={classes.list} className={classes.content}>
            <div className={classes.list}>
                {list}
            </div>
            <div className={`row `}>
                <div className={`col ${classes.buttonBack}`}>
                    <ButtonBack id={classes.buttonBack} onClick={HandleOnClickButtonBack}/>
                </div>
                <div className={`col ${classes.buttonNext}`}>
                    <ButtonNext id={classes.buttonNext} onClick={HandleOnClickButtonNext}/>
                </div>
            </div>
        </div>

    )
}