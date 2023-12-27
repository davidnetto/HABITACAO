import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LocadoraService } from '../../services/locadora.service';
import { Router } from '@angular/router';
import * as XLSX from 'xlsx';
import { NgModule } from '@angular/core';


@Component({
  selector: 'app-locadora',
  templateUrl: './locadora-lista.component.html',
  styleUrls: ['./locadora-lista.component.css']
})
export class LocadoraListaComponent implements OnInit {
  locadoras: any[] = [];

  count: number = 0;
  excelData: any[] = [];

  idososData: string[] = [];
  idoso: string[] = [];

  deficienteFisicoData: string[] = [];
  fisico: string[] = [];


  geralData: string[] = [];
  geral: string[] = [];

  vencedoresGeral:any;
  vencedoresIdoso: any;
  vencedoresFisico: any;

  oi : string = 'sasas';
  constructor(
    private fb: FormBuilder,
    private locadoraService: LocadoraService,
    private router: Router
  ) {}

  ngOnInit(): void {

  }

  realizarSorteio(){
    this.idososData.forEach(element => {
      this.idoso.push(element[0]);
    });
    this.deficienteFisicoData.forEach(element => {
      this.fisico.push(element[0]);
    });
    this.geralData.forEach(element => {
      this.geral.push(element[0]);
    });

    const payload = { geral: this.geral, idoso: this.idoso, fisico: this.fisico};
    this.locadoraService.realizarSorteio(payload).subscribe(
      (resposta) => {
 
        this.vencedoresGeral = resposta.vencedoresGeral;
        this.vencedoresIdoso = resposta.vencedoresFisico;
        this.vencedoresFisico = resposta.vencedoresFisico;   
        this.router.navigate(['/veiculo-lista'], { queryParams: resposta});
      },
      (error) => {
        console.error('Erro ao excluir locadora:', error);
      
      }
    );


  }

   validarCPF(cpf: any) {
    // Remove caracteres não numéricos
    cpf = cpf.replace(/\D/g, '');
  
    // Verifica se o CPF possui 11 dígitos
    if (cpf.length !== 11) {
      return false;
    }
  
    // Verifica se todos os dígitos são iguais, o que torna o CPF inválido
    if (/^(\d)\1{10}$/.test(cpf)) {
      return false;
    }
  
    // Calcula o primeiro dígito verificador
    let soma = 0;
    for (let i = 0; i < 9; i++) {
      soma += parseInt(cpf.charAt(i)) * (10 - i);
    }
    let resto = 11 - (soma % 11);
    let digitoVerificador1 = (resto === 10 || resto === 11) ? 0 : resto;
  
    // Verifica se o primeiro dígito verificador é válido
    if (digitoVerificador1 !== parseInt(cpf.charAt(9))) {
      return false;
    }
  
    // Calcula o segundo dígito verificador
    soma = 0;
    for (let i = 0; i < 10; i++) {
      soma += parseInt(cpf.charAt(i)) * (11 - i);
    }
    resto = 11 - (soma % 11);
    let digitoVerificador2 = (resto === 10 || resto === 11) ? 0 : resto;
  
    // Verifica se o segundo dígito verificador é válido
    if (digitoVerificador2 !== parseInt(cpf.charAt(10))) {
      return false;
    }
  
    // Se chegou até aqui, o CPF é válido
    return true;
  }


  onFileSelected(event: any): void {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e: any) => {
        const data = new Uint8Array(e.target.result);
        const workbook = XLSX.read(data, { type: 'array' });
  
        const sheetData = XLSX.utils.sheet_to_json(workbook.Sheets[workbook.SheetNames[0]], { header: 1 });
        this.excelData = sheetData;
       

        // Processar abas
        workbook.SheetNames.forEach(sheetName => {
          const sheetData = XLSX.utils.sheet_to_json<any>(workbook.Sheets[sheetName], { header: 1 });
        
          // Separar dados por abas
          

          sheetData.forEach(item => {
            const idade = Number(item[0].split(',')[2]);
            const cpf = item[0].split(',')[1];
            const renda = Number(item[0].split(',')[3]);
            const cota = item[0].split(',')[4];

            if(renda < 1045 || renda > 5225){
              return;
            }

            if(!this.validarCPF(cpf)){
              return;
            }

            const dataAtual = new Date();
            const dataNascimento = new Date(dataAtual.getFullYear() - idade, 0, 1);
            dataNascimento.setDate(dataNascimento.getDate() + 1);
            const quinzeAnosAtras = new Date(dataAtual.getFullYear() - 15, dataAtual.getMonth(), dataAtual.getDate());
            if(dataNascimento > quinzeAnosAtras){
              return;
            }

            switch (cota) {
              case 'IDOSO':
                this.idososData.push(item);
                this.count +=1;
                break;
              case 'DEFICIENTE FÍSICO':
              case 'DEIFICENTE FÍSICO':

              this.count +=1;
                this.deficienteFisicoData.push(item);
                break;
              case 'GERAL':
                this.count +=1;
                this.geralData.push(item);
                break;
              default:
                break;
            }
         });
          

        });
      };
      reader.readAsArrayBuffer(file);
    }
  }
  
  private parseRows(rows: any[]): any[] {
    return rows.map(row => this.parseRow(row));
  }
  
  private parseRow(row: any[]): any {
    return {
      nome: row[0],
      cpf: row[1],
      dataNascimento: row[2],
      renda: row[3],
      tipo: row[4],
      cid: row[5]
    };
  }
  
 
  onSubmit() {
    // Implemente a lógica para processar o formulário quando necessário
  }
}
