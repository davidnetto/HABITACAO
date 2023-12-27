import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

import { Locadora } from '../locadora/locadora-model';

@Injectable({
  providedIn: 'root'
})


export class LocadoraService {
  
  private apiUrl = 'http://localhost:5000/api/'; // Substitua pela URL da sua API

  constructor(private http: HttpClient) { }


  listarLocadorasRelatorio(): Observable<Locadora[]> {
    return this.http.get<Locadora[]>('http://localhost:5000/api/Locadora/relatorio'); // Ajuste o nome do seu controller aqui
  }

  obterLocadoraPorId(id: number): Observable<Locadora> {
    return this.http.get<Locadora>(`http://localhost:5000/api/Locadora/${id}`);
  }

  // adicionarLocadora(locadora: Locadora): Observable<Locadora> {
  //   return this.http.post<Locadora>('http://localhost:5000/api/Locadora', locadora);
  // }

  adicionarLocadora(locadora: Locadora): Observable<Locadora> {
    return this.http.post<Locadora>('http://localhost:5000/api/Locadora', locadora)
      .pipe(
        catchError((error: any) => {
          if (error instanceof Error) {
            // Erro de cliente (por exemplo, conexão perdida)
            return throwError('Ocorreu um erro de cliente.');
          } else {
            // Erro no servidor (por exemplo, InvalidOperationException)
            return throwError(error.error); // Retorna a mensagem de erro do servidor
          }
        })
      );
  }

  atualizarLocadora(locadora: Locadora, id: number): Observable<Locadora> {
    locadora.id= id;
    return this.http.put<Locadora>(`http://localhost:5000/api/Locadora`, locadora);
  }


  excluirLocadora(id: number): Observable<void> {
    const url = `http://localhost:5000/api/Locadora?id=${id}`;
    return this.http.delete<void>(url);
  }
  



  // realizarSorteio(geral: string[]): Observable<Locadora[]> {
  //   const corpoDaRequisicao = JSON.stringify(geral);
  
  //   console.log('Corpo da Requisição:', corpoDaRequisicao);
  
  //   return this.http.post<Locadora[]>('http://localhost:7075/api/Sorteado/realizar', corpoDaRequisicao, {
  //     headers: {
  //       'Content-Type': 'application/json',
  //     },
  //   }).pipe(
  //     catchError((error: any) => {
  //       console.error('Erro na requisição HTTP:', error);
  //       return throwError(error.error);
  //     })
  //   );
  // }
  
  // realizarSorteio(geral: string[]): Observable<string[]> {
  //   return this.http.post<string[]>('http://localhost:7075/api/Sorteado/realizar', geral, {
  //     headers: {
  //       'Content-Type': 'application/json',
  //     },
  //   }).pipe(
  //     catchError((error: any) => {
  //       console.error('Erro na requisição HTTP:', error);
  //       return throwError(error.error);
  //     })
  //   );
  // }
  

  realizarSorteio(payload: any): Observable<Locadora> {
    

    return this.http.post<Locadora>('https://localhost:7075/api/Sorteado/realizar', payload)
      .pipe(
        catchError((error: any) => {
          if (error instanceof Error) {
            // Erro de cliente (por exemplo, conexão perdida)
            return throwError('Ocorreu um erro de cliente.');
          } else {
            // Erro no servidor (por exemplo, InvalidOperationException)
            return throwError(error.error); // Retorna a mensagem de erro do servidor
          }
        })
      );
  }

}
