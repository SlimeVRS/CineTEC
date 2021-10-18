import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { proyeccionModel } from 'src/app/models/proyeccionModel';
import { MovieService } from 'src/app/services/movie.service';
import { OfficesService } from 'src/app/services/offices.service';
import { ProyeccionService } from 'src/app/services/proyeccion.service';
import { SalaService } from 'src/app/services/sala.service';
import { SalaclienteComponent } from '../salacliente/salacliente.component';

@Component({
  selector: 'app-cartelera',
  templateUrl: './cartelera.component.html',
  styleUrls: ['./cartelera.component.css']
})
export class CarteleraComponent implements OnInit {

  constructor(public projectionService: ProyeccionService, private toastr: ToastrService, private fb: FormBuilder, private salaService: SalaService, private sucursalService: OfficesService,
    private movieService: MovieService) { }
  enableEdit = false;
  enableEditIndex = null;
  arrayIDMovies:any[];
  proyecciones:any[];

  ngOnInit(): void {
    this.projectionService.obtenerProyeccion().subscribe(data => {
      console.log(data);
    });
    this.projectionService.obtenerProyecciones();
    this.arrayIDMovies=[];
    // this.ver();
  }
  ver(){
    this.proyecciones=this.projectionService.list;
    console.log(this.proyecciones);
   
     for(let projection of this.projectionService.list){
      var name = projection.name_Movie_Projection;
      //  console.log(name);
       this.arrayIDMovies.push(name);
     }
  }
  eliminarTarjeta(id) {
    if (confirm('Desea eliminar la tarjeta?')) {
      const index = this.projectionService.list.indexOf(id);
      this.projectionService.list.splice(index, 1);
      this.projectionService.eliminarProyeccion(id).subscribe(data => {
        this.toastr.warning('Eliminar Exitoso', 'Tarjeta Eliminada');

        this.projectionService.obtenerProyecciones();
      })
    }
  }
  // editar(tarjeta) {
  //   this.projectionService.actualizar(tarjeta);
  // }
  booking(pelicula){
    var sala= pelicula.id_room; 
    var nombrepelicula=pelicula.name_movie;
    var hora=pelicula.time_projection;
    var dia=pelicula.day_projection;
    var sucursal=pelicula.name_branch;
    console.log(sala);
    console.log(dia);


  }
  enableEditMethod(e, i) {
    this.enableEdit = true;
    this.enableEditIndex = i;
    console.log(i, e);
  }


}
