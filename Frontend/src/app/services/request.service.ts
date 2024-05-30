import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IRequestData } from '../types/request/requestData.interface';

@Injectable({
  providedIn: 'root'
})
export class RequestService {
  private readonly BASE_URL = 'https://localhost:5033/api/Request'
  constructor(private http:HttpClient) { }

  getRequestData(id:number):Observable<IRequestData[]>{
    return this.http.get<IRequestData[]>(`${this.BASE_URL}/id/${id}`)
  }

  getAllRequestData():Observable<IRequestData[]>{
    return this.http.get<IRequestData[]>(`https://localhost:5033/api/Request/GetAll`)
  }

  rejectRequest(body:{
    id:number,
    status:string,
    requestText:string
  }){
    return this.http.put(`${this.BASE_URL}`,{
      id:body.id,
      status:body.status,
      requestText:body.requestText

    })
  }
  
  addRequestData(
    data:{
      userId: string,
      serviceId: number,
      providerId: string,
      requestText: string,
      status: string

    }
  ){
    return this.http.post(`${this.BASE_URL}`,data)
  }

  updateRequest(body:{
    id:number,
    status:string,
    requestText:string
  }){
    return this.http.put(`${this.BASE_URL}`,{
      id:body.id,
      status:body.status,
      requestText:body.requestText

    })
}
}
