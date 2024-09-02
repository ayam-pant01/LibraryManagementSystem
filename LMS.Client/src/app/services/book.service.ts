import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { catchError, map,Observable, throwError } from 'rxjs';
import { environment } from '../../environments/environment';
import { Book, BookForCreateAndUpdateDto } from '../interfaces/book';
import { PaginationMetaData } from '../interfaces/pagination-meta-data';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  apiUrl: string = environment.apiUrl;
  private bookApiUrl = `${this.apiUrl}/book`;

  constructor(private http: HttpClient) {}

  getBooks(
    searchQuery?: string,
     isAvailable?:boolean | null,
     sortBy:string = 'Title',
     isDescending:boolean = false,
     pageNumber: number = 1,
     pageSize: number = 10
    ): Observable<{books: Book[], pagination: PaginationMetaData}> {
      let params = new HttpParams()
      .append('pageNumber', pageNumber.toString())
      .append('pageSize', pageSize.toString())
      .append('sortBy', sortBy)
      .append('isDescending', isDescending.toString());
  
    if (searchQuery) {
      params = params.append('searchQuery', searchQuery);
    }
  
    if (isAvailable !== null && isAvailable !== undefined) {
        params = params.append('isAvailable', isAvailable.toString());
    }

    return this.http.get<Book[]>(this.bookApiUrl, { params, observe: 'response' })
    .pipe(
      map((response) => { 
          const pagination = JSON.parse(response.headers.get('X-Pagination')!) as PaginationMetaData;
          const books = response.body ?? [];
          return { books, pagination };
      }),
      catchError(this.handleError)
    );
  }

  getFeaturedBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(`${this.bookApiUrl}/featured-books`).pipe(
      catchError(this.handleError)
    );
  }

  getBookById(id: number): Observable<Book> {
    return this.http.get<Book>(`${this.bookApiUrl}/${id}`).pipe(
      catchError(this.handleError)
    );
  }

  createBook(book: BookForCreateAndUpdateDto): Observable<any> {
    return this.http.post<any>(this.bookApiUrl, book).pipe(
      catchError(this.handleError)
    );
  }

  updateBook(id: number, book: BookForCreateAndUpdateDto): Observable<any> {
    return this.http.put<any>(`${this.bookApiUrl}/${id}`, book).pipe(
      catchError(this.handleError)
    );
  }

  deleteBook(id: number): Observable<any> {
    return this.http.delete<any>(`${this.bookApiUrl}/${id}`).pipe(
      catchError(this.handleError)
    );
  }

  

  private handleError(error: any) {
    const errorMessage = error.error?.message || 'Server error';
    return throwError(() => new Error(errorMessage));
  }
}
