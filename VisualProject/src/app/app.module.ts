import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BusService} from './services/busService';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShowbusesComponent } from './showbuses/showbuses.component';
import { SeatlayoutComponent } from './seatlayout/seatlayout.component';

@NgModule({
  declarations: [
    AppComponent,
    ShowbusesComponent,
    SeatlayoutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [BusService],
  bootstrap: [AppComponent]
})
export class AppModule { }
