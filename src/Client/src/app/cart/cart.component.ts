import { Component, OnInit } from '@angular/core';

import { CartsService } from '../core/services/carts.service';

import { IErrors } from '../core/models/errors.model';
import { ICartProduct } from '../core/models/cartProduct.model';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  cartPizzas: Array<ICartProduct>;
  errors: IErrors = { errors: {} };

  constructor(private cartsService: CartsService) { }

  ngOnInit(): void {
    this.fetch();
    this.totalPrice();
  }

  updatePizza(id: number, quantity: number): void {
    this.cartsService.updatePizza(id, quantity).subscribe(
      res => {
        this.fetch();
        this.totalPrice();
      },
      err => {
        this.errors = err;
      }
    );
  }

  removePizza(id: number): void {
    this.cartsService.removePizza(id).subscribe(
      res => window.location.href = "/cart",
      err => this.errors = err
    );
  }

  totalPrice(): number {
    const initialValue = 0;
    return this.cartPizzas?.reduce(
      (sum, product) => sum + product.quantity * product.price,
      initialValue
    );
  }

  private fetch(): void {
    this.cartsService.mine().subscribe(cartProducts => {
      this.cartPizzas = cartProducts;
    });
  }
}
