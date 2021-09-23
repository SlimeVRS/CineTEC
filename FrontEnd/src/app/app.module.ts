import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { EmployeesComponent } from './components/employees/employees.component';
import { ClientsComponent } from './components/clients/clients.component';
import { MoviesComponent } from './components/movies/movies.component';
import { OfficesComponent } from './components/offices/offices.component';
import { ScreensComponent } from './components/screens/screens.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    EmployeesComponent,
    ClientsComponent,
    MoviesComponent,
    OfficesComponent,
    ScreensComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
