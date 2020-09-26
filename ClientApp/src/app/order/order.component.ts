import { Component, OnInit } from '@angular/core';
import { OrderService } from '../services/order.service';

@Component({
    selector: 'app-order',
    templateUrl: './order.component.html',
})
export class OrderComponent implements OnInit {
    options: number = 1;
    constructor(private orderService : OrderService){

    }
    ngOnInit(): void {
    }
    onChangeOption(option: number){
        this.options = option;
    }

}
