import { ToastrService } from 'ngx-toastr';
import { ShippingService } from './../../services/shipping.service';
import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { ISaveShipping } from 'src/app/models/ISaveShipping';

@Component({
    selector: 'app-shipping',
    templateUrl: './shipping.component.html',
    styleUrls : ['./shipping.component.css']
})

export class ShippingComponent implements OnInit {
    @Output() shippingClick = new EventEmitter<number>();
    constructor(private shippingService : ShippingService,
                private toastrService : ToastrService) { }
    shippingSave : ISaveShipping = {
        id: 0,
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
    ngOnInit() {
        var shippingStorage = JSON.parse(localStorage.getItem('shipping'));
        if(shippingStorage != null && shippingStorage != undefined){
            this.shippingSave = shippingStorage;
        }
     }
    submit(){
        var result$ = this.shippingSave.id == 0 ? this.shippingService.addShipping(this.shippingSave) : 
                                                  this.shippingService.updateShipping(this.shippingSave.id , this.shippingSave);
        result$.subscribe((res : ISaveShipping )=> {
            if(res != undefined && res != null)
            {
                this.toastrService.success(`Shipping data was saved.`,"Success...");
                localStorage.setItem('shipping', JSON.stringify(res));
                this.shippingClick.emit(res.id);
            }
            else
                this.shippingClick.emit(null);
        });
    }


}