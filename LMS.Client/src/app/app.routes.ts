import { Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { HomeComponent } from './home/home/home.component';
import { RegisterComponent } from './account/register/register.component';
import { BookComponent } from './books/book/book.component';
import { CategoryComponent } from './books/category/category.component';
import { BookManagementComponent } from './books/book-management/book-management.component';
import { ReturnListComponent } from './return/checkout-list/return-list.component';
import { categoryResolver } from './resolvers/category.resolver';
import { CartComponent } from './cart/cart.component';
import { UserCheckoutsComponent } from './user-checkouts/user-checkouts.component';
import { LibrarianGuard } from './guards/librarian.guard';
import { CustomerGuard } from './guards/customer.guard';

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
        path:"categories",component:CategoryComponent,canActivate:[LibrarianGuard]
    },
    {
        path:"books",component:BookComponent
    },
    {
        path:"cart",component:CartComponent,canActivate:[CustomerGuard]
    },
    {
        path:"user-checkouts",component:UserCheckoutsComponent,canActivate:[CustomerGuard]
    },
    {
        path:"manage-books",component:BookManagementComponent,resolve:{ categories: categoryResolver},canActivate:[LibrarianGuard]
    },
    {
        path:"return-list",component:ReturnListComponent,canActivate:[LibrarianGuard]
    }
];
