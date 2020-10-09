import { IAddress } from './IAddress';
export interface ISaveShipping{
    id : number;
    shppingMethod : string;
    shippingCharge : number;
    address : IAddress;
}