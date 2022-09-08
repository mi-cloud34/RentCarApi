using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Constants
{
    public class Message
    {
        public static string CarAddedd = "Ürün Eklendi";
        public static string CartNameInvalid = "Ürün Adı Geçersiz";
        public static string MaintanceTime = "Sistem bakımda ";
        public static string CarList = "Ürünler listelendi";

        public static string UpdatedCar ="Araba güncellendi";
        public static string DeletedCar = "Araba silindi";

        public static string CardGetByIdCustomer { get; internal set; }
        public static string CarImageDeleted { get; internal set; }
        public static string CarImageUpdated { get; internal set; }
        public static string CarImageLimitExceded { get; internal set; }
        public static string CarImageAdded { get; internal set; }
        public static string   AuthorizationDenied ="oturum izni yok";
        internal static string UserRegistered;
        internal static User UserNotFound;
        internal static User PasswordError;
        internal static string SuccessfulLogin;
        internal static string UserAlreadyExists;
        internal static string AccessTokenCreated;
        internal static string UserAdded;
        internal static string UserDeleted;
        internal static string UserUpdated;
    }
}
