import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent {

  @Input() page: number;
  @Input() totalPages: number;

  constructor(private router: Router) { }

  nextPage() {
    if (this.page + 1 <= this.totalPages) {
      this.page++;
      this.router.navigate(['/menu/page/' + this.page]);
    }
  }

  previousPage() {
    if (this.page - 1 >= 0) {
      this.page--;
      this.router.navigate(['/menu/page/' + this.page]);
    }
  }
}
