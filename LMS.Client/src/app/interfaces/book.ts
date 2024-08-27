import { Category } from "./category";

export interface Book {
    bookId: number;
    title: string; // Max length 255
    author: string; // Max length 255
    description: string; // Max length 1000
    coverImage: string; // URL
    publisher: string; // Max length 255
    publicationDate: Date;
    isbn: string; // Max length 20, unique
    pageCount: number;
    categoryId: number; // Foreign key
    category: Category; // Associated category
    isAvailable: boolean; // Default true
    // checkouts: Checkout[]; // Collection of associated checkouts
    // reviews?: Review[]; // Uncomment if you later add reviews
  }