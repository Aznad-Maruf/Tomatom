import { ICartItem } from './../models/cartItem';
import { ShoppingCartService } from './../services/shopping-cart.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {

  constructor(public cartService: ShoppingCartService) { }
  totalItems: number;
  totalPrice: number;
  items: ICartItem[];
  async ngOnInit() {
    await this.cartService.totalAddedItems();
    await this.cartService.getTotalItems().subscribe(response=>this.totalItems=parseInt(response));
    await this.cartService.getTotalPrice().subscribe(response=>{
      this.totalPrice = parseFloat(response);
    });

    await (await this.cartService.getAddedItemsObservable()).subscribe(response => {
      this.items = response;

      // console.log(this.items);
    });
    
  }



}
