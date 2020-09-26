export interface IProductSave
{
    id : number;
    name: string;
    description: string;
    price : number;
    rating : number;
    categoryId :number;
    photos : { 
        id : number;
        fileName : string;
     };
    inStock : boolean;
    materialId : number;
}