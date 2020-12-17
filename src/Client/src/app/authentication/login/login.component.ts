import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { IErrors } from '../../core/models/errors.model';
import { AuthService } from '../../core/services/auth.service';
import { JwtService } from '../../core/services/jwt.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  isSubmitting = false;
  loginForm: FormGroup;
  errors: IErrors = { errors: {} };

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private authService: AuthService,
    private jwtService: JwtService,
  ) {
    if (this.authService.isAuthenticated()) {
      this.router.navigateByUrl('/');
    }
  }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: [
        { value: '', disabled: this.isSubmitting },
        Validators.required
      ],
      password: [
        { value: '', disabled: this.isSubmitting },
        Validators.required,
      ],
    });
  }

  login() {
    this.isSubmitting = true;
    this.authService.login(this.loginForm.value).subscribe(
      res => {
        this.jwtService.saveToken(res['token']);
        window.location.href = "/";
      },
      err => {
        this.errors = err;
        this.isSubmitting = false;
      }
    );
  }
}
