import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

import { setTheme } from 'ngx-bootstrap/utils';
import { User } from './models/User';
import { AccountService } from './services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Bug Byte';
  users: any;

  constructor(private http : HttpClient, private accountService : AccountService)
  {
    setTheme('bs4');
    this.setCurrentUser();
  }

  setCurrentUser() {
    const user : User =  JSON.parse(localStorage.getItem('user'));
    this.accountService.setCurrentUser(user);
  }

  ngOnInit(){
    this.http.get('https://localhost:5003/api/users').subscribe(
      response => {
        this.users = response;
        console.log(this.users);
      },
      error => {
        console.log(error);
      }

      );
  }
}
