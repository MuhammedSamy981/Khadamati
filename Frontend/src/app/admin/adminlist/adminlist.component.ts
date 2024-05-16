import { Component, OnInit } from '@angular/core';
import UserReadDto from 'src/app/Types/Users/UserReadDto';
import { NotificationService } from 'src/app/services/notification.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-adminlist',
  templateUrl: './adminlist.component.html',
  styleUrls: ['./adminlist.component.css']
})
export class AdminlistComponent implements OnInit{
  Admins:UserReadDto[]|undefined;
  constructor(private user:UserService)
  {
    
  }
  ngOnInit():void {
    this.user.getAdmins().subscribe(
      {
        next:(list)=>{
          this.Admins=list;
          console.log(list);
        },
        error:(err)=>{
          console.log(err);
        }
      }
    )
  }
  DeleteUser(id:string)
  {
    this.user.DeleteUser(id).subscribe(
      {
        next:()=>{
          console.log("Success!");
        },
        error:(err)=>{
          console.log("Fail!");
        }
      }
    )
  }
}
