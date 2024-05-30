import { Component, OnInit } from '@angular/core';
import { ServicesOfKhadamatiService } from '../services/services-of-khadamati.service';
import { ActivatedRoute, Router } from '@angular/router';
import { GetServiceDetailsByIdDTO } from '../types/services/GetServiceDetailsByIdDTO';
import { RatingsService } from '../services/ratings.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-service-details',
  templateUrl: './service-details.component.html',
  styleUrls: ['./service-details.component.css']
})
export class ServiceDetailsComponent implements OnInit {

   clientId:string=this.user.GetUserId()!;// replace this value with id from user after login
   service?:GetServiceDetailsByIdDTO;
   ratingId?:number;
   deletingStatus:boolean=false;

  constructor(private servicesOfKhadamatiService:ServicesOfKhadamatiService,
   private activatedRoute:ActivatedRoute,public user:UserService,
   private ratingsService:RatingsService,private router:Router){}
  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe({
      next:(map)=> {
        const serviceId=+map.get("id")!;
        this.servicesOfKhadamatiService.getDetailsById(serviceId).subscribe(
          {
            next:(service)=> {
              this.service=service;
              for(let rating of service.ratings!)
              {
                if(rating.userId==this.clientId)
                {
                  this.ratingId=rating.id;
                }
              }
            },
            error:(error)=> {
              console.error('Calling API failed',error);
            },
          })
      },
      error:(error)=> {
        console.error('This service is not found',error);
      }, 
    })
  }

  deleteRating() {
    this.ratingsService.delete(this.ratingId!).subscribe({
      next:()=> {
        this.deletingStatus=true;
        this.ratingId=undefined;
      },
      error:(error)=> {
        console.error("Calling API failed ,this id: "+this.ratingId+"is not found",error);     
      },
    })
    }
    AddBookmark()
    {
      if(this.user.IsLoggedIn())
      {
        this.user.AddBookMark(this.service?.id!).subscribe({
          next:()=> {
            console.log("Success");
          },
          error:(error)=> {
            console.log(error);;     
          },
        })
      }
      else
      {
        this.router.navigateByUrl("/Login");
      }
      
    }
}
