import { Component, inject, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { BookService } from '../../services/book.service';
import { Book } from '../../interfaces/book';
import { ToastService } from '../../services/toast.service';
import { CommonModule } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';
import { BookDetailComponent } from '../../books/book/book-detail/book-detail.component';
import { BookCardComponent } from '../../books/book/book-card/book-card.component';


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatCardModule,MatButtonModule,MatIconModule,RouterLink,CommonModule,BookCardComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
authService = inject(AuthService);
bookService = inject(BookService);
dialog = inject(MatDialog);
toastService = inject(ToastService)
books: Book[] = [];

ngOnInit(): void {
  this.loadFeaturedBooks()
}

loadFeaturedBooks(): void {
  this.bookService.getFeaturedBooks().subscribe({
    next: (response) => {
      this.books = response;
    },
    error: (error) => this.toastService.openSnackBar(error)
  });
}

openBookDetailDialog(book?: Book): void {
  const dialogRef = this.dialog.open(BookDetailComponent, {
    data: book ? { book } : null
  });
}
}
