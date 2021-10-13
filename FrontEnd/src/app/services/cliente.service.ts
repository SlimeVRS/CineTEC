import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { clientsModel } from '../models/clientsModel';
import { HttpClient } from '@angular/common/http'; 
import { data } from 'jquery';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  myAppUrl: 'http://localhost:15451/api/Client';
  list: clientsModel[];
  private actualizarForm = new BehaviorSubject<clientsModel>({} as any);

  constructor(private http: HttpClient) { }
  guardarCliente(cliente: clientsModel): Observable<clientsModel> {
    return this.http.post<clientsModel>('http://localhost:15451/api/Client', cliente);

  }

  obtenerClientes() {
    this.http.get('http://localhost:15451/api/Client').toPromise().then(data => {
      this.list = data as clientsModel[];
    }
    );
  }
  actualizar(cliente){
    this.actualizarForm.next(cliente);
  }
  actualizarCliente(id:number , cliente: clientsModel): Observable<clientsModel>{
    return this.http.put<clientsModel>('http://localhost:15451/api/Client/'+id,cliente);
  }
  obtenerCliente(): Observable<clientsModel>{
    return this.actualizarForm.asObservable();
  }
  eliminarCliente(id: number): Observable<clientsModel>{
    return this.http.delete<clientsModel>('http://localhost:15451/api/Client'+ id);
  }

}
