import classes from "./Search.module.css";
import {ISearchProps} from "./ISearchProps";
export default function Search(props: ISearchProps){
    function expand() {
        let search = document.getElementById(classes.search);
        let input = document.getElementById(classes.input);
        if(search.classList.contains(classes.close)){
            search.classList.remove(classes.close);
            input.classList.remove(classes.square);
        }else {
            search.classList.add(classes.close);
            input.classList.add(classes.square);
        }
        input.value = "";
        props.onChange("");
    }
    function onChange(){
        let value = document.getElementById(classes.input).value
        props.onChange(value);
    }
    return(
        <div id={props.id} className={`${classes.content}`}>
            <input type="text" onChange={onChange} name="input" id={classes.input} className={classes.input} />
            <button onClick={expand} type="reset" id={classes.search} className={`${classes.search}`}></button>
        </div>
    )
}