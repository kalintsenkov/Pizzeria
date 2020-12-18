import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { PreloaderComponent } from './preloader/preloader.component';
import { ErrorListComponent } from './error-list/error-list.component';
import { SubheaderComponent } from './subheader/subheader.component';

@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    PreloaderComponent,
    ErrorListComponent,
    SubheaderComponent
  ],
  exports: [
    HeaderComponent,
    FooterComponent,
    PreloaderComponent,
    ErrorListComponent,
    SubheaderComponent,
    FormsModule,
    RouterModule,
    ReactiveFormsModule
  ],
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule
  ]
})
export class SharedModule { }
