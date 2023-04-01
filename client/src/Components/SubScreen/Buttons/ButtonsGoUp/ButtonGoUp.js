import classes from "./ButtonGoUp.module.css";
export default function ButtonGoUp(props){
    return(
        <div id={"btnGoUp"} onClick={props.onClick} className={`${classes.content} ${props.none}`}>
            <svg className={`${classes.iconSize}`} width="80" height="80" viewBox="0 0 80 80" fill="none" xmlns="http://www.w3.org/2000/svg">
                <path className={`${classes.iconColorMain}`} d="M0 40C0 62.0914 17.9086 80 40 80C62.0914 80 80 62.0914 80 40C80 17.9086 62.0914 0 40 0C17.9086 0 0 17.9086 0 40Z" fill="none"/>
                <path className={`${classes.iconColorBack}`} d="M40 72C22.36 72 8 57.64 8 40C8 22.36 22.36 8 40 8C57.64 8 72 22.36 72 40C72 57.64 57.64 72 40 72ZM40 80C62.08 80 80 62.08 80 40C80 17.92 62.08 0 40 0C17.92 0 0 17.92 0 40C0 62.08 17.92 80 40 80ZM36 40V56H44V40H56L40 24L24 40H36Z" fill="#A72036"/>
            </svg>
        </div>
    )
}