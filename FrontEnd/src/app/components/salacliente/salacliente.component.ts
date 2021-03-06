import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { oficcesModel } from 'src/app/models/oficcesModels';
import { salaModel } from 'src/app/models/salaModel';
import { seatModel } from 'src/app/models/seat';
import { BookingService } from 'src/app/services/booking.service';

import { OfficesService } from 'src/app/services/offices.service';
import { ReservService } from 'src/app/services/reserv.service';
import { SalaService } from 'src/app/services/sala.service';
import { CarteleraComponent } from './cartelera.component';

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
  filasX:number;
  columnasX:number;
  salasForm: FormGroup;

  contenedor:any[];
  arraySalas: any[];

  filasNuevas:any[];
  columnasNuevas:any[];

  seatContainer:any[];
  seatContainer2:any[];

  constructor(private toastr: ToastrService,private seatService:ReservService,private bookingServices: BookingService, private fb: FormBuilder, private salaService: SalaService, private sucursalService: OfficesService) { }

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
    this.arraySalas = [];
    this.contenedor=[];
    this.seatContainer2=[];
    this.filasNuevas=[];
    


    this.sucursalesForm = this.fb.group({
      sucursalControl: []
    });

    this.salasForm = this.fb.group({
      salaControl: []
    });
  
    console.log(this.bookingServices.salaCartelera);

  

    this.obtenerSucursal();
    this.salaService.obtenerSala();
     this.obtenerDimensionesSala();

  }
  
  obtenerDimensionesSala() {
    this.salaService.obtenerSalas();
    this.salaService.obtenerSalaId(this.bookingServices.salaCartelera).then(data => {
      this.arraySalas as salaModel[];
      this.arraySalas = data as salaModel[];
       console.log(this.arraySalas);

      for (let sala of Object.keys(this.arraySalas)) {
        var nueva = this.arraySalas[sala];
        this.contenedor.push(nueva);
      }
     
       console.log(this.contenedor);
      // this.obtenerFilasyColumnas();
    });
   
  }
  obtenerFilasyColumnas(){
  
   
    var x = this.contenedor[2];
    var y = this.contenedor[3];
    console.log(this.contenedor[2]);
    console.log(this.contenedor[3]);
    
     this.filasX=x;
     this.columnasX=y;
     this.populateArray(this.filasX,this.columnasX);
    //  this.generateTable(this.filasX,this.columnasX);
  }
  obtenerSucursal() {
    this.sucursalService.obtenerOffices();
    this.lugares.push(this.bookingServices.sucursalCartelera);
    // this.sucursalService.getHeroes().then(data => {
    //   this.sucursal as oficcesModel[];
    //   this.sucursal = data as oficcesModel[];
    //   for (let sucursalx of this.sucursal) {
    //     var nombreSucursal = sucursalx.name_Branch;
    //     this.lugares.push(nombreSucursal);
    //   }
    //   //  this.populateArray(this.filas,this.columnas);
    //   console.log(this.lugares);
    // });
  }
  // getValue(){
  //   console.log(this.sucursalesForm.value);
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
  obtenerFilas(){
    for (let salaxx of Object.keys(this.seatContainer2)) {
      var nueva = this.seatContainer2[salaxx];
      this.filasNuevas.push(nueva);
    }
    console.log(this.filasNuevas);
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
    this.seatService.getHeroes2(this.bookingServices.salaCartelera).then(data => {
      this.seatContainer as seatModel[];
      this.seatContainer = data as seatModel[];
      for (let sucursalx of this.seatContainer) {
        var nombreSucursal = sucursalx.state_Seat;
        this.seatContainer2.push(sucursalx);
      }
     
      console.log(this.seatContainer2);
    });
  
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

  generateTable(filasX: number, columnasX: number) {
    // console.log("ADENTREO "+filasX);
    // console.log("ADENTREO "+columnasX);
    this.obtenerFilas();
    var count = 1;
    var disponibleO = document.getElementById('disponible');

    var seleccionadoO = document.getElementById('seleccionado');
    var vendidoO = document.getElementById('vendido');

    var table = document.getElementById('seatTable') as HTMLTableElement;
    for (var i = 0; i < filasX; i++) {
      var newRow = table.insertRow(i);
      for (var j = 0; j < columnasX; j++) {
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
  guardarReservacion(){
    for(var i = 0; i < this.seatsMatrix.length; i++){
      for(var j = 0; j < this.seatsMatrix[0].length; j++){
        if (this.seatsMatrix[i][j] === 1) {
          const cliente: seatModel = {
            row_Seat: i,
            column_Seat:j,
            state_Seat:2, 
            id_Room_Seat:this.bookingServices.salaCartelera,
          }
          this.seatService.actualizarOffices(cliente).subscribe(data => {
            this.toastr.success('Asientos Reservados', 'Agregada Exitosamente');
            
          })
          console.log(cliente);
        }
      }
      
    }
  }


}
