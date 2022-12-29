import classes from "./PasswordInput.module.css"
export default function PasswordInput(props){
    function Hint(name, message){
        let element = document.getElementById(name);
        element.innerText = message;
    };
    function handleOnChange(e){
        props.onChange(e.target.value);
        Hint(props.idSpan, "")
    }
    function handleHidePassword(e){
        if(e.target.checked) {
            let element = document.getElementById(props.id);
            element.type = "text";
        }
        else{
            let element = document.getElementById(props.id);
            element.type = "password";
        }
    }
    return(
        <div className={classes.formGroup}>
            <input onChange={handleOnChange} type={"password"} className={`form-control ${classes.textInput}`} id={props.id} placeholder={props.placeholder} required={props.required} />
            <div className="form-check form-switch">
                <input onClick={handleHidePassword} className="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault" />
                <label className="form-check-label" htmlFor="flexSwitchCheckDefault">Показать пароль</label>
            </div>
            <span className={classes.errorInput} id={props.idSpan}></span>
        </div>
    )
}