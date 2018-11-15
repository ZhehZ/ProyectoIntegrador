import { Fotografo } from "./fotografo";
import {Http , Response} from '@angular/http';
import {Injectable} from '@angular/core'
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { error } from "util";
import { Router } from "@angular/router/src/router";


@Injectable()
export class FotografoService{

    private _getFotografosURL : string = "http://localhost:54116/api/Fotografos/ListarFotografos";
    private _createFotografoURL : string = "http://localhost:54116/api/Fotografos/RegistrarFotografos";
    fotografo : Fotografo = null;

    constructor(private _http : Http){
    }

    fotografos : Fotografo[]; 

    getFotografos() :  Observable<Fotografo[]> {
        return this._http.get(this._getFotografosURL)
        .map((Response : Response) => <Fotografo[]>Response.json())
        .catch(this.controlarException);
    }

    private controlarException(error : Response) {
        console.log("error",error);
        return Observable.throw(error.json().error || "Server Error");
    }

    createFotografo(fotografo : Fotografo) : Observable<Fotografo>{
        var body = {
            NomFotografo : fotografo.nomFotografo,
            telfFotografo : fotografo.telfFotografo,
            dirFotografo : fotografo.dirFotografo
        }

        var req = this._http.post(this._createFotografoURL,body);
        return req.map((response:Response) => <Fotografo>response.json())
        .catch(this.handleError);

    } 

    private handleError(error:Response){
        return Observable.throw(error.json().error || "server error");
    }

}