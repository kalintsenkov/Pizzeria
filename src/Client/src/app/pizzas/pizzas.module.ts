import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoreModule } from '../core/core.module';
import { SharedModule } from '../shared/shared.module';
import { PizzasRoutingModule } from './pizzas-routing.module';

import { MenuComponent } from './menu/menu.component';
import { DetailsComponent } from './details/details.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';

@NgModule({
  declarations: [
    MenuComponent,
    DetailsComponent,
    CreateComponent,
    EditComponent
  ],
  imports: [
    CommonModule,
    CoreModule,
    SharedModule,
    PizzasRoutingModule
  ]
})
export class PizzasModule { }
