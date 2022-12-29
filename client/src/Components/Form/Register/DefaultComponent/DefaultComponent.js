import classes from "./DefaultComponent.module.css"

export default function DefaultComponent(props){
    return(
        <div className={classes.contentDefault}>
            <div className={`row ${classes.titleText}`}>
                <div  className={`col ${classes.textOne}`}>Регистрация</div>
            </div>
            <div className={`row ${classes.titleText}`}>
                <div className={`col ${classes.textTwo}`}>Выберите вид пользователя</div>
            </div>
        </div>
    )
}