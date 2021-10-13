import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { rolModel } from '../models/rolModel';
import { data } from 'jquery';

@Injectable({
  providedIn: 'root'
})
export class RolService {
  myAppUrl: 'http://localhost:15451/api/Rol';
  list: rolModel[]; 
  private actualizarForm = new BehaviorSubject<rolModel>({} as any);

  constructor(private http: HttpClient) { }
  guardarRol(rol: rolModel): Observable<rolModel> {
    return this.http.post<rolModel>('http://localhost:15451/api/Rol', rol);
  }
  obtenerRol():Observable<rolModel> {
     return this.actualizarForm.asObservable();
  }
  obtenerRoles() {
    this.http.get('http://localhost:15451/api/Rol').toPromise().then(data => {
      this.list = data as rolModel[];
    }
    );
  }
  actualizar(cliente){
    this.actualizarForm.next(cliente);
  }
 
}
