import { Component, OnInit } from '@angular/core';
import { GetAllServicesDetailsDTO } from '../types/services/GetAllServicesDetailsDTO';
import { ServicesOfKhadamatiService } from '../services/services-of-khadamati.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-services-list-for-clients',
  templateUrl: './services-list-for-clients.component.html',
  styleUrls: ['./services-list-for-clients.component.css']
})
export class ServicesListForClientsComponent implements OnInit {

  services?:GetAllServicesDetailsDTO[];
  totalRatings:number=0;
  currentPage:number = 1;
  sizeOfPage:number = 3;
  paginatedServices: GetAllServicesDetailsDTO[] = [];

  constructor(private servicesOfKhadamatiService:ServicesOfKhadamatiService
    ,private router:Router) {}

  ngOnInit(): void {
    this.servicesOfKhadamatiService.getAllDetails().subscribe({
      next:(services)=> {
        this.services=services;
        for(let i=0; i<services.length;i++)
        {
          if(services[i].ratings?.length!==0)
          {
           let sum=0;
           for(let j=0 ; j<services[i].ratings?.length! ;j++)
          {
             sum+=services[i].ratings![j].rating;
             console.log(services[i].ratings![j].rating+"**");
           }
           services[i].rating=sum/services[i].ratings?.length!;
           console.log(services[i].rating);
          }
          else
          {
            services[i].rating=0;
          }
        }
      },
      error:(error)=>{
        console.error('Calling API failed',error);
      },
    });
  }  

  GetData(paginatedData:any[])
  {
    this.paginatedServices=paginatedData;
    console.log(this.paginatedServices);
  }

  search(location:string,category:string): void 
  {
    if(location=="-Select-")
    {
      location="empty";
    }
    if(category=="-Select-")
    {
      category="empty";
    }

     this.router.navigateByUrl("/search/"+location+"/"+category);
  }

}
 