import { CanActivateLoggedInService } from './services/can-activate-logged-in.service';
import { CanActivateAdminService } from './services/can-activate-admin.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router'

import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { HomeComponent } from './home/home.component';
import { ProductsComponent } from './products/products.component';
import { CheckOutComponent } from './check-out/check-out.component';
import { OrderSuccessComponent } from './order-success/order-success.component';
import { MyOrdersComponent } from './my-orders/my-orders.component';
import { AdminProductsComponent } from './admin/admin-products/admin-products.component';
import { AdminOrdersComponent } from './admin/admin-orders/admin-orders.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { LowerCaseDirective } from './lower-case.directive';
import { LogoutComponent } from './logout/logout.component';
import { ProductFormComponent } from './admin/product-form/product-form.component';
import {CustomFormsModule} from 'ng2-validation'

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    ShoppingCartComponent,
    HomeComponent,
    ProductsComponent,
    CheckOutComponent,
    OrderSuccessComponent,
    MyOrdersComponent,
    AdminProductsComponent,
    AdminOrdersComponent,
    LoginComponent,
    RegisterComponent,
    LowerCaseDirective,
    LogoutComponent,
    ProductFormComponent
  ],
  imports: [
    BrowserModule,
    NgbModule,
    HttpClientModule,
    FormsModule,
    CustomFormsModule,
    RouterModule.forRoot([
      {
        path: '',
        component: HomeComponent
      },
      {
        path: 'shopping-cart',
        component: ShoppingCartComponent,
      },
      {
        path: 'products',
        component: ProductsComponent
      },
      {
        path: 'my/checkout',
        component: CheckOutComponent,
        canActivate:[CanActivateLoggedInService]
      },
      {
        path: 'my/orders',
        component: MyOrdersComponent,
        canActivate:[CanActivateLoggedInService]
      },
      {
        path: 'my/order-success',
        component: OrderSuccessComponent
      },
      {
        path: 'login',
        component: LoginComponent
      },
      {
        path: 'register',
        component: RegisterComponent
      },
      {
        path: 'admin/products',
        component: AdminProductsComponent,
        canActivate: [CanActivateAdminService]
      },
      {
        path: 'admin/orders',
        component: AdminOrdersComponent,
        canActivate:[CanActivateAdminService]
      },
      {
        path: 'admin/products/new',
        component: ProductFormComponent,
        canActivate: [CanActivateAdminService]
      },
      {
        path: 'admin/products/:id',
        component: ProductFormComponent,
        canActivate: [CanActivateAdminService]
      }

    ])
  ],
  providers: [
    CanActivateAdminService,
    CanActivateLoggedInService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
