import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbar } from '@angular/material/toolbar';
import { MatMenuItem, MatMenuModule } from '@angular/material/menu';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { CommonModule } from '@angular/common';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [MatToolbar,MatButtonModule,MatIconModule,MatSnackBarModule,MatMenuModule,MatMenuItem,RouterLink,CommonModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
authService = inject(AuthService);
matSnackBar = inject(MatSnackBar);
router = inject(Router);
userName: string = 'test';
userRole: string = 'eta';
userDetail : any = this.authService.getUserDetail();
isLoggedIn(){
  return this.authService.isLoggedIn();
}
logout=()=>{
  this.authService.logout();
  this.matSnackBar.open("Logout Success",'Close',{
    duration:5000,
    horizontalPosition:'center'
  });
  this.router.navigate(['/'])
}  
}
