import { CrudBackendService } from './../crud-backend.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  constructor(public backEnd: CrudBackendService) { }
  ngOnInit(): void {
  }

  userName = this.backEnd.userName();
  test(){
    console.log(this.userName);
    return true;
  }

  active: number = 1;

}
