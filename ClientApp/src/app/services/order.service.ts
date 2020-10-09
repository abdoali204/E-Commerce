import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({providedIn: 'root'})
export class OrderService {
    constructor(private http :HttpClient) { }
    addOrder(order){
        return this.http.post("/api/orders",order);
    }
    getOrder(id){
        return this.http.get("/api/orders/"+id);
    }
    getOrdersByUserId(userId){
        return this.http.get("/api/orders/userOrders/"+userId);
    }
    updateOrder(id,order){
        return this.http.put("/api/orders/"+id,order);
    }
    deleteOrder(id){
        return this.http.delete("/api/orders/"+id);
    }
}
