import {useState} from "react";
import classes from "./InputWithDynamicDataList.module.css"
export default function InputWithDynamicDataList(props){
    const [options, setOptions] = useState([]);

    async function runSearch(event){
        let value = event.target.value
        const data = await props.api(value);
        setOptions(data);
        props.setValue(value);
    }
    function handleInputBlur(event){
        debugger
        let tmp = options;
        let element = document.getElementById(props.id);
        for(let i = 0; i < options.length; i++){
            if(options[i].toLowerCase() === element.value.toLowerCase()){
                element.value = options[i];
                return;
            }
        }
    }
    return(
        <div className={"col-7 input"}>
            <div className={classes.formGroup}>
                <input onChange={runSearch} list={props.list}
                       type={"text"} className={`form-control ${classes.textInput}`}
                       id={props.id} placeholder={props.placeholder}
                       onBlur={handleInputBlur}/>
                <span className={classes.errorInput} id={props.idSpan}></span>
            </div>
            <datalist id={"country"}>
                {options.map((o) => (
                    <option value={o} />
                ))}
            </datalist>
        </div>
    )
}