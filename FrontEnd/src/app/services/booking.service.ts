import { Injectable } from '@angular/core';
import { bookingModel } from '../models/infoFactura';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  lista: bookingModel[];
  sucursalCartelera: string;
  salaCartelera: number;
  nombrepeliculaCartelera:string;
  horaCartelera:string;
  diaCartelera:string;
  constructor() { }
  storesucursalCarteleral(sucursalCartelera: string){
    this.sucursalCartelera=sucursalCartelera;
  }
  storesalaCartelera(salaCartelera: number){
    this.salaCartelera=salaCartelera;
  }
  storenombrepeliculaCartelera(nombrepeliculaCartelera:string){
    this.nombrepeliculaCartelera=nombrepeliculaCartelera;
  }
  storehoraCartelera(horaCartelera:string){
    this.horaCartelera=horaCartelera;
  }
  storediaCartelera(diaCartelera:string){
    this.diaCartelera=diaCartelera;
  }
}
