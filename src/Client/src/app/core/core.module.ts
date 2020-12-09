import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { ApiService } from './services/api.service';
import { JwtService } from './services/jwt.service';

import { TokenInterceptorService } from './interceptors/token-interceptor.service';

@NgModule({
  declarations: [],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true,
    },
    ApiService,
    JwtService,
  ],
  imports: [
    CommonModule
  ]
})
export class CoreModule { }
