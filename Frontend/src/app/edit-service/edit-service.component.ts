import { Component, OnInit } from '@angular/core';
import { ServicesOfKhadamatiService } from '../services/services-of-khadamati.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UpdateServiceDTO } from '../types/services/UpdateServiceDTO';
import { PicturesService } from '../services/pictures.service';
import { CategoryService } from '../services/category.service';
import { CategoryReadDTO } from '../types/category/CategoryReadDTO';
import { UpdatePictureDTO } from '../types/pictures/UpdatePictureDTO';

@Component({
  selector: 'app-edit-service',
  templateUrl: './edit-service.component.html',
  styleUrls: ['./edit-service.component.css']
})
export class EditServiceComponent implements OnInit {

 categoryId?:number;
 serviceId?:number;
 categories?:CategoryReadDTO[];
 categoryName:string="";

//images inputs
 selectedFiles: FileList[]=[];
currentFile?: File;
previews:string[]=[];
picIds:number[]=[];

 constructor(private servicesOfKhadamatiService:ServicesOfKhadamatiService,
  private picturesService:PicturesService,
  private activatedRoute:ActivatedRoute,
  private categoryService:CategoryService,
  private router:Router){}

  
  form=new FormGroup({
    name:new FormControl<string>('',[
      Validators.required,
      Validators.minLength(3),
    ]),
    price:new FormControl<number>(0,[
      Validators.required,
      Validators.min(3),
    ]),
    category:new FormControl<string>(''),
    location:new FormControl<string>('',[
      Validators.required,
    ]),
    description:new FormControl<string>('',
    [
      Validators.required,
    ]),
});

  ngOnInit(): void {

    this.categoryService.getAll().subscribe({
      next:(categories)=>{
        this.categories=categories;
      },
      error:(error)=>{
        console.error('Calling API failed',error);
      },
    });

    this.activatedRoute.paramMap.subscribe({
      next:(map)=> {
        this.serviceId=+map.get('id')!;
        this.servicesOfKhadamatiService.getDetailsById(this.serviceId).subscribe({
          next:(service)=> {
            this.form.patchValue(service);
            const pictures=service.pictures!;
            for(let i=0; i<pictures?.length!;i++)
            {
               this.picIds[i]=pictures[i].id;
               this.previews[i] = pictures[i].url as string;
            }
            console.log(service.categoryName);
            this.categoryName=service.categoryName;
          },
          error:(error)=> {
            console.error('Calling API failed',error);
          },
        })
      },
      error:(error)=> {
        console.error('This service was not found',error);
      },
    });

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

  EditService(e:Event):void
  {
    e.preventDefault();
    if(this.form.invalid) return;
    const service:UpdateServiceDTO=
    {
      id: this.serviceId!,
      name: this.form.value.name!,
      categoryId: this.categoryId!,
      price: this.form.value.price!,
      location: this.form.value.location!,
      description: this.form.value.description!
    }
    this.servicesOfKhadamatiService.update(service).subscribe({
      next:()=> {
        for(let i=0;i<this.previews.length;i++)
          {
             this.storeImages(i,this.serviceId!);
          }

        this.router.navigateByUrl("/service");
      },
      error:(error)=> {
        console.error('Calling API failed',error);     
      },
    })
  }

  
//images code start

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
  const picture:UpdatePictureDTO=
  {
    id:this.picIds[index],
    url: this.previews[index] as string,
    serviceId: servId
  };
  this.picturesService.update(picture).subscribe({
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
