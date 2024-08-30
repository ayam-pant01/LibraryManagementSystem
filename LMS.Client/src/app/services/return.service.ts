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

  getUserCheckouts(name?: string, pageNumber: number = 1, pageSize: number = 10): Observable<{checkouts: CheckoutResponse[], pagination: PaginationMetaData}> {
    const url = `${this.returnApiUrl}/user-checkouts`;
    let params = new HttpParams();
    if (name) params = params.append('name', name);
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    return this.http.get<CheckoutResponse[]>(url, { params, observe: 'response' })
    .pipe(
      map((response) => { 
          const pagination = JSON.parse(response.headers.get('X-Pagination')!) as PaginationMetaData;
          const checkouts = response.body ?? [];
          return { checkouts, pagination };
      }),
      catchError(this.handleError)
    );
  }

  getCheckoutDetails(checkoutId:number) : Observable<CheckoutDetailResponse[]>{
    const url = `${this.returnApiUrl}/checkout-details/${checkoutId}`;
    return this.http.get<CheckoutDetailResponse[]>(url).pipe(
      catchError(this.handleError)
    );
  }

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
