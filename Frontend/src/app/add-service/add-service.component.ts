import { Component, OnInit } from '@angular/core';
import { ServicesOfKhadamatiService } from '../services/services-of-khadamati.service';
import { Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AddServiceDTO } from '../types/services/AddServiceDTO';
import { PicturesService } from '../services/pictures.service';
import { AddPictureDTO } from '../types/pictures/AddPictureDTO';
import { CategoryService } from '../services/category.service';
import { CategoryReadDTO } from '../types/category/CategoryReadDTO';
import { UserService } from 'src/app/services/user.service';
import { LocationsListService } from 'src/app/services/locations-list.service';

@Component({
  selector: 'app-add-service',
  templateUrl: './add-service.component.html',
  styleUrls: ['./add-service.component.css']
})
export class AddServiceComponent implements OnInit {

  categoryId:number=0;
  categories?:CategoryReadDTO[];
 constructor(private servicesOfKhadamatiService:ServicesOfKhadamatiService,
  private picturesService:PicturesService,
  private categoryService:CategoryService,
  private router:Router,private user:UserService
  ,public loc:LocationsListService){}

ngOnInit(): void {
    this.categoryService.getAll().subscribe({
      next:(categories)=>{
        this.categories=categories;
        console.log(this.categories);
      },
      error:(error)=>{
        console.error('Calling API failed',error);
      },
    })
}

onChange():void
{
  for(let c of this.categories!)
  {
    if(c.name==this.form.controls.category.value)
    {
      this.categoryId=c.id;
    }
  }
}


form=new FormGroup({
    name:new FormControl<string>('',[
      Validators.required,
      Validators.minLength(3),
    ]),
    price:new FormControl<number>(0,[
      Validators.required,
      Validators.min(3),
    ]),
    category:new FormControl<string>('',[
      Validators.required,
    ]),
    location:new FormControl<string>('',[
      Validators.required,
    ]),
    description:new FormControl<string>('',
    [
      Validators.required,
    ]),
});
  
  
AddService(e:Event):void
{
  e.preventDefault();
  if(this.form.invalid) return;
  const service:AddServiceDTO=
  {
    name: this.form.value.name!,
    categoryId: this.categoryId!,
    price: this.form.value.price!,
    location: this.form.value.location!,
    description: this.form.value.description!,
    //replace providerId with Id from user after login
    providerId: this.user.GetUserId()!,
  };
  this.servicesOfKhadamatiService.add(service).subscribe({
    next:()=> {

      this.servicesOfKhadamatiService.getAll().subscribe({
        next:(services)=> {
          for(let i=0;i<this.previews.length;i++)
          {
            this.storeImages(i, services[services.length-1].id);
          }
        }
      });
      
      this.router.navigateByUrl("/User");
    },
    error:(error)=> {
      console.error('Calling API failed',error);

    },
  })
}

//images code start
selectedFiles: FileList[]=[];
currentFile?: File;
preview:string='';
previews:string[]=[];

onImageUpload1(event: any): void {
   this.imageUpload(event,0);
}

onImageUpload2(event: any): void {
  this.imageUpload(event,1);
}

onImageUpload3(event: any): void {
this.imageUpload(event,2);
}

onImageUpload4(event: any): void {
this.imageUpload(event,3);
}


imageUpload(event: any,index:number): void {
  this.previews[index] = '';
  this.selectedFiles[index] = event.target.files;
  if (this.selectedFiles[index]) {
    const file: File | null = this.selectedFiles[index].item(0);

    if (file) {
     this.previews[index] = '';
      this.currentFile = file;
      const reader = new FileReader();
  
      reader.onload = (e: any) => {
       this.previews[index] = e.target.result;
        if(this.previews[index].includes("image")){
          console.log(this.previews[index]);
        }
      };
      reader.readAsDataURL(this.currentFile);
    }
  }
}

storeImages(index:number,servId:number):void
{
  if(!this.previews[index].includes("image"))
  {
     return;
  }
  const picture:AddPictureDTO=
  {
    url:this.previews[index] as string,
    serviceId:servId
  };
  this.picturesService.add(picture).subscribe({
    next:()=> {
      console.log("picture "+(index+1)+" was added");
    },
    error:(err)=> {
      console.error("picture "+(index+1)+" was not correct format",err);
    },
  });
}
//images codes end

}

