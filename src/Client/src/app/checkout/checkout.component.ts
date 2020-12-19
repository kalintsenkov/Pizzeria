import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { flatMap } from 'rxjs/operators';

import { IErrors } from '../core/models/errors.model';
import { ICartPizza } from '../core/models/cartPizza.model';
import { CartsService } from '../core/services/carts.service';
import { OrdersService } from '../core/services/orders.service';
import { AddressesService } from '../core/services/addresses.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  checkoutForm: FormGroup;
  cartProducts: Array<ICartPizza>;
  errors: IErrors = { errors: {} };

  constructor(
    private formBuilder: FormBuilder,
    private cartsService: CartsService,
    private ordersService: OrdersService,
    private addressesService: AddressesService
  ) { }

  get notes() {
    return this.checkoutForm.get('notes').value;
  }

  ngOnInit(): void {
    this.checkoutForm = this.formBuilder.group({
      city: ['', Validators.required],
      region: ['', Validators.required],
      description: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      notes: [''],
    });

    this.cartsService.mine().subscribe(cartProducts => {
      this.cartProducts = cartProducts;
    });
  }

  totalPrice(): number {
    const initialValue = 0;
    return this.cartProducts?.reduce((sum, product) => {
      return sum + product.quantity * product.price;
    }, initialValue);
  }

  purchase(): void {
    this.addressesService.create(this.checkoutForm.value)
      .pipe(
        flatMap(
          addressId => this.ordersService.purchase(addressId, this.notes)
        )
      )
      .subscribe(
        _ => window.location.href = '/',
        err => this.errors = err
      );
  }
}
