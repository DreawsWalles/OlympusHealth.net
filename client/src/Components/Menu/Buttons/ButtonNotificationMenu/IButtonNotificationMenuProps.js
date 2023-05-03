export interface INotification{
    value: number,
    setValue();
    getValue();
}
export interface IButtonNotificationMenuProps extends INotification{
    Icon: string,
    HoverIcon: string,
    State: "Select" | "NotSelect",
    onClick(): () => {}
}