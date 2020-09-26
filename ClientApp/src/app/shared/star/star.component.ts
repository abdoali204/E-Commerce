import { Component, Input, Output, EventEmitter, OnChanges, OnInit } from '@angular/core';


@Component({
  selector: 'app-star',
  templateUrl: './star.component.html',
  styleUrls: ['./star.component.css']
})
export class StarComponent implements OnChanges,OnInit {
  @Input() rating : number=0;
  stars : number[] = [1,2,3,4,5];
  selectedValue: number;
  @Input() editable : boolean = false;
  @Output() ratingClicked : EventEmitter<number>
            = new EventEmitter<number>();
  starWidth: number;
  constructor() {

   }
  ngOnInit(): void {
    
    this.selectedValue = this.rating? this.rating : 0;
    console.log(this.rating);
  }
  ngOnChanges(changes: import("@angular/core").SimpleChanges): void {
    
  }
  
  onStarClick(star : number): void{
    if(this.editable)
    {
      this.selectedValue = star;
      this.rating = star;
      this.ratingClicked.emit(star);
    }

  }

}
