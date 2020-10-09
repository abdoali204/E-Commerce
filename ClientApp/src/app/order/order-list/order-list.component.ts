import { IOrder } from './../../models/IOrder';
import { AuthService } from './../../services/auth.service';
import { OrderService } from './../../services/order.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {
  orders : IOrder[] = [];
  constructor(private orderService : OrderService,
              private auth : AuthService) { }

    ngOnInit() {
        console.log(this.auth.profile.sub + " Subb");
    if(this.auth.loggedIn)
      this.orderService.getOrdersByUserId(this.auth.profile.sub).subscribe((order : IOrder[] )=> {
          if(order != null && order != undefined)
          this.orders = order;
        console.log(JSON.stringify(this.orders));
    });
  }

}
