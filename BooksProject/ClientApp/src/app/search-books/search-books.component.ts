import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';

import { BookService } from '../Services/book.service'
import { BookItem } from '../Services/BookItem';

@Component({
  selector: 'app-add-contact',
  templateUrl: './search-books.component.html',
  
})

export class SearchBooksComponent {
  public name: string;
  public type: number;
  public number: number;
  public newContact: FormGroup;

  bookItems: BookItem[];

  constructor(
    private bookService: BookService,
    private formBuilder: FormBuilder,
    private location: Location
  ) {
    this.newContact = new FormGroup({
      title: new FormControl(''),
      author: new FormControl(''),
      genre: new FormControl(''),
      price: new FormControl(''),
    });
  }

  //addContact(): void {
  //  this.bookService.addContact(this.newContact.value)
  //    .subscribe(() => this.goBack());
  //}

  getTitle(value: string) {
    this.bookService.getTitles().subscribe(bookItems => this.bookItems = bookItems);
  };

  //getAutor(value: string) {
  //  this.bookService.getAutors
  //};

  //getGenre(value: string) {
  //  this.bookService.getGenres
  //};

  //getPrice(value: string) {
  //  this.bookService.getPrices
  //};

}
