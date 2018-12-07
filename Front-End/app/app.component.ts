import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FotografoService } from './Fotografo/fotografo.service';
import { UsuarioService } from './login/usuario.service';
import { Usuario } from './login/usuario';
@Component({
    selector: 'pm-app',
    templateUrl: 'app/app.component.html'
})
export class AppComponent {
    pageTitle: String = "Dijo Si!!!";
    usuario: Usuario;
    id: String;
    nombre : String = '';

    constructor(private _fotografoService: FotografoService,
        private _router: Router, private _usuarioService: UsuarioService) {
    }

    ngOnInit() {
        this._usuarioService.currentMessage.subscribe(message => this.nombre = message);
    }

    logOut(){
        this._router.navigate(['/login']);
        this.nombre = '';
      }
}
