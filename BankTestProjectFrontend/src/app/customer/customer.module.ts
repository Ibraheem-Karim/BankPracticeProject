import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomerRoutingModule } from './customer-routing.module';
import { SingInComponent } from './components/sing-in/sing-in.component';
import { SingUpComponent } from './components/sing-up/sing-up.component';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    SingInComponent,
    SingUpComponent
  ],
  imports: [
    CommonModule,
    CustomerRoutingModule, 
    ReactiveFormsModule
  ]
})
export class CustomerModule { }
