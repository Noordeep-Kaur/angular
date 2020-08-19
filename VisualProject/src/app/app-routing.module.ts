import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {ShowbusesComponent} from './showbuses/showbuses.component';
const routes: Routes = [
  {path:'showbuses',component:ShowbusesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents=[ShowbusesComponent]
