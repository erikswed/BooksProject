import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, isDevMode } from '@angular/core';
import { Observable, of } from 'rxjs';

import { BookItem } from './BookItem';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })

export class BookService {

  private BookItemsUrl: string; // = 'https://v0-dot-unique-yew-244216.appspot.com/api/BooksXml';

  constructor(private http: HttpClient) {

    // Return different backend path depending on runtime environment. important! use ng build --prod to make this work
    if (environment.production) {
      this.BookItemsUrl = 'https://v0-dot-unique-yew-244216.appspot.com/api/BooksXml';
    } else {
      this.BookItemsUrl = 'api/BooksXml';
    }
  }

  /** GET all books from server. */

  getBookItems(): Observable<BookItem[]> {
    return this.http.get<BookItem[]>(this.BookItemsUrl);
  }

  /** GET book by id. */
  getBookItem(id: string): Observable<BookItem[]> {
    const url = `${this.BookItemsUrl}/${id}`;
    return this.http.get<BookItem[]>(url);
  }

  /** GET book by title from server. */
  getBookByTitle(title: string): Observable<BookItem[]> {
    const url = `${this.BookItemsUrl}/title/${title}`;
    return this.http.get<BookItem[]>(url);
  }

  /** GET book by author from server. */
  getBookByAuthor(author: string): Observable<BookItem[]> {
    const url = `${this.BookItemsUrl}/author/${author}`;
    return this.http.get<BookItem[]>(url);
  }

  /** GET book by genre from server. */
  getBookByGenre(genre: string): Observable<BookItem[]> {
    const url = `${this.BookItemsUrl}/genre/${genre}`;
    return this.http.get<BookItem[]>(url);
  }

  /** GET book by price from server. */
  getBookByPrice(price: string): Observable<BookItem[]> {
    const url = `${this.BookItemsUrl}/price/${price}`;
    return this.http.get<BookItem[]>(url);

  }

  /// used for put, add
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
    
      console.error(error); // log to console

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
