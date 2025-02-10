import { Component, ElementRef, input, ViewChild } from '@angular/core';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { EstadiaService } from '../services/estadia.service';
import { Estadia } from '../models/estadia';

@Component({
  selector: 'app-main',
  imports: [
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ],
  templateUrl: './main.component.html',
  styleUrl: './main.component.scss'
})
export class MainComponent {
  displayedColumns: string[] = ['placa', 'dtHoraEntrada', 'dtHoraSaida', 'vlrCalculado'];
  dataSource: MatTableDataSource<Estadia>;

  // @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild('inputPlaca') inputPlaca: ElementRef;
  btMarcarEntradaDisabled: boolean = true;
  btMarcarSaidaDisabled: boolean = true;

  public estadias: Estadia[] = [];

  constructor(private estadiaService: EstadiaService) {}

  placaKeyUp() {
    this.inputPlaca.nativeElement.value = this.inputPlaca.nativeElement.value.toUpperCase();
    this.inputPlaca.nativeElement.value = this.inputPlaca.nativeElement.value.replace(/[^A-Z|0-9]/, '');

    if (this.inputPlaca.nativeElement.value.length == 7) {
      this.btMarcarEntradaDisabled = false;

      this.estadias.forEach(element => {
        if (element.veiculo.placa == this.inputPlaca.nativeElement.value) {
          this.btMarcarSaidaDisabled = false;
        }
      });
    } else {
      this.btMarcarEntradaDisabled = true;
      this.btMarcarSaidaDisabled = true;
    }
  }

  carregarEstadias() {
    this.estadiaService.obterTodas().subscribe(
      (resultado: Estadia[]) => {
        this.estadias = resultado;
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  marcarEntrada() {
    this.estadiaService.salvar(this.inputPlaca.nativeElement.value).subscribe(
      (result: any) => {
        console.log(result);
        this.carregarEstadias();
        this.dataSource = new MatTableDataSource<Estadia>(this.estadias);
        window.location.reload();
      },
      (error: any) => {
        console.log(error);
      }
    )
  }
  
  marcarSaida() {
    // let est = this.estadias.find(element => {
    //   element.veiculo.placa == this.inputPlaca.nativeElement.value;
    // });

    this.estadiaService.editar(this.inputPlaca.nativeElement.value).subscribe(
      (result: any) => {
        console.log(result);
        this.carregarEstadias();
        this.dataSource = new MatTableDataSource<Estadia>(this.estadias);
        window.location.reload();
      },
      (error: any) => {
        console.log(error);
      }
    )
  }

  ngOnInit() {
    this.carregarEstadias();
    this.dataSource = new MatTableDataSource<Estadia>(this.estadias);
  }

  ngAfterViewInit() {
    // this.dataSource.paginator = this.paginator;

    // Tradução do paginator
    // this.paginator._intl.itemsPerPageLabel = "Itens por página:"
    // this.paginator._intl.firstPageLabel = "Primeira página"
    // this.paginator._intl.lastPageLabel = "Última página"
    // this.paginator._intl.nextPageLabel = "Próxima página"
    // this.paginator._intl.previousPageLabel = "Página anterior"
    // this.paginator._intl.getRangeLabel = (page: number, pageSize: number, length: number) => {
    //   if (length === 0 || pageSize === 0) {
    //     return `0 a ${length }`;
    //   }
    //   length = Math.max(length, 0);
    //   const startIndex = page * pageSize;
    //   // If the start index exceeds the list length, do not try and fix the end index to the end.
    //   const endIndex = startIndex < length ? Math.min(startIndex + pageSize, length) : startIndex + pageSize;
    //   return `${startIndex + 1} - ${endIndex} de ${length}`;
    // };
  }
}
