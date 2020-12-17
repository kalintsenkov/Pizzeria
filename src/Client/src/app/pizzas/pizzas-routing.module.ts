import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MenuComponent } from './menu/menu.component';
import { DetailsComponent } from './details/details.component';

import { RoleGuardService } from '../core/services/role-guard.service';

const routes: Routes = [
  { path: 'menu', component: MenuComponent },
  { path: 'menu/page/:page', component: MenuComponent },
  { path: 'menu/search/:query/page/:page', component: MenuComponent },
  // { path: 'pizza/create', component: CreateComponent, canActivate: [RoleGuardService] },
  { path: 'pizza/:id', component: DetailsComponent },
  // { path: 'pizza/:id/edit', component: EditComponent, canActivate: [RoleGuardService] },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PizzasRoutingModule { }
