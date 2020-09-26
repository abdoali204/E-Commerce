import { ISaveBasket } from "./ISaveBasket";

export interface ISaveOrder{
    id: number;
    totalAmount: number;
    paymentId: number;
    invoiceId: number;
    shippingId: number;
    basket: ISaveBasket;
}
