import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { protagonistModel } from '../models/protagonistModel';

@Injectable({
  providedIn: 'root'
})
export class ProtagonistService {
  myAppUrl: 'http://localhost:15451/api/Protagonist';
  list: protagonistModel[];
  private actualizarForm = new BehaviorSubject<protagonistModel>({} as any);

  constructor(private http: HttpClient) { }
  guardarCliente(cliente: protagonistModel): Observable<protagonistModel> {
    return this.http.post<protagonistModel>('http://localhost:15451/api/Protagonist', cliente);

  }

  obtenerClientes() {
    this.http.get('http://localhost:15451/api/Protagonist').toPromise().then(data => {
      this.list = data as protagonistModel[];
    }
    );
  }
  getHeroes(): Promise<protagonistModel[]> {
    return this.http.get('http://localhost:15451/api/Protagonist')
               .toPromise()
               .then(response => this.list= response as protagonistModel[]);         
  }
  actualizar(cliente){
    this.actualizarForm.next(cliente);
  }
  actualizarCliente(id:number , cliente: protagonistModel): Observable<protagonistModel>{
    return this.http.put<protagonistModel>('http://localhost:15451/api/Protagonist/'+id,cliente);
  }
  obtenerCliente(): Observable<protagonistModel>{
    return this.actualizarForm.asObservable();
  }
  eliminarCliente(id: number): Observable<protagonistModel>{
    return this.http.delete<protagonistModel>('http://localhost:15451/api/Protagonist/'+ id);
  }
}
