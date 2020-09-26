import { IAddress } from './../models/IAddress';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ISaveShipping } from '../models/ISaveShipping';

@Injectable({providedIn: 'root'})
export class ShippingService {
    constructor(private http : HttpClient) { }
    addShipping(shipping : ISaveShipping){
        return this.http.post("/api/shippings",shipping);
    }
    getShipping(id){
        return this.http.get("/api/shippings/"+id);
    }
    updateShipping(id,shipping){
        return this.http.put("/api/shippings/"+id , shipping);
    }
    deleteShipping(id){
        return this.http.delete("/api/shippings/"+id);
    }
}