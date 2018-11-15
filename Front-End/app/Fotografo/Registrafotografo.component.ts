import { Component } from '@angular/core';
import { flatten } from '@angular/compiler';
import { Fotografo } from "./fotografo";
import {FotografoService} from "./fotografo.service"
import { Router } from '@angular/router';

@Component({
    selector: 'lista-app',
    templateUrl: 'app/Fotografo/Registrafografo.component.html'
})

export class RegistrarFotografoComponent {
    fotografo : Fotografo = null;

    constructor(private _fotografoService : FotografoService, private _router : Router){
        this.fotografo = <Fotografo> {
            nomFotografo : "",
            telfFotografo : "",
            dirFotografo  :""
        };
    }

    registrar() : void {
        
        var fotoRegi = this._fotografoService.createFotografo(this.fotografo)
        .subscribe(fotografo => {
            this.fotografo = fotografo;
            this._router.navigate(['fotografos/']);
        } );  
       
        
    }

}