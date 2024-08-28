import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { Book } from '../../../interfaces/book';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { Review } from '../../../interfaces/review';
import { MatIconModule } from '@angular/material/icon';
import { StarRatingComponent } from '../../../components/star-rating/star-rating.component';

@Component({
  selector: 'app-book-detail',
  standalone: true,
  imports: [MatCardModule,MatDialogModule,CommonModule,MatButtonModule,MatIconModule,StarRatingComponent],
  templateUrl: './book-detail.component.html',
  styleUrl: './book-detail.component.css'
})
export class BookDetailComponent {
  constructor(
    public dialogRef: MatDialogRef<BookDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { book: Book }
  ) {
  }
  onClose(): void {
    this.dialogRef.close();
  }
}
