import classes from "./LoginInput.module.css"

export default function LoginInput(props){
    function Hint(name, message){
        let element = document.getElementById(name);
        element.innerText = message;
    };

    function handleChange(event){
        props.onChange(event.target.value)
        Hint(props.idSpan, "");
    }
    return(
        <div className={classes.formGroup}>
            <label className={classes.labelTitle}>{props.labelText}</label>
            <input onChange={handleChange} type={props.type} className={`form-control ${classes.textInput}`} id={props.id} placeholder={props.placeholder} required={props.required}/>
            <span className={classes.errorInput} id={props.idSpan}></span>
        </div>
    )
}