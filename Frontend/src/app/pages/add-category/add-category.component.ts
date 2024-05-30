import { ICategoryData } from 'src/app/types/category/categoryData.interface';
import { CategoryService } from './../../services/category.service';
import { ChangeDetectorRef, Component } from '@angular/core';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent {
  Name:string = "Category Text"
  
  data:ICategoryData[]|undefined;
  selectedItem:any;
  i: number = 0
  constructor(private categoryService: CategoryService,private cdr:ChangeDetectorRef) { }

  category(){
    this.categoryService.getCategoryData().subscribe((res)=>{
      this.data =res;
    })
  }
  addCategory() {
    this.categoryService.addCategoryData( {
      name : this.Name
    }).subscribe(
      ()=>{
        this.categoryService.getCategoryData().subscribe((res)=>{
          this.data =res;
        })
      })
  }
}
