import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { TransactionRoutingModule } from './transaction-routing.module';
import { NewTransactionComponent } from './components/new-transaction/new-transaction.component';


@NgModule({
  declarations: [
    NewTransactionComponent
  ],
  imports: [
    CommonModule,
    TransactionRoutingModule,
    ReactiveFormsModule
  ]
})
export class TransactionModule { }
