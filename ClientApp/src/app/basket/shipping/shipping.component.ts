import { ShippingService } from './../../services/shipping.service';
import { Component, OnInit } from '@angular/core';
import { ISaveShipping } from 'src/app/models/ISaveShipping';

@Component({
    selector: 'app-shipping',
    templateUrl: './shipping.component.html',
    styleUrls : ['./shipping.component.css']
})

export class ShippingComponent implements OnInit {
    constructor(private shippingService : ShippingService) { }
    shippingSave : ISaveShipping = {
        shippingCharge : 0,
        shppingMethod : '',
        address : {
            line1: '',
            line2:'',
            line3:'',
            city:'',
            zip:''
        }
    };
    ngOnInit() { }

    submit(){
        this.shippingService.addShipping(this.shippingSave).subscribe(res => {
            if(res != undefined && res != null)
                localStorage.setItem('shipping', JSON.stringify(res));
        });
    }


}