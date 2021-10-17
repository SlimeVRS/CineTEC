import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { movieModel } from '../models/movieModel';

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  myAppUrl: 'http://localhost:15451/api/Movie';
  lista: movieModel[];
  private actualizarForm = new BehaviorSubject<movieModel>({} as any);

  constructor(private http: HttpClient) { }
  guardarMovie(movie: movieModel): Observable<movieModel> {
    return this.http.post<movieModel>('http://localhost:15451/api/Movie', movie);

  }

  obtenerMovies() {
    this.http.get('http://localhost:15451/api/Movie').toPromise().then(data => {
      this.lista = data as movieModel[];
    }
    );
  }
  getHeroes(): Promise<movieModel[]> {
    return this.http.get('http://localhost:15451/api/Movie')
               .toPromise()
               .then(response => this.lista= response as movieModel[]);         
  }
  actualizar(movie){
    this.actualizarForm.next(movie);
  }
  actualizarMovie(id:number , movie: movieModel): Observable<movieModel>{
    return this.http.put<movieModel>('http://localhost:15451/api/Movie/'+id,movie);
  }
  obtenerMovie(): Observable<movieModel>{
    return this.actualizarForm.asObservable();
  }
  eliminarMovie(id: number): Observable<movieModel>{
    return this.http.delete<movieModel>('http://localhost:15451/api/Movie/'+ id);
  }
}
