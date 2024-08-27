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
import { MatButtonModule } from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';


@Component({
  selector: 'app-category',   

  standalone: true,
  imports: [CommonModule, MatIconModule, MatCardModule, FormsModule, MatInputModule, MatListModule,MatButtonModule,MatTableModule],
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  newCategoryName: string = '';
  displayedColumns: string[] = ['name', 'actions'];
  categories: Category[] = [];
  editingCategoryId: number | null = null;

  categoryService = inject(CategoryService);
  toastService = inject(ToastService);

  ngOnInit(): void {
    this.loadCategories();
  }

  loadCategories() {
    this.categoryService.getCategories().subscribe({
      next: (response) => {
        this.categories = response.map(category => ({ ...category, isEditing: false }));
      },
      error: (error) => this.toastService.openSnackBar(error)
    });
  }

  addCategory() {
    if (!this.newCategoryName) return;

    const newCategory: Category = {
      categoryId: 0,
      name: this.newCategoryName
    };

    this.categoryService.addCategory(newCategory).subscribe({
      next: (response) => {
        this.newCategoryName = '';
        this.loadCategories();
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
  }

  editCategory(categoryId: number) {
    const category = this.categories.find(cat => cat.categoryId === categoryId);
    if (category) {
      category.isEditing = !category.isEditing;
    }
  }

  saveCategory(categoryId: number) {
    const category = this.categories.find(cat => cat.categoryId === categoryId);
    if (category) {
      this.categoryService.updateCategory(categoryId, category).subscribe({
        next: (response) => {
          category.isEditing = false;
          this.toastService.openSnackBar('Category updated successfully!');
        },
        error: (error) => this.toastService.openSnackBar(error)
      });
    }
  }

  cancelEdit(categoryId: number) {
    const category = this.categories.find(cat => cat.categoryId === categoryId);
    if (category) {
      category.isEditing = false;
    }
  }
}