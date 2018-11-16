import { Component } from '@angular/core';
import { flatten } from '@angular/compiler';
import { Local } from "./local";
import {LocalService} from "./local.service"
import { Router } from '@angular/router';

@Component({
    selector: 'lista-app',
    templateUrl: 'app/Local/ListaLocal.component.html'
})

export class ListaLocalComponent {
    locales : Local[] ;
    local : Local = null;

    constructor(private _localService : LocalService, private _router : Router){
        this._localService.getLocales()
        .subscribe(
            localReponse => this.locales = localReponse
        )
    }
    eliminarLocal(local : Local){
        var response = confirm("Esta seguro que desea eliminar el registro?")
        if(response){
            this._localService.deleteLocal(local)
            .subscribe(local => {
                this.local = local
                this._router.navigate(['locales/']);
            } );  

            
        }
    }

}