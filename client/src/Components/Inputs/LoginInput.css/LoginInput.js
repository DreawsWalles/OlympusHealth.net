

export default function ValidationInput(props){
    function Hint(name, message){
        let element = document.getElementById(name);
        element.innerText = message;
    };

    function handleChange(event){
        props.onChange(event.target.value)
        Hint(props.idSpan, "");
    }
    return(
        <div className={"classes.formGroup"}>
            <label className={"label-title"}>{props.labelText}</label>
            <input onChange={handleChange} type={props.type} className={"classes.textInput"} id={props.id} placeholder={props.placeholder} required={props.required}/>
            <span className={"error-input"} id={props.idSpan}></span>
        </div>
    )
}