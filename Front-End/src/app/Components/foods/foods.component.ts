import { Component, OnInit } from '@angular/core';
import { Foods } from 'src/app/Models/foods';
import { FoodsService } from 'src/app/Services/foods.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-foods',
  templateUrl: './foods.component.html',
  styleUrls: ['./foods.component.css']
})
export class FoodsComponent implements OnInit {

  listFoods: Foods[] = [];

  constructor(private foodservice: FoodsService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getFoods();
  }


  getFoods() {
    this.foodservice.getList().subscribe(data => {
      this.listFoods = data;
      console.log(data);
    }, error => {
      this.toastr.error('Opss Ocurrio un error!', 'Error');
      console.log(error);
    })
  }


  deleteFood(id: number) {
    console.log(id);

    this.foodservice.delete(id).subscribe(data => {
      this.getFoods();
      this.toastr.error('El comentario fue eliminado con exito!', 'Registro eliminado');
    }, error => {
      this.toastr.error('Opss Ocurrio un error!', 'Error');
      console.log(error);
    })
  }
}
