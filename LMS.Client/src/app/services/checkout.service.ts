import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { catchError, Observable, throwError } from 'rxjs';
import { CheckoutResponse, UserCheckoutResponse } from '../interfaces/checkout-response';

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

  private handleError(error: any) {
    const errorMessage = error.error?.message || 'Server error';
    return throwError(() => new Error(errorMessage));
  }
}
