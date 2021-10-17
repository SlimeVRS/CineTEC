import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { salaModel } from '../models/salaModel';

@Injectable({
  providedIn: 'root'
})
export class SalaService {

  myAppUrl: 'http://localhost:15451/api/Room';
  list: salaModel[]; 
  private actualizarForm = new BehaviorSubject<salaModel>({} as any);

  constructor(private http: HttpClient) { }
  guardarSala(sala: salaModel): Observable<salaModel> {
    return this.http.post<salaModel>('http://localhost:15451/api/Room', sala);
  }
  obtenerSala():Observable<salaModel> {
     return this.actualizarForm.asObservable();
  }
  obtenerSalas() {
    this.http.get('http://localhost:15451/api/Room').toPromise().then(data => {
      this.list = data as salaModel[];
    }
    );
  }
  obtenerBranchAsociadas(nombreSala: string ){
    this.http.get('http://localhost:15451/api/Room/byroomid'+ nombreSala).toPromise().then(data => {
      this.list = data as salaModel[];
    }
    );
  }
  actualizar(cliente){
    this.actualizarForm.next(cliente);
  }
 
  eliminarSala(id: number): Observable<salaModel>{
    return this.http.delete<salaModel>('http://localhost:15451/api/Room/'+ id);
  }
  getHeroes(): Promise<salaModel[]> {
    return this.http.get('http://localhost:15451/api/Room')
               .toPromise()
               .then(response => this.list= response as salaModel[]);         
  }
}
