import classes from "./Loader.module.css"
import type {ILoaderProps} from "./ILoaderProps";

export default function Loader(props: ILoaderProps){
    return(
        <div id={props.id} className={`${classes.preloader}, ${classes.none}, ${classes.position}`}>
            <div className={classes.preloader__row}>
                <div className={classes.preloader__item}></div>
                <div className={classes.preloader__item}></div>
            </div>
        </div>
    );
}