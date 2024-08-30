import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { ToastService } from '../../services/toast.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MatInputModule,MatCardModule,MatIconModule,ReactiveFormsModule,MatButtonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  authService = inject(AuthService);
  toastService = inject(ToastService)
  router = inject(Router);

  hidePasspordVisiblity = true; 
  loginForm!: FormGroup;
  fb = inject(FormBuilder);

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      this.authService.login(this.loginForm.value).subscribe({
        next:(response)=>{
          this.toastService.openSnackBar(response.message!);
          // this.authService.userLoggedIn.next(true);
          this.router.navigate(['/'])
        },
        error:(error)=>{
          this.toastService.openSnackBar(error.error.message);
        }
      })
    }
  }
}