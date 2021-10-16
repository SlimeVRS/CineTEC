import { Component, OnInit } from '@angular/core';
import { image } from '@cloudinary/url-gen/qualifiers/source';
import { movieModel } from 'src/app/models/movieModel';
import { MovieService } from 'src/app/services/movie.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  urlArray: any[];
  lista: any[];
  constructor(private movieService: MovieService) { }

  ngOnInit(): void {
    this.movieService.obtenerMovie();
    this.movieService.obtenerMovies();
    this.movieService.obtenerMovies();
    this.urlArray = [];
    this.obtenerPelicula();
  }
  obtenerPelicula() {
    this.movieService.obtenerMovies();
    this.movieService.getHeroes().then(data => {
      this.lista as movieModel[];
      this.lista = data as movieModel[];
      for (let movie of this.lista) {
        var nueva = movie.poster_Movie;
        this.urlArray.push(movie.poster_Movie);
      }
      this.createTable();
    });
   
  }
  createTable() {
    var tabla = document.getElementById('tabla') as HTMLTableElement;
    var count = 0;
    const posters = this.urlArray.length;
    
    console.log(this.urlArray);
    console.log(posters);
    var numero= Math.floor(posters/4);
    Math.round(numero);
 
    var size;
    var controller= Math.round((posters-1)/4);
    console.log("numero: "+controller); 
    if (posters<4){
      size = posters;
    }else{
      size=posters;
    }
    for (var i = 0; i <= controller; i++) {
          var newRow= tabla.insertRow(i);

      for (var j = 0; j < 4; j++) {
        if(this.urlArray[count]!==undefined){
          var imagen = document.createElement('img') as HTMLImageElement;
          var newCell = newRow.insertCell(j);
          imagen.src = this.urlArray[count];
          count =count+1;
          newCell.style.maxWidth = "234px";
          newCell.appendChild(imagen);
        }
        
      }
      size=0;
    }
    //  var imagen = document.createElement('img') as HTMLImageElement;
    //  if(this.urlArray[0]!== undefined){
    //   imagen.src = this.urlArray[0];
    //   tabla.appendChild(imagen);
    //  }
    for (var movie of this.movieService.lista) {
      movie.poster_Movie;
      console.log(movie.poster_Movie);
    }
  }
  updater() {

  }
}
