import { Component, inject, Input } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbar } from '@angular/material/toolbar';
import { MatMenuItem, MatMenuModule } from '@angular/material/menu';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { CommonModule } from '@angular/common';
import { MatSidenav } from '@angular/material/sidenav';
import { ToastService } from '../../services/toast.service';
import { UserDetail } from '../../interfaces/user-detail';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [MatToolbar,MatButtonModule,MatIconModule,MatMenuModule,MatMenuItem,RouterLink,CommonModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
@Input() sidenav!: MatSidenav;

toggleSidenav() {
  this.sidenav.toggle();
}
authService = inject(AuthService);
toastService = inject(ToastService)
router = inject(Router);
userName: string = 'test';
userRole: string = 'eta';
userDetail : UserDetail | null = null;
isLoggedIn : boolean = false;

constructor() {
  this.authService.userDetail$.subscribe({
    next:(detail)=>{
      if(detail){
        this.userDetail = detail;
        this.isLoggedIn = true;
      }else{
        this.isLoggedIn = false
      }
    }
  })
  }

logout=()=>{
  this.authService.logout();
  this.toastService.openSnackBar("Logout Success");
  this.router.navigate(['/'])
}  
}
