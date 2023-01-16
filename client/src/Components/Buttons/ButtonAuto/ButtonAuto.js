import classes from "./Buttom.module.css"
export default function ButtonAuto(props){
    function handleOnClick(){
        let element = document.getElementById(props.id)
        if(element.classList.contains("btn-outline-success")){
            element.classList.add("btn-success");
            element.classList.remove("btn-outline-success");
            let refresh = document.getElementById(props.btnRefresh);
            refresh.classList.remove(classes.none);
            props.onClick(true);
            let input = document.getElementById(props.idInput)
            props.oldDataSet(input.value);
        }
        else{
            element.classList.remove("btn-success");
            element.classList.add("btn-outline-success");
            props.onClick(false);
            let refresh = document.getElementById(props.btnRefresh);
            refresh.classList.add(classes.none);
            document.getElementById(props.idInput).value = props.oldData;
        }
    }
    return(
        <button id={props.id} className={`btn ${classes.btnIsAuto} btn-outline-success`} onClick={handleOnClick}>auto</button>
    )
}