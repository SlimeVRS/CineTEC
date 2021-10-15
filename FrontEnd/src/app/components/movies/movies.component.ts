import { Component, OnInit } from '@angular/core';
import { AngularFireStorage } from '@angular/fire/compat/storage';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { movieModel } from 'src/app/models/movieModel';
import { ImageService } from 'src/app/services/image.service';
import { MovieService } from 'src/app/services/movie.service';
import { map, finalize } from "rxjs/operators";
import { Observable } from 'rxjs';
import { image } from '@cloudinary/url-gen/qualifiers/source';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {
  list: movieModel[];
  lista: any[];
  cliente: movieModel;
  form: FormGroup;
  f2;
  title = "CineTEC";
  selectedFile: File = null;
  fb;
  downloadURL: Observable<string>;
  finalURL;
  urlArray: any[];

  onFileSelected(event) {
    var n = Date.now();
    const file = event.target.files[0];
    const filePath = `${n}`;
    const fileRef = this.storage.ref(filePath);
    const task = this.storage.upload(`${n}`, file);
    task
      .snapshotChanges()
      .pipe(finalize(() => {
          this.downloadURL = fileRef.getDownloadURL();
          this.downloadURL.subscribe(url => {
            if (url) {
              this.fb = url;
            }
            this.finalURL= this.fb;
            console.log(this.fb);
          });
        })
      )
      .subscribe(url => {
        if (url) {
          
          console.log(url);
        }
      });
  }
  constructor( private Api: ImageService, private storage: AngularFireStorage,private formBuilder: FormBuilder, public movieService: MovieService, private toastr: ToastrService) {
    this.form = this.formBuilder.group({
      id1:0,
      nombre: ['', [Validators.required]],
      duracion: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      protagonistas: ['', [Validators.required, Validators.maxLength(16)]],
      director: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      clasificacion: ['', [Validators.required, Validators.maxLength(16)]],
      precio_adulto: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      precio_adulto_mayor: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      precio_child: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
    });
  }
  ngOnInit(): void {
    this.movieService.obtenerMovie().subscribe(data => {
      console.log(data);
      this.cliente = data;
      this.form.patchValue({
        nombre: this.cliente.name_Movie,
        duracion: this.cliente.duration_Movie,
        protagonistas: this.cliente.name_Protagonist_Movie,
        director: this.cliente.name_Director_Movie,
        clasificacion: this.cliente.classif_Movie,
        precio_adulto: this.cliente.price_Adult_Movie,
        precio_adulto_mayor: this.cliente.price_Elder_Movie,
        precio_child: this.cliente.price_Kid_Movie,
      });
    })
    this.movieService.obtenerMovies();
    this.urlArray=[];
  }
  guardarPelicula(){
    const cliente: movieModel = {
      name_Movie : this.form.get('nombre').value,
      duration_Movie : this.form.get('duracion').value,
      name_Protagonist_Movie : this.form.get('protagonistas').value,
      name_Director_Movie : this.form.get('director').value,
      classif_Movie : this.form.get('clasificacion').value,
      price_Adult_Movie : this.form.get('precio_adulto').value,
      price_Elder_Movie : this.form.get('precio_adulto_mayor').value,
      price_Kid_Movie: this.form.get('precio_child').value,
      poster_Movie : this.finalURL,
    }
    this.movieService.guardarMovie(cliente).subscribe(data=>{
      this.toastr.success('Tarjeta Guardada', 'Agregada Exitosamente');
      this.form.reset();
    })
    
    console.log(this.form);
    console.log(cliente);
  }
  obtenerPosters(){
   // this.movieService.get
  }
  obtenerPelicula(){
      this.movieService.obtenerMovies();
      this.movieService.getHeroes().then(data => {
        // console.log(data);
        this.lista as movieModel[];
        this.lista = data as movieModel[];
        //console.log(this.lista);
        for(let movie of this.lista){
         // console.log(movie.poster_Movie);
          var nueva = movie.poster_Movie;
          this.urlArray.push(movie.poster_Movie);
        }
       // console.log(this.urlArray);
      });
      this.testTabla();
      //console.log(this.urlArray);
      //this.lista = this.movieService.lista;
      // console.log(this.urlArray);
      // // if(this.lista.length !== undefined){
      // //   console.log(this.movieService.lista.length);
      // // }
      // // console.log(this.lista.find(({poster_Movie})=>poster_Movie));
      
  }
  // meterArray(url:any){
  //   console.log(url);
  //   this.urlArray.push(url);
  // }
  testTabla(){
    var tabla = document.getElementById('tabla') as HTMLTableElement;
    var count = 1;
    const filas = this.urlArray.length;
    const columnas =3 ;
    console.log(this.urlArray);
     var imagen = document.createElement('img') as HTMLImageElement;
     if(this.urlArray[0]!== undefined){
      imagen.src = this.urlArray[0];
      tabla.appendChild(imagen);
     }
  
   
    //this.lista = this.movieService.lista;

    // if(this.lista.length !== undefined){
    //   console.log(this.movieService.lista.length);
    // }
    // console.log(this.lista.find(({poster_Movie})=>poster_Movie));
    //  for (var i = 0; i < filas; i++) {
    //   var newRow = tabla.insertRow(i);
    //   for (var j = 0; j < columnas; j++) {
    //     var newCell = newRow.insertCell(j);
    //       var disponible = document.createElement('img') as HTMLImageElement;
    //       disponible.src = this.urlArray[0];
    //       newCell.appendChild(disponible);
        
        
    //     count++;
    //   }
    // }
    for (var movie of this.movieService.lista) {
      movie.poster_Movie;
      console.log(movie.poster_Movie);
    }
  }
  

}
