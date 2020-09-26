import { PhotoService } from './photo.service';
import { IItem } from './../models/IItem';
import { IProduct } from './../models/product';
import { ISaveItem } from './../models/ISaveItem';
import { Observable } from 'rxjs';
import { IBasket } from './../models/IBasket';
import { ISaveBasket } from './../models/ISaveBasket';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({providedIn: 'root'})
export class BasketService {
    basket: IBasket = {
        basketId: 0,
        basketItems: [],
        totalItems : 0
    };
    saveBasket: ISaveBasket = {
        basketId: 0,
        basketItems : []
    };
  totalItems : number =0;
  constructor(private http : HttpClient,
              private photoService : PhotoService) {
      if(!this.isStoredBasket()){
          this.createBasket();
          console.log("Saved Basket Constructor Not True : " + JSON.stringify(this.saveBasket));
      }else{
      this.basket = JSON.parse(localStorage.getItem('basket'));
          this.setBasket(this.basket);
          console.log("Saved Basket Constructor  True : " + JSON.stringify(this.saveBasket));
      }
   }
   // Start of Crud Operations
  addBasket(basket:ISaveBasket){
     this.http.post<IBasket>("/api/baskets",basket).subscribe(basket  => {this.setBasket(basket)});
  }
  getBasket(id : number){
    return this.http.get<IBasket>("/api/baskets/"+id).subscribe(basket=> this.setBasket(basket));
  }
  updateBasket(id : number,basket : ISaveBasket){
    return this.http.put<IBasket>("/api/baskets/"+id,basket).subscribe(basket => {this.setBasket(basket);
    console.log(JSON.stringify(this.basket));
    
    });
  }
  deleteBasket(id: number){
     this.http.delete<IBasket>("/api/baskets/"+id).subscribe(basket => this.setBasket(basket));
  }
  // End Of Crud Operations
  createBasket(){  
      this.addBasket(this.saveBasket);
    };
  isStoredBasket() : boolean{
    if(localStorage.getItem('basket')== undefined && localStorage.getItem('basket') == null)
      return false;
      else
      return true;
  }
  addItemToBasket(product : IProduct){
    var item : ISaveItem= {
      id:0,
      productId : product.id,
      quantity : 1
      };
      if (this.isStoredBasket && item.productId != 0) {
        var itemIndex = this.isExistItem(item) ;
        if(itemIndex == -1){
          this.saveBasket.basketItems.push(item);
        }else{
          this.saveBasket.basketItems[itemIndex].quantity++;
        }
        console.log("Saved Basket Added Item Before : " + JSON.stringify(this.saveBasket));
        this.updateBasket(this.basket.basketId, this.saveBasket);
        console.log("Saved Basket added Item After : " + JSON.stringify(this.saveBasket));
    }
  }
  increaseItem(item){
    if(item != null && item != undefined && item.productId != null && item.productId != undefined && item.productId != 0){
      var itemIndex = this.isExistItem(item);
      if(itemIndex > -1){
        item.quantity++;
        this.saveBasket.basketItems[itemIndex].quantity = item.quantity;
        this.updateBasket(this.basket.basketId,this.saveBasket);
      }
    }
  }
  decreaseItem(item : IItem){
    if(item != null && item != undefined && item.productId != null && item.productId != undefined && item.productId != 0){
      var itemIndex = this.isExistItem(item);
      if(itemIndex > -1){
        if(this.saveBasket.basketItems[itemIndex].quantity > 0){
            if (this.basket.basketItems[itemIndex].quantity == 1) {
                this.saveBasket.basketItems.splice(itemIndex, 1);
              this.updateBasket(this.basket.basketId,this.saveBasket);
            }else{
            item.quantity--;
            this.saveBasket.basketItems[itemIndex].quantity = item.quantity;
            this.updateBasket(this.basket.basketId,this.saveBasket);
          }
        }
      }
  }
}
  removeItemFromBasket(product : IProduct){
    var item : ISaveItem= {
      id:0,
      productId : product.id,
      quantity : 1
    };
    if(this.isStoredBasket){
      var itemIndex = this.isExistItem(item) ;
      if(itemIndex == -1){
        this.saveBasket.basketItems.slice(itemIndex,1);
      }else{
        if(this.basket.basketItems.find(b => b.productId == item.productId).quantity >0){
            this.saveBasket.basketItems[itemIndex].quantity--;
        }
      }
      this.updateBasket(this.basket.basketId,this.saveBasket);
  }
}
  isExistItem(item): number{
    return this.saveBasket.basketItems.findIndex( sb => sb.productId == item.productId);
  }
  setBasket(basket : IBasket){
      this.basket = basket;
      this.basket.totalItems = this.basket.basketItems.length;
      this.saveBasket.basketId = basket.basketId;
      //remove not selected items
      this.saveBasket.basketItems.forEach((item: ISaveItem) => {
          var indexInBasket = this.basket.basketItems.findIndex(bi => bi.productId == item.productId);
          if (indexInBasket == -1) {
              this.saveBasket.basketItems.slice(indexInBasket, 1);
          }
      });
      //adding new items
      this.basket.basketItems.forEach((item: IItem) => {
          var indexInSaveBasket = this.saveBasket.basketItems.findIndex(sbi => sbi.productId == item.productId);
          if (indexInSaveBasket == -1) {
              this.saveBasket.basketItems.push({
                  id : item.id,
                  productId: item.productId,
                  quantity: item.quantity
              });
          }
      });
      //photo Section
      this.getPhotos();
    localStorage.setItem('basket',JSON.stringify(this.basket));
    
  }
  getPhotos(){
    this.basket.basketItems.forEach((item : IItem)=> {
      this.photoService.getPhotos(item.productId).subscribe(photos => {item.fileName = photos[0].fileName});
  });
  }
  getBasketFromStorage() : IBasket{
    return JSON.parse(localStorage.getItem('basket'));
  }
}
