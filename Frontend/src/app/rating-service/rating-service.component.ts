import { Component, Input, OnInit } from '@angular/core';
import { RatingsService } from '../services/ratings.service';
import { RatingAddDto } from '../types/Ratings/RatingAddDto';
import { Router } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-rating-service',
  templateUrl: './rating-service.component.html',
  styleUrls: ['./rating-service.component.css']
})
export class RatingServiceComponent implements OnInit{

  @Input() serviceId?:number;
  @Input() userId?:string;
  @Input() checkUserId:boolean=false;
  @Input() ratingId?:number;

  newRatingId?:number;
  userName?:string;
  comment?:string;
  rating?:number;
  ratingDate?:string;
  

  AddingStatus:boolean=false;

  constructor(private ratingsService:RatingsService,private router:Router) { }

  ngOnInit(): void 
  {
    throw new Error('Method not implemented.');
  }

  ratingGroup=new FormGroup({

    rating:new FormControl<number>(0),
    comment:new FormControl<string>(''),
  })
  
  addRating():void
  {
    const ratingService:RatingAddDto=
    {
      serviceId: this.serviceId!,
      userId: this.userId!,
      comment: this.ratingGroup.value.comment!,
      rating: this.ratingGroup.value.rating!,
    };
    this.ratingsService.add(ratingService).subscribe({
      next:()=> 
      {
        this.ratingsService.getRatingByUserAndService(this.serviceId!,this.userId!).subscribe({
          next:(rating)=> {
            this.newRatingId=rating.id;
            this.userName=rating.userName;
            this.comment= this.ratingGroup.value.comment!;
            this.rating=this.ratingGroup.value.rating!;
            this.ratingDate=rating.date!;
            this.AddingStatus=true;
          },
          error:(error)=> {
            console.error("Calling API failed",error);     
          },
        })
      },
      error:(err)=> {
        console.log("failed",err);
        console.log(ratingService.serviceId+"/"+ratingService.userId+"/"+ratingService.comment+"/"+ratingService.rating+"/");
      },
    });
  }

   deleteRating() {
    this.ratingsService.delete(this.newRatingId!).subscribe({
      next:()=> {
        this.AddingStatus=false;
      },
      error:(error)=> {
        console.error("Calling API failed ,this id: "+this.newRatingId+"is not found",error);     
      },
    })
    }

    ratingChanged(event: CustomEvent<number>) {
      this.ratingGroup.value.rating=event.detail;
      console.log(event.detail+"/"+this.ratingGroup.value.rating!);
     }


}
