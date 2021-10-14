import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { clientsModel } from 'src/app/models/clientsModel';
import { ClienteService } from 'src/app/services/cliente.service';

@Component({
  selector: 'app-clientslist',
  templateUrl: './clientslist.component.html',
  styleUrls: ['./clientslist.component.css']
})
export class ClientslistComponent implements OnInit {
  enableEdit = false;
  enableEditIndex = null;
  constructor(public clientService:ClienteService, public toastr:ToastrService) { }
  ngOnInit(): void {
    this.clientService.obtenerClientes();
  }
  eliminarTarjeta(id){
    if(confirm('Desea eliminar la tarjeta?')){
    const index = this.clientService.list.indexOf(id);
     this.clientService.list.splice(index,1);
      this.clientService.eliminarCliente(id).subscribe(data=>{
         this.toastr.warning('Eliminar Exitoso', 'Tarjeta Eliminada');
 
         this.clientService.obtenerClientes();
      })
    }
   }
   editar(tarjeta){
     this.clientService.actualizar(tarjeta);
   }
   enableEditMethod(e, i) {
     this.enableEdit = true;
     this.enableEditIndex = i;
     console.log(i, e);
   }

}
