import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-offices',
  templateUrl: './offices.component.html',
  styleUrls: ['./offices.component.css']
})
export class OfficesComponent implements OnInit {
  cityForm: FormGroup;
  cities = ['Cartago', 'Alajuela', 'San Carlos','Limon','San Jose']
  constructor(private fb: FormBuilder) { }

  

  ngOnInit(){
    this.cityForm = this.fb.group({
      cityControl: ['Cartago']
    });
  }

}
