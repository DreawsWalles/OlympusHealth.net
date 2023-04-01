import CustomCheckbox from "../CustomCheckbox/CustomCheckbox";
import classes from "./GlobalCheckbox.module.css";

export default function GlobalCheckbox(props){
    function handleClick(){
        let checkboxes = document.querySelectorAll('input[type=checkbox]');
        let globalCheckbox = document.getElementById("global");
        for(let i = 0; i < checkboxes.length - 1; i++){
            if(checkboxes.item(i).attributes[0].nodeValue !== "global"){
                checkboxes[i].checked = globalCheckbox.checked;
            }
        }
        props.setGlobalClick(globalCheckbox.checked);
    }
    return(
        <CustomCheckbox onClick={handleClick} id={props.id} size={props.size}/>
    )
}