import { Category } from "./category";
import { Review } from "./review";

export interface Book {
    bookId: number;
    title: string; 
    author: string; 
    description: string; 
    coverImage: string; 
    publisher: string; 
    publicationDate: Date;
    isbn: string; 
    pageCount: number;
    categoryId: number; 
    categoryName?: string; 
    category: Category; 
    isAvailable: boolean; 
    averageRating:number;
    // checkouts: Checkout[]; // Collection of associated checkouts
    reviews?: Review[]; // Uncomment if you later add reviews
  }

  export interface BookForCreateAndUpdateDto {
    title: string;
    author: string;
    description: string;
    coverImage: string;
    publisher: string;
    publicationDate: Date;
    categoryId: number;
    isbn: string;
    pageCount: number;
  }