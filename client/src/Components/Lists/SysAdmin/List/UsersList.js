import {useEffect, useState} from "react";
import classes from "./UsersList.module.css";

import Row from "../Row/Row";
import {IUserListProps} from "./IUserListProps";
import {EntityRow} from "../EntityRow";
import {AllUsers} from "../../../../Swapi/SwapiSysAdmin/Entities";
import Button from "../../../Buttons/Button/Button";

export default function UsersList(props: IUserListProps){
    const ids = {
        buttonNext: 'userList-button-next',
        buttonBack: 'userList-button-back'
    }
    const buttonBackDisable = <Button id={ids.buttonBack}
                                              size={"L"}
                                              text={"<"}
                                              theme={"Disable"}
                                              isDisplay={true}
                                              onClick={() => {}} />;

    const buttonBackActive = <Button id={ids.buttonBack}
                                             size={"L"}
                                             text={"<"}
                                             theme={"Red"}
                                             isDisplay={true}
                                             onClick={onClickButtonBack} />;

    const buttonNextDisable = <Button id={ids.buttonNext}
                                              size={"L"}
                                              text={">"}
                                              theme={"Disable"}
                                              isDisplay={true}
                                              onClick={() => {}}/>;

    const buttonNextActive = <Button id={ids.buttonNext}
                                             size={"L"}
                                             text={">"}
                                             theme={"Red"}
                                             isDisplay={true}
                                             onClick={onClickButtonNext}/>;

    const [buttonBack, setButtonBack] = useState(buttonBackDisable);
    const [buttonNext, setButtonNext] = useState(buttonNextDisable)
    const [elements : EntityRow[], setElements] = useState();
    const [list, setList] = useState();
    const [maxPage, setMaxPage] = useState();
    const [countElementOnOnePage, setCountElementOnOnePage] = useState();
    const [totalCount, setTotalCount] = useState();
    const [page, setPage] = useState(1);
    useEffect(() =>{
        (() =>{
            let elements = ConvertFromList(props.currentData);
            setTotalCount(elements.length);
            setElements(elements);
        })();
    }, [])

    useEffect(() => {
        (() => {
            let elements = ConvertFromList(props.currentData);
            setTotalCount(elements.length);
            setElements(elements);
        })();
    },[props.currentData]);
    const ConvertFromList = (data: AllUsers, oldData: AllUsers = null): EntityRow[] => {
        let result: Set<EntityRow> = new Set();
        data.patients.forEach(element => result.add(new EntityRow(element)));
        data.doctors.forEach(element => result.add(new EntityRow(element)));
        data.sysAdmins.forEach(element => result.add(new EntityRow(element)));
        data.medicRegistrations.forEach(element => result.add(new EntityRow(element)));
        data.headOfDepartments.forEach(element => result.add(new EntityRow(element)))
        data.chiefsOfMedicine.forEach(element => result.add(new EntityRow(element)));
        return Array.from(result);
    }

    useEffect(() => {
        (() =>{
            if(totalCount !== undefined){
                console.log(countElementOnOnePage);
                let tmp = undefined;
                if(countElementOnOnePage === undefined){
                    let elementList = document.getElementById(props.id);
                    tmp = Math.round(elementList.clientHeight / 46) - 3;
                    setCountElementOnOnePage(tmp);
                }
                tmp = tmp === undefined ? Math.ceil(totalCount / countElementOnOnePage) : Math.ceil(totalCount / tmp);
                setMaxPage(tmp);
            }
        })()
    }, [totalCount]);
    const SubArray = (array: EntityRow[], startIndex: number, endIndex: number) => {
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
                setList(tmp.map((element) => <Row data={element}
                                                  actionMessageBox={props.actionMessageBox}
                                                  actionConfirm={props.actionConfirm}
                                                  clickOnCheckBox={clickOnCheckBox} />));
            }
        })()
    }, [elements, countElementOnOnePage]);
    useEffect(() => {
        (() =>{
            if(maxPage !== undefined) {
                RedrewButtonNext(page < maxPage);
            }
        })()
    }, [maxPage]);

    const clickOnCheckBox = (e) => {
        debugger
        e.checked = !e.checked;
        let tmp = document.getElementById(props.id);
        let checkBoxes =  tmp.querySelectorAll('input[type=checkbox]');
        let count = 0 ;
        checkBoxes.forEach((element) => {
            if(element.checked){
                count++;
            }
        })
        props.actionGlobalClick(count !== 0);
        document.getElementById(props.idGlobalCheckBox).checked = count === checkBoxes.length;
    }
    const RedrawingCheckboxes = () =>{
        let checkBoxes = document.getElementById(props.id).querySelectorAll(`input[type = checkbox]`);
        let globalCheckBox = document.getElementById(props.idGlobalCheckBox);
        if(globalCheckBox.checked){
            checkBoxes.forEach((element) => {
                element.checked = true;
            })
        }
    }
    function onClickButtonBack() {
        setPage(page - 1);
        let tmp = SubArray(elements, countElementOnOnePage * (page - 1), countElementOnOnePage * page - 1);
        setList(tmp.map((element) => <Row data={element}
                                          actionMessageBox={props.actionMessageBox}
                                          actionConfirm={props.actionConfirm}
                                          clickOnCheckBox={clickOnCheckBox}/>));
        RedrewButtonNext(true);
        if(page === 1 ){
            RedrewButtonBack(false);
        }
    }
    function onClickButtonNext(){
        setPage(page + 1);
        let tmp = SubArray(elements, countElementOnOnePage * page, countElementOnOnePage * (page + 1) - 1);
        setList(tmp.map((element) => <Row data={element}
                                          actionMessageBox={props.actionMessageBox}
                                          actionConfirm={props.actionConfirm}
                                          clickOnCheckBox={clickOnCheckBox}/>));
        if(page + 1 === maxPage){
            RedrewButtonNext(false);
        }
        RedrewButtonBack(true);
    }
    const RedrewButtonBack = (isWork: boolean) => {
        if(isWork){
            setButtonBack(buttonBackActive);
        }else{
            setButtonBack(buttonBackDisable);
        }
    }
    const RedrewButtonNext = (isWork: boolean) => {
        if(isWork){
            setButtonNext(buttonNextActive);
        }else{
            setButtonNext(buttonNextDisable);
        }
    }
    useEffect(() => {
        (() => {
            RedrawingCheckboxes();
        })()
    }, [list])
    return(
        <div className={classes.content}>
            <div id={props.id} className={classes.list}>
                {list}
            </div>
            <div className={`row ${classes.buttons}`}>
                <div className={`col`}></div>
                <div className={`col-2 ${classes.buttonBack}`}>
                    {buttonBack}
                </div>
                <div className={`col-1`}></div>
                <div className={`col-2 ${classes.buttonNext}`}>
                    {buttonNext}
                </div>
                <div className={`col`}></div>
            </div>
        </div>
    )
}