import { Component, OnInit } from '@angular/core';

import { IPizza } from '../core/models/pizza.model';
import { PizzasService } from '../core/services/pizzas.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  pizzas: Array<IPizza>;

  constructor(private pizzasService: PizzasService) { }

  ngOnInit(): void {
    this.pizzasService.search().subscribe(pizzas => {
      this.pizzas = pizzas;
    });
  }
}
