import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEditAddonComponent } from './addon/add-edit-addon/add-edit-addon.component';
import { AddonDetailsComponent } from './addon/addon-details/addon-details.component';
import { AddonComponent } from './addon/addon.component';
import { AddEditBookingComponent } from './booking/add-edit-booking/add-edit-booking.component';
import { BookingDetailsComponent } from './booking/booking-details/booking-details.component';
import { BookingComponent } from './booking/booking.component';
import { AddEditCustomerComponent } from './customer/add-edit-customer/add-edit-customer.component';
import { CustomerDetailsComponent } from './customer/customer-details/customer-details.component';
import { CustomerComponent } from './customer/customer.component';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { AddEditVillaComponent } from './villa/add-edit-villa/add-edit-villa.component';
import { VillaDetailsComponent } from './villa/villa-details/villa-details.component';
import { VillaComponent } from './villa/villa.component';

const routes: Routes = [
  { path: "home", component: HomeComponent },

  { path: "customers", component: CustomerComponent },
  { path: "customers/details/:id", component: CustomerDetailsComponent },
  { path: "customers/create", component: AddEditCustomerComponent },
  { path: "customers/edit/:id", component: AddEditCustomerComponent },

  { path: "villas", component: VillaComponent },
  { path: "villas/details/:id", component: VillaDetailsComponent },
  { path: "villas/create", component: AddEditVillaComponent },
  { path: "villas/edit/:id", component: AddEditVillaComponent },

  { path: "addons", component: AddonComponent },
  { path: "addons/details/:id", component: AddonDetailsComponent },
  { path: "addons/create", component: AddEditAddonComponent },
  { path: "addons/edit/:id", component: AddEditAddonComponent },

  { path: "bookings", component: BookingComponent },
  { path: "bookings/details/:id", component: BookingDetailsComponent },
  { path: "bookings/create", component: AddEditBookingComponent },
  { path: "bookings/edit/:id", component: AddEditBookingComponent },

  { path: "not-found", component: NotFoundComponent },
  { path: '**', redirectTo: '/home', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
