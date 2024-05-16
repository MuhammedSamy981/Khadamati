import { Component, OnInit } from '@angular/core';
import { GetAllServicesDTO } from '../types/services/GetAllServicesDTO';
import { ServicesOfKhadamatiService } from '../services/services-of-khadamati.service';
import { NotificationService } from 'src/app/services/notification.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-services-list',
  templateUrl: './services-list.component.html',
  styleUrls: ['./services-list.component.css']
})
export class ServicesListComponent implements OnInit
 {
  services?:GetAllServicesDTO[];

  constructor(private UserService:UserService,
    private servicesOfKhadamatiService:ServicesOfKhadamatiService, 
    private notifications:NotificationService){}

  ngOnInit(): void {
    this.servicesOfKhadamatiService.getAll().subscribe({
      next:(services)=> {
        this.services=services;
        console.log(this.services);
      },
      error:(error)=>{
        console.error('Calling API failed',error);
      },
    })
  }
   Approve(service:GetAllServicesDTO,user:string):void {
    this.servicesOfKhadamatiService.Approve(service.id).subscribe
    (
      {
        next: (services)=>{
          console.log(services);
          const text=`Your service ${service.name} has been approved`  ;
          this.notifications.CreateNotification(text,user);
        }
        
      }
      
    )
  }

  DeleteService(e:HTMLElement,Service:GetAllServicesDTO)
  {
    
    if(confirm("Are you sure you want to delete ?"))
    {
      const text=`Your service ${Service.name} has been rejected and deleted`;
      this.notifications.CreateNotification(text,Service.providerId);
      this.UserService.DeleteService(Service.id).subscribe(
      {
        next:(any)=>{
         
          e.remove();
          this.services?.splice(this.services.indexOf(Service),1)
        },
        error:(error)=>{
          console.log("Api Call Failed",error)
        },
      }     
    );}
  }
}
