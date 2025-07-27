import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TransactionRoutingModule } from './transaction-routing.module';
import { NewTransactionComponent } from './components/new-transaction/new-transaction.component';


@NgModule({
  declarations: [
    NewTransactionComponent
  ],
  imports: [
    CommonModule,
    TransactionRoutingModule
  ]
})
export class TransactionModule { }
