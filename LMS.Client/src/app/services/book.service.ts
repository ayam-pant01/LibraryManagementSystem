import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { map,Observable } from 'rxjs';
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

  // Get all books with optional filtering, paging, and search query
  getBooks(title?: string, searchQuery?: string, pageNumber: number = 1, pageSize: number = 10): Observable<{books: Book[], pagination: PaginationMetaData}> {
    let params = new HttpParams();
    if (title) params = params.append('title', title);
    if (searchQuery) params = params.append('searchQuery', searchQuery);
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    return this.http.get<Book[]>(this.bookApiUrl, { params, observe: 'response' })
    .pipe(
      map((response) => { 
          console.log("response",response)
          const pagination = JSON.parse(response.headers.get('X-Pagination')!) as PaginationMetaData;
          // const books = response.body?.books ?? [];
          const books = response.body ?? [];
          console.log("pagination",pagination)
          console.log("books",books)
          return { books, pagination };
      })
    );
  }

  // Get book by ID
  getBookById(id: number): Observable<Book> {
    return this.http.get<Book>(`${this.bookApiUrl}/${id}`);
  }

  // Create a new book
  createBook(book: BookForCreateAndUpdateDto): Observable<Book> {
    return this.http.post<Book>(this.bookApiUrl, book);
  }

  // Update an existing book
  updateBook(id: number, book: BookForCreateAndUpdateDto): Observable<void> {
    return this.http.put<void>(`${this.bookApiUrl}/${id}`, book);
  }

  // Delete a book by ID
  deleteBook(id: number): Observable<void> {
    return this.http.delete<void>(`${this.bookApiUrl}/${id}`);
  }
}
