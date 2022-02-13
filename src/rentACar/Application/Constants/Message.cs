namespace Application.Constants
{
    public static class Message
    {
        #region SuccessResult
        public static string SuccessCreate => "Adding successful.";
        public static string SuccessUpdate => "Update successful.";
        public static string SuccessDelete => "Deletion successful.";
        public static string SuccessGet => "Data extraction successful.";
        public static string SuccessStateUpdate => "Car state change successful.";

        #endregion

        #region ErrorResult
        public static string ErrorCreate => "Add failed.";
        public static string ErrorUpdate => "Update failed.";
        public static string ErrorDelete => "Deletion failed.";
        public static string ErrorGet => "Data extraction failed.";
        #endregion

        #region Auth
        public static string PasswordLength => "Password length is not enough.";
        public static string UserNotFound => "User not found";
        public static string PasswordError => "Password error";
        public static string SuccessfulLogin => "Successful login";
        public static string OperationClaimExists => "Operation claim already exists";
        public static string UserRegistered => "User registered successfully";
        public static string NameAlreadyExist => "Name already exists.";
        public static string UserNotExists => "User mail do not exists.";
        public static string UserAlreadyExists => "User mail already exists.";
        public static string PasswordNotMatch => "Password don't match.";
        #endregion

        #region Car
        public static string CarNotExists => "Car not exists.";
        public static string ModelYearCheck => "Model year cannot be greater than today";
        public static string CarPlateCheck => "Plate format is not correct.";
        public static string CarIsRented => "Rental can't be create when car is rented.";
        public static string CarIsntMaintainIsRent => "Car can't be maintain when is rented.";
        public static string CarIsMaintenance => "Car can not be rent when is in maintenance.";
        public static string ModelPriceCheck => "Model daily price can't be less than zero";
        public static string FindeksIsNotExist => "Findeks credit not exists";
        public static string CarDeliveryIsDifferent => "Car delivery point is different";
        public static string PlateNotValid => "Car plate not valid";
        public static string CarHasOpenInvoice => "The car has an open invoice.";
        public static string KmNotValid => "The car KM not valid.";
        #endregion

        #region Others
        public static string ExistingData => "Data already exists.";
        public static string DamageRecordNotFound => "Damage record not found.";
        public static string NotFound => "Not found.";
        #endregion
    }
}
