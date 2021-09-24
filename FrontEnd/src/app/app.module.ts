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
import { RouterModule } from '@angular/router';
import {MatSelectModule} from '@angular/material/select';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { CarouselComponent } from './components/navbar/carousel/carousel.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    EmployeesComponent,
    ClientsComponent,
    MoviesComponent,
    OfficesComponent,
    ScreensComponent,
    CarouselComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatSelectModule,
    ReactiveFormsModule,NgbModule,
    
    RouterModule.forRoot([
      {path: 'login', component: EmployeesComponent},
      {path: 'tarjetas', component: ClientsComponent},
      
    ]),
    BrowserAnimationsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
