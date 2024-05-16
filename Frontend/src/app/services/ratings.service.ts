import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RatingAddDto } from '../types/Ratings/RatingAddDto';
import { RatingDto } from '../types/Ratings/RatingDto';

@Injectable({
  providedIn: 'root'
})
export class RatingsService {

  constructor(private client:HttpClient) { }

  public add(rating:RatingAddDto):Observable<object>
  {
    return this.client.post("http://localhost:5033/api/Rating",rating);
  }

  public delete(id:number):Observable<object>
  {
    return this.client.delete("http://localhost:5033/api/Rating/"+id);
  }

  public getRatingByUserAndService(sid:number,uid:string):Observable<RatingDto>
  {
    return this.client.get<RatingDto>("http://localhost:5033/api/Rating?sid="+sid+"&uid="+uid);
  }

}
