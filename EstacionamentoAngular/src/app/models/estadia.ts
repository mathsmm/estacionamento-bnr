import { Veiculo } from "./veiculo";

export class Estadia {

  constructor () {
    this.veiculo = new Veiculo()
    this.dtHrEntrada = new Date();
    this.dtHrSaida = new Date();
    this.vlrCalculado = 0.0;
  }

  veiculo: Veiculo;
  dtHrEntrada: Date;
  dtHrSaida: Date;
  vlrCalculado: number;
}