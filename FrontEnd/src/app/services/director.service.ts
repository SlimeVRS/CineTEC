import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { directorModel } from '../models/directorModel';

@Injectable({
  providedIn: 'root'
})
export class DirectorService {

  myAppUrl: 'http://localhost:15451/api/Directors';
  list: directorModel[];
  private actualizarForm = new BehaviorSubject<directorModel>({} as any);

  constructor(private http: HttpClient) { }
  guardarCliente(cliente: directorModel): Observable<directorModel> {
    return this.http.post<directorModel>('http://localhost:15451/api/Directors', cliente);

  }

  obtenerClientes() {
    this.http.get('http://localhost:15451/api/Directors').toPromise().then(data => {
      this.list = data as directorModel[];
    }
    );
  }
  actualizar(cliente){
    this.actualizarForm.next(cliente);
  }
  actualizarCliente(id:number , cliente: directorModel): Observable<directorModel>{
    return this.http.put<directorModel>('http://localhost:15451/api/Directors/'+id,cliente);
  }
  obtenerCliente(): Observable<directorModel>{
    return this.actualizarForm.asObservable();
  }
  eliminarCliente(id: number): Observable<directorModel>{
    return this.http.delete<directorModel>('http://localhost:15451/api/Directors/'+ id);
  }
}
