import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookingsEditComponent } from './bookings-edit/bookings-edit.component';
import { BookingsListComponent } from './bookings-list/bookings-list.component';
import { Routes, RouterModule } from '@angular/router';
import { BookingsComponent } from './bookings.component';

const routes: Routes = [
  {
    path: '', component: BookingsComponent,
    children: [
      { path: '', redirectTo: 'list', pathMatch: 'full' },
      { path: 'list', component: BookingsListComponent },
      { path: 'edit/:id', component: BookingsEditComponent },
      { path: 'edit', component: BookingsEditComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookingsRoutingModule {
  static routedComponents = [BookingsComponent, BookingsListComponent, BookingsEditComponent];
}
