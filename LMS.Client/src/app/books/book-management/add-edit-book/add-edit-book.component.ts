import { Component, Inject, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators, AbstractControl } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Book } from '../../../interfaces/book';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { BookService } from '../../../services/book.service';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { ToastService } from '../../../services/toast.service';
import { Category } from '../../../interfaces/category';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-add-edit-book',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule,MatInputModule,MatDatepickerModule,MatIconModule,MatButtonModule,MatCardModule,MatSelectModule],
  templateUrl: './add-edit-book.component.html',
  styleUrl: './add-edit-book.component.css'
})
export class AddEditBookComponent implements OnInit {
  bookForm!: FormGroup;
  fb = inject(FormBuilder);
  bookService = inject(BookService);
  toastService = inject(ToastService)
  isEditMode: boolean = false;
  categories: Category[] = [];
  private dialogRef = inject(MatDialogRef<AddEditBookComponent>);
  private data = inject(MAT_DIALOG_DATA) as { book?: Book; categories: Category[] };


  ngOnInit(): void {
    this.isEditMode = !!this.data.book;
    this.bookForm = this.fb.group({
      bookId: [this.data?.book?.bookId || null],
      title: [this.data?.book?.title || '', [Validators.required, Validators.maxLength(255)]],
      author: [this.data?.book?.author || '', [Validators.required, Validators.maxLength(255)]],
      description: [this.data?.book?.description || '', [Validators.maxLength(1000)]],
      coverImage: [this.data?.book?.coverImage || '', [Validators.required]],
      publisher: [this.data?.book?.publisher || '', [Validators.required, Validators.maxLength(255)]],
      publicationDate: [this.data?.book?.publicationDate || new Date(), [Validators.required]],
      isbn: [this.data?.book?.isbn || '', [Validators.required, Validators.maxLength(20)]],
      pageCount: [this.data?.book?.pageCount || 0, [Validators.required, Validators.min(1)]],
      categoryId: [this.data?.book?.categoryId || null, [Validators.required]]
    });
    this.categories = this.data.categories;
  }

  onSubmit(): void {
    if (this.bookForm.invalid) {
      return;
    }
    const bookData = this.bookForm.value as Book;
    if (this.isEditMode && this.data?.book?.bookId) {
      this.bookService.updateBook(this.data.book.bookId, bookData).subscribe({
        next: (response) => {
          this.toastService.openSnackBar(response.message); 
          this.dialogRef.close(true);
        },
        error: (error) => {
          this.toastService.openSnackBar(error.message);  
        }
      });
    } else {
      this.bookService.createBook(bookData).subscribe({
        next: (response) => {
          this.toastService.openSnackBar(response.message); 
          this.dialogRef.close(true);  
        },
        error: (error) => {
          this.toastService.openSnackBar(error); 
        }
      });
    }
  }
  

  onCancel(): void {
    this.dialogRef.close(false);
  }
}
