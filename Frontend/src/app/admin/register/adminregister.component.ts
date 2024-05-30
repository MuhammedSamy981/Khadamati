import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import UserAddDTO from 'src/app/Types/Users/UserAddDto';
import { HelperService } from 'src/app/services/helper.service';
import { LocationsListService } from 'src/app/services/locations-list.service';
import { UserService } from 'src/app/services/user.service';
import Goverment from 'src/app/types/goverment/Goverment';

@Component({
  selector: 'app-register',
  templateUrl: './adminregister.component.html',
  styleUrls: ['./adminregister.component.css']
})
export class AdminRegisterComponent implements OnInit {
  DuplicateUsername:boolean = false;
  goverments:Goverment[] | undefined;
  Registerform=new FormGroup({
    userName: new FormControl<string>('',[
      Validators.required,
      Validators.minLength(3)
    ]
    ),
    password: new FormControl<string>('',[
      Validators.minLength(8),
      Validators.required
    ]
    ),
    phone: new FormControl<string>('',[
      Validators.minLength(12),
      Validators.required
    ]
    ),
    email: new FormControl<string>('',[
      Validators.email,
      Validators.required
    ]
    ),
    Location: new FormControl<string>('',[
      Validators.required
    ]
    )

  })

  constructor(private helper: HelperService, private user: UserService,private Loc:LocationsListService)
  {}
  ngOnInit(): void {
    this.goverments=this.Loc.Goverments;
  }
  Login():void{
    if(this.Registerform.invalid) return;
      const UserLogin : UserAddDTO={ 
        userName:this.Registerform.value.userName!,
        password:this.Registerform.value.password!,
        phone:this.Registerform.value.phone!,
        email:this.Registerform.value.email!,
        location:this.Registerform.value.Location!,
      }
    this.user.RegisterUser(UserLogin).subscribe(
      {
        next:(Utoken:any)=>
        {

        },
        error:(error)=>{
          this.DuplicateUsername= error["error"][0]["code"]=="DuplicateUserName";
        },
      }
    )
  }
}
