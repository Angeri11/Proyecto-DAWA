import { Component, OnInit } from '@angular/core';
import { Revisor } from './interfaces/revisor-model';
import { RevisorService } from './services/revisor.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-asignar-revisores',
  standalone: true,
  imports: [
    ReactiveFormsModule,
  ],
  templateUrl: './asignar-revisores.component.html',
  styleUrl: './asignar-revisores.component.css'
})
export class AsignarRevisoresComponent implements OnInit {

  public form!: FormGroup;
  public revisores: Revisor[] = [];
  public id: number = 0;

  constructor(
    private _fb: FormBuilder,
    private revisorService: RevisorService
  ) { }

  ngOnInit(): void {
    this.initializeForm();
    this.listarRevisores();
  }

  onSubmit() {
    this.id == 0 ? this.createRevisor() : this.editarRevisor();
  }

  createRevisor(): void {
    const body: Revisor = this.getData();
    this.revisorService.registrar(body).subscribe({
      next: () => {
        this.listarRevisores();
        this.form.reset();
      },
    });
  }

  editarRevisor(): void {
    const body: Revisor = this.getData();
    if (this.id == 0) return;
    body.id = this.id;
    this.revisorService.editar(body).subscribe({
      next: () => {
        this.listarRevisores();
        this.onCancel();
      },
    });
  }

  listarRevisores(): void {
    this.revisorService.listarTodos().subscribe({
      next: (data: Revisor[]) => this.revisores = data,
    });
  }

  eliminar(id: number) {
    this.revisorService.eliminar(id).subscribe({
      next: () => this.listarRevisores(),
    });
  }

  setData(data: Revisor) {
    this.id = data.id!;
    this.form.patchValue({
      nombres: data.nombres,
      apellidos: data.apellidos,
      cedula: data.cedula,
      correo: data.correo
    });
  }

  onCancel() {
    this.id = 0;
    this.form.reset();
  }

  private getData(): Revisor {
    return {
      nombres: this.nombres.value,
      apellidos: this.apellidos.value,
      cedula: this.cedula.value,
      correo: this.correo.value
    };
  }

  private initializeForm() {
    this.form = this._fb.group({
      nombres: ['', [Validators.required, Validators.maxLength(255)]],
      apellidos: ['', [Validators.required, Validators.maxLength(255)]],
      cedula: ['', [Validators.required, Validators.pattern(/^\d{10}$/)]],
      correo: ['', [Validators.required, Validators.email, Validators.maxLength(100)]]
    });
  }

  get nombres() { return this.form.get('nombres')!; }
  get apellidos() { return this.form.get('apellidos')!; }
  get cedula() { return this.form.get('cedula')!; }
  get correo() { return this.form.get('correo')!; }

}