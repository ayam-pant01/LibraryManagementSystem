import { Component, inject } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ReactiveFormsModule, ValidationErrors, Validators } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatOptionModule } from '@angular/material/core';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { AuthService } from '../../services/auth.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [MatCardModule,MatIconModule,ReactiveFormsModule,MatInputModule,MatOptionModule,MatSelectModule,MatButtonModule,CommonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  authService = inject(AuthService);
  matSnackBar = inject(MatSnackBar);
  router = inject(Router);

  hidePassword = true; // This is used to toggle password visibility
  hideConfirmPassword = true; // This is used to toggle password visibility

  registerForm: FormGroup;
  fb = inject(FormBuilder);

  constructor() {
    this.registerForm = this.fb.group({
      firstName: ['', Validators.required],
      middleName: [''], // Optional
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, this.passwordValidator]],
      confirmPassword: ['', Validators.required],
      role: ['', Validators.required],
    }, { validators: this.passwordMatchValidator });
  }

  passwordValidator(control: AbstractControl): ValidationErrors | null {
    const password = control.value;
  
    if (!password) {
      return null;
    }
  
    const errors: any = {};
    const hasUpperCase = /[A-Z]/.test(password);
    const hasLowerCase = /[a-z]/.test(password);
    const hasDigit = /[0-9]/.test(password);
    const hasNonAlphanumeric = /[^a-zA-Z0-9]/.test(password);
    const hasMinLength = password.length >= 6;
    const hasUniqueChars = new Set(password).size >= 1;
  
    if (!hasUpperCase) {
      errors.requireUppercase = true;
    }
    if (!hasLowerCase) {
      errors.requireLowercase = true;
    }
    if (!hasDigit) {
      errors.requireDigit = true;
    }
    if (!hasNonAlphanumeric) {
      errors.requireNonAlphanumeric = true;
    }
    if (!hasMinLength) {
      errors.minLength = true;
    }
    if (!hasUniqueChars) {
      errors.uniqueChars = true;
    }
  
    return Object.keys(errors).length > 0 ? errors : null;
  }
  

  passwordMatchValidator(formGroup: FormGroup) {
    const password = formGroup.get('password')?.value;
    const confirmPassword = formGroup.get('confirmPassword')?.value;
    return password === confirmPassword ? null : { mismatch: true };
  }

  onSubmit() {
    if (this.registerForm.valid) {
      this.authService.register(this.registerForm.value).subscribe({
        next: () => {
          this.matSnackBar.open('Registration successful!', 'Close', {
            duration: 3000,
          });
          this.router.navigate(['/login']);
        },
        error: (err) => {
          console.log("error",err);
          this.matSnackBar.open(`Registration failed: ${err}`, 'Close', {
            duration: 3000,
          });
        },
      });
    } else {
      this.matSnackBar.open('Please fill in all required fields correctly.', 'Close', {
        duration: 3000,
      });
    }
  }
}
