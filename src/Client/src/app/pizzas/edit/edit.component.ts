import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { IErrors } from '../../core/models/errors.model';
import { IPizza } from '../../core/models/pizza.model';

import { PizzasService } from '../../core/services/pizzas.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  id: number;
  pizza: IPizza;
  pizzaForm: FormGroup;
  errors: IErrors = { errors: {} };

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private pizzasService: PizzasService,
  ) {
    this.id = Number(this.route.snapshot.paramMap.get('id'));

    this.pizzaForm = this.formBuilder.group({
      name: ['', Validators.required],
      price: [0, Validators.required],
      imageUrl: ['', Validators.required],
      calories: [0, Validators.required],
      description: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.pizzasService.details(this.id).subscribe(pizza => {
      this.pizza = pizza;
      this.pizzaForm = this.formBuilder.group({
        name: [pizza.name, Validators.required],
        price: [pizza.price, Validators.required],
        imageUrl: [pizza.imageUrl, Validators.required],
        calories: [pizza.calories, Validators.required],
        description: [pizza.description, Validators.required],
      });
    });
  }

  edit(): void {
    this.pizzasService.edit(this.id, this.pizzaForm.value).subscribe(
      res => this.router.navigate(['/pizza/' + this.id]),
      err => this.errors = err
    );
  }
}
