import { Router } from '@angular/router';
import { BasketService } from './../services/basket.service';
import { ProductCategoryService } from './../services/product-category.service';
import { ProductService } from './../services/product.service';
import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  private readonly PAGE_SIZE = 10;
  query : any = {
    pageSize : this.PAGE_SIZE
  }
  categories = [];
  queryResult : any = {};

  products : any[];
  constructor(private productService: ProductService,
              private categoryService: ProductCategoryService,
              private auth: AuthService,
              private router : Router) { }
  
  ngOnInit() {
   this.populateProducts();
   this.categoryService.getCategories().subscribe(cats => this.categories = cats);
  }
  onFilterChange(cat : string)
  {
    this.query.categoryName = cat;
    console.log("Filter "+ JSON.stringify(this.query));
    this.query.page = 1;
    this.query.pageSize = this.PAGE_SIZE;
    this.populateProducts();
  }
  resetFilters(){
    this.query = {};
    this.query.page = {
      pageSize : this.PAGE_SIZE,
      page:1
    };
    this.populateProducts();
  }
  private populateProducts(){
    this.productService.getProducts(this.query)
    .subscribe(result => this.queryResult = result);
  }
  onPageChange(page){
    this.query.page = page;
    this.populateProducts();
  }
  sortBy(sortBy){
    if(this.query.sortBy === sortBy)
    {
        this.query.isSortAscending = !this.query.isSortAscending;
    }
    else{
      this.query.categoryName = sortBy;
      this.query.isSortAscending = true;
    }
    console.log(JSON.stringify(this.query));
    this.populateProducts();
  }
  
}
