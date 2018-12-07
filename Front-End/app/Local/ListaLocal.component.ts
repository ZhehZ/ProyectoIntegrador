import { Component } from '@angular/core';
import { flatten } from '@angular/compiler';
import { Local } from "./local";
import { LocalService } from "./local.service"
import { Router } from '@angular/router';
import { Reserva } from '../Reserva/reserva';

@Component({
    selector: 'lista-app',
    templateUrl: 'app/Local/ListaLocal.component.html'
})

export class ListaLocalComponent {
    locales: Local[];
    local: Local = null;
    reserva : Reserva;

    constructor(private _localService: LocalService, private _router: Router) {
        this.reserva = <Reserva>{
            fechaReserva : ""
        };
    }

    ngOnInit(): void {
        this.listar();
    }

    listar(): void {
        this._localService.getLocales()
            .subscribe(
                localReponse => this.locales = localReponse
            )
    }

    eliminarLocal(id: String) {
        var response = confirm("Esta seguro que desea eliminar el registro?")
        if (response) {
            this._localService.deleteLocal(id)
                .subscribe(local => {
                    this.local = local
                    alert("Se elimino Registro")
                    this.listar()
                });
        }
    }

    SeleccionarLocal(id : String , fecha : String){
        this._localService.obtenerId(id);
        this._localService.obtenerFecha(fecha);
        this._router.navigate(['buffets/']);
    }


}