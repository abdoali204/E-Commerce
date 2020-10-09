import { ISaveBasket } from "./ISaveBasket";

export interface ISaveOrder{
    id: number;
    totalAmount: number;
    invoiceId: number;
    shippingId: number;
    UserSessionId : string;
    basket: ISaveBasket;
}
