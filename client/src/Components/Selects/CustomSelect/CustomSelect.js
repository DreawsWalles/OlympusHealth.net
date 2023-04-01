import classes from "./CustomSelect.module.css"
function SelectItem(props){
    const key = props.element.key;
    const value = props.element.name;
    const id = props.element.id;
    return(
        <option value={id.toString()} key={key.toString()}>{value}</option>
    )
}

export default function CustomSelect(props){
    const elements = props.elements;
    const list = elements.map((element) => <SelectItem element={element} />);
    const firstElem = props.FirstElement;
    function Hint(name, message){
        let element = document.getElementById(name);
        element.innerText = message;
    };
    function handleOnSelect(e){
        console.log(e.target.value);
        props.onChange(e.target.value);
        Hint(props.idSpan, "");
    }
    return(
        <div className={classes.formGroup}>
            <select onChange={handleOnSelect} className={`${classes.custom} form-control`} >
                <option selected>{firstElem}</option>
                {list}
            </select>
            <span className={classes.errorInput} id={props.idSpan}></span>
        </div>
    );

}