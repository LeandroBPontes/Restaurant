import { Component } from '@angular/core';
import { RestaurantService } from '../../services/restaurant.service';
import { RestaurantTypeEnum } from '../../enums/restaurantTypeEnum.enum';
import { RestaurantJson } from '../../jsonResources/restaurantJson';
import { RestaurantModel } from '../models/restaurant.model';


@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.css']
})

export class RestaurantComponent {

  payload: string = '';
  restaurantOne = RestaurantTypeEnum.RestaurantOne;
  restaurantTwo = RestaurantTypeEnum.RestaurantTwo;
  restaurantThree = RestaurantTypeEnum.RestaurantThree;
  restaurantFour = RestaurantTypeEnum.RestaurantFour;
  restaurantFive = RestaurantTypeEnum.RestaurantFive;

  constructor(private restaurantService: RestaurantService) { }

  sendRecipe() {
    try {
      const object = JSON.parse(this.payload);
      this.restaurantService.create(object)
        .subscribe();
    } catch (error) {

      alert("JSON Inválido" + '\n\n' + "Por favor, entre com um formato válido.");
    }
  }

  chooseAndSend(restaurantType: RestaurantTypeEnum) {
    const json = this.chooseEnum(restaurantType);

    const object = JSON.parse(json);

    var data = RestaurantModel.create(object, restaurantType);

    this.restaurantService.createFormatted(data)
      .subscribe();
  }

  chooseEnum(type: RestaurantTypeEnum): any {
    switch (type) {
      case RestaurantTypeEnum.RestaurantOne:
        return RestaurantJson.restaurantOne;
      case RestaurantTypeEnum.RestaurantTwo:
        return RestaurantJson.restaurantTwo;
      case RestaurantTypeEnum.RestaurantThree:
        return RestaurantJson.restaurantThree;
      case RestaurantTypeEnum.RestaurantFour:
        return RestaurantJson.restaurantFour;
      case RestaurantTypeEnum.RestaurantFive:
        return RestaurantJson.restaurantFive;
      default:
        return RestaurantJson.restaurantOne;
    }
  }
}
