import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Estadia } from '../models/estadia';

@Injectable({
  providedIn: 'root'
})
export class EstadiaService {

  urlApi = 'http://localhost:5203/Estadia';

  constructor(private http: HttpClient) { }

  obterTodas() : Observable<Estadia[]> {
    return this.http.get<Estadia[]>(this.urlApi);
  }

  salvar(placa: string) {
    return this.http.post(`${this.urlApi}/placa=${placa}`, {});
  }

  editar(placa: string) {
    return this.http.put(`${this.urlApi}/placa=${placa}`, {});
  }

  // deletar(placa: string, dtHora: Date) {
  //   return this.http.delete(`${this.urlApi}/placa=${placa}&dataHora=${dtHora.toString()}`);
  // }
}
