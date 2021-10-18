import { Component, OnInit } from '@angular/core';
import { Form, FormBuilder, FormGroup, FormGroupDirective } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { movieModel } from 'src/app/models/movieModel';
import { oficcesModel } from 'src/app/models/oficcesModels';
import { proyeccionModel } from 'src/app/models/proyeccionModel';
import { salaModel } from 'src/app/models/salaModel';
import { MovieService } from 'src/app/services/movie.service';
import { OfficesService } from 'src/app/services/offices.service';
import { ProyeccionService } from 'src/app/services/proyeccion.service';
import { SalaService } from 'src/app/services/sala.service';

@Component({
  selector: 'app-screens',
  templateUrl: './screens.component.html',
  styleUrls: ['./screens.component.css']
})
export class ScreensComponent implements OnInit {
  rows: number;
  columns: number;
  seatsMatrix = [];
  formData: FormGroup;
  sala: salaModel;
  movies: any[];
  arrayMovies: any[]
  lugares: any[];
  salasDeBranch: any[];
  salasDeBranchDef: any[];


  sucursales: any[];
  sucursalesForm: FormGroup;
  hourForm: FormGroup;
  MoviesForm: FormGroup;
  salasForm: FormGroup;
  sucursalForm: FormGroup;
  formDia: FormGroup;
 
  constructor(private toastr: ToastrService,private fb: FormBuilder, private salaService: SalaService, private sucursalService: OfficesService,
    private movieService: MovieService, private proyeccionService:ProyeccionService) { }

  ngOnInit(): void {
    this.sucursalService.obtenerOffices();

    this.sucursales = [];
    this.lugares = [];
    this.arrayMovies = [];
    this.salasDeBranch = [];

    this.salasDeBranchDef = [];
    this.formDia = this.fb.group({
      day_Projection: []
    });
    this.sucursalesForm = this.fb.group({
      sucursalControl: []
    });
    this.MoviesForm = this.fb.group({
      movieControl: []
    });
    this.salasForm = this.fb.group({
      salaControl: []
    });
    this.hourForm = this.fb.group({
      hoursControl: []
    });
    this.obtenerSucursal();
    this.obtenerMovies();

  }
  obtenerMovies() {
    this.movieService.obtenerMovies();
    this.movieService.getHeroes().then(data => {
      this.movies as movieModel[];
      this.movies = data as movieModel[];
      for (let movie of this.movies) {
        var nombreMovie = movie.name_Movie;
        this.arrayMovies.push(nombreMovie);
      }
      //  this.populateArray(this.filas,this.columnas);
      console.log(this.arrayMovies);
    });
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
      console.log(this.lugares);
    });
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
  getValue() {
    console.log(this.sucursalesForm.value);
    var sites = (document.getElementById("sucursales")) as HTMLSelectElement;
    var selfS = sites.selectedIndex;
    var optS = sites.options[selfS];
    console.log(optS.textContent);
    this.salasDeBranch = [];
    this.obtenerSalas(optS.textContent);
  }
  getValueDate() {
    var hora = (document.getElementById("hours")) as HTMLSelectElement;
    var selF = hora.selectedIndex;
    var optF = hora.options[selF];
    var valorFilas = (<HTMLSelectElement><unknown>optF).textContent;
    return valorFilas;
    
  }
  guardarProyeccion(){
    const cliente: proyeccionModel = {
      name_Movie_Projection : this.MoviesForm.get('movieControl').value,
      time_Projection : this.getValueDate(),
      id_Room_Projection : parseInt(this.salasForm.get('salaControl').value),
      day_Projection : this.formDia.get('day_Projection').value,
    }
    this.proyeccionService.guardarProyeccion(cliente).subscribe(data=>{
      this.toastr.success('Proyeccion Asignada', 'Agregada Exitosamente');
    })
    console.log(cliente);
  }

}
