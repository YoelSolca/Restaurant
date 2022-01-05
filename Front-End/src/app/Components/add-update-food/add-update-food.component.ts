import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Foods } from 'src/app/Models/foods';
import { FoodsService } from 'src/app/Services/foods.service';

@Component({
  selector: 'app-add-update-food',
  templateUrl: './add-update-food.component.html',
  styleUrls: ['./add-update-food.component.css']
})
export class AddUpdateFoodComponent implements OnInit {

  agregarComida: FormGroup;
  accion = 'Agregar';
  id = 0;
  food: Foods | undefined;

  constructor(private fb: FormBuilder,
    private _foodService: FoodsService,
    private router: Router,
    private aRoute: ActivatedRoute) {
    this.agregarComida = this.fb.group({
      name: ['', Validators.required],
      price: ['', Validators.required],
      photo: ['', Validators.required],
    })
    this.id = +this.aRoute.snapshot.paramMap.get('id')!;
  }


  ngOnInit(): void {
    this.esEditar();
  }

  esEditar() {
    if (this.id !== 0) {
      this.accion = 'Editar';
      this._foodService.get(this.id).subscribe(data => {
        this.food = data;
        this.agregarComida.patchValue({
          name: data.name,
          price: data.price,
          photo: data.photo,
        })
      }, error => {
        console.log(error);
      })
    }
  }

  agregarEdtiarComida() {

    if (this.food == undefined) {

      // Agregamos un nuevo comentario
      const food: Foods = {
        name: this.agregarComida.get('name')?.value,
        price: this.agregarComida.get('price')?.value,
        photo: this.agregarComida.get('photo')?.value,
      }
      this._foodService.save(food).subscribe(data => {
        this.router.navigate(['/']);
      }, error => {
        console.log(error);
      })
    } else {

      // Editamos comentario
      const comida: Foods = {
        name: this.agregarComida.get('name')?.value,
        price: this.agregarComida.get('price')?.value,
        photo: this.agregarComida.get('photo')?.value,
      }

      this._foodService.Update(this.id, comida).subscribe(data => {
        console.log(comida);
        this.router.navigate(['/']);
      }, error => {
        console.log(error);
      })
    }


  }
}



