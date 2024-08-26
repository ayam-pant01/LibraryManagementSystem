import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {MatButtonModule} from '@angular/material/button'
import { NavbarComponent } from "./components/navbar/navbar.component";
import {MatSidenavModule} from '@angular/material/sidenav';
import { SideNavPagesComponent } from './components/side-nav-pages/side-nav-pages.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, MatButtonModule, NavbarComponent,MatSidenavModule,SideNavPagesComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'LMS.Client';
}
