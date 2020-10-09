import { IBasket } from './IBasket';
export interface IOrder {
     id : number;
     date : string;
     totalPrice : number;
     totalAmount : number;
     state : string;
     invoice : {
         date : string;
     };
     shipping  : {
         shippingMethod : string;
         shippingCharge : number;
     };
     basket : IBasket;
}