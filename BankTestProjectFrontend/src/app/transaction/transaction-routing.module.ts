import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NewTransactionComponent } from './components/new-transaction/new-transaction.component';
import { AuthGuard } from '../core/guards/auth.guard';


const routes: Routes = [
  { path: 'new-transaction', component: NewTransactionComponent, canActivate: [AuthGuard] },
  // { path: 'new-transaction', component: NewTransactionComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TransactionRoutingModule { }
