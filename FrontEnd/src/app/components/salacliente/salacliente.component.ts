import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { oficcesModel } from 'src/app/models/oficcesModels';
import { salaModel } from 'src/app/models/salaModel';
import { OfficesService } from 'src/app/services/offices.service';
import { SalaService } from 'src/app/services/sala.service';

@Component({
  selector: 'app-salacliente',
  templateUrl: './salacliente.component.html',
  styleUrls: ['./salacliente.component.css']
})
export class SalaclienteComponent implements OnInit {
  salas: any[];
  sucursal: any[];
  seatsMatrix = [];
  filas: any[];
  columnas: any[];
  lugares: any[];
  salasDeBranch: any[];
  sucursalesForm: FormGroup;
  salasForm: FormGroup;

  salaCartelera;
  nombrepeliculaCartelera;
  horaCartelera;
  diaCarteral;
  sucursalCartelera;
  constructor(private fb: FormBuilder, private salaService: SalaService, private sucursalService: OfficesService) { }

  ngOnInit(): void {
    // this.salaService.obtenerSalas();
    this.sucursalService.obtenerOffices();
    this.seatsMatrix = [];
    this.salas = [];
    this.filas = [];
    this.lugares = [];
    this.columnas = [];
    this.sucursal = [];
    this.salasDeBranch = [];

    this.sucursalesForm = this.fb.group({
      sucursalControl: []
    });

    this.salasForm = this.fb.group({
      salaControl: []
    });

    this.obtenerSucursal();

  }
  obtenerSucursal() {
    this.sucursalService.obtenerOffices();
    this.sucursalService.getHeroes().then(data => {
      this.sucursal as oficcesModel[];
      this.sucursal = data as oficcesModel[];
      for (let sucursalx of this.sucursal) {
        var nombreSucursal = sucursalx.name_Branch;
        this.lugares.push(nombreSucursal);
      }
      //  this.populateArray(this.filas,this.columnas);
      console.log(this.lugares);
    });
  }
  // getValue(){
  //   console.log(this.sucursalesForm.value);
  // }

  // obtenerSala() {
  //   this.salaService.obtenerSalas();
  //   this.salaService.getHeroes().then(data => {
  //     this.salas as salaModel[];
  //     this.salas = data as salaModel[];

  //     for (let sala of this.salas) {
  //       var rows = sala.rows_Room;
  //       var cells = sala.columns_Room;
  //       this.filas.push(rows);
  //       this.columnas.push(cells);
  //     }
  //     //  this.populateArray(this.filas,this.columnas);
  //     console.log(this.filas);
  //     console.log(this.columnas);
  //   });
  // }
  getValue() {
    //console.log(this.sucursalesForm.value);
    // var sites = this.sucursal;es.get('movieControl').value,
    // var selfS = sites.selectedIndex;
    // var optS = sites.options[selfS];
    // console.log(optS.textContent);
    // this.salasDeBranch = [];
    var sucursal = this.sucursalesForm.get('sucursalControl').value;
    if (sucursal !== null) {
      this.salasDeBranch = [];
      this.obtenerSalas(sucursal);
    }
    //
    console.log(sucursal);

  }
  obtenerSalas(sucursal: string) {
    this.salaService.obtenerBranchAsociadas(sucursal);
    //var salas = this.salaService.list;
    for (let sala of this.salaService.list) {
      var nombreSala = sala.id_Room;
      this.salasDeBranch.push(nombreSala);
    }
    console.log(this.salasDeBranch);
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

      Array.from(row.cells).forEach((cell, idxC) => {
        var seleccionado = seleccionadoO.cloneNode(true);
        var disponible = disponibleO.cloneNode(true);
        var vendido = vendidoO.cloneNode(true);
        cell.addEventListener('click', event => {
          if (this.seatsMatrix[idx][idxC] == 0) {
            row.deleteCell(idxC);
            var newCell = table1.rows[idx].insertCell(idxC);
            newCell.appendChild(seleccionado);
            this.seatsMatrix[idx][idxC] = 1;
          }
          else if (this.seatsMatrix[idx][idxC] == 1) {
            row.deleteCell(idxC);
            var newCell = table1.rows[idx].insertCell(idxC);
            newCell.appendChild(disponible);
            this.seatsMatrix[idx][idxC] = 0;
          }
          else if (this.seatsMatrix[idx][idxC] == 2) {
            row.deleteCell(idxC);
            var newCell = table1.rows[idx].insertCell(idxC);
            newCell.appendChild(vendido);
            this.seatsMatrix[idx][idxC] = 0;
          }

          console.clear();
          console.log(this.seatsMatrix);
          console.log('row index:', idx, idxC);
        });
      });
    });
  }


}
