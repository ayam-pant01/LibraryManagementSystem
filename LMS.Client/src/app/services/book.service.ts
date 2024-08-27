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

  getBooks(title?: string, searchQuery?: string, pageNumber: number = 1, pageSize: number = 10): Observable<{books: Book[], pagination: PaginationMetaData}> {
    let params = new HttpParams();
    if (title) params = params.append('title', title);
    if (searchQuery) params = params.append('searchQuery', searchQuery);
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

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

  getBookById(id: number): Observable<Book> {
    return this.http.get<Book>(`${this.bookApiUrl}/${id}`).pipe(
      catchError(this.handleError)
    );
  }

  createBook(book: BookForCreateAndUpdateDto): Observable<Book> {
    return this.http.post<Book>(this.bookApiUrl, book).pipe(
      catchError(this.handleError)
    );
  }

  updateBook(id: number, book: BookForCreateAndUpdateDto): Observable<void> {
    return this.http.put<void>(`${this.bookApiUrl}/${id}`, book).pipe(
      catchError(this.handleError)
    );
  }

  deleteBook(id: number): Observable<void> {
    return this.http.delete<void>(`${this.bookApiUrl}/${id}`).pipe(
      catchError(this.handleError)
    );
  }

  

  private handleError(error: any) {
    const errorMessage = error.error?.message || 'Server error';
    return throwError(() => new Error(errorMessage));
  }
}
