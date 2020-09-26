import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductCategoryService {
  categories : any[];
  constructor(private http: HttpClient) { }
  getCategories() : Observable<any>{
    return this.http.get("/api/products/categories");
  }
}
