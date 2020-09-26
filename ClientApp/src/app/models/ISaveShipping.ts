import { IAddress } from './IAddress';
export interface ISaveShipping{
    shppingMethod : string;
    shippingCharge : number;
    address : IAddress;
}