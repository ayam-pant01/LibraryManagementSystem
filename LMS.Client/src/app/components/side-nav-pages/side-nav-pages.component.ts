import { Component, inject } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { AuthService } from '../../services/auth.service';
import {MatListModule} from '@angular/material/list';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { UserDetail } from '../../interfaces/user-detail';

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
  this.authService.userDetail$.subscribe({
    next:(userDetail)=>{
      if (userDetail) {
        this.isLoggedIn = true;
        this.panelName = userDetail.role;
        this.setNavItemsBasedOnRole(userDetail.role);
      } else {
        this.navItems = [];
        this.panelName = '';
      }
    }
  })
  }

  private setNavItemsBasedOnRole(role: string) {
    if (role != "Librarian") {
      this.navItems = [
        { value: "View Books", link: 'books' },
        { value: "Cart", link: 'cart' },
        { value: "My checkout list", link: 'user-checkouts' },
      ];
    } else {
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
        // { value: "All Orders", link: 'login' },
        // { value: "User List", link: 'register' },
        {
          value: "Return Management",
          link: '',
          subItems: [
            { value: "Return List", link: 'return-list' }
          ]
        },
      ];
    }
    this.panelName = role;
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