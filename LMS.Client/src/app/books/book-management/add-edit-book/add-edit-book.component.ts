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

@Component({
  selector: 'app-add-edit-book',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule,MatInputModule,MatDatepickerModule,MatIconModule,MatButtonModule,MatCardModule],
  templateUrl: './add-edit-book.component.html',
  styleUrl: './add-edit-book.component.css'
})
export class AddEditBookComponent implements OnInit {
  bookForm!: FormGroup;
  fb = inject(FormBuilder);
  bookService = inject(BookService);
  isEditMode: boolean = false;

  constructor(
    public dialogRef: MatDialogRef<AddEditBookComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any | null
  ) {
  }

  ngOnInit(): void {
    this.isEditMode = !!this.data;
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
      categoryId: [this.data?.book?.categoryId || 1, [Validators.required]]
    });
  }
  
  onSubmit(): void {
    if (this.bookForm.invalid) {
      return;
    }

    const bookData: Book = this.bookForm.value;

    if (this.isEditMode) {
      this.bookService.updateBook(this.data?.book?.bookId,bookData).subscribe(() => {
        this.dialogRef.close(true);
      });
    } else {
      this.bookService.createBook(bookData).subscribe(() => {
        this.dialogRef.close(true);
      });
    }
  }

  onCancel(): void {
    this.dialogRef.close(false);
  }
}
