import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SingInComponent } from './components/sing-in/sing-in.component';
import { SingUpComponent } from './components/sing-up/sing-up.component';

const routes: Routes = [
  { path: 'sign-in', component: SingInComponent },
  { path: 'sign-up', component: SingUpComponent },
  { path: '', redirectTo: 'sign-in', pathMatch: 'full' }, // default

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule { }
