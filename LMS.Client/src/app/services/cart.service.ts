import { Injectable } from '@angular/core';
import { Book } from '../interfaces/book';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private cartItems = new Set<Book>();

  private cartItemsSubject: BehaviorSubject<Set<Book>>;
  cartItems$: Observable<Set<Book>>;

  constructor() {
    this.cartItemsSubject = new BehaviorSubject<Set<Book>>(this.cartItems);
    this.cartItems$ = this.cartItemsSubject.asObservable();
  }

  addToCart(book:Book):void{
    this.cartItems.add(book);
    this.cartItemsSubject.next(this.cartItems);
  }

  removeBook(book: Book): void {
    this.cartItems.delete(book);
    this.cartItemsSubject.next(this.cartItems);
  }

  getCartItems(): Set<Book> {
    return this.cartItems;
  }

  clearCart() {
    this.cartItems.clear();
    this.cartItemsSubject.next(this.cartItems);
  }

  getTotalBooks(): number {
    return this.cartItems.size;
  }

}
