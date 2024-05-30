import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AddPictureDTO } from '../types/pictures/AddPictureDTO';
import { Observable } from 'rxjs';
import { UpdatePictureDTO } from '../types/pictures/UpdatePictureDTO';

@Injectable({
  providedIn: 'root'
})
export class PicturesService {

  constructor(private client:HttpClient) {}

  public add(picture:AddPictureDTO):Observable<object>
  {
    return this.client.post("http://localhost:5033/api/Picture",picture);
  }

  public update(picture:UpdatePictureDTO):Observable<object>
  {
    return this.client.put("http://localhost:5033/api/Picture",picture);
  }
  
}
