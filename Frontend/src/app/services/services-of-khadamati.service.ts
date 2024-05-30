import { HttpClient, HttpParams} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GetAllServicesDTO } from '../types/services/GetAllServicesDTO';
import { Observable } from 'rxjs';
import { GetAllServicesDetailsDTO } from '../types/services/GetAllServicesDetailsDTO';
import { GetServiceByIdDTO } from '../types/services/GetServiceByIdDTO';
import { GetServiceDetailsByIdDTO } from '../types/services/GetServiceDetailsByIdDTO';
import { AddServiceDTO } from '../types/services/AddServiceDTO';
import { UpdateServiceDTO } from '../types/services/UpdateServiceDTO';
import { GetSpecificServicesDetailsDTO } from '../types/services/GetSpecificServicesDetailsDTO';

@Injectable({
  providedIn: 'root'
})
export class ServicesOfKhadamatiService {

  constructor(private client:HttpClient) 
  {}

  
  public getAllDetails():Observable<GetAllServicesDetailsDTO[]> 
  {
    return this.client.get<GetAllServicesDetailsDTO[]>("http://localhost:5033/api/Service/Details");
  }

  public getAll():Observable<GetAllServicesDTO[]>
  {
    return this.client.get<GetAllServicesDTO[]>("http://localhost:5033/api/Service");
  }

  public getById(id:number):Observable<GetServiceByIdDTO>
  {
    return this.client.get<GetServiceByIdDTO>("http://localhost:5033/api/Service/"+id);
  }

  public getDetailsById(id:number):Observable<GetServiceDetailsByIdDTO>
  {
    return this.client.get<GetServiceDetailsByIdDTO>("http://localhost:5033/api/Service/Details/"+id);
  }

  public getSpecificDetails(location:string,category:string):Observable<GetSpecificServicesDetailsDTO[]>
  {
    return this.client.get<GetSpecificServicesDetailsDTO[]>
    ("http://localhost:5033/api/Service/SpecificDetails?loction="+location+"&category="+category);
  }

  public add(service:AddServiceDTO):Observable<object>
  {
    return this.client.post("http://localhost:5033/api/Service",service);
  }

  public update(service:UpdateServiceDTO):Observable<object>
  {
    return this.client.put("http://localhost:5033/api/Service",service);
  }

  public delete(id:number):Observable<object>
  {
    return this.client.delete("http://localhost:5033/api/Service/"+id); 
  }

  public Approve(id:number):Observable<object>
  {
    return this.client.post("https://localhost:5033/api/Service/Approve/"+id,id); 
  }
  
}
