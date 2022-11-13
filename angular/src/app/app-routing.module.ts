import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEditCustomerComponent } from './customer/add-edit-customer/add-edit-customer.component';
import { CustomerDetailsComponent } from './customer/customer-details/customer-details.component';
import { CustomerComponent } from './customer/customer.component';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './not-found/not-found.component';

const routes: Routes = [
  { path: "home", component: HomeComponent },

  // Customer Routes
  { path: "customers", component: CustomerComponent },
  { path: "customers/details/:id", component: CustomerDetailsComponent },
  { path: "customers/create", component: AddEditCustomerComponent },
  { path: "customers/edit/:id", component: AddEditCustomerComponent },

  { path: "not-found", component: NotFoundComponent },
  { path: '**', redirectTo: '/home', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
