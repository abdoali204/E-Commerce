import { ToastrService } from 'ngx-toastr';
import { MaterialService } from './../../services/material.service';
import { PhotoService } from './../../services/photo.service';
import { IProductSave } from './../../models/productSave';
import { ProductService } from './../../services/product.service';
import { ProductCategoryService } from './../../services/product-category.service';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IProduct } from 'src/app/models/product';


@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})
export class ProductFormComponent implements OnInit {
  pageTitle : string = 'Product List';
  materials : any[] = [];

  product : IProductSave ={
    id :0,
    description : '',
    name: '',
    photos :{ 
      id : 0,
      fileName:''
      },
    price:0,
    categoryId: 0,
    rating : 0,
    inStock : true,
    materialId : 0
    
    };
  categories: any[];
  constructor(private catService : ProductCategoryService,
              private productService : ProductService,
              private toastrService : ToastrService,
              private materialService : MaterialService,
              private router : Router,
              private route : ActivatedRoute) {
                  route.params.subscribe(p=>{
                      this.product.id = +p['id'] || 0;
                })

               }

  ngOnInit() {
  
    this.catService.getCategories().subscribe(cats => this.categories = cats);
    this.materialService.getMaterials().subscribe(materials => this.materials = materials);
  
    if(this.product.id)
    {
        this.productService.getProduct(this.product.id).subscribe(product => this.setProduct(product));
  
    }
  }
  onCategoryChange(){
    this.product.categoryId = +this.product.categoryId;
  }

  onClick(message : number ) : void
  {
    if(message != null && message != undefined)
      {
        this.product.rating = message;
      }
  }
  submit(){
    var result$ = (this.product.id) ? this.productService.updateProduct(this.product) : this.productService.add(this.product);
    result$.subscribe(res =>{
      if(res != null && res != undefined)
      {
        this.toastrService.success("Data was saved sucessfuly","Success...")
      this.router.navigate(['products']);
      }
    });
   
  }
  setProduct(p : IProduct)
  {
    this.product.id = p.id;
    this.product.name = p.name;
    this.product.description = p.description;
    this.product.photos = p.photos;
    this.product.price = p.price;
    this.product.categoryId = p.category.id;
    this.product.rating = p.rating? p.rating : 0;
    this.product.materialId = p.material.id;
  }


  onMaterialChange(){
    this.product.materialId = +this.product.materialId;
  }

}
