import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent {

  @Input() page: number = 1;
  @Input() totalPages: number;

  nextPage() {
    if (this.page + 1 <= this.totalPages) {
      this.page++;
    }
  }

  previousPage() {
    if (this.page - 1 >= 0) {
      this.page--;
    }
  }
}
