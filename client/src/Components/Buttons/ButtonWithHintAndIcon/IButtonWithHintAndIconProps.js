import type {AttributeHint} from "../../Hint/AttributeHint";

export class AttributeIcon
{
    width: number;
    height: number | "auto";
    marginLeft: number | null;
    marginRight: number | null;
    constructor(width: number, height: number | "auto", marginLeft?: number, marginRight?: number) {
        this.width = width;
        this.height = height
        this.marginLeft = marginLeft;
        this.marginRight = marginRight
    }
}

export interface IButtonWithHintAndIconProps
{
    id?: number,
    width: number,
    iconEnable?: string,
    iconHover?: string,
    iconDisable?: string,
    attributeIcon: AttributeIcon,
    status: "Active" | "NotActive",
    isNeedHint: boolean,
    size?: "xs" | "s" | "m" | "L" | "XL" | null,
    theme?: "Circle" | "Square" | null,
    color?: "Red",
    onClick(): () => {},
    attributeHint?: AttributeHint,
}