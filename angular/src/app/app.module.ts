import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerComponent } from './customer/customer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HomeComponent } from './home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { CustomerDetailsComponent } from './customer/customer-details/customer-details.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { AddEditCustomerComponent } from './customer/add-edit-customer/add-edit-customer.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from './shared/shared.module';
import { EnumToArrayPipe } from './pipes/enum-to-array.pipe';
import { DeleteCustomerComponent } from './customer/delete-customer/delete-customer.component';
import { VillaComponent } from './villa/villa.component';
import { AddEditVillaComponent } from './villa/add-edit-villa/add-edit-villa.component';
import { DeleteVillaComponent } from './villa/dialogs/delete-villa/delete-villa.component';

@NgModule({
  declarations: [
    AppComponent,
    CustomerComponent,
    HomeComponent,
    CustomerDetailsComponent,
    NotFoundComponent,
    AddEditCustomerComponent,
    EnumToArrayPipe,
    DeleteCustomerComponent,
    VillaComponent,
    AddEditVillaComponent,
    DeleteVillaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NgbModule,
    HttpClientModule,
    ReactiveFormsModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
