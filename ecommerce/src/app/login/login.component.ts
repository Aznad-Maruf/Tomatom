import { Router, ActivatedRoute } from '@angular/router';
import { CrudBackendService } from './../crud-backend.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  constructor(
    private crudBackendService: CrudBackendService,
    private route: ActivatedRoute,
    private router: Router
    ) {}

  ngOnInit(): void {}

  onSubmit(form, table) {
    this.crudBackendService.url =
      this.crudBackendService.rootUrl + '/' + 'users';
    this.crudBackendService.getAll();
    let isSuccessful = this.crudBackendService.login(form.value);
    console.log(isSuccessful, "login");
    if(isSuccessful) this.router.navigate(['shopping-cart']);
  }
}
