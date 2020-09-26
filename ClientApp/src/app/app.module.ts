import { OrderComponent } from './order/order.component';
import { PaymentService } from './services/payment.service';
import { ShippingService } from './services/shipping.service';
import { ShippingComponent } from './basket/shipping/shipping.component';
import { PaginationComponent } from './shared/pagination/pagination.component';
import { ProductCategoryService } from './services/product-category.service';
import { PhotoService } from './services/photo.service';
import { ProductService } from './services/product.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ProductComponent } from './product/product.component';
import { ProductDetailsComponent } from './product/product-details/product-details.component';
import { ProductFormComponent } from './product/product-form/product-form.component';
import { StarComponent } from './shared/star/star.component';
import { ViewProductComponent } from './product/view-product/view-product.component';
import { BasketComponent } from './basket/basket.component';
import { PaymentComponent } from './basket/payment/payment.component';





@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ProductComponent,
    ProductDetailsComponent,
    ProductFormComponent,
    StarComponent,
    ViewProductComponent,
    PaginationComponent,
    BasketComponent,
    ShippingComponent,
    PaymentComponent,
    OrderComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path:'products', component : ProductComponent},
      { path:'products/new',component: ProductFormComponent },
      { path:'products/:id', component : ViewProductComponent },
      { path:'order',component : OrderComponent},
      { path:'basket',component : BasketComponent},
      { path:'shipping',component : ShippingComponent},
      { path:'payment',component : PaymentComponent},
      { path:'products/edit/:id',component: ProductFormComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  providers: [
    ProductService,
    PhotoService,
    ProductCategoryService,
    ShippingService,
    PaymentService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
