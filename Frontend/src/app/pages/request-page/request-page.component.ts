import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NotificationService } from 'src/app/services/notification.service';
import { RequestService } from 'src/app/services/request.service';
import { UserService } from 'src/app/services/user.service';
import { IRequestData } from 'src/app/types/request/requestData.interface';

@Component({
  selector: 'app-request-page',
  templateUrl: './request-page.component.html',
  styleUrls: ['./request-page.component.css']
})
export class RequestPageComponent implements OnInit{
  isAdmin:Boolean=this.user.IsAdmin();
  id:number = 2
  data:IRequestData|undefined
  constructor(private RequestService:RequestService, private req:ActivatedRoute,private user:UserService,private router:Router, private noti:NotificationService){}


  ngOnInit(): void {
    this.user.getUser().subscribe(
    {
      next:(user)=>{
        if(this.data?.userDetails.userName!==user.userName)
        {
          if(!this.isAdmin)
          {this.router.navigateByUrl("User");}
        }
      },
      error:(error)=>{
        console.log("Api Call Failed",error)
      },
    }
    )
    if(this.data?.providerDetails.providerName)
    {

    }

  this.req.queryParamMap.subscribe(params =>{this.id=parseInt(params.get("id")!);})
  console.log(this.id);
  this.request()
  }

  request(){
    this.RequestService.getRequestData(this.id).subscribe((res)=>{
      this.data = res[0]
      console.log(this.data)
    })
  }


  changeStatus(status:'Approved'|'Rejected'){
    this.RequestService.rejectRequest(
      {
        id:this.data?.id ||this.id,
        status:status,
        requestText:this.data?.requestText || ''
      }
    ).subscribe(
    {
      next:()=>{
        const text=`Your request for service ${this.data?.serviceDetails.name} has been ${status}`
        this.noti.CreateNotification(text,this.data?.userDetails.userID!)
        this.request()
      }
      
    }
    )
  }
  
}
