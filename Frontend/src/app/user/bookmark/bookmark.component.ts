import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { UserChildBookmarkDTO } from 'src/app/Types/Users/UserDetailsDto';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-bookmark',
  templateUrl: './bookmark.component.html',
  styleUrls: ['./bookmark.component.css']
})
export class BookmarkComponent {
  @Input() Bookmarks?:UserChildBookmarkDTO[];
  constructor(private user: UserService,private router: Router)
  {

  }
  Details(id:number)
  {
    this.router.navigateByUrl("/service/"+id);
  }
  DeleteBookmark(id:number,e:HTMLElement)
  {
    this.user.DeleteBookMark(id).subscribe(
      {
        next:()=>{
          console.log("Success");
          e.remove();
        },
        error:(error)=>{
          console.log(error);
        }
      }
    )
  }
}
