import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { RequestService } from 'src/app/services/request.service';
import { UserService } from 'src/app/services/user.service';


@Component({
  selector: 'app-add-request',
  templateUrl: './add-request.component.html',
  styleUrls: ['./add-request.component.css']
})
export class AddRequestComponent {
  @Input() serviceId = 0
  @Input() providerId: string = ""
  requestText: string = ""
  status: string = ""

  constructor(private RequestService: RequestService,private userService:UserService,private router:Router) { }
  addRequest() {
    
    if(!this.userService.IsLoggedIn())
    {
      this.router.navigateByUrl("/Login");
    }else
    {
      this.RequestService.addRequestData(
        {
          userId: this.userService.GetUserId()!,
          serviceId: this.serviceId,
          providerId: this.providerId,
          requestText: this.requestText,
          status: this.status = "waiting",
        }).subscribe()
    }
    
  }
}
