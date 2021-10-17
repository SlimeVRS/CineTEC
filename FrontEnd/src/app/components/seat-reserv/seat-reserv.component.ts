import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { oficcesModel } from 'src/app/models/oficcesModels';
import { salaModel } from 'src/app/models/salaModel';
import { OfficesService } from 'src/app/services/offices.service';
import { SalaService } from 'src/app/services/sala.service';

@Component({
  selector: 'app-seat-reserv',
  templateUrl: './seat-reserv.component.html',
  styleUrls: ['./seat-reserv.component.css']
})
export class SeatReservComponent implements OnInit {

  rows: number;
  columns: number;
  seatsMatrix = [];
  formData:FormGroup;
  sala: salaModel;
  lugares: any[];
  sucursales: any[];
  sucursalesForm:FormGroup;
  constructor(private fb:FormBuilder,private salaService:SalaService, private toastr: ToastrService, private sucursalService:OfficesService) { }

  ngOnInit(): void {
    this.sucursalService.obtenerOffices();
    this.sucursales=[];
    this.lugares=[];
    this.sucursalesForm = this.fb.group({
      sucursalControl: []
    });
    this.obtenerSucursal();
  }
  obtenerSucursal() {
    this.sucursalService.obtenerOffices();
    this.sucursalService.getHeroes().then(data => {
      this.sucursales as oficcesModel[];
      this.sucursales = data as oficcesModel[];
      for (let sucursalx of this.sucursales) {
        var nombreSucursal = sucursalx.name_Branch;
        this.lugares.push(nombreSucursal);
      }
      //  this.populateArray(this.filas,this.columnas);
      console.log(this.lugares);
    });
  }
  getValue(){
    console.log(this.sucursalesForm.value);
    var sites = (document.getElementById("sites")) as HTMLSelectElement;
    var selfS= sites.selectedIndex;
    var optS = sites.options[selfS];
    console.log(optS.textContent);
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
    this.populateArray(intvalorFilas, intvalorColumnas);
  }
  populateArray(filas: number, columnas: number) {
    var count = 1;

    for (var i = 0; i < filas; i++) {
      var data = [];
      for (var j = 0; j < columnas; j++) {
        data.push(0);
        count++;
      }

      this.seatsMatrix.push(data);

    }
    this.generateTable(filas, columnas);
    console.log(this.seatsMatrix);
    console.log(filas, columnas)
  }
  generateTable(filas: number, columnas: number) {

    var count = 1;
    var disponibleO = document.getElementById('disponible');

    var seleccionadoO = document.getElementById('seleccionado');
    var vendidoO = document.getElementById('vendido');

    var table = document.getElementById('seatTable') as HTMLTableElement;
    for (var i = 0; i < filas; i++) {
      var newRow = table.insertRow(i);
      for (var j = 0; j < columnas; j++) {
        var newCell = newRow.insertCell(j);

        if (this.seatsMatrix[i][j] == 0) {
          var disponible = disponibleO.cloneNode(true);
          newCell.appendChild(disponible)
        }
        else if (this.seatsMatrix[i][j] == 1) {
          var vendido = vendidoO.cloneNode(true);
          table.appendChild(vendido);
        }
        else if (this.seatsMatrix[i][j] == 2) {
          var seleccionado = seleccionadoO.cloneNode(true);
          table.appendChild(seleccionado);
        }
        count++;
      }
    }
    

  }
  updater() {
    var table1 = document.getElementById('seatTable') as HTMLTableElement;
    const rows = table1.tBodies[0].rows;
    var seleccionadoO = document.getElementById('seleccionado');
    var disponibleO = document.getElementById('disponible');
    var vendidoO = document.getElementById('vendido');

    Array.from(rows).forEach((row, idx) => {
    
      Array.from(row.cells).forEach((cell,idxC)=>{
        var seleccionado = seleccionadoO.cloneNode(true);
        var disponible = disponibleO.cloneNode(true);
        var vendido = vendidoO.cloneNode(true);
        cell.addEventListener('click', event => {
          if(this.seatsMatrix[idx][idxC] == 0) {
            row.deleteCell(idxC);
            var newCell=table1.rows[idx].insertCell(idxC);
            newCell.appendChild(seleccionado);
            this.seatsMatrix[idx][idxC]=1;
          }
          else if(this.seatsMatrix[idx][idxC] == 1){
            row.deleteCell(idxC);
            var newCell=table1.rows[idx].insertCell(idxC);
            newCell.appendChild(disponible);
            this.seatsMatrix[idx][idxC]=0; 
          } 
          else if(this.seatsMatrix[idx][idxC] == 2){
            row.deleteCell(idxC);
            var newCell=table1.rows[idx].insertCell(idxC);
            newCell.appendChild(vendido);
            this.seatsMatrix[idx][idxC]=0; 
          }
        
          console.clear();
          console.log(this.seatsMatrix);
          console.log('row index:', idx ,idxC);
        });
      });
    });
  }

  guardarSala(){
    var filas = (document.getElementById("filas")) as HTMLSelectElement;
    var columnas = (document.getElementById("columnas")) as HTMLSelectElement;
    var sites = (document.getElementById("sites")) as HTMLSelectElement;
    var selF = filas.selectedIndex;
    var selfS= sites.selectedIndex;
    var selC = columnas.selectedIndex;
    var optC = columnas.options[selC];
    var optF = filas.options[selF];
    var optS = sites.options[selfS];
    var valorFilas = (<HTMLSelectElement><unknown>optF).value;
    var valorColumnas = (<HTMLSelectElement><unknown>optC).value;
    var intvalorColumnas = parseInt(valorColumnas);
    var intvalorFilas = parseInt(valorFilas);
    const sala: salaModel={
      capacity_Room:intvalorColumnas*intvalorFilas,
      rows_Room:intvalorFilas,
      columns_Room:intvalorColumnas,
      name_Branch_Room:optS.textContent.toString(),
    }
    console.log(sala);
    this.salaService.guardarSala(sala).subscribe(data => {
      this.toastr.success('Sala Guardada', 'Agregada Exitosamente');
    })
  }


}