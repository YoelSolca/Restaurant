
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddUpdateFoodComponent } from './Components/add-update-food/add-update-food.component';
import { FoodsComponent } from './Components/foods/foods.component';

export const routes: Routes = [
  { path: '', component: FoodsComponent },
  { path: 'list-foods', component: FoodsComponent },
  { path: 'add-food', component: AddUpdateFoodComponent },
  { path: 'update-food/:id', component: AddUpdateFoodComponent },
  { path: '**', redirectTo: '/', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }