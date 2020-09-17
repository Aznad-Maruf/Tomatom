import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { GreaterThanValidator } from 'ng2-validation';
import {take} from 'rxjs/operators'

interface user {
  id;
  name;
  email;
  isAdmin;
  password;
  isDeleted;
}

@Injectable({
  providedIn: 'root',
})
export class CrudBackendService {
  constructor(private http: HttpClient, private router: Router) {
    this.rootUrl = 'http://localhost:50302/api';
  }
  users: any;
  rootUrl;
  url: string;
  token: any;

  getDecodedToken() {
    var encoded = localStorage.getItem('token');

    if (encoded == 'undefined') return null;
    const jwt = new JwtHelperService();
    var decoded = jwt.decodeToken(encoded);
    return decoded;
  }

  userName() {
    var decoded = this.getDecodedToken();
    if (decoded == null) return null;
    return this.getDecodedToken()['name'];
  }
  isAdmin() {
    var decoded = this.getDecodedToken();
    if (decoded == null) return null;
    return this.getDecodedToken()['isAdmin'];
  }

  async push(data) {
    console.log(data.value+"before post");
    await this.http.post(this.url, data).toPromise().then((response) => {
      
      this.data = response;
      // console.log(this.data+"inside");
    });
    console.log(JSON.stringify(this.data)+"after post");
    return JSON.stringify(this.data);
    // map((response) => {
    //   console.log(response);
    // });
  }
  cont = 0;
  async login(data) {
    //console.log(this.cont, this.users);
    var isMached = false;
    for (let user of this.users) {
      if (user.email == data['email'] && user.password == data['password']) {
        console.log('success');
        await this.http
          .post(this.rootUrl + '/' + 'login' + '/', data)
          .toPromise()
          .then((response) => {
            console.log(response);
            console.log(response['token']);
            this.token = response['token'];
            isMached = true;
            localStorage.clear();
            localStorage.setItem('token', this.token);
            console.log(isMached);
            return true;
          });
      }
      //console.log(user);
    }

    return isMached;
  }

  logOut() {
    localStorage.removeItem('token');
  }

  isLoggedIn() {
    if (localStorage.getItem('token') == null) return false;
    return true;
  }

  data: any;
  async getAll() {
    await this.http
      .get(this.url)
      .toPromise()
      .then((response) => {
        //console.log(response);
        console.log('test');
        this.data = response;
        // return this.data;
        console.log(this.data);

        //this.users = response;
        //console.log(this.users);
        //return this.users;
      });
      console.log("out")
      return this.data;
    
  }

  async get(){
    await this.http.get(this.url)
      .toPromise()
      .then(response=>{
        this.data = response;
      });
      return this.data;
  }

  async getObservable(){
    return await this.http.get(this.url);
  }

  async put(data){
    await this.http.put(this.url, data)
      .toPromise()
      .then(response=>{
        this.data = data;
      });
    return this.data;
  }

  async delete(){
    await this.http.delete(this.url)
    .toPromise()
    .then(response=>{
      this.data = response;
    })
    return this.data;
  }

  makeUrl(postfix){
    this.url = this.rootUrl + '/' + postfix;
    return this.url;
  }

  async getAddedItems(){
    this.makeUrl('cartitem/' + localStorage.getItem('cartId'));
    var items = await this.get();
    return items;
  }

}
