import { ICartItem } from './../models/cartItem';
import { HttpClient } from '@angular/common/http';
import { NavBarComponent } from './../nav-bar/nav-bar.component';
import { map } from 'rxjs/operators';
import { CrudBackendService } from './../crud-backend.service';
import { Injectable, OnInit } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ShoppingCartService {
  productQuantity: any = {};
  private _url: string;
  private totalItems = new BehaviorSubject('information');
  private totalPrice = new BehaviorSubject('information');

  constructor(
    private backEnd: CrudBackendService,
    private http: HttpClient
    ) {}
  async OnInit() {
  }

  async getCartId() {
    if (localStorage.getItem('cartId')) return localStorage.getItem('cartId');
    this.backEnd.makeUrl('shoppingcart');

    var newCart: any = await this.backEnd.push({});
    var jsonCart = JSON.parse(newCart);
    console.log(jsonCart.id);
    let cartId = jsonCart.id;
    localStorage.setItem('cartId', cartId);

    console.log(cartId);

    return cartId;
  }

  cartIdExists() {
    return this.getCartId();
  }
  async getAddedItems() {
    if(!this.cartIdExists()) return null;
    this.backEnd.makeUrl('cartitem/' + await this.getCartId());
    var items = await this.backEnd.get();
    return items;
  }

  async getAddedItemsObservable(): Promise<Observable<ICartItem[]>>{
    if(!this.cartIdExists()) return null;
    this._url = this.backEnd.makeUrl('cartitem/' + await this.getCartId());
    console.log(this._url);
    return await this.http.get<ICartItem[]>(this._url);
  }

  getTotalItems(): Observable<string> {
    return this.totalItems.asObservable();
  }

  getTotalPrice(): Observable<string>{
    return this.totalPrice.asObservable();
  }


  async clearCart(){
    var items = await this.getAddedItems();
    for(let item of items){
      for(let i=1; i<=item.quantity; i++){
         await this.removeFromCart({id:item.productId})
      }
    }
    return;
  }

  async totalAddedItems(){
    //return 0;
    if(!this.cartIdExists()) return 0;
    var items = await this.getAddedItems();
    if(!items) return 0;
    let total = 0, totalPrice = 0;
    for(let item of items){
      total += item.quantity;
      totalPrice += item.quantity*item.product.price;
    }
    this.totalItems.next(total.toString());
    this.totalPrice.next(totalPrice.toString());
    return total;
  }

  async updateCartQuantity() {
    if(!this.cartIdExists()) return null;
    var items = await this.getAddedItems();
    if(!items) return null;
    console.log(items);

    for (let item of items) {
      console.log(item);
      this.productQuantity[item.productId] = item.quantity;
    }
    
    console.log(this.productQuantity);
    this.totalAddedItems();
  }

  async addToCart(product) {
    var tempProduct = {
      ProductId: product.id,
      ShoppingcartId: parseInt(await this.getCartId()),
    };
    this.backEnd.makeUrl('cartitem');
    await this.backEnd.push(tempProduct);
    await this.updateCartQuantity();
  }

  async removeFromCart(product) {
    var tempProduct = {
      ProductId: product.id,
      ShoppingCartId: parseInt(await this.getCartId()),
      Quantity: -1,
    };
    this.backEnd.makeUrl('cartitem');
    await this.backEnd.push(tempProduct);
    await this.updateCartQuantity();
  }
}

// @Injectable()
// export class TestService {
//   private info = new BehaviorSubject('information');

//   getInfo(): Observable<string> {
//     return this.info.asObservable();
//   }

//   getInfoValue(): string {
//     return this.info.getValue();
//   }

//   setInfo(val: string) {
//     this.info.next(val);
//   }
// }