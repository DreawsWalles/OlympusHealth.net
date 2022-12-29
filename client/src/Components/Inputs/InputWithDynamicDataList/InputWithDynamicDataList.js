import {useState} from "react";

export default function InputWithDynamicDataList(props){
    const [options, setOptions] = useState([]);

    async function runSearch(event){
        debugger
        const data = await props.api(event.target.value);
        setOptions(data);
    }
    return(
        <div className={"col-7 input"}>
            <div className={"form-group"}>
                <input onChange={runSearch} list={props.list} type={"text"} className={props.className} id={props.id} placeholder={props.placeholder}/>
                <span className={"error-input"} id={props.idSpan}></span>
            </div>
            <datalist id={"country"}>
                {options.map((o) => (
                    <option value={o} />
                ))}
            </datalist>
        </div>
    )
}