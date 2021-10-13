import { Component, OnInit } from '@angular/core';
import { Form, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-tab-group-align',
  templateUrl: './tab-group-align.component.html',
  styleUrls: ['./tab-group-align.component.css']
})
export class TabGroupAlignComponent implements OnInit {
  form: FormGroup;
  constructor() { }

  ngOnInit(): void {
  }

}
