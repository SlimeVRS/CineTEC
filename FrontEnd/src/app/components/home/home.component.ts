import { Component, OnInit } from '@angular/core';
import { MovieService } from 'src/app/services/movie.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {


  constructor(private movieService:MovieService) { }

  ngOnInit(): void {
    this.movieService.obtenerMovie();
    this.movieService.obtenerMovies();
  }

  //  obtenerPelicula() {
  //   var count = 1;
  //   var tabla = document.getElementById('tabla') as HTMLTableElement;
  //   const rows = tabla.tBodies[0].rows;
   
  //   const filas = this.movieService.lista.length;
  //   const columnas =3 ;
  //   var disponibleO = document.getElementById('tabla1');
  //   //this.lista = this.movieService.lista;

  //   // if(this.lista.length !== undefined){
  //   //   console.log(this.movieService.lista.length);
  //   // }
  //   // console.log(this.lista.find(({poster_Movie})=>poster_Movie));
  //   for (var i = 0; i < filas; i++) {
  //     var newRow = tabla.insertRow(i);
  //     for (var j = 0; j < columnas; j++) {
  //       var newCell = newRow.insertCell(j);
  //         var disponible = document.createElement('img') as HTMLImageElement;
  //         disponible.src = movie.poster_Movie;
  //         newCell.appendChild(disponible)
        
        
  //       count++;
  //     }
  //   }
  //   for (var movie of this.movieService.lista) {
  //     movie.poster_Movie;
  //     console.log(movie.poster_Movie);
  //   }
  // }
  updater() {

  }
}
