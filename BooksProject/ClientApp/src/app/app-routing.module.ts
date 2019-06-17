import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SearchBooksComponent } from './search-books/search-books.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/search',
    pathMatch: 'full'
  },
  {
    path: 'search',
    component: SearchBooksComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
