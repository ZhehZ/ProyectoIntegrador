import { Component } from '@angular/core';
import { flatten } from '@angular/compiler';
import { Buffet } from "./buffet";
import {BuffetService} from "./buffet.service"
import { Router } from '@angular/router';
import { Categoria } from './Categoria';

@Component({
    selector: 'lista-app',
    templateUrl: 'app/Buffet/RegistrarBuffet.component.html'
})

export class RegistrarBuffetComponent {
    buffet : Buffet = null;
    buffets : Buffet[]
    categorias : Categoria[]

    constructor(private _buffetService : BuffetService, private _router : Router){
        this._buffetService.getCategorias()
        .subscribe(          
            localReponse => this.categorias = localReponse
            
        )
        this.buffet = <Buffet> {
            nomprovBuffet : "",
            nomBuffet : "",
            desBuffet : "",
            preBuffet : 0.0,
            idCategoria : ""
        };
    }

    registrar() : void {
        
        this._buffetService.createBuffet(this.buffet)
        .subscribe(buffet => {
            this.buffet = buffet;
            this._router.navigate(['buffets/']);
        } );  
       
        
    }

}