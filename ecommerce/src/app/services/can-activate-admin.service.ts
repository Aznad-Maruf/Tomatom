import { CanActivate } from '@angular/router';
import { CrudBackendService } from './../crud-backend.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CanActivateAdminService implements CanActivate{

  constructor(private backEnd: CrudBackendService) { }

  canActivate(){
    if(this.backEnd.isLoggedIn() && this.backEnd.isAdmin()) return true;
    return false;
  }

}
