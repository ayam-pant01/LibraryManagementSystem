import { Component } from '@angular/core';
import { Book } from '../../interfaces/book';
import { BooksByCatergory } from '../../interfaces/category';
import { BookCardComponent } from '../book-card/book-card.component';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-book',
  standalone: true,
  imports: [BookCardComponent,MatIconModule,MatInputModule,CommonModule,MatCardModule],
  templateUrl: './book.component.html',
  styleUrl: './book.component.css'
})
export class BookComponent {
  books: Book[] = [ 
    {
    bookId: 1,
    title: "The Great Gatsby",
    author: "F. Scott Fitzgerald",
    description: "A classic novel set in the Jazz Age...",
    coverImage: "https://f.media-amazon.com/images/I/519u1zDcM8L._SY445_SX342_.jpg",
    publisher: "Scribner",
    publicationDate: new Date("1925-04-10"),
    isbn: "9780743273565",
    pageCount: 180,
    categoryId: 1,
    category: { categoryId: 1, categoryName: "Classics" },
    isAvailable: true
  },
  {
    bookId: 2,
    title: "How to win",
    author: "F. Scott Fitzgerald",
    description: "A classic novel set in the Jazz Age...",
    coverImage: "https://f.media-amazon.com/images/I/41aR2EjGKKL._SY445_SX342_.jpg",
    publisher: "Scribner",
    publicationDate: new Date("1925-04-10"),
    isbn: "9780743273565",
    pageCount: 180,
    categoryId: 1,
    category: { categoryId: 1, categoryName: "Classics" },
    isAvailable: true
  },{
    bookId: 3,
    title: "Kalo chasma",
    author: "F. Scott Fitzgerald",
    description: "A classic novel set in the Jazz Age...",
    coverImage: "https://f.media-amazon.com/images/I/519u1zDcM8L._SY445_SX342_.jpg",
    publisher: "Scribner",
    publicationDate: new Date("1925-04-10"),
    isbn: "9780743273565",
    pageCount: 180,
    categoryId: 1,
    category: { categoryId: 1, categoryName: "Classics" },
    isAvailable: true
  },
  {
    bookId: 4,
    title: "seto ghadi",
    author: "F. Scott Fitzgerald",
    description: "A classic novel set in the Jazz Age...",
    coverImage: "https://f.media-amazon.com/images/I/41aR2EjGKKL._SY445_SX342_.jpg",
    publisher: "Scribner",
    publicationDate: new Date("1925-04-10"),
    isbn: "9780743273565",
    pageCount: 180,
    categoryId: 1,
    category: { categoryId: 1, categoryName: "Classics" },
    isAvailable: true
  },{
    bookId: 1,
    title: "The Great Gatsby",
    author: "F. Scott Fitzgerald",
    description: "A classic novel set in the Jazz Age...",
    coverImage: "https://f.media-amazon.com/images/I/519u1zDcM8L._SY445_SX342_.jpg",
    publisher: "Scribner",
    publicationDate: new Date("1925-04-10"),
    isbn: "9780743273565",
    pageCount: 180,
    categoryId: 1,
    category: { categoryId: 1, categoryName: "Classics" },
    isAvailable: true
  },
  {
    bookId: 2,
    title: "How to win",
    author: "F. Scott Fitzgerald",
    description: "A classic novel set in the Jazz Age...",
    coverImage: "https://f.media-amazon.com/images/I/41aR2EjGKKL._SY445_SX342_.jpg",
    publisher: "Scribner",
    publicationDate: new Date("1925-04-10"),
    isbn: "9780743273565",
    pageCount: 180,
    categoryId: 1,
    category: { categoryId: 1, categoryName: "Classics" },
    isAvailable: true
  },{
    bookId: 3,
    title: "Kalo chasma",
    author: "F. Scott Fitzgerald",
    description: "A classic novel set in the Jazz Age...",
    coverImage: "https://f.media-amazon.com/images/I/519u1zDcM8L._SY445_SX342_.jpg",
    publisher: "Scribner",
    publicationDate: new Date("1925-04-10"),
    isbn: "9780743273565",
    pageCount: 180,
    categoryId: 1,
    category: { categoryId: 1, categoryName: "Classics" },
    isAvailable: true
  },
  {
    bookId: 4,
    title: "seto ghadi",
    author: "F. Scott Fitzgerald",
    description: "A classic novel set in the Jazz Age...",
    coverImage: "https://f.media-amazon.com/images/I/41aR2EjGKKL._SY445_SX342_.jpg",
    publisher: "Scribner",
    publicationDate: new Date("1925-04-10"),
    isbn: "9780743273565",
    pageCount: 180,
    categoryId: 1,
    category: { categoryId: 1, categoryName: "Classics" },
    isAvailable: true
  }];
  booksToDisplay: BooksByCatergory[] = [];
}
