import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';

import { BookService } from '../Services/book.service'
import { BookItem } from '../Services/BookItem';

@Component({
  selector: 'app-search',
  templateUrl: './search-books.component.html',
  styleUrls: ['./search-books.component.scss']
  
})

export class SearchBooksComponent {
  public name: string;
  public type: number;
  public number: number;
 
  bookItems: BookItem[];
  public bookGroup = new FormGroup({
        title: new FormControl(''),
        author: new FormControl(''),
        genre: new FormControl(''),
        price: new FormControl(''),
      });
  constructor(private bookService: BookService) {

  }

  /** GET all book from server. */
  getBookItems() {
    this.bookService.getBookItems().subscribe(bookItems => this.bookItems = bookItems);
  };

  /** GET book by id from server. */
  getBookById(value: string) {
    this.bookService.getBookItem(value).subscribe(bookItems => this.bookItems = bookItems);

  };

  /** GET book by title from server. */
  getBookByTitle(value: string) {
    this.bookService.getBookByTitle(value).subscribe(bookItems => this.bookItems = bookItems);

  };

  /** GET book by autor from server. */
  getBookByAuthor(value: string) {
    this.bookService.getBookByAuthor(value).subscribe(bookItems => this.bookItems = bookItems);

  };

  /** GET book by genre from server. */
  getBookByGenre(value: string) {
    this.bookService.getBookByGenre(value).subscribe(bookItems => this.bookItems = bookItems);

  };

  /** GET book by price from server. */
  getBookByPrice(value: string) {
    this.bookService.getBookByPrice(value).subscribe(bookItems => this.bookItems = bookItems);

  };
}
