import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { MovieService } from 'src/app/services/movie.service';

@Component({
  selector: 'app-movieslist',
  templateUrl: './movieslist.component.html',
  styleUrls: ['./movieslist.component.css']
})
export class MovieslistComponent implements OnInit {

  enableEdit = false;
  enableEditIndex = null;
  constructor(public movieService: MovieService, public toastr: ToastrService) { }
  ngOnInit(): void {
    this.movieService.obtenerMovies();
  }
  eliminarTarjeta(id) {
    if (confirm('Desea eliminar la tarjeta?')) {
      const index = this.movieService.lista.indexOf(id);
      this.movieService.lista.splice(index, 1);
      this.movieService.eliminarMovie(id).subscribe(data => {
        this.toastr.warning('Eliminar Exitoso', 'Pelicula Eliminada');

        this.movieService.obtenerMovies();
      })
    }
  }
  // editar(tarjeta) {
  //   this.movieService.actualizar(tarjeta);
  //   // this.employee.put=true;
  //   // console.log(this.employee.put);
  // }
  enableEditMethod(e, i) {
    this.enableEdit = true;
    this.enableEditIndex = i;
    console.log(i, e);
  }

}
