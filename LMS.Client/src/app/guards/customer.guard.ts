import { inject, Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class CustomerGuard implements CanActivate {
  authService = inject(AuthService)
  router = inject(Router)

  canActivate(): boolean {
    const user = this.authService.getUserDetail();
    if (user && user.role === 'Customer') {
      return true;
    } else {
      this.router.navigate(['/']); 
      return false;
    }
  }
}