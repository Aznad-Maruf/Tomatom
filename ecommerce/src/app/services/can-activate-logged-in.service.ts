import { CrudBackendService } from './../crud-backend.service';
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class CanActivateLoggedInService implements CanActivate{

  constructor(private backEnd: CrudBackendService) { }
  canActivate(){
    if(this.backEnd.isLoggedIn())return true;
    return false;
  }
}
