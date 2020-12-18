import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Size } from '../../core/common/size.enum';
import { IErrors } from '../../core/models/errors.model';
import { IPizza } from '../../core/models/pizza.model';

import { AuthService } from '../../core/services/auth.service';
import { CartsService } from '../../core/services/carts.service';
import { PizzasService } from '../../core/services/pizzas.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  id: number;
  orderQuantity: number = 1;
  orderSize: Size = Size.Small;
  pizza: IPizza;
  errors: IErrors = { errors: {} };

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthService,
    private cartsService: CartsService,
    private pizzasService: PizzasService
  ) {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
  }

  ngOnInit(): void {
    this.pizzasService.details(this.id).subscribe(pizza => {
      this.pizza = pizza;
    });
  }

  get Size(): typeof Size {
    return Size;
  }

  changeSize(size: Size, event: Event): void {
    this.orderSize = size;
    this.toggleActive(event);
  }

  increment(): void {
    this.orderQuantity++;
  }

  decrement(): void {
    this.orderQuantity--;
  }

  addToCart(): void {
    if (!this.authService.isAuthenticated()) {
      this.router.navigate(['/login']);
      return;
    }

    this.cartsService.addPizza(this.id, this.orderQuantity, this.orderSize).subscribe(
      res => window.location.href = "/cart",
      err => this.errors = err
    );
  }

  deleteProduct(): void {
    this.pizzasService.delete(this.id).subscribe(
      res => this.router.navigate(['/menu']),
      err => this.errors = err
    );
  }

  isAdministrator(): boolean {
    return this.authService.isAdministrator();
  }

  private toggleActive(event: Event): void {
    const activeClass = 'active';
    const activeDiv = document.getElementsByClassName('customize-size active')[0];
    activeDiv.classList.remove(activeClass);
    (event.target as HTMLTextAreaElement).classList.add(activeClass);
  }
}
