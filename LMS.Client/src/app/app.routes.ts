import { Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { HomeComponent } from './home/home/home.component';
import { RegisterComponent } from './account/register/register.component';
import { BookComponent } from './books/book/book.component';
import { CategoryComponent } from './books/category/category.component';
import { BookManagementComponent } from './books/book-management/book-management.component';
import { CheckoutListComponent } from './return/checkout-list/checkout-list.component';
import { categoryResolver } from './resolvers/category.resolver';

export const routes: Routes = [
    {
        path:"",component:HomeComponent
    },
    {
        path:"login",component:LoginComponent
    },
    {
        path:"register",component:RegisterComponent
    },
    {
        path:"manage-books",component:BookManagementComponent,resolve:{ categories: categoryResolver}
    },
    {
        path:"books",component:BookComponent
    },
    {
        path:"categories",component:CategoryComponent
    },
    {
        path:"checkout-list",component:CheckoutListComponent
    }
];
