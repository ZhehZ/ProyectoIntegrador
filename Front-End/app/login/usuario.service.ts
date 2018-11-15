import { Usuario } from "./usuario";
import { Injectable } from "@angular/core";
import {Http} from "@angular/http"
import { Response } from "@angular/http/src/static_response";
import { Observable } from "rxjs/Observable";

@Injectable()
export class UsuarioService{
    private _Login : string ="http://localhost:54116//api/Usuario/Login";
    usuario : Usuario = null;

    constructor(private _http : Http){

    }

    login(usuario : Usuario) : Observable<Usuario> {

        var body = {
            loginUsuario : usuario.loginUsuario,
            passUsuario : usuario.passUsuario
            
        };

        var req = this._http.post(this._Login,body);
        return req.map((response:Response) => <Usuario>response.json())
        .catch(this.handleError);

    }

    private handleError(error:Response){
        return Observable.throw(error.json().error || "server error");
    }

    getUsuarios() : Usuario{
        return this.usuario;
        
    } 
}