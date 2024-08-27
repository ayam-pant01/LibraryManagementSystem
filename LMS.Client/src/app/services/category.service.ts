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

  // Get all categories
  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.categoryApiUrl).pipe(
      catchError(this.handleError)
    );
  }

  // Add a new category
  addCategory(category: Category): Observable<Category> {
    return this.http.post<Category>(this.categoryApiUrl, category).pipe(
      catchError(this.handleError)
    );
  }

  // Update an existing category
  updateCategory(categoryId: number, category: Category): Observable<Category> {
    return this.http.put<Category>(`${this.categoryApiUrl}/${categoryId}`, category).pipe(
      catchError(this.handleError)
    );
  }

  // Delete a category
  deleteCategory(categoryId: number): Observable<Category> {
    return this.http.delete<Category>(`${this.categoryApiUrl}/${categoryId}`).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: any) {
    const errorMessage = error.error?.message || 'Server error';
    return throwError(() => new Error(errorMessage)); // Updated to new syntax
  }
}
