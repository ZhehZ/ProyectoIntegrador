import { Component } from '@angular/core';
import { flatten } from '@angular/compiler';
import { UsuarioService } from './usuario.service';
import { Usuario } from './usuario';
import { Router } from '@angular/router';
@Component({
    selector: 'login',
    templateUrl: 'app/login/login.component.html'
})
export class LoginComponent {
    usuario: Usuario = null;
    public idusu: String;
    public nombre: String;
    constructor(private _userService: UsuarioService,
        private _router: Router) {
        this.usuario = <Usuario>{
            loginUsuario: "",
            passUsuario: ""
        };
    }

    Ingresar(): void {

        this._userService.login(this.usuario)
            .subscribe(usuario => {
                this.usuario = usuario;
                if (this.usuario == null) {
                    alert("Usuario no registrado");
                    this.usuario = <Usuario>{
                        loginUsuario: "",
                        passUsuario: ""
                    };
                }
                else if (!this.usuario.verificaEmail) {
                    alert("Cuenta no Activada");
                }
                else {
                    this.nombre = this.usuario.nomUsuario
                    this.idusu = this.usuario.idUsuario
                    this._userService.changeMessage(this.nombre)
                    this._userService.obtenerId(this.idusu);
                    this._router.navigate(['fotografos/']);
                }
            });

    }
    Borrar(): void {
        this.usuario.loginUsuario = "";
        this.usuario.passUsuario = "";
    }
}