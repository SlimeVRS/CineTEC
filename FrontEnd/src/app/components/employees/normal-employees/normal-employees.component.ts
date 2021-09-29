import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-normal-employees',
  templateUrl: './normal-employees.component.html',
  styleUrls: ['./normal-employees.component.css']
})
export class NormalEmployeesComponent implements OnInit {

  constructor() { }
  form: FormGroup;
  ngOnInit(): void {
  }

}
