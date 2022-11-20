import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEditCustomerComponent } from './customer/add-edit-customer/add-edit-customer.component';
import { CustomerDetailsComponent } from './customer/customer-details/customer-details.component';
import { CustomerComponent } from './customer/customer.component';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { AddEditVillaComponent } from './villa/add-edit-villa/add-edit-villa.component';
import { VillaComponent } from './villa/villa.component';

const routes: Routes = [
  { path: "home", component: HomeComponent },

  { path: "customers", component: CustomerComponent },
  { path: "customers/details/:id", component: CustomerDetailsComponent },
  { path: "customers/create", component: AddEditCustomerComponent },
  { path: "customers/edit/:id", component: AddEditCustomerComponent },

  { path: "villas", component: VillaComponent },
  // { path: "villas/details/:id", component: CustomerDetailsComponent },
  { path: "villas/create", component: AddEditVillaComponent },
  { path: "villas/edit/:id", component: AddEditVillaComponent },

  { path: "not-found", component: NotFoundComponent },
  { path: '**', redirectTo: '/home', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
