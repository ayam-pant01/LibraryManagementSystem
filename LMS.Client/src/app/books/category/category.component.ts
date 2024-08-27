import { Component, inject, OnInit } from '@angular/core';
import { CategoryService } from '../../services/category.service';
import { Category } from '../../interfaces/category';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { ToastService } from '../../services/toast.service';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';

@Component({
  selector: 'app-category',
  standalone: true,
  imports: [CommonModule,MatIconModule,MatCardModule,FormsModule,MatInputModule,MatListModule],
  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent implements OnInit {
  newCategoryName: string = '';
  categories: Category[] = [];
  editingCategoryId: number | null = null;
  categoryService = inject(CategoryService)
  toastService = inject(ToastService)

  ngOnInit(): void {
    this.loadCategories();
  }

  loadCategories() {
      // Dummy data for testing
      const dummyCategories: Category[] = [
        { categoryId: 1, name: 'Fiction' },
        { categoryId: 2, name: 'Non-Fiction' },
        { categoryId: 3, name: 'Science Fiction' },
        { categoryId: 4, name: 'Fantasy' }
      ];
  
      // Simulate a successful response
      this.categories = dummyCategories;
    // this.categoryService.getCategories().subscribe({
    //   next: (response) => this.categories = response, // Adjust according to your data structure
    //   error: (error) => this.toastService.openSnackBar(error)
    // });
  }

  addCategory() {
    if (!this.newCategoryName) return;

    const newCategory: Category = {
      categoryId: 0, // This will be set by the backend or API
      name: this.newCategoryName
    };

    this.categoryService.addCategory(newCategory).subscribe({
      next: (response) => {
        this.newCategoryName = ''; // Clear input field
        this.loadCategories(); // Refresh the list
        this.toastService.openSnackBar('Category added successfully!');
      },
      error: (error) => this.toastService.openSnackBar(error)
    });
  }

  onCategoryNameChange(categoryId: number, newName: string) {
    const category = this.categories.find(cat => cat.categoryId === categoryId);
    if (category) {
      category.name = newName;
    }
    this.editingCategoryId = categoryId;
  }

  editCategory(categoryId: number) {
    const category = this.categories.find(cat => cat.categoryId === categoryId);
    if (category) {
      this.categoryService.updateCategory(categoryId,category).subscribe({
        next: (response) => {
          this.editingCategoryId = null;
          this.toastService.openSnackBar('Category updated successfully!');
        },
        error: (error) => this.toastService.openSnackBar(error)
      });
    }
  }
}
