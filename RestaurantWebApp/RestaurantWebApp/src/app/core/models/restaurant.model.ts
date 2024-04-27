import { RestaurantTypeEnum } from "../../enums/restaurantTypeEnum.enum";

export class RestaurantModel {
  constructor(
    public payload: any,
    public restaurantType: RestaurantTypeEnum
  ) {

  }

  public static create(payload: any, restaurantType: RestaurantTypeEnum): RestaurantModel {
    return new RestaurantModel(payload, restaurantType);
  }
}