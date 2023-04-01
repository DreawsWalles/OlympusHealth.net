import classes from "./ButtonGoBack.module.css";
export default function ButtonGoBack(props){
    return(
        <div className={classes.content}>
            <svg className={`${classes.iconSize}`} width="80" height="80" viewBox="0 0 80 80" fill="none" xmlns="http://www.w3.org/2000/svg">
                <path className={`${classes.iconColorMain}`} d="M40 80C62.0914 80 80 62.0914 80 40C80 17.9086 62.0914 0 40 0C17.9086 0 0 17.9086 0 40C0 62.0914 17.9086 80 40 80Z" fill="none"/>
                <path className={`${classes.iconColorBack}`} d="M72 40C72 57.64 57.64 72 40 72C22.36 72 8 57.64 8 40C8 22.36 22.36 8 40 8C57.64 8 72 22.36 72
                         40ZM80 40C80 17.92 62.08 0 40 0C17.92 0 0 17.92 0 40C0 62.08 17.92 80 40 80C62.08 80 80 62.08 80
                         40ZM40 44H56V36H40V24L24 40L40 56V44Z" fill="black"/>
            </svg>
        </div>
    )
}