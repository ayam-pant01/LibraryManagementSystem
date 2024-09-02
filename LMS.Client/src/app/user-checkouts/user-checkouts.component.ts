import { Component, inject, OnInit } from '@angular/core';
import { CheckoutService } from '../services/checkout.service';
import { UserCheckoutResponse } from '../interfaces/checkout-response';
import { ToastService } from '../services/toast.service';
import { CommonModule } from '@angular/common';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatDialog } from '@angular/material/dialog';
import { ReviewComponent } from '../components/review/review.component';

@Component({
  selector: 'app-user-checkouts',
  standalone: true,
  imports: [CommonModule,MatExpansionModule,MatListModule,MatIconModule,MatButtonModule,MatTooltipModule],
  templateUrl: './user-checkouts.component.html',
  styleUrl: './user-checkouts.component.css'
})
export class UserCheckoutsComponent implements OnInit {
  checkoutService = inject(CheckoutService);
  toastService = inject(ToastService);
  dialog = inject(MatDialog);
  userCheckouts: UserCheckoutResponse[] = [];
  displayedColumns: string[] = ['title','isReturned','returnedDate'];
  totalCheckouts:number = 0;

  
  ngOnInit(): void {
    this.checkoutService.getUserCheckouts().subscribe({
      next:(response)=>{
        this.userCheckouts = response;
        this.totalCheckouts = this.userCheckouts.length;
      },
      error: (error) => this.toastService.openSnackBar(error)
    })
  }

  openReviewDialog(bookId: number): void {
    const dialogRef = this.dialog.open(ReviewComponent, {
      data: {
        bookId: bookId
      }
    });
  }

}
