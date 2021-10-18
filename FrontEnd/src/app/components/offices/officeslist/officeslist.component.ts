import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { OfficesService } from 'src/app/services/offices.service';

@Component({
  selector: 'app-officeslist',
  templateUrl: './officeslist.component.html',
  styleUrls: ['./officeslist.component.css']
})
export class OfficeslistComponent implements OnInit {
  enableEdit = false;
  enableEditIndex = null;

  constructor(public officesService:OfficesService, public toastr:ToastrService) { }

  ngOnInit(): void {
    this.officesService.obtenerOffices();
  }
  eliminarOffices(id){
    if(confirm('Desea eliminar la tarjeta?')){
    const index = this.officesService.list.indexOf(id);
     this.officesService.list.splice(index,1);
      this.officesService.eliminarOffices(id).subscribe(data=>{
         this.toastr.warning('Eliminar Exitoso', 'Sucursal Eliminada');
 
         this.officesService.obtenerOffices();
      })
    }
   }
   editar(tarjeta){
     this.officesService.actualizar(tarjeta);
   }
   enableEditMethod(e, i) {
     this.enableEdit = true;
     this.enableEditIndex = i;
     console.log(i, e);
   }

}
