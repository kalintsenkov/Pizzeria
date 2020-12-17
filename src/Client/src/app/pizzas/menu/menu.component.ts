import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { IPizza } from '../../core/models/pizza.model';
import { PizzasService } from '../../core/services/pizzas.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  query: string;
  page: number;
  totalPages: number;
  pizzas: Array<IPizza>;

  constructor(
    private route: ActivatedRoute,
    private pizzasService: PizzasService
  ) {
    this.query = this.route.snapshot.paramMap.get('query') ?? '';
    this.page = Number(this.route.snapshot.paramMap.get('page')) ?? 1;
  }

  ngOnInit(): void {
    if (this.page == 0) {
      this.page = 1;
    }

    this.pizzasService.search(this.query).subscribe(pizzas => {
      this.pizzas = pizzas;
      // this.page = res['page'];
      // this.totalPages = res['totalPages'];
    });
  }
}
