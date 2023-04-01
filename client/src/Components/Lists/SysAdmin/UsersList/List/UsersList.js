import {useEffect, useState} from "react";
import classes from "./UsersList.module.css";
import ButtonBack from "../../../Buttons/ButtonsList/ButtonBack/ButtonBack";
import ButtonNext from "../../../Buttons/ButtonsList/ButtonsNext/ButtonNext";
import classesButtonNext from "../../../Buttons/ButtonsList/ButtonsNext/ButtonNext.module.css";
function Element(props){
    debugger
    return(
        <div>
            {props.element.role}
        </div>)
}

export default function UsersList(props){
    const [elements, setElements] = useState();
    const [list, setList] = useState();
    const [maxPage, setMaxPage] = useState();
    const [countElementOnOnePage, setCountElementOnOnePage] = useState();
    const [totalCount, setTotalCount] = useState();
    useEffect(() =>{
        (() =>{
            let elements = [];
            for(let i = 0; i < props.data.sysAdmins.length; i++){
                elements[elements.length] =
                    {
                        key: props.data.sysAdmins[i].id,
                        login: props.data.sysAdmins[i].login,
                        role: 'Системный администратор'
                    };
            }
            for(let i = 0; i < props.data.chiefsOfMedicine.length; i++){
                elements[elements.length] =
                    {
                        key: props.data.chiefsOfMedicine[i].id,
                        login: props.data.chiefsOfMedicine[i].login,
                        role: 'Главврач'
                    };
            }
            for(let i = 0; i < props.data.medicRegistrators.length; i++){
                elements[elements.length] =
                    {
                        key: props.data.medicRegistrators[i].id,
                        login: props.data.medicRegistrators[i].login,
                        role: 'Медицинский регистратор'
                    };
            }
            for(let i = 0; i < props.data.doctors.length; i++){
                elements[elements.length] =
                    {
                        key: props.data.doctors[i].id,
                        login: props.data.doctors[i].login,
                        role: 'Врач'
                    };
            }
            for(let i = 0; i < props.data.headOfDepartments.length; i++){
                elements[elements.length] =
                    {
                        key: props.data.headOfDepartments[i].id,
                        login: props.data.headOfDepartments[i].login,
                        role: 'Заведующий отделением'
                    };
            }
            for(let i = 0; i < props.data.patients.length; i++){
                elements[elements.length] =
                    {
                        key: props.data.patients[i].id,
                        login: props.data.patients[i].login,
                        role: 'Пациент'
                    };
            }
            setTotalCount(elements.length);
            setElements(elements);
        })();
    }, [])

    useEffect(() => {
        (() => {
            let elements = [];
             if(props.oldList !== undefined){
                 for(let i = 0; i < props.oldList.sysAdmins.length; i++){
                     elements[elements.length] =
                         {
                             key: props.oldList.sysAdmins[i].id,
                             login: props.oldList.sysAdmins[i].login,
                             role: 'Системный администратор'
                         };
                 }
                 for(let i = props.data.sysAdmins.length - 1; i >= props.oldList.sysAdmins.length; i--){
                     elements[elements.length] =
                         {
                             key: props.data.sysAdmins[i].id,
                             login: props.data.sysAdmins[i].login,
                             role: 'Системный администратор'
                         };
                 }
                 for(let i = 0; i < props.oldList.chiefsOfMedicine.length; i++){
                     elements[elements.length] =
                         {
                             key: props.oldList.chiefsOfMedicine[i].id,
                             login: props.oldList.chiefsOfMedicine[i].login,
                             role: 'Главврач'
                         };
                 }
                 for(let i = props.data.chiefsOfMedicine.length - 1; i >= props.oldList.chiefsOfMedicine.length; i--){
                     elements[elements.length] =
                         {
                             key: props.data.chiefsOfMedicine[i].id,
                             login: props.data.chiefsOfMedicine[i].login,
                             role: 'Главврач'
                         };
                 }
                 for(let i = 0; i < props.oldList.medicRegistrators.length; i++){
                     elements[elements.length] =
                         {
                             key: props.oldList.medicRegistrators[i].id,
                             login: props.oldList.medicRegistrators[i].login,
                             role: 'Медицинский регистратор'
                         };
                 }
                 for(let i = props.data.medicRegistrators.length - 1; i >= props.oldList.medicRegistrators.length; i--){
                     elements[elements.length] =
                         {
                             key: props.data.medicRegistrators[i].id,
                             login: props.data.medicRegistrators[i].login,
                             role: 'Медицинский регистратор'
                         };
                 }
                 for(let i = 0; i < props.oldList.doctors.length; i++){
                     elements[elements.length] =
                         {
                             key: props.oldList.doctors[i].id,
                             login: props.oldList.doctors[i].login,
                             role: 'Врач'
                         };
                 }
                 for(let i = props.data.doctors.length - 1; i >= props.oldList.doctors.length; i--){
                     elements[elements.length] =
                         {
                             key: props.data.doctors[i].id,
                             login: props.data.doctors[i].login,
                             role: 'Врач'
                         };
                 }
                 for(let i = 0; i < props.oldList.headOfDepartments.length; i++){
                     elements[elements.length] =
                         {
                             key: props.oldList.headOfDepartments[i].id,
                             login: props.oldList.headOfDepartments[i].login,
                             role: 'Заведующий отделением'
                         };
                 }
                 for(let i = props.data.headOfDepartments.length - 1; i >= props.oldList.headOfDepartments.length; i--){
                     elements[elements.length] =
                         {
                             key: props.data.headOfDepartments[i].id,
                             login: props.data.headOfDepartments[i].login,
                             role: 'Заведующий отделением'
                         };
                 }
                 for(let i = 0; i < props.oldList.patients.length; i++){
                     elements[elements.length] =
                         {
                             key: props.oldList.patients[i].id,
                             login: props.oldList.patients[i].login,
                             role: 'Пациент'
                         };
                 }
                 for(let i = props.data.patients.length - 1; i >= props.oldList.patients.length; i--){
                     elements[elements.length] =
                         {
                             key: props.data.patients[i].id,
                             login: props.data.patients[i].login,
                             role: 'Пациент'
                         };
                 }
                 debugger
                 setTotalCount(elements.length);
                 setElements(elements);
             }
        })();
    },[props.oldList]);

    useEffect(() => {
        (() =>{
            if(totalCount !== undefined){
                let elementList = document.getElementById(`${classes.list}`);
                let tmp = Math.round(elementList.clientHeight / 30);
                setCountElementOnOnePage(tmp);
                tmp = Math.ceil(totalCount / tmp);
                setMaxPage(tmp);
            }
        })()
    }, [totalCount]);
    useEffect(() => {
        (() =>{
            if(maxPage !== undefined) {
                if (props.page > maxPage) {
                    let btnNext = document.getElementById(`${classes.buttonNext}`);
                    if (!btnNext.classList.contains(classesButtonNext.active)) {
                        btnNext.classList.add(classesButtonNext.active);
                    }
                    if (btnNext.classList.contains(classesButtonNext.non_active)) {
                        btnNext.classList.remove(classesButtonNext.non_active)
                    }
                } else {
                    let btnNext = document.getElementById(`${classes.buttonNext}`);
                    if (!btnNext.classList.contains(classesButtonNext.non_active)) {
                        btnNext.classList.add(classesButtonNext.non_active);
                    }
                    if (btnNext.classList.contains(classesButtonNext.active)) {
                        btnNext.classList.remove(classesButtonNext.active);
                    }
                }
                debugger
                setList(elements.map((element) => <Element element={element} />));
            }
        })()
    }, [maxPage]);
    return(
        <div id={classes.list} className={classes.content}>
            <div className={classes.list}>
                {list}
            </div>
            <div className={`row ${classes.buttons}`}>
                <div className={`col ${classes.buttonBack}`}><ButtonBack id={classes.buttonBack} /></div>
                <div className={`col ${classes.buttonNext}`}><ButtonNext id={classes.buttonNext} /></div>
            </div>
        </div>

    )
}