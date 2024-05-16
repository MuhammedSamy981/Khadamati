import { Component, Input, OnInit } from '@angular/core';
import { RequestService } from 'src/app/services/request.service';
import { IRequestData } from 'src/app/types/request/requestData.interface';

@Component({
  selector: 'app-update-request',
  templateUrl: './update-request.component.html',
  styleUrls: ['./update-request.component.css']
})
export class UpdateRequestComponent implements OnInit {
  @Input() id:number=0
  requestText:string = 'requestText'
  data:IRequestData|undefined
  constructor(private RequestService:RequestService){}


  ngOnInit(): void {
    this.request()
  }
 
  request(){
    this.RequestService.getRequestData(this.id).subscribe((res)=>{
      this.data = res[0]
    })
  }


  updateRequest(request_text:string){
    this.RequestService.updateRequest(
      {
        id:this.data?.id ||this.id,
        status: "waiting" || '',
        requestText: request_text || ''
      }
    ).subscribe(
    ()=>{
      this.request()
    }
    )
  }
}


