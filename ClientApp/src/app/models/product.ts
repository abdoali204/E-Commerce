export interface IProduct
{
    id : number;
    name: string;
    description: string;
    price : number;
    rating : number;
    category : {
        id: number;
        name : string;
    };
    photos : { 
        id : number;
        fileName : string;
     },
    inStock : boolean;
    material: {
        id : number;
        name : string;
    };

}