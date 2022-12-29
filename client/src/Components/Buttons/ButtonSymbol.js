import "../../style.css"


export default function ButtonSymbol(props){
    function handleOnClick(){
        props.setRefresh(!props.refresh);
    }
    return(
        <button id={props.id} className={"btn btn-IsAuto btn-success none btn-symbol"} onClick={handleOnClick}>{props.Symbol}</button>
    )
}