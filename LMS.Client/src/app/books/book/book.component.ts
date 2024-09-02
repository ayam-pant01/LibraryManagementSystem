import { AfterViewInit, Component, inject, OnInit, ViewChild } from '@angular/core';
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
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-book',
  standalone: true,
  imports: [BookCardComponent,MatIconModule,MatInputModule,CommonModule,MatCardModule,FormsModule,MatPaginatorModule],
  templateUrl: './book.component.html',
  styleUrl: './book.component.css'
})
export class BookComponent implements OnInit, AfterViewInit {
  bookService = inject(BookService)
  books: Book[] = [];
  pagination: PaginationMetaData | null = null;
  pageSize: number = 14;
  pageNumber: number = 1;
  booksToDisplay: BooksByCatergory[] = [];
  private searchString = new Subject<string>();
  searchQuery: string = '';
  selectedAvailability: boolean | null = null;
  dialog = inject(MatDialog);
  toastService = inject(ToastService)
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  ngOnInit(): void {
    this.searchString.pipe(
      debounceTime(350),
      distinctUntilChanged()
    ).subscribe(query=>{
      this.loadBooks();
    })
    this.loadBooks();
  }

  
  ngAfterViewInit() {
    this.paginator.page.subscribe(() => this.loadBooks());
    // this.books.sort = this.sort;
  }
  
  applySearchQuery(): void {
    this.searchString.next(this.searchQuery)
  }
  applyAvailabilityFilter(value: string): void {
    this.selectedAvailability = null
    if(value == "true"){
      this.selectedAvailability = true;
    }else if(value == "false"){
      this.selectedAvailability = false;
    }
    this.loadBooks();
  }

  loadBooks(sortField: string = 'title', sortDirection: string = 'asc'): void {
    const isDescending = sortDirection === 'desc';
    this.bookService.getBooks(this.searchQuery,this.selectedAvailability, sortField, isDescending, this.pageNumber, this.pageSize).subscribe({
      next: (response) => {
        this.books = response.books;
        this.pagination = response.pagination;
        if (this.paginator) {
          this.paginator.pageIndex = this.pagination.CurrentPage - 1;
          this.paginator.pageSize = this.pagination.PageSize;
          this.paginator.length = this.pagination.TotalItemCount; // Total items count
        }

      },
      error: (error) => this.toastService.openSnackBar(error)
    });
  }
  onPageChange(event: any): void {
    this.pageNumber = event.pageIndex + 1;
    this.pageSize = event.pageSize;
    this.loadBooks();
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
