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
    console.log("bookdata",this.data.book)
    const sampleReviews: Review[] = [
      {
        reviewerName: "Harry Porter",
        userId: 101,
        bookId: 1,
        rating: 5,
        comment: "An absolutely captivating book! A must-read for everyone.",
        reviewDate: new Date('2024-08-01')
      },
      {
        reviewerName: "John bush",
        userId: 102,
        bookId: 1,
        rating: 4,
        comment: "Great storyline, but the ending was a bit predictable.Great storyline, but the ending was a bit predictableGreat storyline, but the ending was a bit predictablGreat storyline, but the ending was a bit predictableGreat storyline, but the ending was a bit predictableGreat storyline, but the ending was a bit predictableGreat storyline, but the ending was a bit predictableGreat storyline, but the ending was a bit predictableGreat storyline, but the ending was a bit predictablee",
        reviewDate: new Date('2024-08-02')
      },
      {
        reviewerName: "Jimmy carter",
        userId: 103,
        bookId: 1,
        rating: 3,
        comment: "It was an average read. Some parts were engaging, others not so much.",
        reviewDate: new Date('2024-08-03')
      }
    ];
    this.data.book.reviews = sampleReviews
  }
  onClose(): void {
    this.dialogRef.close();
  }
}
