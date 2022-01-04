import { Component, OnInit } from '@angular/core';
import { Foods } from 'src/app/Models/foods';
import { FoodsService } from 'src/app/Services/foods.service';

@Component({
  selector: 'app-foods',
  templateUrl: './foods.component.html',
  styleUrls: ['./foods.component.css']
})
export class FoodsComponent implements OnInit {

  listFoods: Foods[] = [];

  constructor(private foodservice: FoodsService) { }

  ngOnInit(): void {
    this.getFoods();
  }


  getFoods() {
    this.foodservice.getList().subscribe(data => {
      this.listFoods = data;
      console.log(data);
    }, error => {
      console.log(error);
    })
  }


  deleteFood(id: number) {
    console.log(id);

    this.foodservice.delete(id).subscribe(data => {
      this.getFoods();
    }, error => {
      console.log(error);
    })
  }
}
