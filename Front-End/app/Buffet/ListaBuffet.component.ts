import { Component } from '@angular/core';
import { flatten } from '@angular/compiler';
import { Buffet } from "./buffet";
import {BuffetService} from "./buffet.service"
import { Router } from '@angular/router';

@Component({
    selector: 'lista-app',
    templateUrl: 'app/Buffet/ListaBuffet.component.html'
})

export class ListaBuffetComponent {
    buffets : Buffet[] ;
    buffet : Buffet = null;

    constructor(private _buffetService : BuffetService, private _router : Router){
        this._buffetService.getBuffets()
        .subscribe(
            buffetReponse => this.buffets = buffetReponse
        )
    }

    eliminarBuffet(buffet : Buffet){
        var response = confirm("Esta seguro que desea eliminar el registro?")
        if(response){
            this._buffetService.deleteBuffet(buffet)
            .subscribe(buffet => {
                this.buffet = buffet
                this._router.navigate(['buffets/']);
            } );  

            
        }
    }

}