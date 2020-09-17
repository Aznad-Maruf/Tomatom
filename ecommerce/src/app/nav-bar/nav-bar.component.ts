import { TestService } from './../test.service';
import { ICartItem } from './../models/cartItem';
import { Observable } from 'rxjs';
import { ShoppingCartService } from './../services/shopping-cart.service';
import { CrudBackendService } from './../crud-backend.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  totalItems:number;
  testString: string;
  constructor(
    public backEnd: CrudBackendService,
    public cartService: ShoppingCartService,
    public testService: TestService
    
    ) { }
  async ngOnInit() {
    var cart$ = await this.cartService.getAddedItemsObservable();
    console.log(cart$);
    var items:any;
    // cart$.subscribe((response: ICartItem[])=>{
    //   this.totalItems = 0;
    //   //items = response;
    //   console.log(response);
    //   for(let item of response){
    //     console.log("item", item.quantity);
    //     this.totalItems += item.quantity;
    //   }
    //   console.log(this.totalItems);
    // });

    // Test it
    var test$ = this.testService.getInfo();
    test$.subscribe(response=>{
      console.log("Test: "+response);
    })

    var totalItems$ = this.cartService.getTotalItems()
                            .subscribe(response=>{
                              console.log("works?: "+response);
                              this.totalItems = parseInt(response);
                            });


  }

  testIt(){
    this.testService.setInfo("abc");
  }

  // async update(){
  //   var cart$ = await this.cartService.getAddedItemsObservable();
  //   var items:any;
  //   cart$.subscribe((response: any)=>{
  //     this.totalItems = 0;
  //     //items = response;
  //     for(let item of response){
  //       this.totalItems += item.quantity;
  //     }
  //     console.log(this.totalItems);
  //   });
  // }

  userName = this.backEnd.userName();
  test(){
    console.log(this.userName);
    return true;
  }

  active: number = 1;

}
