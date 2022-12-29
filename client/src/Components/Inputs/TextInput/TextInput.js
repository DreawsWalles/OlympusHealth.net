export default function TextInput(props){
    function Hint(name, message){
        let element = document.getElementById(name);
        element.innerText = message;
    };
    function handleOnChange(e){
        props.onChange(e.target.value);
        Hint(props.idSpan, "")
    }
    return(
        <div className={"form-group"}>
            <input onChange={handleOnChange} type={props.type} className={props.className} id={props.id} placeholder={props.placeholder} required={props.required} />
            <span className={"error-input"} id={props.idSpan}></span>
        </div>
    )
}