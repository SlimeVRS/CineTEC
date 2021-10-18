import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { userAdminModel } from '../models/userAModel';
import { data } from 'jquery';
@Injectable({
  providedIn: 'root'
})
export class UserAdminService {
  myAppUrl: 'http://localhost:15451/api/Employee';
  list: userAdminModel[]; 
  private actualizarForm = new BehaviorSubject<userAdminModel>({} as any);
  constructor(private http: HttpClient) {
   }
   guardarRol(user: userAdminModel): Observable<userAdminModel> {
    return this.http.post<userAdminModel>('http://localhost:15451/api/Employee', user);
  }
  obtenerRol():Observable<userAdminModel> {
     return this.actualizarForm.asObservable();
  }
  obtenerRoles() {
    this.http.get('http://localhost:15451/api/Employee').toPromise().then(data => {
      this.list = data as userAdminModel[];
    }
    );
  }
  actualizar(cliente){
    this.actualizarForm.next(cliente);
  }
 
  eliminarTarjeta(id: number): Observable<userAdminModel>{
    return this.http.delete<userAdminModel>('http://localhost:15451/api/Employee/'+ id);
  }
}
