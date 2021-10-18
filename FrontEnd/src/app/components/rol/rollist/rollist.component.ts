import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { RolService } from 'src/app/services/rol.service';

@Component({
  selector: 'app-rollist',
  templateUrl: './rollist.component.html',
  styleUrls: ['./rollist.component.css']
})
export class RollistComponent implements OnInit {
  enableEdit = false;
  enableEditIndex = null;
  constructor(public rolService:RolService, public toastr:ToastrService) { }

  ngOnInit(): void {
    this.rolService.obtenerRoles();
  }
  eliminarTarjeta(id){
    if(confirm('Desea eliminar la tarjeta?')){
    const index = this.rolService.list.indexOf(id);
     this.rolService.list.splice(index,1);
      this.rolService.eliminarTarjeta(id).subscribe(data=>{
         this.toastr.warning('Eliminar Exitoso', 'Rol Eliminada');
 
         this.rolService.obtenerRoles();
      })
    }
   }
   editar(tarjeta){
     this.rolService.actualizar(tarjeta);
   }
   enableEditMethod(e, i) {
     this.enableEdit = true;
     this.enableEditIndex = i;
     console.log(i, e);
   }
}
