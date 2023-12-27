import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LocadoraListaComponent } from './locadora/locadora-lista/locadora-lista.component';

import { VeiculoListaComponent } from './veiculo/veiculo-lista/veiculo-lista.component';


const routes: Routes = [
  { path: '', redirectTo: '/locadora-lista', pathMatch: 'full' }, // Rota padrão
  { path: 'locadora-lista', component: LocadoraListaComponent },
  { path: 'veiculo-lista', component: VeiculoListaComponent },


  // Outras rotas, se necessário
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
