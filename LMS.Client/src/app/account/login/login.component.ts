import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { AuthService } from '../../services/auth.service';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MatInputModule,MatCardModule,MatSnackBarModule,MatIconModule,ReactiveFormsModule,MatButtonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  authService = inject(AuthService);
  matSnackBar = inject(MatSnackBar);
  router = inject(Router);

  hide = true;  // This is used to toggle password visibility
  loginForm!: FormGroup;
  fb = inject(FormBuilder);

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],  // Email field with required and email format validation
      password: ['', [Validators.required, Validators.minLength(6)]],  // Password field with required and minimum length validation
    });
  }

  // Getter methods for form controls for easier access in the template
  get email() {
    return this.loginForm.get('email');
  }

  get password() {
    return this.loginForm.get('password');
  }

  // Method to handle form submission
  onSubmit() {
    if (this.loginForm.valid) {
      this.authService.login(this.loginForm.value).subscribe({
        next:(response)=>{
          this.matSnackBar.open(response.message!,'Close',{
            duration:5000,
            horizontalPosition:'center'
          });
          this.authService.userLoggedIn.next(true);
          this.router.navigate(['/'])
        },
        error:(error)=>{
          this.matSnackBar.open(error.error.message,'Close',{
            duration:5000,
            horizontalPosition:'center'
          });
        }
      })
    }
  }
}