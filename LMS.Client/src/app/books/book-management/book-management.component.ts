import { AfterViewInit, Component, inject, OnInit, ViewChild } from '@angular/core';
import { BookService } from '../../services/book.service';
import { Book } from '../../interfaces/book';
import { PaginationMetaData } from '../../interfaces/pagination-meta-data';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { CommonModule, DatePipe } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';
import { AddEditBookComponent } from './add-edit-book/add-edit-book.component';
import { ToastService } from '../../services/toast.service';
import { Category } from '../../interfaces/category';
import { ActivatedRoute } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import {Sort, MatSortModule, MatSort} from '@angular/material/sort';
import { MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { debounceTime, distinctUntilChanged, Subject } from 'rxjs';

@Component({
  selector: 'app-book-management',
  standalone: true,
  imports: [MatTableModule,MatIconModule,MatButtonModule,MatPaginatorModule,DatePipe,MatFormFieldModule,MatOptionModule,MatSelectModule,MatInputModule,CommonModule,FormsModule,MatSortModule],
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
  categories: Category[] = [];
  route = inject(ActivatedRoute);
  selectedAvailability: boolean | null = null;
  searchQuery: string = '';
  private searchString = new Subject<string>();
  @ViewChild(MatSort, {static: true}) sort!: MatSort;
  
  ngOnInit(): void {
    this.route.data.subscribe(data=>{
      this.categories = data['categories'];
    })
    this.searchString.pipe(
      debounceTime(350),
      distinctUntilChanged()
    ).subscribe(query=>{
      this.loadBooks();
    })
    this.loadBooks();
  }
  
  ngAfterViewInit() {
    this.books.paginator = this.paginator;
    this.books.sort = this.sort;
    this.sort.sortChange.subscribe(() => {
      this.loadBooks(this.sort.active, this.sort.direction);
    });
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

  applySearchQuery(): void {
    this.searchString.next(this.searchQuery)
  }

  loadBooks(sortField: string = 'title', sortDirection: string = 'asc',pageNumber: number = 1, pageSize: number = 10): void {
    const isDescending = sortDirection === 'desc';
    this.bookService.getBooks(this.searchQuery,this.selectedAvailability, sortField,isDescending,pageNumber, pageSize).subscribe({
      next: (response) => {
        this.books.data = response.books;
        this.pagination = response.pagination;
      },
      error: (error) => this.toastService.openSnackBar(error)
    });
  }

  onPageChange(event: any): void {
    this.loadBooks(this.sort.active, this.sort.direction,event.pageIndex + 1, event.pageSize);
  }

  openAddEditBookDialog(book?: Book): void {
    const dialogRef = this.dialog.open(AddEditBookComponent, {
      data: {
        book: book ? book : null,
        categories: this.categories
      }
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
