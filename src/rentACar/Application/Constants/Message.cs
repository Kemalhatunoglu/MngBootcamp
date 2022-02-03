using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Constants
{
    public static class Message
    {
        public static string SuccessCreate => "Adding successful.";
        public static string SuccessUpdate => "Update successful.";
        public static string SuccessDelete => "Deletion successful.";
        public static string SuccessGet => "Data extraction successful.";

        public static string ErrorCreate => "Add failed.";
        public static string ErrorUpdate => "Update failed.";
        public static string ErrorDelete => "Deletion failed.";
        public static string ErrorGet => "Data extraction failed.";

        public static string ExistingData => "Data already exists.";

        public static string ModelYearCheck => "Model year cannot be greater than today";
        public static string CarPlateCheck => "Plate format is not correct.";
        public static string CarIsRented => "Rental can't be create when car is rented.";
        public static string CarIsntMaintainIsRent => "Car can't be maintain when is rented.";
        public static string CarIsMaintenance => "Car can not be rent when is in maintenance.";

        public static string ModelPriceCheck => "Model daily price can't be less than zero";


    }
}
