import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import {ListaFotografoComponent} from './Fotografo/Listafotografo.component';
import {FotografoService} from './Fotografo/fotografo.service';
import { HttpModule } from '@angular/http';
import {ListaRegaloComponent} from './Regalo/Listaregalo.componet';
import { RegaloService } from './Regalo/regalo.service';
import {ListaBuffetComponent} from './Buffet/ListaBuffet.component';
import { BuffetService } from './Buffet/buffet.service';
import {ListaLocalComponent} from './Local/ListaLocal.component';
import { LocalService } from './Local/local.service';
import {LoginComponent} from './login/login.coponent';
import { UsuarioService } from './login/usuario.service';
import {FormsModule} from '@angular/forms';
import {RegistrarFotografoComponent} from './Fotografo/Registrafotografo.component'

@NgModule({
  declarations: [
    AppComponent,
    ListaFotografoComponent,
    ListaRegaloComponent,
    ListaBuffetComponent,
    ListaLocalComponent,
    LoginComponent,
    RegistrarFotografoComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot([
      { path : 'fotografos',component:ListaFotografoComponent},
      { path : 'regalos',component : ListaRegaloComponent},
      { path : 'buffets',component : ListaBuffetComponent},
      { path : 'locales',component : ListaLocalComponent},
      { path : 'login',component : LoginComponent},
      { path : 'registrarFotografo' , component : RegistrarFotografoComponent},
    ])
  ],
  providers: [
    FotografoService,
    RegaloService,
    BuffetService,
    LocalService,
    UsuarioService
  ],
  bootstrap: [AppComponent]
}) 


export class AppModule { }
