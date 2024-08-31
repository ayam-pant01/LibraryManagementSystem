import { Component, Inject, inject, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { ReturnService } from '../../services/return.service';
import { CheckoutDetailResponse, CheckoutResponse } from '../../interfaces/checkout-response';
import { PaginationMetaData } from '../../interfaces/pagination-meta-data';
import {MatExpansionModule, MatExpansionPanel} from '@angular/material/expansion';
import { CommonModule, DatePipe } from '@angular/common';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatDialog, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { ToastService } from '../../services/toast.service';

@Component({
  selector: 'app-return-list',
  standalone: true,
  imports: [FormsModule,MatButton,MatIconModule,MatInputModule,MatCardModule,MatExpansionModule,DatePipe,CommonModule,MatTableModule,MatDialogModule],
  templateUrl: './return-list.component.html',
  styleUrl: './return-list.component.css'
})
export class ReturnListComponent implements OnInit{
searchString: string = "";
returnService = inject(ReturnService);
toastService = inject(ToastService);
pagination?: PaginationMetaData;
returns: CheckoutResponse[] = [];
returnDetails = new MatTableDataSource<CheckoutDetailResponse>();
displayedColumns: string[] = ['title','isReturned','returnedDate','actions'];
@ViewChild('confirmDialog') confirmDialog!: TemplateRef<any>;
dialogRef!: MatDialogRef<any>;
constructor(private dialog: MatDialog) {}
ngOnInit(): void {
  this.loadReturnLists();
}
trackByCheckoutId(index: number, checkout: CheckoutResponse): number {
  return checkout.checkoutId;
}

loadReturnLists(pageNumber: number = 1, pageSize: number = 10): void {
  this.returnService.getUserCheckouts(this.searchString, pageNumber, pageSize).subscribe({
    next: (response) => {
      this.returns = response.checkouts;
      this.pagination = response.pagination;
    },
    error: (error) => this.toastService.openSnackBar(error)
  });
}

getCheckOutDetail(checkoutId:number){
  this.returnDetails.data = [];
  this.returnService.getCheckoutDetails(checkoutId).subscribe({
    next: (response) => {
      this.returnDetails.data = response;
    },
    error: (error) => this.toastService.openSnackBar(error)
  })
}

confirmReturn(checkoutDetailId: number,panel: MatExpansionPanel): void {
  this.dialogRef = this.dialog.open(this.confirmDialog);
  this.dialogRef.afterClosed().subscribe(result => {
    if (result) {
      this.returnService.returnBook(checkoutDetailId).subscribe({
        next:(response)=>{
          this.loadReturnLists();
          this.toastService.openSnackBar(response.message); 
          panel.close();
        },
        error: (error) => {
          this.toastService.openSnackBar(error.message)
        }
      })
    }
  });
}
}
