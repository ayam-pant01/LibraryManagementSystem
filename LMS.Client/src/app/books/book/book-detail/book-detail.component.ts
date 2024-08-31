import { Component, inject, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { Book } from '../../../interfaces/book';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { StarRatingComponent } from '../../../components/star-rating/star-rating.component';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ToastService } from '../../../services/toast.service';
import { CartService } from '../../../services/cart.service';

@Component({
  selector: 'app-book-detail',
  standalone: true,
  imports: [MatCardModule,MatDialogModule,CommonModule,MatButtonModule,MatIconModule,StarRatingComponent,MatTooltipModule],
  templateUrl: './book-detail.component.html',
  styleUrl: './book-detail.component.css'
})
export class BookDetailComponent {
  private dialogRef = inject(MatDialogRef<BookDetailComponent>);
  data = inject(MAT_DIALOG_DATA) as { book: Book };
  toastService = inject(ToastService);
  private cartService = inject(CartService);
  
  onClose(): void {
    this.dialogRef.close();
  }
  
  addBookToCart() {
    if(this.data.book && this.data.book.isAvailable){
      this.toastService.openSnackBar("Book added to cart for checkout.");
      this.cartService.addToCart(this.data.book);
      this.onClose();
      return;
    }else{
      this.toastService.openSnackBar("The book is not available for checkout");
    }
  }
}
