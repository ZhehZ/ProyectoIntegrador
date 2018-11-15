import {Buffet  } from "./buffet";
import {Http , Response} from '@angular/http';
import {Injectable} from '@angular/core'
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { error } from "util";


@Injectable()
export class BuffetService{

    private _getBuffetsURL : string = "http://localhost:54116/api/Buffets/ListarBuffets";

    constructor(private _http : Http){

    }

    buffets : Buffet[]; 

    getBuffets() :  Observable<Buffet[]> {
        return this._http.get(this._getBuffetsURL)
        .map((Response : Response) => <Buffet[]>Response.json())
        .catch(this.controlarException);
    }

    private controlarException(error : Response) {
        console.log("error",error);
        return Observable.throw(error.json().error || "Server Error");
    }
}