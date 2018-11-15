import { Component } from '@angular/core';
import { flatten } from '@angular/compiler';
import { Local } from "./local";
import {LocalService} from "./local.service"

@Component({
    selector: 'lista-app',
    templateUrl: 'app/Local/ListaLocal.component.html'
})

export class ListaLocalComponent {
    locales : Local[] ;

    constructor(private _localService : LocalService){
        this._localService.getLocales()
        .subscribe(
            localReponse => this.locales = localReponse
        )
    }

}