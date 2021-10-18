import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { proyeccionModelAll } from '../models/proyeccionAll';
import { proyeccionModel } from '../models/proyeccionModel';

@Injectable({
  providedIn: 'root'
})
export class ProyeccionService {
  myAppUrl: 'http://localhost:15451/api/Projection';
  list: proyeccionModel[];
  lista:proyeccionModelAll[];
  private actualizarForm = new BehaviorSubject<proyeccionModel>({} as any);

  constructor(private http: HttpClient) { }
  guardarProyeccion(proyeccion: proyeccionModel): Observable<proyeccionModel> {
    return this.http.post<proyeccionModel>('http://localhost:15451/api/Projection', proyeccion);

  }

  obtenerProyecciones() {
    this.http.get('http://localhost:15451/api/Projection/all').toPromise().then(data => {
      this.lista = data as proyeccionModelAll[];
    }
    );
  }
  actualizar(proyeccion){
    this.actualizarForm.next(proyeccion);
  }
  actualizarProyeccion(id:number , proyeccion: proyeccionModel): Observable<proyeccionModel>{
    return this.http.put<proyeccionModel>('http://localhost:15451/api/Projection/'+id,proyeccion);
  }
  obtenerProyeccion(): Observable<proyeccionModel>{
    return this.actualizarForm.asObservable();
  }
  eliminarProyeccion(id: number): Observable<proyeccionModel>{
    return this.http.delete<proyeccionModel>('http://localhost:15451/api/Projection/'+ id);
  }
}
