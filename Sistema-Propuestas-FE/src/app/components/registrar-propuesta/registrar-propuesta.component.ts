import { Component, OnInit, signal } from '@angular/core';
import { Propuesta } from './interfaces/propuesta-model';
import { PropuestaService } from './services/propuesta.service';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-registrar-propuesta',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CommonModule
  ],
  templateUrl: './registrar-propuesta.component.html',
  styleUrl: './registrar-propuesta.component.css'
})
export class RegistrarPropuestaComponent implements OnInit {

  public form!: FormGroup;
  public propuestas: Propuesta[] = [];

  public id: number = 0;

  constructor(
    private _fb: FormBuilder,
    private propuestaService: PropuestaService
  ) { }

  ngOnInit(): void {
    this.initializeForm();
    this.listarPropuestas();
  }

  onSubmit() {
    this.id == 0 ? this.createPropuesta() : this.editarPropuesta()
  }

  createPropuesta(): void {
    const body: Propuesta = this.getData()
    this.propuestaService.registrar(body).subscribe({
      next: () => {
        this.listarPropuestas()
        this.form.reset()
      },
    });
  }

  editarPropuesta(): void {
    const body: Propuesta = this.getData()
    if (this.id == 0) return
    body.id = this.id
    this.propuestaService.editar(body).subscribe({
      next: () => {
        this.listarPropuestas()
        this.onCancel()
      },
    });
  }

  listarPropuestas(): void {
    this.propuestaService.listarTodas().subscribe({
      next: (data: Propuesta[]) => this.propuestas = data,
    });
  }

  eliminar(id: number) {
    this.propuestaService.eliminar(id).subscribe({
      next: () => this.listarPropuestas(),
    });
  }

  setData(data: Propuesta) {
    this.id = data.id!
    const formatDate = new Date(data.fechaRegistro!);
    this.form.patchValue({
      nombrePropuesta: data.nombrePropuesta,
      nombreEstudiante: data.nombreEstudiante,
      cedulaEstudiante: data.cedulaEstudiante,
      fechaRegistro: formatDate.toISOString().split('T')[0],
    })
  }

  onCancel() {
    this.id = 0;
    this.form.reset()
  }

  private getData(): Propuesta {
    return {
      nombrePropuesta: this.nombrePropuesta.value,
      nombreEstudiante: this.nombreEstudiante.value,
      cedulaEstudiante: this.cedulaEstudiante.value,
      fechaRegistro: this.fechaRegistro.value
    }
  }

  private initializeForm() {
    this.form = this._fb.group({
      nombrePropuesta: ['', [Validators.required, Validators.maxLength(500)]],
      nombreEstudiante: ['', [Validators.required, Validators.maxLength(255)]],
      cedulaEstudiante: ['', [Validators.required, Validators.maxLength(10)]],
      fechaRegistro: ['', Validators.required],
    })
  }

  get nombrePropuesta() { return this.form.get('nombrePropuesta')!; }
  get nombreEstudiante() { return this.form.get('nombreEstudiante')!; }
  get cedulaEstudiante() { return this.form.get('cedulaEstudiante')!; }
  get fechaRegistro() { return this.form.get('fechaRegistro')!; }

}
