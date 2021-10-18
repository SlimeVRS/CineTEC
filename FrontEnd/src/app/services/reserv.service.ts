import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { seatModel } from '../models/seat';

@Injectable({
  providedIn: 'root'
})
export class ReservService {

  myAppUrl: 'http://localhost:15451/api/Seat';
  list: seatModel[];
  private actualizarForm = new BehaviorSubject<seatModel>({} as any);

  constructor(private http: HttpClient) { }

  
  guardarOffices(offices: seatModel): Observable<seatModel> {
    return this.http.post<seatModel>('http://localhost:15451/api/Seat ', offices);

  }
  obtenerOffices() {
    this.http.get('http://localhost:15451/api/Seat').toPromise().then(data => {
      this.list = data as seatModel[];
    }
    );
  }

  actualizar(offices){
    this.actualizarForm.next(offices);
  }
  actualizarOffices(offices: seatModel): Observable<seatModel>{
    return this.http.put<seatModel>('http://localhost:15451/api/Seat/checkin',offices);
  }
  obtenerOffice(): Observable<seatModel>{
    return this.actualizarForm.asObservable();
  }
  eliminarOffices(id: number): Observable<seatModel>{
    return this.http.delete<seatModel>('http://localhost:15451/api/Seat/'+ id);
  }
  getHeroes(id:number): Promise<seatModel[]> {
    return this.http.get('http://localhost:15451/api/Seat/room/'+id)
               .toPromise()
               .then(response => this.list= response as seatModel[]);         
  }
  getHeroes2(id:number): Promise<seatModel[]> {
    return this.http.get('http://localhost:15451/api/Seat/ocupied/'+id)
               .toPromise()
               .then(response => this.list= response as seatModel[]);         
  }
}
