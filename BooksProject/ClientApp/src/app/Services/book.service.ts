import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

import { BookItem } from './BookItem';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })

export class BookService {

  private BookItemsUrl = 'api/BooksXml';  // URL to web api

  constructor(private http: HttpClient) { }

  getTitles(): Observable<BookItem[]> {
    return this.http.get<BookItem[]>(this.BookItemsUrl);
  }

  /** GET book from server. */
  getBookItems(): Observable<BookItem[]> {
    return this.http.get<BookItem[]>(this.BookItemsUrl);
  }

  /** GET contact by id. */
  getBookItem(id: number): Observable<BookItem> {
    const url = `${this.BookItemsUrl}/${id}`;
    return this.http.get<BookItem>(url);
  }

  /** POST: add new contact to server */
  addContact(contact: BookItem): Observable<BookItem> {
    return this.http.post<BookItem>(this.BookItemsUrl, contact, httpOptions).pipe(
      tap(() => catchError(this.handleError<BookItem>('addContact')))
    );
  }

  /** PUT: update contact on server */
  updataContact(id: number, contact: BookItem): Observable<any> {
    return this.http.put(`${this.BookItemsUrl}/${id}`, contact, httpOptions);
  }

  /** DELETE: delete contact from server */
  deleteContact(id: number): Observable<BookItem> {
    return this.http.delete<BookItem>(`${this.BookItemsUrl}/${id}`, httpOptions);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
    
      console.error(error); // log to console

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
