import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { employeesModel } from '../models/employeesModel';

@Injectable({
  providedIn: 'root'
})
export class EmpleadoService {
  myAppUrl: 'http://localhost:15451/api/Employee';
  list: employeesModel[];
  private actualizarForm = new BehaviorSubject<employeesModel>({} as any);

  constructor(private http: HttpClient) { }
  guardarEmpleado(empleado: employeesModel): Observable<employeesModel> {
    return this.http.post<employeesModel>('http://localhost:15451/api/Employee', empleado);

  }
  obtenerEmpleados() {
    this.http.get('http://localhost:15451/api/Employee').toPromise().then(data => {
      this.list = data as employeesModel[];
    }
    );
  }
  actualizar(empleado){
    this.actualizarForm.next(empleado);
  }
  actualizarEmpleados(id:number , empleado: employeesModel): Observable<employeesModel>{
    return this.http.put<employeesModel>('http://localhost:15451/api/Employee/'+id,empleado);
  }
  obtenerEmpleado(): Observable<employeesModel>{
    return this.actualizarForm.asObservable();
  }
  eliminarEmpleado(id: number): Observable<employeesModel>{
    return this.http.delete<employeesModel>('http://localhost:15451/api/Employee/'+ id);
  }


}
