import { Component, OnInit, inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { ReviewService } from '../../services/review.service';
import { Review } from '../../interfaces/review';
import { FormsModule, NgForm } from '@angular/forms';
import { StarRatingComponent } from '../star-rating/star-rating.component';
import { CommonModule, DatePipe } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { ToastService } from '../../services/toast.service';

@Component({
  selector: 'app-review',
  standalone: true,
  imports: [MatDialogModule,StarRatingComponent,CommonModule,MatFormFieldModule,FormsModule,MatButtonModule,DatePipe,MatIconModule,MatInputModule],
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css'],
})
export class ReviewComponent implements OnInit {
  review: Review | null = null; 
  rating: number | undefined;
  comment: string | undefined;
  private dialogRef = inject(MatDialogRef<ReviewComponent>);
  data = inject(MAT_DIALOG_DATA) as { bookId: number };
  reviewService = inject(ReviewService);
  toastService = inject(ToastService);
  isNewReview: boolean = true;
  isAddEditMode: boolean = true; 

  ngOnInit(): void {
    this.loadReview();
  }

  loadReview(): void {
    this.reviewService.getReview(this.data.bookId).subscribe(existingReview => {
      if (existingReview) {
        this.review = existingReview;
        this.rating = existingReview.rating;
        this.comment = existingReview.comment;
        this.isNewReview = false;
        this.isAddEditMode = false; 
      }
    });
  }

  onSave(): void {
    if (!this.rating || !this.comment) {
      return; 
    }
    if(this.rating <0 || this.rating > 5){
      this.toastService.openSnackBar("Rating should be between 1 and 5");
      return;
    }

    if (this.isNewReview) {
      this.reviewService.addReview(this.data.bookId, this.rating, this.comment).subscribe({
        next: (response) => {
          this.dialogRef.close(true);
          this.toastService.openSnackBar(response.message);
        },
        error: (error) =>this.toastService.openSnackBar(error.message)
      });
    } else {
      this.reviewService.updateReview(this.data.bookId, this.rating, this.comment).subscribe({
        next: (response) => {
          this.dialogRef.close(true);
          this.toastService.openSnackBar(response.message);
        },
        error: (error) =>this.toastService.openSnackBar(error.message)
      });
    }
  }

  editReview(): void {
    this.isAddEditMode = true;
  }

  onClose(): void {
    this.dialogRef.close();
  }
}