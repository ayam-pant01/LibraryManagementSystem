import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Book } from '../../../interfaces/book';
import { MatCardModule } from '@angular/material/card';
import { StarRatingComponent } from '../../../components/star-rating/star-rating.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-book-card',
  standalone: true,
  imports: [MatCardModule,StarRatingComponent,CommonModule],
  templateUrl: './book-card.component.html',
  styleUrl: './book-card.component.css'
})
export class BookCardComponent {
  @Input() book!: Book;
  @Output() bookClick = new EventEmitter<Book>();
  onBookClick() {
    this.bookClick.emit(this.book);
  }
}
