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
  panelName = '';
  navItems: NavItems[] = [];
  constructor() {
  this.authService.userLoggedIn.subscribe({
    next:(status)=>{
      if(status){
        let userDetail = this.authService.getUserDetail();
        console.log("comeshere",userDetail);
        if(userDetail != null){
          if(userDetail.role != "Librarian"){
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
          this.panelName = userDetail.role;
          console.log("Panel name printed", this.panelName);
        }
      }
    }
  })
  }
  
  
}

export interface NavItems{
  value:string,
  link:string
}
