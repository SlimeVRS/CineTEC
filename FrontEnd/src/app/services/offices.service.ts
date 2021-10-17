import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { oficcesModel } from '../models/oficcesModels';

@Injectable({
  providedIn: 'root'
})
export class OfficesService {
  myAppUrl: 'http://localhost:15451/api/Branch';
  list: oficcesModel[];
  private actualizarForm = new BehaviorSubject<oficcesModel>({} as any);

  constructor(private http: HttpClient) { }

  
  guardarOffices(offices: oficcesModel): Observable<oficcesModel> {
    return this.http.post<oficcesModel>('http://localhost:15451/api/Branch ', offices);

  }
  obtenerOffices() {
    this.http.get('http://localhost:15451/api/Branch').toPromise().then(data => {
      this.list = data as oficcesModel[];
    }
    );
  }

  actualizar(offices){
    this.actualizarForm.next(offices);
  }
  actualizarOffices(id:number , offices: oficcesModel): Observable<oficcesModel>{
    return this.http.put<oficcesModel>('http://localhost:15451/api/Branch/'+id,offices);
  }
  obtenerOffice(): Observable<oficcesModel>{
    return this.actualizarForm.asObservable();
  }
  eliminarOffices(id: number): Observable<oficcesModel>{
    return this.http.delete<oficcesModel>('http://localhost:15451/api/Branch/'+ id);
  }
  getHeroes(): Promise<oficcesModel[]> {
    return this.http.get('http://localhost:15451/api/Branch')
               .toPromise()
               .then(response => this.list= response as oficcesModel[]);         
  }
}
