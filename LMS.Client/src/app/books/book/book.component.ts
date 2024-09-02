import { Component, inject, OnInit } from '@angular/core';
import { Book } from '../../interfaces/book';
import { BooksByCatergory } from '../../interfaces/category';
import { BookCardComponent } from './book-card/book-card.component';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { BookService } from '../../services/book.service';
import { PaginationMetaData } from '../../interfaces/pagination-meta-data';
import { FormsModule } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { BookDetailComponent } from './book-detail/book-detail.component';
import { ToastService } from '../../services/toast.service';
import { debounceTime, distinctUntilChanged, Subject } from 'rxjs';

@Component({
  selector: 'app-book',
  standalone: true,
  imports: [BookCardComponent,MatIconModule,MatInputModule,CommonModule,MatCardModule,FormsModule],
  templateUrl: './book.component.html',
  styleUrl: './book.component.css'
})
export class BookComponent implements OnInit {
  bookService = inject(BookService)
  books: Book[] = [];
  pagination: PaginationMetaData | null = null;
  booksToDisplay: BooksByCatergory[] = [];
  private searchString = new Subject<string>();
  searchQuery: string = '';
  selectedAvailability: boolean | null = null;
  dialog = inject(MatDialog);
  toastService = inject(ToastService)

  ngOnInit(): void {
    this.searchString.pipe(
      debounceTime(350),
      distinctUntilChanged()
    ).subscribe(query=>{
      this.loadBooks();
    })
    this.loadBooks();
  }
  
  applySearchQuery(): void {
    this.searchString.next(this.searchQuery)
  }

  loadBooks(sortField: string = 'title', sortDirection: string = 'asc',pageNumber: number = 1, pageSize: number = 10): void {
    const isDescending = sortDirection === 'desc';
    this.bookService.getBooks(this.searchQuery,this.selectedAvailability, sortField,isDescending,pageNumber, pageSize).subscribe({
      next: (response) => {
        this.books = response.books;
        this.pagination = response.pagination;
      },
      error: (error) => this.toastService.openSnackBar(error)
    });
  }
  

  openBookDetailDialog(book?: Book): void {
    const dialogRef = this.dialog.open(BookDetailComponent, {
      data: book ? { book } : null
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadBooks();
      }
    });
  }
}
