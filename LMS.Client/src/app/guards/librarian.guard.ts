import { inject, Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class LibrarianGuard implements CanActivate {
  authService = inject(AuthService)
  router = inject(Router)

  canActivate(): boolean {
    const user = this.authService.getUserDetail();
    if (user && user.role === 'Librarian') {
      return true;
    } else {
      this.router.navigate(['/']); 
      return false;
    }
  }
}