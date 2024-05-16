import { Component } from '@angular/core';
import { ServicesOfKhadamatiService } from '../services/services-of-khadamati.service';
import { ActivatedRoute, Router } from '@angular/router';
import { GetServiceByIdDTO } from '../types/services/GetServiceByIdDTO';

@Component({
  selector: 'app-delete-service',
  templateUrl: './delete-service.component.html',
  styleUrls: ['./delete-service.component.css']
})
export class DeleteServiceComponent {
  serviceId?:number;
  service?:GetServiceByIdDTO;
  constructor(private servicesOfKhadamatiService:ServicesOfKhadamatiService,
   private activatedRoute:ActivatedRoute,
   private router:Router){}

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe({
      next:(map)=> {
        this.serviceId=+map.get('id')!;
        this.servicesOfKhadamatiService.getById(this.serviceId).subscribe({
          next:(service)=> {
            this.service=service;
          },
          error:(error)=> {
            console.error('Calling API failed',error);
          },
        })
      },
      error:(error)=> {
        console.error('This service was not found',error);
      },
    })
  }

  DeleteService(e:Event):void
  {
    e.preventDefault();
    this.servicesOfKhadamatiService.delete(this.serviceId!).subscribe({
      next:()=> {
        this.router.navigateByUrl("/");
      },
      error:(error)=> {
        console.error('Calling API failed',error);     
      },
    })
  }
}
