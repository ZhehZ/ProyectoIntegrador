import { Component } from '@angular/core';
import { flatten } from '@angular/compiler';
import { Fotografo } from "./fotografo";
import {FotografoService} from "./fotografo.service"

@Component({
    selector: 'lista-app',
    templateUrl: 'app/Fotografo/ListaFotografo.component.html'
})

export class ListaFotografoComponent {
    fotografos : Fotografo[] ;

    constructor(private _fotografoService : FotografoService){
        this._fotografoService.getFotografos()
        .subscribe(
            fotografoReponse => this.fotografos = fotografoReponse
        )
    }

}