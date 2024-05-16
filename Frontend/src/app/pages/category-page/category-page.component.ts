import { Component, OnInit  } from '@angular/core';
import { CategoryService } from 'src/app/services/category.service';
import { ICategoryData } from 'src/app/types/category/categoryData.interface';

@Component({
  selector: 'app-category-page',
  templateUrl: './category-page.component.html',
  styleUrls: ['./category-page.component.css']
})
export class CategoryPageComponent implements OnInit {
  Name:string = "";
  data:ICategoryData[]|undefined;
  selectedItem:any;
  id: number = 0
  constructor(private categoryService: CategoryService)  { }
  ngOnInit(): void {
    this.category()
  }

  category(){
    this.categoryService.getCategoryData().subscribe((res)=>{
      this.data = res
    })
  }
  addCategory() {
    this.categoryService.addCategoryData( {
      name : this.Name
    }).subscribe(()=>{this.category()})
    
    }  

  delete(id:number){
    this.categoryService.deleteCategory(id).subscribe(
    ()=>{
      this.category()
    })
  }
}
