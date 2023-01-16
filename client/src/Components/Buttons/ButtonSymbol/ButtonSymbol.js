import classes from "../ButtonAuto/Buttom.module.css"


export default function ButtonSymbol(props){
    function handleOnClick(){
        props.setRefresh(!props.refresh);
    }
    return(
        <button id={props.id} className={`btn ${classes.btnIsAuto} btn-success ${classes.btnSymbol} ${classes.none}`} onClick={handleOnClick}>{props.Symbol}</button>
    )
}