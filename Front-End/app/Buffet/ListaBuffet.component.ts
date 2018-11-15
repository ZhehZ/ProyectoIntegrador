import { Component } from '@angular/core';
import { flatten } from '@angular/compiler';
import { Buffet } from "./buffet";
import {BuffetService} from "./buffet.service"

@Component({
    selector: 'lista-app',
    templateUrl: 'app/Buffet/ListaBuffet.component.html'
})

export class ListaBuffetComponent {
    buffets : Buffet[] ;

    constructor(private _buffetService : BuffetService){
        this._buffetService.getBuffets()
        .subscribe(
            buffetReponse => this.buffets = buffetReponse
        )
    }

}