import { Component, OnInit } from '@angular/core';
import { Propuesta } from '../registrar-propuesta/interfaces/propuesta-model';
import { PropuestaService } from '../registrar-propuesta/services/propuesta.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-generar-informe',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './generar-informe.component.html',
  styleUrl: './generar-informe.component.css'
})
export class GenerarInformeComponent implements OnInit {

  public propuestas: Propuesta[] = [];
  public estadoSeleccionado: string = '';
  public propuestasFiltradas: Propuesta[] = [];

  constructor(
    private propuestaService: PropuestaService
  ) { }

  ngOnInit(): void {
    this.listarPropuestas();
  }

  listarPropuestas(): void {
    this.propuestaService.listarTodas().subscribe({
      next: (data: Propuesta[]) => {
        this.propuestas = data;
        this.filtrarPropuestas();
      }
    });
  }

  filtrarPropuestas(): void {
    if (!this.estadoSeleccionado) {
      this.propuestasFiltradas = this.propuestas;
    } else {
      this.propuestasFiltradas = this.propuestas.filter(
        propuesta => propuesta.estado === this.estadoSeleccionado
      );
    }
  }

}

