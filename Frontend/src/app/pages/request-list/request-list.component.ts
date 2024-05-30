import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProviderChildRequestDTO } from 'src/app/Types/Users/UserDetailsDto';
import { RequestService } from 'src/app/services/request.service';
import { UserService } from 'src/app/services/user.service';
import { IRequestData } from 'src/app/types/request/requestData.interface';

@Component({
  selector: 'app-request-list',
  templateUrl: './request-list.component.html',
  styleUrls: ['./request-list.component.css']
})
export class RequestListComponent implements OnInit {
  constructor(private requests:RequestService,private user:UserService,private router:Router)
  {}
  AllReqests:IRequestData[]|undefined
  ngOnInit() {
    this.requests.getAllRequestData().subscribe({
      next:(user)=>{
        this.AllReqests=user;
      },
      error:(error)=>{
        console.log("Api Call Failed",error)
      },
    })
  }
  DeleteRequest(e:HTMLElement,id:IRequestData)
  {
    this.user.DeleteRequest(id.id).subscribe(
      {
        next:(any)=>{
          e.remove();
          this.AllReqests?.splice(this.AllReqests.indexOf(id),1)
        },
        error:(error)=>{
          console.log("Api Call Failed",error)
        },
      }     
    );
  }
  Details(id:number)
  {
    this.router.navigateByUrl("/Request?id="+id);
  }
  changeStatus(status:'Rejected',data:IRequestData){
    this.requests.rejectRequest(
      {
        id:data?.id,
        status:status,
        requestText:data?.requestText || ''
      }
    ).subscribe(
      {
        next:()=>{console.log("Success");},
        error:()=>{console.log("Error");}
      }
    )
  }
  
}
