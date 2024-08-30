import { Component, inject } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { AuthService } from '../../services/auth.service';
import {MatListModule} from '@angular/material/list';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-side-nav-pages',
  standalone: true,
  imports: [MatCardModule,MatListModule,RouterLink,CommonModule,MatIconModule],
  templateUrl: './side-nav-pages.component.html',
  styleUrl: './side-nav-pages.component.css'
})
export class SideNavPagesComponent {
  authService = inject(AuthService);
  panelName = '';
  navItems: NavItems[] = [];
  expandedItem: NavItems | null = null;
  isLoggedIn: boolean = false;

  constructor() {
  this.authService.userLoggedIn$.subscribe({
    next:(status)=>{
      this.isLoggedIn = status;
      if(status){
        const userDetail = this.authService.getUserDetail();
        if(userDetail){
          if(userDetail.role != "Librarian"){
            this.navItems = [
              {value:"View Books", link:'books'},
              {value:"My collections", link:'register'},
            ]
          }else{
            this.navItems = [
              {
                value: "Book Management",
                link: '', 
                subItems: [
                  { value: "Manage Categories", link: 'categories' },
                  { value: "Manage Books", link: 'manage-books' }
                ]
              },
              { value: "All Books", link: 'books' },
              { value: "All Orders", link: 'login' },
              { value: "User List", link: 'register' },
              {
                value: "Return Management",
                link: '', 
                subItems: [
                  { value: "Checkout List", link: 'checkout-list' },
                  { value: "Return List", link: 'manage-books' }
                ]
              },
            ];
          }
          this.panelName = userDetail.role;
        }
      }
      else {
        this.navItems = []
      }
    }
  })
  }

  toggleSubItems(item: NavItems) {
    if (this.expandedItem === item) {
      this.expandedItem = null;
    } else {
      this.expandedItem = item;
    }
  }
  
  
}

export interface NavItems{
  value:string,
  link:string,
  subItems?: NavItems[]
}