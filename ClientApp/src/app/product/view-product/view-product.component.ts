import { Router, ActivatedRoute } from '@angular/router';
import { ProductService } from './../../services/product.service';
import { IProduct } from 'src/app/models/product';
import { Component, OnInit, ElementRef, ViewChild, Input } from '@angular/core';
import { PhotoService } from 'src/app/services/photo.service';

@Component({
  selector: 'app-view-product',
  templateUrl: './view-product.component.html',
  styleUrls: ['./view-product.component.css']
})
export class ViewProductComponent implements OnInit {
  @ViewChild('fileInput',{static: false}) fileInput : ElementRef;
  options : number = 1;
  @Input() productId : number;
  photos : any[] = [];
  product : IProduct = {
    id : 0,
    name: '',
    category : {
      id : 0,
      name : ''
    },
    description : '',
    inStock : true,
    material : {
      id : 0,
      name : ''
    },
    photos: {
      fileName: '',
      id:0
    },
    price : 0,
    rating : 0
  }
  constructor(private photoService : PhotoService,
              private productService : ProductService,
              private router : Router,
              private route : ActivatedRoute) { 
                route.params.subscribe(p=>{
                  this.productId = +p['id'] || 0;
              });
            }
  ngOnInit() {
    if(this.productId)
      this.productService.getProduct(this.productId).subscribe(product => this.product = product);
  }
  onChangeOption(option) {
    this.options = option;
    if(option == 2)
    {
      this.photoService.getPhotos(this.product.id).subscribe(photos => this.photos= photos);
    }
  }
  displayUploadedImage(){
    var nativeElement : HTMLInputElement = this.fileInput.nativeElement;
    this.photoService.upload(this.product.id,nativeElement.files[0]).subscribe(photos=>
      this.photos.push(photos)
    );
}
  removePhoto(photoId) {
      this.photoService.remove(this.product.id, photoId).subscribe(res  => {
          var photoIndex = this.photos.find(ph => ph.id == res.id);
          this.photos.splice(photoIndex,1);
    })
}
removeProduct(){
  this.productService.removeProduct(this.product).subscribe(res=>{
      console.log("Data has been deleted Succesfully");
      this.router.navigate(['products']);
  });
}

}
