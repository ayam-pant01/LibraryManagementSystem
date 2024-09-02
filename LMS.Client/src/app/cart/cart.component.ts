import { Component, inject, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { CartService } from '../services/cart.service';
import { Book } from '../interfaces/book';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { CommonModule } from '@angular/common';
import { MatIcon } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatButtonModule } from '@angular/material/button';
import { Router, RouterLink } from '@angular/router';
import { MatDialog, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { CheckoutService } from '../services/checkout.service';
import { ToastService } from '../services/toast.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  standalone: true,
  imports: [MatCardModule,MatListModule,CommonModule,MatIcon,MatTooltipModule,MatButtonModule,RouterLink,MatDialogModule],
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  cartItems = new Set<Book>();
  totalBooks: number = 0;
  @ViewChild('confirmCheckoutDialog') confirmDialog!: TemplateRef<any>;
  dialogRef!: MatDialogRef<any>;
  cartService = inject(CartService)
  checkoutService = inject(CheckoutService)
  toastService = inject(ToastService)
  router = inject(Router);

  constructor(private dialog: MatDialog) {}

  ngOnInit(): void {
    this.cartService.cartItems$.subscribe((items: Set<Book>) => {
      this.cartItems = items;
      this.totalBooks = this.cartService.getTotalBooks();
    });
  }

  removeBook(book: Book): void {
    this.cartService.removeBook(book);
  }

  clearCart(): void {
    this.cartService.clearCart();
  }

  checkout(): void {
    this.dialogRef = this.dialog.open(this.confirmDialog);
    this.dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const checkoutRequest = {
          bookIds: Array.from(this.cartItems).map(book => book.bookId)
        };
        this.checkoutService.checkoutBooks(checkoutRequest).subscribe({
          next:(response)=>{
            this.toastService.openSnackBar(response.message); 
            this.router.navigate(['/user-checkouts'])
          },
          error: (error) => {
            this.toastService.openSnackBar(error.message)
          }
        })
        
      }
    });
  }
}











