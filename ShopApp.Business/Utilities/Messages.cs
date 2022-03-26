using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Utilities
{
    public static class Messages
    {
        public static string AddingCompleted = "Ekleme Başarılı";
        public static string UpdatingCompleted = "Güncelleme Başarılı";
        public static string DeletingCompleted = "Silme Başarılı";
        public static string ListingCompleted = "Listeleme Başarılı";
        public static string GettingCompleted = "Görüntüleme Başarılı";

        public static string ThereIsNoDataInTable = "Tabloda Hiç Veri Yok!";

        public static string AddingNotCompleted = "Ekleme Başarısız!";
        public static string UpdatingNotCompleted = "Güncelleme Başarısız!";
        public static string DeletingNotCompleted = "Silme Başarısız!";
        public static string ListingNotCompleted = "Listeleme Başarısız!";
        public static string GettingNotCompleted = "Görüntüleme Başarısız!";

        public static string CreatingTokenCompleted = "Token Oluşturma Başarılı";
        public static string CreatingTokenNotCompleted = "Token Oluşturma Başarısız!";

        public static string LoginError = "E-Posta veya Şifre yanlış";  //Tek bir hata donuyoruz guvenlik amacli

        public static string UserNotFound = "Kullancı Bulunamadı";

        public static string TokenFound = "Token Bulundu";
        public static string TokenNotFound = "Token Bulunamadi";

        public static string LoginSuccess = "Giriş Başarılı";

        public static string TokenDeletingCompleted = "Token Silindi";

        public static string ClientNotFound = "Client Bulunamadi";
        public static string UserNotAdded = "Kullanıcı Oluşturulamadı";
        public static string UserAdded = "Kullanıcı Oluşturuldu";

        public static string UserChecked = "Kullanıcı Doğrulandı";
        public static string UserNotChecked = "Kullanıcı Bulunamadı";

        public static string EmailSent = "E-Posta Gönderildi";
        public static string EmailNotConfirmed = "Email Onaylanmamış";


        public static string InvalidDateOfProduction = "Lütfen geçerli bir tarih giriniz";
        public static string InvalidInputTypes = "Lütfen doğru formlarda veri giriniz";

        public static string UserVerified = "Kulanıcı Doğrulandı";
        public static string UserNotVerified = "Kullanıcı Doğrulanamadı,Lütfen Ad,Soyad,T.C. Kimlik No ve Doğum Tarihi alanlarını doğru giriniz";

        public static string NotUniqueUsername = "Bu Kullanıcı Adı Daha Önce Alınmış,Lütfen Başka Bir Kullanıcı Adı Seçiniz";
        public static string UserConfirmed = "Kullanıcı Onaylandı";
        public static string UserNotConfirmed = "Kullanıcı Onaylanmadı";

        public static string UndoDeletingCompleted = "Silinen Veri Geri Getirildi";
        public static string UndoDeletingNotCompleted = "Silinen Veri Geri Getirilemedi";
    }
}
