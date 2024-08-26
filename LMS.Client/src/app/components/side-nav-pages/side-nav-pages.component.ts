import { Component, inject } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { AuthService } from '../../services/auth.service';
import {MatListModule} from '@angular/material/list';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-side-nav-pages',
  standalone: true,
  imports: [MatCardModule,MatListModule,RouterLink],
  templateUrl: './side-nav-pages.component.html',
  styleUrl: './side-nav-pages.component.css'
})
export class SideNavPagesComponent {
  authService = inject(AuthService);
  isLoggedIn = this.authService.isLoggedIn();
  userDetail : any = this.authService.getUserDetail();
  panelName = this.isLoggedIn ? this.userDetail.role : '';
  navItems: NavItems[] = [];
  constructor() {
    if(this.userDetail.role != "Librarian"){
      this.navItems = [
        {value:"View Books", link:'login'},
        {value:"My collections", link:'register'},
      ]
    }else{
      this.navItems = [
        {value:"View Books", link:'register'},
        {value:"All orders", link:'login'},
        {value:"User List", link:'register'},
        {value:"Return books", link:'login'},
      ]
    }
  }
}

export interface NavItems{
  value:string,
  link:string
}
