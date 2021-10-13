import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-screens',
  templateUrl: './screens.component.html',
  styleUrls: ['./screens.component.css']
})
export class ScreensComponent implements OnInit {

  hourForm: FormGroup;
  hours = ['15:00','13:00','17:00', '21:00', '23:00']

  cinemasForm: FormGroup;
  cinemas = ['Paseo Metropoli', 'City Mall', 'TEC Cinemas','Citicinemas','Multiplaza del Este']

  salaForm: FormGroup;
  salas = ['1', '2', '3','4','5']

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
  }

}
