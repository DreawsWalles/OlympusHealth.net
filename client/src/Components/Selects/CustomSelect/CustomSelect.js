import dropListDown from "../../Screens/Images/dropListDown.svg"

function SelectItem(props){
    const key = props.element.key;
    const value = props.element.name;
    const id = props.element.id;
    return(
        <option value={id.toString()} key={key.toString()}>{value}</option>
    )
}

export default function CustomSelect(props){
    const elements = props.genders;
    const list = elements.map((element) => <SelectItem element={element} />);
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
        <div className={"form-group"}>
            <select onChange={handleOnSelect} className={"select-css"} style={{ backgroundImage:`url(${dropListDown})` }} >
                <option selected>Выберите пол</option>
                {list}
            </select>
            <span className={"error-input"} id={props.idSpan}></span>
        </div>
    );

}