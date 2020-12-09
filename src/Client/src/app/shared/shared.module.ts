import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { PreloaderComponent } from './preloader/preloader.component';

@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    PreloaderComponent
  ],
  exports: [
    HeaderComponent,
    FooterComponent,
    PreloaderComponent,
    FormsModule,
    RouterModule,
    ReactiveFormsModule
  ],
  imports: [
    CommonModule
  ]
})
export class SharedModule { }
