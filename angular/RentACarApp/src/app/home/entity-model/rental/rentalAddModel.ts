export interface RentalAddModel {
  carId: number;
  customerId: number;
  startDate: Date;
  endDate: Date;
  rentedCityId: number;
  deliveryCityId: number;
  additionalServiceIdList: number[];
}
