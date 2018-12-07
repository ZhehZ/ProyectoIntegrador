import { Reserva } from "./reserva";
import { Http, Response } from '@angular/http';
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { error } from "util";
import { Router } from "@angular/router/src/router";
import { BehaviorSubject } from "rxjs/BehaviorSubject"


@Injectable()
export class ReservaService {

    private _createReservaURL: string = "http://localhost:54116/api/Reserva/RegistrarReserva";
    reserva: Reserva = null;

    constructor(private _http: Http) {
    }


    private idLocalObtenido = new BehaviorSubject(new String);
    idLocal = this.idLocalObtenido.asObservable();
    
    idL(message:String){
      this.idLocalObtenido.next(message);
    }

    private idBuffetbtenido = new BehaviorSubject(new String);
    idBuffet = this.idBuffetbtenido.asObservable();
    
    idB(message:String){
      this.idBuffetbtenido.next(message);
    }

    private FechaObtenida = new BehaviorSubject(new Date);
    fecha = this.FechaObtenida.asObservable();
    
    fec(message:Date){
      this.FechaObtenida.next(message);
    }

    private Selecciono = new BehaviorSubject(new Boolean);
    selecciono = this.Selecciono.asObservable();
    
    select(message:Boolean){
      this.Selecciono.next(message);
    }

    createReserva(reserva: Reserva): Observable<Reserva> {
        var body = {
            idBuffet: reserva.idBuffet,
            idLocal: reserva.idLocal,
            idUsuario: reserva.idUsuario,
            fechaReserva: reserva.fechaReserva,
            Selecciona: reserva.Selecciona
        }

        var req = this._http.post(this._createReservaURL, body);
        return req.map((response: Response) => <Reserva>response.json())
            .catch(this.handleError);

    }

    private handleError(error: Response) {
        return Observable.throw(error.json().error || "server error");
    }

}