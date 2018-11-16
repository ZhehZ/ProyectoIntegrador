import { Component } from '@angular/core';
import { flatten } from '@angular/compiler';
import { Fotografo } from "./fotografo";
import {FotografoService} from "./fotografo.service"
import {Router} from '@angular/router'

@Component({
    selector: 'lista-app',
    templateUrl: 'app/Fotografo/ListaFotografo.component.html'
})

export class ListaFotografoComponent {
    fotografos : Fotografo[] ;
    fotografo : Fotografo = null;

    constructor(private _fotografoService : FotografoService, private _router : Router){
        this._fotografoService.getFotografos()
        .subscribe(
            fotografoReponse => this.fotografos = fotografoReponse
        )
        this.fotografo = <Fotografo> {
            idFotografo : "",
        };

    }

    irActualizar(fotografo : Fotografo){
        this._fotografoService.getFotografo(fotografo)
        console.log(fotografo)
        this._router.navigate(['actualizarFotografo/'])

    }

    eliminarFotografo(fotografo : Fotografo){
        var response = confirm("Esta seguro que desea eliminar el registro?")
        if(response){
            this._fotografoService.deleteFotografo(fotografo)
            .subscribe(fotografo => {
                this.fotografo = fotografo
                this._router.navigate(['fotografos/']);
            } );  

            
        }
    }

    

}