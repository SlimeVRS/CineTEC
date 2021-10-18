import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { userClientModel } from '../models/userCModel';
import { data } from 'jquery';
@Injectable({
  providedIn: 'root'
})
export class UserClientService {
  myAppUrl: 'http://localhost:15451/api/Client';
  list: userClientModel[]; 
  private actualizarForm = new BehaviorSubject<userClientModel>({} as any);
  constructor(private http: HttpClient) { }
  guardarRol(user: userClientModel): Observable<userClientModel> {
    return this.http.post<userClientModel>('http://localhost:15451/api/Client', user);
  }
  obtenerRol():Observable<userClientModel> {
     return this.actualizarForm.asObservable();
  }
  obtenerRoles() {
    this.http.get('http://localhost:15451/api/Client').toPromise().then(data => {
      this.list = data as userClientModel[];
    }
    );
  }
  actualizar(cliente){
    this.actualizarForm.next(cliente);
  }
 
  eliminarTarjeta(id: number): Observable<userClientModel>{
    return this.http.delete<userClientModel>('http://localhost:15451/api/Client/'+ id);
  }
}
