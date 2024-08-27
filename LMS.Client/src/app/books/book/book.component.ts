import { Component, inject } from '@angular/core';
import { Book } from '../../interfaces/book';
import { BooksByCatergory } from '../../interfaces/category';
import { BookCardComponent } from '../book-card/book-card.component';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { BookService } from '../../services/book.service';
import { PaginationMetaData } from '../../interfaces/pagination-meta-data';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-book',
  standalone: true,
  imports: [BookCardComponent,MatIconModule,MatInputModule,CommonModule,MatCardModule,FormsModule],
  templateUrl: './book.component.html',
  styleUrl: './book.component.css'
})
export class BookComponent {
  bookService = inject(BookService)
  books: Book[] = [];
  pagination?: PaginationMetaData;
  booksToDisplay: BooksByCatergory[] = [];
  searchString: string = "";

  ngOnInit(): void {
    this.loadBooks();
  }

  loadBooks(pageNumber: number = 1, pageSize: number = 10): void {
    this.bookService.getBooks("", this.searchString, pageNumber, pageSize).subscribe(response => {
      this.books = response.books;
      this.pagination = response.pagination;
    });
  }
}
