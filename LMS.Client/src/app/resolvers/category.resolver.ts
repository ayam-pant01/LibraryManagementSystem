import { ResolveFn } from '@angular/router';
import { Category } from '../interfaces/category';
import { inject } from '@angular/core';
import { CategoryService } from '../services/category.service';

export const categoryResolver: ResolveFn<Category[]> = (route, state) => {
  const categoryService = inject(CategoryService);
  return categoryService.getCategories();
};
