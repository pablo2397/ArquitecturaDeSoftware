import { Component } from '@angular/core';
import { CommonModule, NgFor } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { VehiculoService } from './services/vehiculo.service';
import { Vehiculo } from './services/vehiculo.object';

@Component({
  selector: 'app-vehiculo',
  standalone: true,
  imports: [NgFor,CommonModule, ReactiveFormsModule],
  templateUrl: './vehiculo.component.html',
  styleUrl: './vehiculo.component.css'
})
export class VehiculoComponent {

  mostrar: boolean = true;
  vehiculos: Vehiculo[] = [];
  formulario: FormGroup;
  id: number;

  vehiculo: Vehiculo = {
      idVehiculo: 0,
      tipoVehiculo: '',
      color: '',
      kilometraje: '',
      placa: '',
      marca: '',
      estado: false,
      referencia: ''
    };

  constructor(private vehiculoService: VehiculoService, private formBuilder: FormBuilder) {
    this.Consulta();

  }
  ngOnInit(): void {
    this.formulario = this.formBuilder.group({
      tipoVehiculo: ['', Validators.required],
      color: ['', Validators.required],
      kilometraje: ['', Validators.required],
      placa: ['', Validators.required],
      marca: ['', Validators.required],
      estado: [false, Validators.required]
    })
  }

  Crear(){
    if(this.formulario.valid){
      console.log(this.formulario.value)
    this.vehiculoService.Post(this.formulario.value)
    .subscribe(res => {
      //2xx
      if(res == 1){
        this.Consulta();
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

  Consulta() {
    this.vehiculoService.Get()
      .subscribe(res => {
        this.vehiculos = res;
      }, error=>{
        console.log(error)
      });
  }

  Limpiar(){
      this.formulario.reset();
    }
  
    Eliminar(id: number){
      this.vehiculoService.Delete(id)
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
  
    Editar(vehiculo: Vehiculo){
      this.formulario.get('tipoVehiculo').setValue(vehiculo.tipoVehiculo),
      this.formulario.get('color').setValue(vehiculo.color),
      this.formulario.get('kilometraje').setValue(vehiculo.kilometraje),
      this.formulario.get('placa').setValue(vehiculo.placa),
      this.formulario.get('marca').setValue(vehiculo.marca),
      this.formulario.get('estado').setValue(vehiculo.estado)
      this.mostrar = false;
      this.id = vehiculo.idVehiculo;
    }
  
    Cancelar(){
      this.Limpiar();
      this.mostrar = true;
    }
  
    Modificar(){
        this.vehiculo = this.formulario.value;
        this.vehiculo.idVehiculo = this.id;
      this.vehiculoService.Edit(this.vehiculo)
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
