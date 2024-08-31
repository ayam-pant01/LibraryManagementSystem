import { Component, inject, OnInit } from '@angular/core';
import { CheckoutService } from '../services/checkout.service';
import { CheckoutDetailResponse, UserCheckoutResponse } from '../interfaces/checkout-response';
import { ToastService } from '../services/toast.service';
import { CommonModule } from '@angular/common';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatListModule } from '@angular/material/list';

@Component({
  selector: 'app-user-checkouts',
  standalone: true,
  imports: [CommonModule,MatExpansionModule,MatListModule],
  templateUrl: './user-checkouts.component.html',
  styleUrl: './user-checkouts.component.css'
})
export class UserCheckoutsComponent implements OnInit {
  checkoutService = inject(CheckoutService);
  toastService = inject(ToastService);
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

}
