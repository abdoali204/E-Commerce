import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MaterialService {

  constructor(private http :HttpClient) { }
  getMaterials(): Observable<any>{
      return this.http.get("/api/materials");
  }
  getMaterial(id) : Observable<any>{
      return this.http.get("/api/materials/"+id);
  }
  addMaterial(material) : Observable<any>{
      return this.http.post("/api/materials",material);
  }
}
