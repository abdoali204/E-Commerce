import { IItem } from './../models/IItem';
import { PhotoService } from './../services/photo.service';

import { BasketService } from './../services/basket.service';
import { Component, OnInit } from '@angular/core';
import { IBasket } from '../models/IBasket';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent implements OnInit {
  constructor(private basket:BasketService,
              private photoService : PhotoService) { }

  ngOnInit() {

  }
}
