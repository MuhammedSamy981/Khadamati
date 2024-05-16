import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-star-rating',
  templateUrl: './star-rating.component.html',
  styleUrls: ['./star-rating.component.css']
})
export class StarRatingComponent {

    @Input() rating?: number;
    get checkedStars() {
      return Array(Math.floor(this.rating!)).fill(0);
    }

    get uncheckedStars() {
      return Array(Math.floor(5-this.rating!)).fill(0);
    }
  
}
