import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { environment } from '../../environments/environment';
import { Category } from '../interfaces/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  apiUrl: string = environment.apiUrl;
  private categoryApiUrl = `${this.apiUrl}/category`;

  constructor(private http: HttpClient) { }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.categoryApiUrl).pipe(
      catchError(this.handleError)
    );
  }

  addCategory(category: Category): Observable<any> {
    return this.http.post<any>(this.categoryApiUrl, category).pipe(
      catchError(this.handleError)
    );
  }

  updateCategory(categoryId: number, category: Category): Observable<any> {
    return this.http.put<any>(`${this.categoryApiUrl}/${categoryId}`, category).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: any) {
    const errorMessage = error.error?.message || 'Server error';
    return throwError(() => new Error(errorMessage)); 
  }
}
