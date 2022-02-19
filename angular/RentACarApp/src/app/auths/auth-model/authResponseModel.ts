export interface AuthResponseModel {
  token: string;
  expiration: Date;
  claims: string[];
}
