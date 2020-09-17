import { IProduct } from './../../models/product';
import { CrudBackendService } from './../../crud-backend.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import {Subject} from 'rxjs'

@Component({
  selector: 'app-admin-products',
  templateUrl: './admin-products.component.html',
  styleUrls: ['./admin-products.component.css']
})
export class AdminProductsComponent implements OnInit, OnDestroy {
  dtOptions: DataTables.Settings = {};
  dtTrigger = new Subject();
  public products: IProduct[];
  private allProducts: IProduct[];
  constructor( 
    private backEnd: CrudBackendService
    ) 
    { }
  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }
  async ngOnInit() {
    this.backEnd.url = this.backEnd.rootUrl+"/"+"product"
    this.products = await this.backEnd.getAll();
    this.allProducts = this.products;
    console.log(this.products);
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 2
    };
  }

  searchProducts(searchBy){
    console.log(searchBy);
    this.products = this.allProducts.filter(p=>p.name.toLowerCase().includes(searchBy.toLowerCase()));
  }

  // private extractData(res: Response) {
  //   const body = res.json();
  //   return body.data || {};
  // }

}
