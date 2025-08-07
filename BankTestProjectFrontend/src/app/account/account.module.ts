import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountRoutingModule } from './account-routing.module';
import { CreateAccountComponent } from './components/create-account/create-account.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [CreateAccountComponent],
  imports: [CommonModule, AccountRoutingModule, ReactiveFormsModule],
})
export class AccountModule {}

//Some extra code
