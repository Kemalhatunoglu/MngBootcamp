export class User {
  constructor(
    public email: string,
    public firstName?: string,
    public lastName?: string,
    public id?: number,
    private _token?: string,
    private _tokenExpirationDate?: Date) { }

  get token() {
    if (this._tokenExpirationDate || new Date() > this._tokenExpirationDate) {
      return null;
    }

    return this._token;
  }
}
