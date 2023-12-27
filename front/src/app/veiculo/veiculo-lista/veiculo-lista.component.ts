import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LocadoraService } from '../../services/locadora.service';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

@Component({
  selector: 'app-veiculo',
  templateUrl: './veiculo-lista.component.html',
  styleUrls: ['./veiculo-lista.component.css']
})
export class VeiculoListaComponent implements OnInit {
  veiculos: any[] = [];

  geral: any[] =[];
  idoso: any[] =[];
  fisico: any[] =[];

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.route.queryParams.subscribe(params => {
      
      this.geral =params['vencedoresGeral'];
      this.fisico =params['vencedoresDeficienteFisico'];
      this.idoso =params['vencedoresIdoso'];

      console.log('geral:', this.geral);
      console.log('fisico:', this.fisico);
      console.log('idoso:', this.idoso);
  })}



  ngOnInit(): void {

  }

  
  onSubmit() {
    // Implemente a lógica para processar o formulário quando necessário
  }
}
