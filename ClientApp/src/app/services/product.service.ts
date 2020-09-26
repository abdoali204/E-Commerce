import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { tap} from'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http : HttpClient) { }
  
  getProducts(filter) : Observable<any>{
    return this.http.get("/api/products"+ '?' + this.toQueryString(filter)).pipe(tap(data => JSON.stringify(data)));
  }
  add(product){
    return this.http.post("/api/products",product);
  }
  getProduct(id) : Observable<any>
  {
    return this.http.get(`/api/products/${id}`);
  }
  updateProduct(product) : Observable<any>
  {
    return this.http.put(`/api/products/${product.id}`,product);
  }
  removeProduct(product) : Observable<any>
  {
    return this.http.delete(`/api/products/${product.id}`);
  }

  toQueryString(obj){
    var parts = [];
    for(var prop in obj)
    {
      var value = obj[prop];
      if(value != null && value != undefined)
        parts.push(encodeURIComponent(prop)+ '=' + encodeURIComponent(value));
    }
    return parts.join('&');
  }
}
