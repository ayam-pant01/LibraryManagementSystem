import { AfterViewInit, Component, inject, OnInit, ViewChild } from '@angular/core';
import { BookService } from '../../services/book.service';
import { Book } from '../../interfaces/book';
import { PaginationMetaData } from '../../interfaces/pagination-meta-data';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { DatePipe } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';
import { AddEditBookComponent } from './add-edit-book/add-edit-book.component';
import { ToastService } from '../../services/toast.service';

@Component({
  selector: 'app-book-management',
  standalone: true,
  imports: [MatTableModule,MatIconModule,MatButtonModule,MatPaginatorModule,DatePipe],
  templateUrl: './book-management.component.html',
  styleUrl: './book-management.component.css'
})
export class BookManagementComponent implements OnInit,AfterViewInit  {
  displayedColumns: string[] = ['title','categoryName',  'author', 'publisher', 'publicationDate', 'pageCount', 'isAvailable', 'actions'];
  bookService = inject(BookService)
  dialog = inject(MatDialog);
  toastService = inject(ToastService)
  books = new MatTableDataSource<Book>();
  pagination?: PaginationMetaData;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  
  ngOnInit(): void {
    this.loadBooks();
  }
  ngAfterViewInit() {
    this.books.paginator = this.paginator;
  }

  loadBooks(pageNumber: number = 1, pageSize: number = 10): void {
    this.bookService.getBooks("", "", pageNumber, pageSize).subscribe({
      next: (response) => {
        this.books.data = response.books;
        this.pagination = response.pagination;
      },
      error: (error) => this.toastService.openSnackBar(error)
    });
  }

  onPageChange(event: any): void {
    this.loadBooks(event.pageIndex + 1, event.pageSize);
  }

  openAddEditBookDialog(book?: Book): void {
    const dialogRef = this.dialog.open(AddEditBookComponent, {
      data: book ? { book } : null
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadBooks();
      }
    });
  }

  editBook(book: Book): void {
    this.openAddEditBookDialog(book);
  }

}
