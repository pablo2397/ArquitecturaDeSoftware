import { Component } from '@angular/core';
import { CommonModule, NgFor } from '@angular/common';
import { FormBuilder, FormGroup, FormsModule, NgForm, ReactiveFormsModule, Validators } from '@angular/forms';
import { tipoVehiculo } from './services/tipo-vehiculo.objetec';
import { TipoVehiculoService } from './services/tipo-vehiculo.service';

@Component({
  selector: 'app-tipo-vehiculo',
  standalone: true,
  imports: [FormsModule, NgFor, ReactiveFormsModule, CommonModule],
  templateUrl: './tipo-vehiculo.component.html',
  styleUrl: './tipo-vehiculo.component.css'
})
export class TipoVehiculoComponent {

  mostrar: boolean = true;
  tipoVehiculos: tipoVehiculo[] = [];
  formulario: FormGroup;
  id: number;

  tipoVehiculo: tipoVehiculo = {
    idTipovehiculo: 0,
    nombre: '',
    descripcion: '',
    estado: false
  };

  constructor(private TipoVehiculoService: TipoVehiculoService, private formBuilder: FormBuilder) {
    this.Consulta();
  }

  ngOnInit(): void {
    this.formulario = this.formBuilder.group({
      nombre: ['', Validators.required],
      descripcion: ['', Validators.required],
      estado: [false, Validators.required]
    })
  }

  Crear(){
    if(this.formulario.valid){
      console.log(this.formulario.value)
    this.TipoVehiculoService.Post(this.formulario.value)
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
    this.TipoVehiculoService.Get()
    .subscribe(res => {
      this.tipoVehiculos = res;
    }, error =>{
    console.log(error)
  });
  }

  Limpiar(){
    this.formulario.reset();
  }

  Eliminar(id: number){
    this.TipoVehiculoService.Delete(id)
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

  Editar(tipoVehiculo: tipoVehiculo){
    this.formulario.get('nombre').setValue(tipoVehiculo.nombre),
    this.formulario.get('descripcion').setValue(tipoVehiculo.descripcion),
    this.formulario.get('estado').setValue(tipoVehiculo.estado)
    this.mostrar = false;
    this.id = tipoVehiculo.idTipovehiculo;
  }

  Cancelar(){
    this.Limpiar();
    this.mostrar = true;
  }

  Modificar(){
      this.tipoVehiculo = this.formulario.value;
      this.tipoVehiculo.idTipovehiculo = this.id;
    this.TipoVehiculoService.Edit(this.tipoVehiculo)
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

