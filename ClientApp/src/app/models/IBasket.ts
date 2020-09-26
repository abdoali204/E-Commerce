import { IItem } from './IItem';
export interface IBasket{
    basketId : number;
    basketItems : IItem[];
    totalItems: number;
}