import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { catchError, map, Observable, throwError } from 'rxjs';
import { CheckoutDetailResponse, CheckoutResponse, UserCheckoutResponse } from '../interfaces/checkout-response';
import { PaginationMetaData } from '../interfaces/pagination-meta-data';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {
  apiUrl: string = environment.apiUrl;
  private checkoutApiUrl = `${this.apiUrl}/checkout`;
  http = inject(HttpClient)
  
  getUserCheckouts(): Observable<UserCheckoutResponse[]> {
    return this.http.get<UserCheckoutResponse[]>(`${this.checkoutApiUrl}`);
  }

  checkoutBooks(checkoutRequest: { bookIds: number[] }): Observable<any> {
    return this.http.post<any>(`${this.checkoutApiUrl}`, checkoutRequest).pipe(
      catchError(this.handleError)
    );
  }
  getCheckoutDetails(checkoutId:number) : Observable<CheckoutDetailResponse[]>{
    const url = `${this.checkoutApiUrl}/${checkoutId}`;
    return this.http.get<CheckoutDetailResponse[]>(url).pipe(
      catchError(this.handleError)
    );
  }

  getAllUserCheckouts(name?: string, pageNumber: number = 1, pageSize: number = 10): Observable<{checkouts: CheckoutResponse[], pagination: PaginationMetaData}> {
    const url = `${this.checkoutApiUrl}/user-checkouts`;
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


  private handleError(error: any) {
    const errorMessage = error.error?.message || 'Server error';
    return throwError(() => new Error(errorMessage));
  }
}
