import { Component } from '@angular/core';
import { CommonModule, NgFor } from '@angular/common';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { asesor } from './services/asesor.objetec';
import { AsesorService } from './services/asesor.service';
import { departamento } from './services/departamento.objetec';
import { ciudad } from './services/ciudad.objetec';

@Component({
  selector: 'app-asesor',
  standalone: true,
  imports: [FormsModule, NgFor, ReactiveFormsModule, CommonModule],
  templateUrl: './asesor.component.html',
  styleUrl: './asesor.component.css'
})
export class AsesorComponent {
  
  mostrar: boolean = true;
  asesores: asesor[] = [];
  departamentos: departamento[] = [];
  ciudades: ciudad[] = [];
  filtroCiudades: ciudad[] = [];
  formulario: FormGroup;
  id: number;
  departamentoSeleccionado: string;
  idDepartamento: number;
  ciudadSeleccionado: string;
  idCiudad: number;

  departamento: departamento = {
    idDepartamento: 0,
    nombre: '',
    estado: false
  }

  ciudad: ciudad = {
    idCiudad: 0,
    nombre: '',
    estado: false,
    idDepartamento: 0
  }

  asesor: asesor = {
    idAsesor: 0,
    nombre: '',
    identificacion: '',
    estado: false,
    idDepartamento: 0,
    idCiudad: 0,
    nombreDepartamento: '',
    nombreCiudad: ''
  }

  constructor(private AsesorService: AsesorService, private formBuilder: FormBuilder) {
    this.Consulta();
    this.ConsultaDepartamento();
    this.ConsultaCiudad();
  }
  
  CapturarDepartamento(e) {
    this.departamentoSeleccionado = e.target.value;
    this.departamento = this.departamentos.find(x => x.nombre == this.departamentoSeleccionado);
    this.idDepartamento = this.departamento.idDepartamento;
    this.Ciudades();
}

  Ciudades(){
    this.filtroCiudades = this.ciudades.filter(x => x.idDepartamento == this.idDepartamento);
  }

  CapturarCiudad(e) {
    this.ciudadSeleccionado = e.target.value;
    this.ciudad = this.ciudades.find(x => x.nombre == this.ciudadSeleccionado);
    this.idCiudad = this.ciudad.idCiudad;
  }

  ngOnInit(): void {
    this.formulario = this.formBuilder.group({
      nombre: ['', Validators.required],
      identificacion: ['', Validators.required],
      estado: [false, Validators.required]
    })
  }

  Crear(){
    if(this.formulario.valid){
      console.log(this.formulario.value);
      this.asesor = this.formulario.value;
      this.asesor.idDepartamento = this.idDepartamento;
      this.asesor.idCiudad = this.idCiudad;
      console.log(this.asesor);
    this.AsesorService.Post(this.formulario.value)
    .subscribe(res => {
      //2xx
      if(res == 1){
        this.Consulta();
        this.Limpiar();
      }else{
        alert('No se pudo guardar')
      }
    }, 
    //!=2xx
    error=>{
      console.log(error)
    });
    }
  }

  Consulta(){
    this.AsesorService.Get()
    .subscribe(res => {
      this.asesores = res;
    }, error =>{
    console.log(error)
  });
  }

  ConsultaDepartamento(){
    this.AsesorService.GetDepartamento()
    .subscribe(res => {
      this.departamentos = res;
    }, error =>{
      console.log(error)
    });
  }

  ConsultaCiudad(){
    this.AsesorService.GetCiudad()
    .subscribe(res => {
      this.ciudades = res;
    }, error =>{
      console.log(error)
    });
  }

Limpiar() {
  if (this.formulario) {
    this.formulario.reset();
  }
}

  Eliminar(id: number){
    this.AsesorService.Delete(id)
    .subscribe(res => {
      if(res == 1){
        this.Consulta();
      }else{
        alert('No se pudo eliminar')
      }
    },
    error=>{
      console.log(error)
    });
  }
  
  Editar(asesor: asesor){
    this.formulario.get('nombre').setValue(asesor.nombre),
    this.formulario.get('identificacion').setValue(asesor.identificacion),
    this.formulario.get('estado').setValue(asesor.estado)
    console.log(asesor.nombreCiudad, asesor.nombreDepartamento);
    this.mostrar = false;
    this.id = asesor.idAsesor;
  }

  Cancelar(){
    this.Limpiar();
    this.mostrar = true;
  }
  
  Modificar(){
    this.asesor = this.formulario.value;
    this.asesor.idAsesor = this.id;
    this.asesor.idDepartamento = this.idDepartamento;
      this.asesor.idCiudad = this.idCiudad;
  this.AsesorService.Edit(this.asesor)
  .subscribe(res => {
    if(res == 1){
      this.Consulta();
      this.Limpiar();
    }else{
      alert('No se pudo guardar')
    }
  },
  error=>{
    console.log(error)
  });
}
}
