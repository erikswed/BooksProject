import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';

import { BookItem } from './BookItem';

@Injectable({ providedIn: 'root' })

export class BookService {

  private BookItemsUrl = 'api/BooksXml';  // URL to web api

  constructor(private http: HttpClient) { }

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
