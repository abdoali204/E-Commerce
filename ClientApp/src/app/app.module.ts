import { AuthGuard } from './services/auth-guard.service';
import { AdminAuthGuard } from './services/admin-auth-guard.service';
import { OrderDetailsComponent } from './order/order-details/order-details.component';

import { ToastrModule } from 'ngx-toastr';
import { AppErrorHandler } from './app.error-handler';
import { OrderComponent } from './order/order.component';
import { ShippingService } from './services/shipping.service';
import { ShippingComponent } from './basket/shipping/shipping.component';
import { PaginationComponent } from './shared/pagination/pagination.component';
import { ProductCategoryService } from './services/product-category.service';
import { PhotoService } from './services/photo.service';
import { ProductService } from './services/product.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ProductComponent } from './product/product.component';
import { ProductDetailsComponent } from './product/product-details/product-details.component';
import { ProductFormComponent } from './product/product-form/product-form.component';
import { StarComponent } from './shared/star/star.component';
import { ViewProductComponent } from './product/view-product/view-product.component';
import { BasketComponent } from './basket/basket.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthModule } from '@auth0/auth0-angular';
import { OrderListComponent } from './order/order-list/order-list.component';




@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ProductComponent,
    ProductDetailsComponent,
    ProductFormComponent,
    StarComponent,
    ViewProductComponent,
    PaginationComponent,
    BasketComponent,
    ShippingComponent,
    OrderComponent,
    OrderDetailsComponent,
    OrderListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
   
    HttpClientModule,
    AuthModule.forRoot({
      domain: 'vegacourse.us.auth0.com',
      clientId: 'p2XJ30J1dCnOd58ZCfPVVq5uF2CMJjf2'
    }),
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: ProductComponent, pathMatch: 'full' },
      { path:'products', component : ProductComponent},
      { path:'products/new',component: ProductFormComponent ,canActivate : [AdminAuthGuard] },
      { path:'products/:id', component : ViewProductComponent },
      { path:'order',component : OrderComponent , canActivate : [AuthGuard]},
      { path:'order/list',component : OrderListComponent , canActivate : [AuthGuard]},
      { path:'order/:id',component : OrderDetailsComponent},
      { path:'basket',component : BasketComponent},
      { path:'shipping',component : ShippingComponent, canActivate: [AuthGuard]},
      { path:'products/edit/:id',component: ProductFormComponent,canActivate : [AdminAuthGuard] }
    
    ]),
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [
    ProductService,
    PhotoService,
    ProductCategoryService,
    ShippingService,
    AuthGuard,
    AdminAuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
