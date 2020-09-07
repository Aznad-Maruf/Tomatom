import { Router, ActivatedRoute } from '@angular/router';
import { CrudBackendService } from './../../crud-backend.service';
import { Component, OnInit } from '@angular/core';
import { delay } from 'rxjs/operators';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})


export class ProductFormComponent implements OnInit {

  constructor(
    private backEnd: CrudBackendService,
    private router: Router,
    private route: ActivatedRoute
    ) 
    { }
  categories: any;
  product = {id:"",name:"",price:"",categoryId:"",imageUrl:""};
  id: any;

  // categories = [
  //   {id:1,"name":"test"},
  //   {id:2,"name":"test2"},
    
  // ]

  

  async ngOnInit() {
    await this.init();
    console.log("in");
    // this.backEnd.url = this.backEnd.rootUrl+'/'+"category";
    // this.categories = this.backEnd.getAll();
    // delay(10000);
    // console.log(this.categories);
    // console.log("end Init");
  }

  async finishThis(){
    this.backEnd.url = await this.backEnd.rootUrl+'/'+"category";
    this.categories = await this.backEnd.getAll();
    console.log("after");
    return this.categories;
  }


  async init(){
    await this.finishThis();
    console.log(this.categories);
    this.id = this.route.snapshot.paramMap.get('id');
    
    if(this.id){
      this.backEnd.url = this.backEnd.rootUrl+'/'+'product/'+this.id.toString();
      this.product = await this.backEnd.get();
      console.log(this.product);
    }
  }

  async onSubmit(f:NgForm){
    //console.log("Inside form");
    f.value['categoryId'] = Number(f.value['categoryId']);
    console.log(f.value);
    if(this.id){
      this.backEnd.url = this.backEnd.rootUrl+'/'+'product/'+this.id.toString();
      await this.backEnd.put(f.value);
    }
    else{
      this.backEnd.url = this.backEnd.rootUrl+'/'+"product";
      await this.backEnd.register(f.value);
    }
    this.router.navigate(['admin/products']);
    
  }

  async onDelete(id){
    if(id!=""){
      if(!confirm("Are you sure you want to delete this Product?")) return;
      this.backEnd.url = this.backEnd.rootUrl+"/"+"product/"+id;
      await this.backEnd.delete();
      this.router.navigate(['admin/products']);
    }
  }

}