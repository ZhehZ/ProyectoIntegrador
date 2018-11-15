import { Local } from "./local";
import {Http , Response} from '@angular/http';
import {Injectable} from '@angular/core'
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { error } from "util";


@Injectable()
export class LocalService{

    private _getLocalesURL : string = "http://localhost:54116/api/Locales/ListarLocales";

    constructor(private _http : Http){

    }

    locales : Local[]; 

    getLocales() :  Observable<Local[]> {
        return this._http.get(this._getLocalesURL)
        .map((Response : Response) => <Local[]>Response.json())
        .catch(this.controlarException);
    }

    private controlarException(error : Response) {
        console.log("error",error);
        return Observable.throw(error.json().error || "Server Error");
    }
}