import { Book } from "./book";

export interface Category {
    categoryId: number;
    name: string;
    isEditing?: boolean;
  }

export interface BooksByCatergory{
    bookCategoryId: number;
    category:string;
    books:Book[];
}