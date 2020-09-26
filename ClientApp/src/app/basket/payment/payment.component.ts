import { PaymentService } from './../../services/payment.service';
import { ISavePayment } from './../../models/ISavePayment';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {
  savePayment : ISavePayment = {
    amount : 0,
    date : '',
    id : 0
  };
  constructor(private paymentService: PaymentService) { }

  ngOnInit() {
  }
  submit(){
    this.paymentService.addPayment(this.savePayment).subscribe(res => {
      console.log(JSON.stringify(res));
    });
  }

}
