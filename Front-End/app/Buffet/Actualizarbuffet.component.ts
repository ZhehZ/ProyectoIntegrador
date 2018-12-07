import { Component } from "@angular/core";
import { Buffet } from "./buffet";
import { Subscription } from "rxjs/Subscription";
import { BuffetService } from "./buffet.service";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
    selector: 'lista-app',
    templateUrl: 'app/Buffet/Actualizarbuffet.component.html'
})

export class ActualizarbuffetComponent {
    buffet: Buffet = null;
    private sub: Subscription
    id: String


    constructor(private _buffetService: BuffetService,
        private _router: Router,
        private _route: ActivatedRoute) {
        this.buffet = <Buffet>{
            nomBuffet: "",
            preBuffet: 0.0
        };
    }

    ngOnInit() {
        this._route.params.subscribe(params => {
            this.id = params['id'];
            this.obtener(this.id)
        });
    }

    obtener(id: String) {
        this._buffetService.getBuffet(id)
            .subscribe(buffet => {
                this.buffet = buffet
            })
    }

    actualizar(): void {

        this._buffetService.updateBuffet(this.buffet)
            .subscribe(buffet => {
                this.buffet = buffet;
                this._router.navigate(['buffets/']);
            });



    }

}