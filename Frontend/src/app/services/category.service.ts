import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoryReadDTO } from '../types/category/CategoryReadDTO';
import { ICategoryData } from '../types/category/categoryData.interface';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private readonly BASE_URL = 'https://localhost:7012/api/Category'
  constructor(private client:HttpClient) { }

  getCategoryData():Observable<ICategoryData[]>{
    return this.client.get<ICategoryData[]>(`${this.BASE_URL}`)
    }
 
  addCategoryData(
    data:{
        name:string
    }
    ){
    return this.client.post(`${this.BASE_URL}`,data)
  }
  deleteCategory(id:number){
  return this.client.delete(`${this.BASE_URL}/${id}`)
  }

  public getAll():Observable<CategoryReadDTO[]>
  {
    return this.client.get<CategoryReadDTO[]>("http://localhost:5033/api/Category");
  }
}
