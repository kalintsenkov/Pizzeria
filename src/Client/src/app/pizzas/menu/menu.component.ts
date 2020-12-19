import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { IPizza } from '../../core/models/pizza.model';
import { IErrors } from '../../core/models/errors.model';
import { AuthService } from '../../core/services/auth.service';
import { CartsService } from '../../core/services/carts.service';
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
  errors: IErrors = { errors: {} };

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthService,
    private cartsService: CartsService,
    private pizzasService: PizzasService
  ) {
    this.query = this.route.snapshot.paramMap.get('query') ?? '';
    this.page = Number(this.route.snapshot.paramMap.get('page')) ?? 1;
  }

  ngOnInit(): void {
    if (this.page == 0) {
      this.page = 1;
    }

    const query = `?query=${this.query}&page=${this.page}`;

    this.pizzasService.search(query).subscribe(res => {
      this.pizzas = res['pizzas'];
      this.page = res['page'];
      this.totalPages = res['totalPages'];
    });
  }

  addToCart(id: number, event: Event): void {
    event.preventDefault();

    if (!this.authService.isAuthenticated()) {
      this.router.navigate(['/login']);
      return;
    }

    this.cartsService.addPizza(id).subscribe(
      res => window.location.href = "/cart",
      err => this.errors = err
    );
  }
}
