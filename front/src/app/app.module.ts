import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ModalModule } from 'ngx-bootstrap/modal';
import { FormsModule } from '@angular/forms';
import { LocadoraListaComponent } from './locadora/locadora-lista/locadora-lista.component';
import { NumericDirective } from './numeric.directive';
import { VeiculoListaComponent } from './veiculo/veiculo-lista/veiculo-lista.component';


@NgModule({
  declarations: [
    AppComponent,
    LocadoraListaComponent,
    VeiculoListaComponent,
    NumericDirective,
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule,ModalModule.forRoot(),
    FormsModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
