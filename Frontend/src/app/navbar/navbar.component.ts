import { Component, Input, OnInit } from '@angular/core';

import { UserService } from '../services/user.service';
import { HelperService } from '../services/helper.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  @Input() LoggedIn=this.user.IsLoggedIn()
  constructor(public user:UserService, public helper:HelperService,private router:Router) {
  }
  ngOnInit(): void {
    console.log(this.user.CheackClaims());
    
  }
  LogOut(){
    this.user.Logout();
    window.location.reload();
  }
  LogIn(){
    this.helper.Redirect('/Login');
    return false;
  }
  checkLoggedIn():void
  {
    this.LoggedIn=this.user.IsLoggedIn()
  }
}

