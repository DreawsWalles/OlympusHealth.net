import {IInputWithSelectProps} from "./IInputWithSelectProps";
import classes from "./InputWithSelect.module.css";
import classesElement from "./ElementDataList/ElementSelect.module.css"
import {useState} from "react";
import {Hint} from "../../Functions";
import {Element} from "./ElementDataList/Element";
import {ChoiceElement as MultiChoice} from "./ElementChoice/ModeMulti/ChoiceElement";
import {ChoiceElement as SingleChoice} from "./ElementChoice/ModeSingle/ChoiceElement";

export function InputWithSelect(props: IInputWithSelectProps){
    const [list, setList] = useState();
    const [options: string[], setOptions] = useState();
    const [listBtn: [], setListBtn] = useState([]);
    const [buttons: [], setButtons] = useState([]);
    const [singleButton, setSingleButton]= useState(null);
    const onChange =  async (e) => {
        let data: [] = await props.funcGetData(e.target.value);
        let element = document.getElementById(`${props.id}-list`);
        if (data.length === 0 ){
            element.classList.remove(classes.openDataList);
            element.classList.add(classes.closeDataList);
        }else{
            element.classList.remove(classes.closeDataList);
            element.classList.add(classes.openDataList);
        }
        setOptions(data);
        setList(data.map((element, index) => <Element value={element}
                                                        id={index}
                                                        fontSize={props.fontSize}/>));
    }
    function onBlur(){
        let element = document.getElementById(props.id);
        if(element.value === ""){
            return;
        }
        try {
            options.forEach(node => {
                if (node.toLowerCase() === element.value.toLowerCase()) {
                    element.value = node;
                }
            })
        }
        catch
        {
            try {
                options.forEach(node => {
                    if (node === element.value) {
                        element.value = node;
                    }
                })
            }
            catch
            {
                Hint(props.idError, "Некорректный ввод");
            }
        }
        debugger
        let list : HTMLElement = document.getElementById(`${props.id}-list`);
        list.classList.remove(classes.openDataList);
        list.classList.add(classes.closeDataList);
        list.childNodes.forEach(element => {
            element.classList.remove(classesElement.open);
            element.classList.add(classesElement.close);
        });
        let value: string = element.value;
        props.mode === "Multi" ? addButton(value) : createButton(value);
    }
    const clickOnRemoveSelectMulti = (e) => {
        let elementBtn = document.getElementById(e);
        let tmp = [];
        buttons.forEach(element => {
            if(element !== elementBtn.innerHTML){
                tmp.push(element);
            }
        });
        setButtons(tmp);
        setListBtn(tmp.map((element, index) => <MultiChoice fontSize={null}
                                                              width={"col-2"}
                                                              id={`${props.id}-${index}`}
                                                              text={element}
                                                              onClick={clickOnRemoveSelectMulti}/>));
        props.setValue(buttons);
        props.actionAfterInput(buttons);
    }
    const clickOnRemoveSelectSingle = (e) => {
        let element = document.getElementById(props.id);
        element.value = e;
        element.classList.remove(classes.none);
        setSingleButton(null);
        props.setValue("");
        props.actionAfterInput("");
        element.focus();
    }
    const addButton = (text: string) => {
        document.getElementById(props.id).value = "";
        for(let i = 0; i < buttons.length; i++){
            if(buttons[i] === text){
                Hint(props.idError, "Данное значение уже добавлено ранеее");
                return;
            }
        }
        buttons.push(text);
        setListBtn(buttons.map((element, index) => <MultiChoice fontSize={null}
                                                                  width={"col-2"}
                                                                  id={`${props.id}-${index}`}
                                                                  text={element}
                                                                  onClick={clickOnRemoveSelectMulti}/>));
        props.setValue(buttons);
        props.actionAfterInput(buttons);
    }
    const createButton = (text: string)=>{
        let element = document.getElementById(props.id);
        element.value = "";
        element.classList.add(classes.none);
        setSingleButton(<SingleChoice fontSize={null}
                                       height={props.height}
                                       id={`${props.id}-0`}
                                       text={text}
                                       onClick={clickOnRemoveSelectSingle}/>)
        props.setValue(text);
        props.actionAfterInput(text);
    }
    function onClick(e){
        if(e.target.classList.contains(classesElement.element)){
            let element = document.getElementById(props.id);
            element.value = e.target.innerHTML;
            Hint(props.idError, "");
        }
    }
    async function onFocus (e){
        let data: [] = await props.funcGetData(e.target.value);
        Hint(props.idError, "");
        let element = document.getElementById(`${props.id}-list`);
        if (data.length === 0 ){
            element.classList.remove(classes.openDataList);
            element.classList.add(classes.closeDataList);
        }else{
            element.classList.remove(classes.closeDataList);
            element.classList.add(classes.openDataList);
            element.childNodes.forEach(element => {
                element.classList.add(classesElement.open);
                element.classList.remove(classesElement.close);
            })
        }
        setOptions(data);
        setList(data.map((element, index) => <Element value={element}
                                                      id={index}
                                                      fontSize={props.fontSize}/>));
    }
    return(
        <div className={`${classes.content}`}
             onClick={onClick}>
            {
                props.mode === "Multi" ?
                    <div style={{minHeight: `${props.height}px`}}
                         className={`row ${classes.containerInput}`}>
                        {listBtn}
                        <div className={`${buttons.length === 0? `col-12` : `col-4`} ${classes.input}`}>
                            <input id={props.id}
                                   style={{minHeight: `${props.height}px`,
                                       fontSize: props.fontSize === null ? ``: `${props.fontSize}px`,
                                       marginLeft: listBtn.length === 0 ? `-15px` : '-15px',
                                       width: buttons.length === 0 ? `100%` : `auto`}}
                                   className={`${classes.input}`}
                                   placeholder={props.placeholder}
                                   onChange={onChange}
                                   onBlur={(e) => {
                                       setTimeout(function (){onBlur();}, 200);}}
                                   onFocus={onFocus}
                                   autoComplete={"off"}
                            />
                        </div>
                    </div>
                    :
                    <div style={{minHeight: `${props.height}px`,
                                padding: singleButton === null ? '' : '0'}}
                         className={`row ${classes.containerInput}`}>
                        <input id={props.id}
                               style={{minHeight: `${props.height}px`,
                                   fontSize: props.fontSize === null ? ``: `${props.fontSize}px`,
                                   marginLeft: '-5px',
                                   width: `100%`}}
                               className={`${classes.input}`}
                               placeholder={props.placeholder}
                               onChange={onChange}
                               onBlur={(e) => {
                                   setTimeout(function (){onBlur();}, 200);}}
                               onFocus={onFocus}
                               autoComplete={"off"}
                        />
                        {singleButton}
                    </div>
            }
            <span className={classes.errorInput} id={props.idError} tabIndex={1}></span>
            <div id={`${props.id}-list`}
                 className={`${classes.datalist} ${classes.closeDataList}`} tabIndex={1}>
                {list}
            </div>
        </div>
    )
}