import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({providedIn: 'root'})
export class PaymentService {
    constructor(private http : HttpClient) { }
    addPayment(payment){
        return this.http.post("/api/Payments",payment);
    }
    getPayment(id){
        return this.http.get("/api/Payments/"+id);
    }
    updatePayment(id,payment){
        return this.http.put("/api/Payments/"+id,payment);
    }
    deletePayment(id){
        return this.http.delete("/api/Payments/"+id);
    }
}