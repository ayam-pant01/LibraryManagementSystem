import { inject, Injectable } from '@angular/core';
import { Review } from '../interfaces/review';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {
  apiUrl: string = environment.apiUrl;
  private reviewApiUrl = `${this.apiUrl}/review`;
  http = inject(HttpClient)

  getReview(bookId: number): Observable<Review> {
    return this.http.get<any>(`${this.reviewApiUrl}/${bookId}`);
  }
  
  addReview(bookId: number, rating: number, comment: string): Observable<any> {
    return this.http.post<any>(`${this.reviewApiUrl}`, { bookId, rating, comment }).pipe(
      catchError(this.handleError)
    );;
  }

  updateReview(bookId: number, rating: number, comment: string): Observable<any> {
    return this.http.put<any>(`${this.reviewApiUrl}/${bookId}`, { rating, comment });
  }
  deleteReview(bookId: number, rating: number, comment: string): Observable<any> {
    return this.http.delete<any>(`${this.reviewApiUrl}/${bookId}`);
  }


  private handleError(error: any) {
    const errorMessage = error.error?.message || 'Server error';
    return throwError(() => new Error(errorMessage));
  }
}
