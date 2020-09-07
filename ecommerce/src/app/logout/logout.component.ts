import { CrudBackendService } from './../crud-backend.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

  constructor(private backEnd: CrudBackendService) { }

  ngOnInit(): void {
  }

}
