import {RouterModule, Routes } from '@angular/router';
import { RestaurantComponent } from './core/restaurant/restaurant.component';
import { NgModule } from '@angular/core';


const routes: Routes = [
    { 
      path: '',
      redirectTo: '/restaurant', 
      pathMatch: 'full' 
    },
    { 
      path: 'restaurant',
      component: RestaurantComponent 
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule {}

