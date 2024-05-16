import { Component, EventEmitter, Input, Output} from '@angular/core';


@Component({
  selector: 'app-paginator',
  templateUrl: './paginator.component.html',
  styleUrls: ['./paginator.component.css']
})
export class PaginatorComponent {

  currentPage:number = 1;
  @Input() sizeOfPage:number = 0;
  totalPages:number=0;  
  @Input() data: any[] = [];

  paginatedData: any[] = []; 
  pageNumbers:number[]=[];


  @Output() sendedData=new EventEmitter<any[]>();
  constructor() {}

  ngOnInit(): void { 
    this.loadData(this.currentPage,this.sizeOfPage);
    this.totalPages = this.data?.length!/this.sizeOfPage;
 for(let i:number = 0 ; i < this.totalPages ;i++)
 {
    this.pageNumbers[i]= i+1;
  }
  console.log(this.totalPages);
  this.postData();
} 

showPreviousPage():void
{
  if(this.currentPage==1)
  {
    return;
  }
  this.currentPage-=1;
  this.loadData(this.currentPage,this.sizeOfPage);
  this.postData();
  console.log(this.currentPage);
}

showPage(pageNumber:number):void
{
  this.loadData(pageNumber,this.sizeOfPage);
  this.postData();
}

showNextPage():void
{
  if(this.currentPage==this.totalPages)
  {
    return;
  }
  this.currentPage+=1;
  this.loadData(this.currentPage,this.sizeOfPage); 
  this.postData();
  console.log(this.currentPage);
}

loadData(pageNumber:number,pageSize:number): void {
  this.paginatedData = []; 
  let length:number=pageSize*pageNumber;
  let index:number=length-pageSize;
  let count:number=0;
  for(let i=index;i<length;i++)
  {
    if(this.data[i]!=undefined)
    {
      this.paginatedData[count]=this.data![i];
      count++;
    }
  }  
}

  postData()
  {
    this.sendedData.emit(this.paginatedData);
  }

}



