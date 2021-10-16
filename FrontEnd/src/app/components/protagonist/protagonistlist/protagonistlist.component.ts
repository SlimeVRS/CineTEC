import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ProtagonistService } from 'src/app/services/protagonist.service';

@Component({
  selector: 'app-protagonistlist',
  templateUrl: './protagonistlist.component.html',
  styleUrls: ['./protagonistlist.component.css']
})
export class ProtagonistlistComponent implements OnInit {

  enableEdit = false;
  enableEditIndex = null;
  constructor(public protagonistService:ProtagonistService, public toastr:ToastrService) { }
  ngOnInit(): void {
    this.protagonistService.obtenerClientes();
  }
  eliminarTarjeta(id){
    if(confirm('Desea eliminar la tarjeta?')){
    const index = this.protagonistService.list.indexOf(id);
     this.protagonistService.list.splice(index,1);
      this.protagonistService.eliminarCliente(id).subscribe(data=>{
         this.toastr.warning('Eliminar Exitoso', 'Tarjeta Eliminada');
 
         this.protagonistService.obtenerClientes();
      })
    }
   }
   editar(tarjeta){
     this.protagonistService.actualizar(tarjeta);
   }
   enableEditMethod(e, i) {
     this.enableEdit = true;
     this.enableEditIndex = i;
     console.log(i, e);
   }

}
