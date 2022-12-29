import classes from "./TextInput.module.css"
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
        <div className={classes.formGroup}>
            <input onChange={handleOnChange} type={props.type}
                   className={`form-control ${classes.textInput}`}
                   id={props.id} placeholder={props.placeholder} required={props.required} />
            <span className={classes.errorInput} id={props.idSpan}></span>
        </div>
    )
}