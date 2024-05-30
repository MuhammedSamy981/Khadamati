import { Component, OnInit } from '@angular/core';
import UserReadDto from 'src/app/Types/Users/UserReadDto';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-userlist',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.css']
})
export class UserlistComponent implements OnInit{
  Admins:UserReadDto[]|undefined;
  constructor(private user:UserService)
  {
    
  }
  ngOnInit():void {
    this.user.getUsers().subscribe(
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
