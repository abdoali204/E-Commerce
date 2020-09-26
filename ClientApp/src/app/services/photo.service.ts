import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {

  constructor(private http: HttpClient) { }
  getPhotos(productId) : Observable<any>{
    return this.http.get(`/api/products/${productId}/photos`);
    }
    upload(productId, file): Observable<any>{
    var formData = new FormData();
    formData.append('file',file);
     return this.http.post(`/api/products/${productId}/photos`,formData);
    }
    remove(productId, photoId): Observable<any>{
    return this.http.delete(`/api/products/${productId}/photos/${photoId}`);
  }
}
