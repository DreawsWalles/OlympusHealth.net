import classes from "./Loader.module.css"

export default function Loader(props){
    return(
        <div id={"load"} className={`${classes.preloader}, ${classes.none}`}>
            <div className={classes.preloader__row}>
                <div className={classes.preloader__item}></div>
                <div className={classes.preloader__item}></div>
            </div>
        </div>
    );
}