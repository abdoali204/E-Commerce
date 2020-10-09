import { AuthService } from './../services/auth.service';
import { ShippingService } from './../services/shipping.service';
import { BasketService } from './../services/basket.service';
import { ISaveBasket } from './../models/ISaveBasket';
import { ISaveOrder } from './../models/ISaveOrder';
import { IOrder } from './../models/IOrder';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { Component, OnInit, Input } from '@angular/core';
import { OrderService } from '../services/order.service';

@Component({
    selector: 'app-order',
    templateUrl: './order.component.html',
})
export class OrderComponent implements OnInit {
    options: number = 1;
    order : IOrder;
    orderSave : ISaveOrder = {
        id : 0,
        basket : {
            basketId : 0,
            basketItems : []
        },
        invoiceId : 0,
        shippingId : 0,
        totalAmount : 0,
        UserSessionId : ''
    }
    shippings : [];
    constructor(private orderService : OrderService,
                private router : Router,
                private auth : AuthService,
                private toastrService:ToastrService,
                private basketService : BasketService,
                private shippingService: ShippingService){
    }
    ngOnInit(): void {
        var storedOrder = localStorage.getItem('order');
        if(storedOrder != null && storedOrder != undefined){
            this.order = JSON.parse(storedOrder);
        }
    }
    onChangeOption(option: number){
        this.options = option;
    }
    shippingConfirm(id : number){
        if(id != null){
            this.orderSave.shippingId = id;
            
            this.orderSave.basket = this.basketService.basket;
            if(this.auth.profile.sub != null && this.auth.profile.sub != undefined){
                this.orderSave.UserSessionId = this.auth.profile.sub;
                console.log(JSON.stringify(this.orderSave));
                this.orderService.addOrder(this.orderSave).subscribe((order : IOrder)=>{
                    this.order = order;
                    this.toastrService.info("Order has been placed","Success..!");
                    this.router.navigate(['order/'+this.order.id]);
                });
            }
        }
        else
            this.toastrService.error("Error Occured In Shipping!","Shipping Error!");
    }
    setOrder(){
    }

}
