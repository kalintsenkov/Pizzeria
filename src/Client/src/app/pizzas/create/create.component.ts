import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { IErrors } from '../../core/models/errors.model';

import { PizzasService } from '../../core/services/pizzas.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  pizzaForm: FormGroup;
  errors: IErrors = { errors: {} };

  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private pizzasService: PizzasService
  ) { }

  ngOnInit(): void {
    this.pizzaForm = this.formBuilder.group({
      name: ['', Validators.required],
      price: [0, Validators.required],
      imageUrl: ['', Validators.required],
      calories: [0, Validators.required],
      description: ['', Validators.required],
    });
  }

  create(): void {
    this.pizzasService.create(this.pizzaForm.value).subscribe(
      id => this.router.navigate(['/pizza/' + id]),
      err => this.errors = err
    );
  }
}
