import { Component, OnInit } from '@angular/core';
import { Propuesta } from '../registrar-propuesta/interfaces/propuesta-model';
import { PropuestaService } from '../registrar-propuesta/services/propuesta.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-revisar-propuestas',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './revisar-propuestas.component.html',
  styleUrl: './revisar-propuestas.component.css'
})
export class RevisarPropuestasComponent implements OnInit {

  public propuestas: Propuesta[] = [];

  constructor(
    private propuestaService: PropuestaService
  ) { }

  ngOnInit(): void {
    this.listarPropuestas();
  }

  listarPropuestas(): void {
    this.propuestaService.listarTodas().subscribe({
      next: (data: Propuesta[]) => this.propuestas = data
    });
  }

  rechazar(id: number) {
    this.propuestaService.rechazar(id).subscribe({
      next: () => this.listarPropuestas()
    });
  }

  aceptar(id: number) {
    this.propuestaService.aceptar(id).subscribe({
      next: () => this.listarPropuestas()
    });
  }

}