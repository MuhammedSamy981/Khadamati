import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { UserChildServicesDTO } from 'src/app/Types/Users/UserDetailsDto';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-services',
  templateUrl: './user-services.component.html',
  styleUrls: ['./user-services.component.css']
})
export class UserServicesComponent {
  @Input() userServices: UserChildServicesDTO[]|undefined ;
  constructor(private UserService: UserService,private router:Router)
  {

  }
  DeleteService(e:HTMLElement,Service:UserChildServicesDTO)
  {
    if(confirm("Are you sure you want to delete ?"))
    {this.UserService.DeleteService(Service.id).subscribe(
      {
        next:(any)=>{
         
          e.remove();
          this.userServices?.splice(this.userServices.indexOf(Service),1)
        },
        error:(error)=>{
          console.log("Api Call Failed",error)
        },
      }     
    );}
  }
  Details(id:number)
  {
    this.router.navigateByUrl("/service/"+id);
  }
  EditService(id:number)
  {
    this.router.navigateByUrl("/service/edit/"+id);
  }
}
