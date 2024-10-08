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
    reviews?: Review[]; 
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