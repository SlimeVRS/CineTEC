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
import { MatSelectModule} from '@angular/material/select';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { CarouselComponent } from './components/navbar/carousel/carousel.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { TabGroupAlignComponent } from './components/employees/tab-group-align/tab-group-align.component';
import { MatTabsModule} from '@angular/material/tabs';
import { NormalEmployeesComponent } from './components/employees/normal-employees/normal-employees.component';
import { NormalEmployeesListComponent } from './components/employees/normal-employees-list/normal-employees-list.component';
import { MatCardModule} from '@angular/material/card';
import { ClientslistComponent } from './components/clients/clientslist/clientslist.component';
import { ResgistrarComponent } from './components/login/resgistrar/resgistrar.component';
import { ImagemanagerComponent } from './components/movies/imagemanager/imagemanager.component';
import { HttpClientModule} from '@angular/common/http';
import { FooterComponent } from './components/home/footer/footer.component';
import { ClientviewComponent } from './components/clientview/clientview.component';
import { AdminviewComponent } from './components/adminview/adminview.component';
import { NavbarClientComponent } from './components/clientview/navbar-client/navbar-client.component';
import { ToastrModule } from 'ngx-toastr';
import { SeatReservComponent } from './components/seat-reserv/seat-reserv.component';
import { RolComponent } from './components/rol/rol.component';
import { RollistComponent } from './components/rol/rollist/rollist.component';
import {CloudinaryModule} from '@cloudinary/angular';
import { ViewPhotosComponent } from './components/movies/view-photos/view-photos.component';
import {MatInputModule} from '@angular/material/input';
import { AngularFireModule } from '@angular/fire/compat' ;
import { environment } from 'src/environments/environment';

import {AngularFirestoreModule} from '@angular/fire/compat/firestore';
import {AngularFireStorageModule} from '@angular/fire/compat/storage';
import {AngularFireAuthModule} from '@angular/fire/compat/auth';
import {
  AngularFireStorageReference,
  AngularFireUploadTask
} from "@angular/fire/compat/storage";


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    EmployeesComponent,
    ClientsComponent,
    MoviesComponent,
    OfficesComponent,
    ScreensComponent,
    CarouselComponent,
    LoginComponent,
    HomeComponent,
    TabGroupAlignComponent,
    NormalEmployeesComponent,
    NormalEmployeesListComponent,
    ClientslistComponent,
    ResgistrarComponent,
    ImagemanagerComponent,
    FooterComponent,
    ClientviewComponent,
    AdminviewComponent,
    NavbarClientComponent,
    SeatReservComponent,
    RolComponent,
    RollistComponent,
    ViewPhotosComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatSelectModule,
    ReactiveFormsModule,NgbModule,
    MatTabsModule,MatCardModule,
    HttpClientModule,
    MatInputModule,
    AngularFireModule.initializeApp(environment.firebaseConfig),
    CloudinaryModule,
    AngularFirestoreModule,
    AngularFireAuthModule,
    AngularFireStorageModule,
    ToastrModule.forRoot(),
  
    RouterModule.forRoot([
      {path: 'employees', component: EmployeesComponent},
      {path: 'empleadosC', component: NormalEmployeesComponent},
      {path: 'home', component: HomeComponent},
      {path: 'movies', component: MoviesComponent},
      {path: 'cliente', component: ClientsComponent},
      {path: 'singup', component: ResgistrarComponent}, 
      {path: 'login', component: LoginComponent}, 
      {path: 'offices', component: OfficesComponent},
      {path: 'screens', component: ScreensComponent},
      {path: 'admin', component: AdminviewComponent},
      {path: 'tools', component: RolComponent},
      {path: 'seat-reserv', component: SeatReservComponent},
      { path: '**', redirectTo: 'login', pathMatch: 'full' },
      
    ]),
    BrowserAnimationsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
