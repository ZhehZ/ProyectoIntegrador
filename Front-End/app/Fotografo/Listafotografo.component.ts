import { Component } from '@angular/core';
import { flatten } from '@angular/compiler';
import { Fotografo } from "./fotografo";
import { FotografoService } from "./fotografo.service"
import { Router } from '@angular/router'
import { Reserva } from '../Reserva/reserva';

@Component({
    selector: 'lista-app',
    templateUrl: 'app/Fotografo/ListaFotografo.component.html'
})

export class ListaFotografoComponent {
    fotografos: Fotografo[];
    fotografo: Fotografo = null;
    reserva : Reserva = null;

    constructor(private _fotografoService: FotografoService, private _router: Router) {
        this.reserva = <Reserva>{
            Selecciona: false
        };
    }

    ngOnInit(): void {
        this.listar();
    }

    listar(): void {
        this._fotografoService.getFotografos()
            .subscribe(
                fotografoReponse => this.fotografos = fotografoReponse
            )
    }

    eliminarFotografo(id: String) {
        var response = confirm("Esta seguro que desea eliminar el registro?")
        if (response) {
            this._fotografoService.deleteFotografo(id)
                .subscribe(fotografo => {
                    this.fotografo = fotografo
                    alert("Se elimino Registro")
                    //this._router.navigate(['fotografos/']);
                    this.listar()
                });


        }
    }

    SeleccionarEleccion(respuesta : boolean){
        this._fotografoService.obtenerCheck(respuesta);
        this._router.navigate(['reserva/']);
    }



}