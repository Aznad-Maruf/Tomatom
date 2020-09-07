import { IProduct } from './../../models/product';
import { CrudBackendService } from './../../crud-backend.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-products',
  templateUrl: './admin-products.component.html',
  styleUrls: ['./admin-products.component.css']
})
export class AdminProductsComponent implements OnInit {
  public products: IProduct[];
  private allProducts: IProduct[];
  constructor( 
    private backEnd: CrudBackendService
    ) 
    { }
  async ngOnInit() {
    this.backEnd.url = this.backEnd.rootUrl+"/"+"product"
    this.products = await this.backEnd.getAll();
    this.allProducts = this.products;
    console.log(this.products);
  }

  searchProducts(searchBy){
    console.log(searchBy);
    this.products = this.allProducts.filter(p=>p.name.toLowerCase().includes(searchBy.toLowerCase()));
  }

}
