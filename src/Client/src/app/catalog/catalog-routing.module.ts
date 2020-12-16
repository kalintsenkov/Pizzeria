import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RoleGuardService } from '../core/services/role-guard.service';

const routes: Routes = [
  // { path: 'catalog', component: CatalogComponent },
  // { path: 'catalog/page/:page', component: CatalogComponent },
  // { path: 'products/search/:query/page/:page', component: CatalogComponent },
  // { path: 'products/create', component: CreateComponent, canActivate: [RoleGuardService] },
  // { path: 'products/:id', component: ViewComponent },
  // { path: 'products/:id/edit', component: EditComponent, canActivate: [RoleGuardService] },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CatalogRoutingModule { }
