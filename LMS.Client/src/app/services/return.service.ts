import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient, HttpParams } from '@angular/common/http';
import { catchError, map, Observable, throwError } from 'rxjs';
import { PaginationMetaData } from '../interfaces/pagination-meta-data';
import { CheckoutDetailResponse, CheckoutResponse } from '../interfaces/checkout-response';

@Injectable({
  providedIn: 'root'
})
export class ReturnService {
  apiUrl: string = environment.apiUrl;
  private returnApiUrl = `${this.apiUrl}/return`;

  constructor(private http: HttpClient) {}


  returnBook(checkoutDetailId:number): Observable<any>{
    const url = `${this.returnApiUrl}/return-book/${checkoutDetailId}`;
    return this.http.put<any>(url, {}).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: any) {
    const errorMessage = error.error?.message || 'Server error';
    return throwError(() => new Error(errorMessage));
  }
}
