import { Component } from '@angular/core';
import { flatten } from '@angular/compiler';
import { Fotografo } from "./fotografo";
import { FotografoService } from "./fotografo.service"
import { Router } from '@angular/router';

@Component({
    selector: 'lista-app',
    templateUrl: 'app/Fotografo/Actualizafotografo.component.html'
})

export class ActualizarFotografoComponent {
    fotografo: Fotografo = null;

    constructor(private _fotografoService: FotografoService, private _router: Router) {
        this.fotografo = <Fotografo>{
            telfFotografo: "",
            dirFotografo: ""
        };
        this._fotografoService.getFotografo("F003")
            .subscribe(fotografo => {
                this.fotografo = fotografo
            })

    }

    actualizar(): void {

        this._fotografoService.updateFotografo(this.fotografo)
            .subscribe(fotografo => {
                this.fotografo = fotografo;
                this._router.navigate(['fotografos/']);
            });



    }




}