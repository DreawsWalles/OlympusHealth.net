import classes from "./Stub.module.css"

export function Stub(props){
    return(
        <div className={classes.contentStub}>
            <div className={`row ${classes.titleText}`}>
                <div  className={`col ${classes.textOne}`}>Ваш аккаунт не подтвержден</div>
            </div>
            <div className={`row ${classes.titleText}`}>
                <div className={`col ${classes.textTwo}`}>обратитесь к системному администратору</div>
            </div>
        </div>
    )
}