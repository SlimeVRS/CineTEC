import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { BookingService } from 'src/app/services/booking.service';
import { MovieService } from 'src/app/services/movie.service';
import { OfficesService } from 'src/app/services/offices.service';
import { ProyeccionService } from 'src/app/services/proyeccion.service';
import { SalaService } from 'src/app/services/sala.service';

@Component({
  selector: 'app-cartelera',
  templateUrl: './cartelera.component.html',
  styleUrls: ['./cartelera.component.css']
})
export class CarteleraComponent implements OnInit {

  constructor(public projectionService: ProyeccionService, private toastr: ToastrService, private fb: FormBuilder, private salaService: SalaService, private sucursalService: OfficesService,
    private movieService: MovieService,private bookingService:BookingService) { }
  enableEdit = false;
  enableEditIndex = null;
  arrayIDMovies:any[];
  proyecciones:any[];
  
  salaCartelera;
  nombrepeliculaCartelera;
  horaCartelera;
  diaCarteral;
  sucursalCartelera;

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
    this.bookingService.storesalaCartelera(pelicula.id_room); 
    this.bookingService.storenombrepeliculaCartelera(pelicula.name_movie); 
    this.bookingService.storehoraCartelera(pelicula.time_projection); 
    this.bookingService.storediaCartelera(pelicula.day_projection); 
    this.bookingService.storesucursalCarteleral(pelicula.name_branch); 
  }
  enableEditMethod(e, i) {
    this.enableEdit = true;
    this.enableEditIndex = i;
    console.log(i, e);
  }


}
