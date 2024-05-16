import { Component, OnInit} from '@angular/core';
import { ServicesOfKhadamatiService } from '../services/services-of-khadamati.service';
import { GetSpecificServicesDetailsDTO } from '../types/services/GetSpecificServicesDetailsDTO';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-search-specific-services',
  templateUrl: './search-specific-services.component.html',
  styleUrls: ['./search-specific-services.component.css']
})
export class SearchSpecificServicesComponent implements OnInit {
  services?:GetSpecificServicesDetailsDTO[];
  currentPage:number = 1;
  sizeOfPage:number = 3;
  paginatedServices: GetSpecificServicesDetailsDTO[] = [];

  constructor(private servicesOfKhadamatiService:ServicesOfKhadamatiService
    ,private activatedRoute:ActivatedRoute) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params)=>
    {
      this.servicesOfKhadamatiService.getSpecificDetails(params['location'],params['category'])
      .subscribe({
        next:(services)=>{
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
    });
  }  



  GetData(paginatedData:any[])
  {
    this.paginatedServices=paginatedData;
    console.log(this.paginatedServices);
  }


}
