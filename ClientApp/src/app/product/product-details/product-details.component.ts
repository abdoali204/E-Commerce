import { IProduct } from './../../models/product';
import { PhotoService } from './../../services/photo.service';
import { Component, OnInit, Input } from '@angular/core';
import { BasketService } from '../../services/basket.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  @Input() product : IProduct;
  pageTitle : string = "Product List";
  photos : any;
    constructor(private photoService: PhotoService,
                private basket : BasketService) { }

  ngOnInit() {
    if(this.product.id != null && this.product.id != undefined)
    {
      this.photoService.getPhotos(this.product.id).subscribe(photos => 
        {
          if(photos != null && photos != undefined && photos[0] != null && photos[0] != undefined)
            {
              console.log(photos[0].fileName+ "   OOO");
              this.photos = photos[0];
            }
         
        });
    }
  }
  onRatingClicked(message : string) : void {
    this.pageTitle = "Product List" + message;
  }
}
