import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-seat-reserv',
  templateUrl: './seat-reserv.component.html',
  styleUrls: ['./seat-reserv.component.css']
})
export class SeatReservComponent implements OnInit {

  rows: number;
  columns: number;
  seatsMatrix = [];

  constructor() { }

  ngOnInit(): void {
  }
  selectValidator() {
    var filas = (document.getElementById("filas")) as HTMLSelectElement;
    var columnas = (document.getElementById("columnas")) as HTMLSelectElement;
    var selF = filas.selectedIndex;
    var selC = columnas.selectedIndex;
    var optC = columnas.options[selC];
    var optF = filas.options[selF];
    var valorFilas = (<HTMLSelectElement><unknown>optF).value;
    var valorColumnas = (<HTMLSelectElement><unknown>optC).value;
    var intvalorColumnas = parseInt(valorColumnas);
    var intvalorFilas = parseInt(valorFilas);
    console.log(intvalorFilas);
    console.log(intvalorColumnas);
    this.populateArray(intvalorFilas,intvalorColumnas);
  }
  populateArray(filas: number, columnas: number) {
    var count =1;
    for (var i = 0; i < filas; i++) {
      var data = [];
      for (var j = 0; j < columnas; j++) {
        data.push("Test" + count);
        count++;
      }

      this.seatsMatrix.push(data);

    }
    this.generateTable();
  }
  generateTable() {
    console.log(this.seatsMatrix);
  }
}