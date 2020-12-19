import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../../core/services/auth.service';
import { CartsService } from '../../core/services/carts.service';
import { JwtService } from '../../core/services/jwt.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  token: string;
  cartTotal: number;

  constructor(
    private router: Router,
    private jwtService: JwtService,
    private authService: AuthService,
    private cartsService: CartsService,
  ) { }

  ngOnInit(): void {
    this.getToken();

    if (this.isAuthenticated()) {
      this.cartsService.total().subscribe(total => {
        this.cartTotal = total;
      });
    }
  }

  logout(): void {
    this.jwtService.removeToken();
    this.getToken();
    this.router.navigate(['/']);
  }

  isAuthenticated(): boolean {
    return this.authService.isAuthenticated();
  }

  isAdministrator(): boolean {
    return this.authService.isAdministrator();
  }

  openSearchForm(): void {
    const searchFrom = document.getElementsByClassName('search-form-wrapper')[0];
    searchFrom.classList.add('open');
  }

  private getToken() {
    this.token = this.jwtService.getToken();
  }
}
