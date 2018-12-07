import { Component } from '@angular/core';
import { flatten } from '@angular/compiler';
import { Regalo } from "./regalo";
import { RegaloService } from "./regalo.service"
import { Router } from '@angular/router';
import { TipoRegalo } from './tipoRegalo';

@Component({
    selector: 'lista-app',
    templateUrl: 'app/Regalo/Registrarregalo.component.html'
})

export class RegistrarRegaloComponent {
    regalo: Regalo = null;
    tipos: TipoRegalo[];

    constructor(private _regaloService: RegaloService, private _router: Router) {
        this._regaloService.getTipoRegalos()
            .subscribe(
                tipoResponse => this.tipos = tipoResponse
            )
        this.regalo = <Regalo>{
            desRegalo: "",
            idTipo: "",
            foto: ""
        };
    }

    registrar(): void {
        if (this.regalo.desRegalo == "") {
            alert("Debe Ingresar un Regalo")
        }
        else if (this.regalo.idTipo == "") {
            alert("Debe Seleccionar una categoria")
        }
        else if (this.regalo.foto == "") {
            alert("Debe ingresar una imagen de muestra")
        }
        else {
            this._regaloService.createRegalo(this.regalo)
                .subscribe(regalo => {
                    this.regalo = regalo;
                    alert("Se agrego Regalo")
                    this._router.navigate(['regalos/']);
                });

        }
    }

}