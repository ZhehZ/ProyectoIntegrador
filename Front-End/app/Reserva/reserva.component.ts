import { Component } from '@angular/core';
import { flatten } from '@angular/compiler';
import { Reserva } from "./reserva";
import { ReservaService } from "./reserva.service"
import { Router } from '@angular/router';
import { Console } from '@angular/core/src/console';
import { UsuarioService } from '../login/usuario.service';
import { BuffetService } from '../Buffet/buffet.service';
import { LocalService } from '../Local/local.service';
import { FotografoService } from '../Fotografo/fotografo.service';
import { Local } from '../Local/local';
import { Buffet } from '../Buffet/buffet';

@Component({
    selector: 'lista-app',
    templateUrl: 'app/Reserva/reserva.component.html'
})

export class RegistrarReservafoComponent {
    reserva: Reserva = null;
    idUsu: String;
    idBuffet: String;
    idLocal: String;
    selecciono: Boolean;
    fecha: String;
    local: Local;
    buffet: Buffet;

    constructor(private _reservaService: ReservaService,
        private _router: Router,
        private _usuarioService: UsuarioService,
        private _buffetService: BuffetService,
        private _localService: LocalService,
        private _fotografoService: FotografoService) {
        this.reserva = <Reserva>{
            idBuffet: this.idBuffet,
            idLocal: this.idLocal,
            idUsuario: this.idUsu,
            fechaReserva: this.fecha,
            Selecciona: this.selecciono
        };
        this.buffet = <Buffet>{
            nomBuffet: "",
            preBuffet: 0.0
        };
        this.local = <Local>{
            nomLocal: "",
            dirLocal: "",
            telfLocal: "",
            cantLocal: 0,
            idDistrito: "",
            foto: ""
        };
    }

    ngOnInit() {
        this._usuarioService.currentId.subscribe(message =>
            this.idUsu = message);

        this._localService.currentId.subscribe(message =>
            this.idLocal = message
        );
        this._buffetService.currentId.subscribe(message =>
            this.idBuffet = message
        );
        this._localService.currentDate.subscribe(message =>
            this.fecha = message
        );
        this._fotografoService.currentCheck.subscribe(message =>
            this.selecciono = message
        );
        this.obtenerLocal(this.idLocal);
        this.obtenerBuffet(this.idBuffet);
    }

    obtenerLocal(id: String) {
        this._localService.getLocal(id)
            .subscribe(local => {
                this.local = local
            })
    }

    obtenerBuffet(id: String) {
        this._buffetService.getBuffet(id)
            .subscribe(buffet => {
                this.buffet = buffet
            })
    }

    registrar(): void {
        this._reservaService.createReserva(this.reserva)
            .subscribe(reserva => {
                this.reserva = reserva;
                alert("Se Registro la Reserva Exitosamente")
                this._router.navigate(['login/']);
            });
    }


}
