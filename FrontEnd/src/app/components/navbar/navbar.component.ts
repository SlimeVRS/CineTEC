import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  template: '<img src="assets/CineTeclogo.png">',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  cityForm: FormGroup;
  cities = ['Cartago', 'Alajuela', 'San Carlos','Limon','San Jose']

  cinemasForm: FormGroup;
  cinemas = ['Paseo Metropoli', 'City Mall', 'TEC Cinemas','Citicinemas','Multiplaza del Este']

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.cityForm = this.fb.group({
      cityControl: ['Cartago']
    });
    this.cinemasForm = this.fb.group({
      cinemaControl: ['Paseo Metropoli']
    });
  }

}
