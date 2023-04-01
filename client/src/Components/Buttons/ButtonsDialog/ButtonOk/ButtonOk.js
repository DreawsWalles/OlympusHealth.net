import ButtonGlobal from "../ButtonGlobal/ButtonGlobal";
import classes from "./ButtonOk.module.css"
export default function ButtonOk(props){
    function handleOnClick(){
        debugger
        props.setResult("Ok");
    }
    return(
        <div className={classes.content}>
            <ButtonGlobal onClick={handleOnClick} text={"Ok"} type={"usually"}/>
        </div>
    )
}