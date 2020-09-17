import { ShoppingCartService } from './../services/shopping-cart.service';
import { ActivatedRoute, Router } from '@angular/router';
import { IProduct } from './../models/product';
import { CrudBackendService } from './../crud-backend.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'],
})
export class ProductsComponent implements OnInit {
  constructor(
    private cartService: ShoppingCartService,
    private backEnd: CrudBackendService,
    private route: ActivatedRoute,
    private router: Router
  ) {}
  products: any;
  allProducts: any;
  categories: any;
  selectedCategory: string = 'AllCategories';
  async ngOnInit() {
    // this.router.navigate(['/'], { queryParams: { category: 'AllCategories' } });

    this.backEnd.url = this.backEnd.rootUrl + '/' + 'product';
    this.products = await this.backEnd.getAll();
    this.allProducts = this.products;

    this.backEnd.url = this.backEnd.rootUrl + '/' + 'category';
    this.categories = await this.backEnd.getAll();

    this.route.queryParamMap.subscribe((params) => {
      this.selectedCategory = params.get('category');
      if (
        this.selectedCategory == null ||
        this.selectedCategory == 'AllCategories'
      )
        this.products = this.allProducts;
      else
        this.products = this.allProducts.filter(
          (p) => p.category.name == this.selectedCategory
        );
    });
  
    this.cartService.updateCartQuantity();
  
  }

  async updateCart(product){
    this.backEnd.makeUrl('cartitem');
    await this.backEnd.push(product);

    
    this.cartService.updateCartQuantity();
  }

  async removeFromCart(product){
    let cartId = localStorage.getItem('cartId');
    var tempProduct = {
      ProductId: product.id,
      ShoppingCartId: parseInt(cartId),
      Quantity: -1
    };
    await this.updateCart(tempProduct);
  }

  async addToCart(product) {
    let cartId = localStorage.getItem('cartId');

    console.log(cartId);
    if (!cartId) {
      this.backEnd.makeUrl('shoppingcart');

      var newCart: any = await this.backEnd.push(product);
      var jsonCart = JSON.parse(newCart);
      console.log(jsonCart.id);
      cartId = jsonCart.id;
      localStorage.setItem('cartId', cartId);
    }
    console.log(product.id, cartId);
    var tempProduct = {
      ProductId: product.id,
      ShoppingCartId: parseInt(cartId),
    };
    await this.updateCart(tempProduct);
  }
}
