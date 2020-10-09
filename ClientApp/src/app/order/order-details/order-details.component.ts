import { ToastrService } from 'ngx-toastr';
import { OrderService } from './../../services/order.service';
import { ActivatedRoute, Router } from '@angular/router';
import { IOrder } from './../../models/IOrder';
import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'app-order-detials',
    templateUrl: 'order-details.component.html'
})

export class OrderDetailsComponent implements OnInit {
    order : IOrder;
    orderId : number = 0;
    constructor(private router : Router,
                private route : ActivatedRoute,
                private orderSerivce : OrderService,
                private toastrService : ToastrService) {
                    route.params.subscribe(p => 
                        this.orderId = +p['id'] || 0 );
                 }

    ngOnInit() {
        console.log(this.orderId);
        if(this.orderId != 0)
            this.orderSerivce.getOrder(this.orderId).subscribe((order : IOrder)=> {
                console.log(JSON.stringify(order));
                this.order = order;
            });

     }
     removeOrder(){
         if(this.order.state.toLowerCase() == 'placed'){
             this.orderSerivce.deleteOrder(this.orderId)
             .subscribe(order => {
                this.toastrService.success("Order has been removed","Removed!");
                localStorage.removeItem('order');
                this.router.navigate(['/products']);
             });
         }
     }
}