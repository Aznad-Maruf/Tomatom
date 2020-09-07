import { CrudBackendService } from './../crud-backend.service';
import { FormValidationService } from './../form-validation.service';
import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(
    private crudBackendService: CrudBackendService, 
    private route: ActivatedRoute,
    private router: Router
    ) { }

  ngOnInit(): void {
  }

  onSubmit(form){
    console.log(form.value);
    this.crudBackendService.url = this.crudBackendService.rootUrl + '/' + 'users';
    this.crudBackendService.register(form.value);
    this.router.navigate(['login']);
  }

  test(v){
    console.log(v);
  }


}
