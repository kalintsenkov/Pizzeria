import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { IErrors } from '../../core/interfaces/IErrors';
import { AuthService } from '../../core/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  isSubmitting = false;
  registerForm: FormGroup;
  errors: IErrors = { errors: {} };

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private authService: AuthService,
  ) { }

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      email: [
        { value: '', disabled: this.isSubmitting },
        Validators.required
      ],
      password: [
        { value: '', disabled: this.isSubmitting },
        Validators.required,
      ],
      confirmPassword: [
        { value: '', disabled: this.isSubmitting },
        Validators.required,
      ],
    });
  }

  register() {
    this.isSubmitting = true;
    this.authService.register(this.registerForm.value).subscribe(
      res => {
        this.router.navigateByUrl('/login');
      },
      err => {
        this.errors = err;
        this.isSubmitting = false;
      }
    );
  }
}
