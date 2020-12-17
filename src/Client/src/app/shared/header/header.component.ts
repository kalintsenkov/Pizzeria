import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthService } from 'src/app/core/services/auth.service';
import { CartsService } from 'src/app/core/services/carts.service';
import { JwtService } from 'src/app/core/services/jwt.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  searchForm: FormGroup;
  token: string;
  cartTotal: number;

  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private jwtService: JwtService,
    private authService: AuthService,
    private cartsService: CartsService,
  ) { }

  get query() {
    return this.searchForm.get('query').value;
  }

  ngOnInit(): void {
    this.getToken();

    this.searchForm = this.formBuilder.group({
      query: [''],
    });

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

  search(): void {
    this.router.navigate([`/catalog/search/${this.query}/page/1`]);
  }

  isAuthenticated(): boolean {
    return this.authService.isAuthenticated();
  }

  isAdministrator(): boolean {
    return this.authService.isAdministrator();
  }

  private getToken() {
    this.token = this.jwtService.getToken();
  }
}
