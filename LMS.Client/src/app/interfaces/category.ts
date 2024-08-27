import { Book } from "./book";

export interface Category {
    categoryId: number;
    name: string;
  }

export interface BooksByCatergory{
    bookCategoryId: number;
    category:string;
    books:Book[];
}