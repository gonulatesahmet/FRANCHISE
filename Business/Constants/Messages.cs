using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        #region Appellation
        public static string AppellationAdded = "Unvan Basariyla Eklendi.";
        public static string AppellationDeleted = "Unvan Basariyla Silindi.";
        public static string AppellationUpdated = "Unvan Bilgileri Başarıyla Güncellendi.";
        public static string AppellationChangeState = "Unvan Durumu Başarıyla Değiştirildi.";
        public static string AppellationGetById = "Unvan Başarıyla Getirildi.";
        public static string AppellationGetAll = "Unvan Başarıyla Listelendi.";

        #endregion
        #region Branch
        public static string BranchAdd = "Şube Başarıyla Eklendi.";
        public static string BranchDeleted = "Şube Başarıyla Silindi.";
        public static string BranchUpdated = "Şube Bilgileri Başarıyla Güncellendi.";
        public static string BranchChangeState = "Şube Durumu Baraşıyla Değiştirildi.";
        public static string BranchGetById = "Şube Başarıyla Getirildi.";
        public static string BranchGetAll = "Şubeler Başarıyla Listelendi.";
        #endregion
        #region Auth
        public static string AuthAdded = "Yetki Başarıyla Eklendi";
        public static string AuthDeleted = "Yetki Başarıyla Silindi.";
        public static string AuthUpdated = "Yetki Başarıyla Güncellendi.";
        public static string AuthChangeState = "Yetki Durumu Başarıyla Değiştirildi.";
        public static string AuthGetById = "Yetki Başarıyla Getirildi.";
        public static string AuthGetAll = "Yetki Başarıyla Listelendi.";
        #endregion
        #region Category
        public static string CategoryAdded = "Kategori Başarıyla Eklendi.";
        public static string CategoryDeleted = "Kategori Başarıyla Silindi";
        public static string CategoryUpdated = "Kategori Bilgileri Başarıyla Güncellendi.";
        public static string CategoryChangeState = "Kategori Durumu Başarıyla Değiştirildi.";
        public static string CategoryGetById = "Kategori Başarıyla Getirildi.";
        public static string CategoryGetAll = "Kategoriler Başarıyla Listelendi.";
        #endregion
        #region Discount
        public static string DiscountAdded = "İndirim Başarıyla Eklendi.";
        public static string DiscountDeleted = "İndirim Başarıyla Silindi.";
        public static string DiscountUpdated = "İndirim Bilgileri Başarıyla Güncellendi";
        public static string DiscountChangeState = "İndirim Durumu Başarıyla Değiştirildi.";
        public static string DiscountGetById = "İndirim Başarıyla Getirildi.";
        public static string DiscountGetAll = "İndirim Başarıyla Listelendi.";
        #endregion
        #region TypeOfPayment
        public static string TypeOfPaymentAdded = "Ödeme Tür Başarıyla Eklendi.";
        public static string TypeOfPaymentDeleted = "Ödeme Tür Başarıyla Silindi.";
        public static string TypeOfPaymentUpdated = "Ödeme Tür Bilgileri Başarıyla Güncellendi.";
        public static string TypeOfPaymentChangeState = "Ödeme Tür Durumu Başarıyla Değiştirildi.";
        public static string TypeOfPaymentGetById = "Ödeme Tür Başarıyla Getirildi.";
        public static string TypeOfPaymentGetAll = "Ödeme Tür Başarıyla Listelendi.";
        #endregion
        #region Device
        public static string DeviceAdded = "Cihaz Başarıyla Eklendi.";
        public static string DeviceDeleted = "Cihaz Başarıyla Silindi.";
        public static string DeviceUpdated = "Cihaz Bilgileri Başarıyla Güncellendi.";
        public static string DeviceChangeState = "Cihaz Durumu Başarıyla Değiştirildi.";
        public static string DeviceGetById = "Cihaz Başarıyla Getirildi.";
        public static string DeviceGetAll = "Cihazlar Başarıyla Listelendi.";
        #endregion
        #region TypeOfDevice
        public static string TypeOfDeviceAdded = "Cihaz Tür Başarıyla Eklendi.";
        public static string TypeOfDeviceDeleted = "Cihaz Tür Başarıyla Silindi.";
        public static string TypeOfDeviceUpdated = "Cihaz Tür Bilgileri Başarıyla Güncellendi.";
        public static string TypeOfDeviceChangeState = "Cihaz Tür Durumu Başarıyla Değiştirildi.";
        public static string TypeOfDeviceGetById = "Cihaz Tür Başarıyla Getirildi.";
        public static string TypeOfDeviceGetAll = "Cihaz Tür Başarıyla Listelendi.";
        #endregion
        #region Product
        public static string ProductAdded = "Ürün Başarıyla Eklendi.";
        public static string ProductDeleted = "Ürün Başarıyla Silindi.";
        public static string ProductUpdated = "Ürün Bilgileri Başarıyla Güncellendi.";
        public static string ProductChangeState = "Ürün Durumu Başarıyla Değiştirildi.";
        public static string ProductGetById = "Ürün Başarıyla Getirildi.";
        public static string ProductGetAll = "Ürünler Başarıyla Listelendi.";
        #endregion
        #region Employee
        public static string EmployeeAdded = "Personel Başarıyla Eklendi.";
        public static string EmployeeDeleted = "Personel Başarıyla Silindi.";
        public static string EmployeeUpdated = "Personel Bilgileri Başarıyla Güncellendi.";
        public static string EmployeeChangeState = "Personel Durumu Başarıyla Değiştirildi.";
        public static string EmployeeGetById = "Personel Başarıyla Getirildi.";
        public static string EmployeeGetAll = "Personel Başarıyla Listelendi.";
        public static string EmployeeCodeNotVerified = "Personel Kodu Doğrulanmadı.";
        public static string EmployeeNotMatchBranch = "Personel Şube İle Eşleşmiyor.";
        public static string EmployeeStateFalse = "Personel Durumu Aktif Değil.";
        #endregion
        #region Area
        public static string AreaAdded = "Saha Başarıyla Eklendi.";
        public static string AreaDeleted = "Saha Başarıyla Silindi.";
        public static string AreaUpdated = "Saha Bilgileri Başarıyla Güncellendi.";
        public static string AreaChangeState = "Saha Durumu Başarıyla Değişti.";
        public static string AreaGetById = "Saha Başarıyla Getirildi.";
        public static string AreaGetAll = "Saha Baraşıyla Listelendi.";
        public static string AreaGetBranch = "Saha Şubeye Göre Listelendi.";
        #endregion
        #region Table
        public static string TableAdded = "Masa Başarıyla Eklendi.";
        public static string TableDeleted = "Masa Başarıyla Silindi.";
        public static string TableUpdated = "Masa Bilgileri Başarıyla Güncelleni.";
        public static string TableChangeState = "Masa Durumu Başarıyla Değişti.";
        public static string TableGetById = "Masa Başarıyla Getirildi.";
        public static string TableGetAll = "Masa Başarıyla Listelendi.";
        public static string TableGetArea = "Masa Sahaya Göre Listelendi.";
        #endregion
        #region BranchProduct
        public static string BranchProductAdded = "Şube Ürün Başarıyla Eklendi.";
        public static string BranchProductDeleted = "Şube Ürün Başarıyla Silindi.";
        public static string BranchProductUpdated = "Şube Ürün Bilgileri Başarıyla Güncellendi.";
        public static string BranchProductChangeState = "Şube Ürün Durumu Başarıyla Değiştirildi.";
        public static string BranchProductGetById = "Şube Ürün Başarıyla Getirildi.";
        public static string BranchProductGetAll = "Şube Ürün Başarıyla Listelendi.";
        public static string BranchProductGetAvailable = "Şube Ürün Mevcut Olanlar Listelendi.";
        public static string BranchProductGetNotAvailable = "Şube Ürün Mevcut Olmayanlar Listelendi.";
        #endregion
        #region BranchDiscountContent
        public static string BranchDiscountContentAdded = "Şube İndirim İçerik Başarıyla Eklendi.";
        public static string BranchDiscountContentDeleted = "Şube İndirim İçerik Başarıyla Silindi.";
        public static string BranchDiscountContentUpdated = "Şube İndirim İçerik Bilgileri Başarıyla Güncellendi.";
        public static string BranchDiscountContentChangeState = "Şube İndirim İçerik Durumu Başarıyla Değiştirildi.";
        public static string BranchDiscountContentGetById = "Şube İndirim İçerik Başarıyla Getirildi.";
        public static string BranchDiscountContentGetAll = "Şube İndirim İçerik Başarıyla Listelendi.";
        #endregion
        #region TypeOfProduct
        public static string TypeOfProductAdded = "Ürün Tür Başarıyla Eklendi.";
        public static string TypeOfProductDeleted = "Ürün Tür Başarıyla Silindi.";
        public static string TypeOfProductUpdated = "Ürün Tür Bilgileri Başarıyla Güncellendi.";
        public static string TypeOfProductChangeState = "Ürün Tür Durumu Başarıyla Değiştirildi.";
        public static string TypeOfProductGetById = "Ürün Tür Başarıyla Getirildi.";
        public static string TypeOfProductGetAll = "Ürün Tür Başarıyla Listelendi.";
        #endregion
        #region Order
        public static string OrderAdd = "Sipariş Başarıyla Eklenmiştir.";

        #endregion
        #region Payment
        public static string PaymentAdded = "Ödeme Başarıyla Eklendi.";
        public static string PaymentDeleted = "Ödeme Başarıyla Silindi.";
        public static string PaymentUpdated = "Ödeme Bilgileri Başarıyla Güncellendi.";
        public static string PaymentChangeState = "Ödeme Durumu Başarıyla Değiştirildi.";
        public static string PaymentGetAll = "Ödemeler Başarıyla Listelendi.";
        public static string PaymentGetById = "Ödeme Başarıyla Getirildi.";
        #endregion

        #region Session
        public static string SessionEnd = "Oturum Başarıyla Sonlandırıldı.";
        #endregion






        public static string AddedFailed = "Ekleme Yapılırken Bir Hata Oluştu.";
        public static string DeletedFailed = "Silme İşlemi Yapılırken Bir Hata Oluştu.";
        public static string UpdatedFailed = "Güncelleme İşlemi Yapılırken Bir Hata Oluştu.";
        public static string ChangeStatedFailed = "Durum Değiştirilirken Bir Hata Oluştu.";
        

        public static string DeviceVerified = "Cihaz Bilgileri Doğrulandı.";
        public static string DeviceCouldNotBeVerified = "Cihaz Bilgileri Doğrulanamadı.";







        #region ErrorResultMessage
        public static string NameCannotBeEmpty = "İsim Boş Bırakılamaz.";
        public static string CodeCannotBeEmpty = "Kod Boş Bırakılamaz.";
        public static string DescriptionCannotBeEmpty = "Açıklama Boş Bırakılamaz.";
        public static string AuthorizedPersonCannotBeEmpty = "Yetkili Kişi Boş Bırakılamaz.";
        public static string RegionCannotBeEmpty = "Bölge Boş Bırakılamaz.";
        public static string CityCannotBeEmpty = "Şehir Boş Bırakılamaz.";
        public static string DistrictCannotBeEmpty = "İlçe Boş Bırakılamaz.";
        public static string AddressCannotBeEmpty = "Adres Boş Bırakılamaz.";
        public static string PhoneCannotBeEmpty = "Telefon Boş Bırakılamaz.";
        public static string MailCannotBeEmpty = "Mail Boş Bırakılamaz.";
        public static string SurnameCannotBeEmpty = "Soyad Boş Bırakılamaz.";
        public static string IdNumberCannotBeEmpty = "Kimlik Numarası Boş Bırakılamaz.";
        public static string BirthDateNotVerified = "Doğum Tarihi Geçerli Değil.";
        public static string BranchCannotBeEmpty = "Şube Boş Bırakılamaz.";
        public static string AppellationCannotBeEmpty = "Unvan Boş Bırakılamaz.";
        public static string AmountCannotBeEmpty = "Miktar Boş Bırakılamaz.";
        public static string TypeOfDiscountCannotBeEmpty = "İndirim Tür Boş Bırakılamaz.";
        public static string DiscountCannotBeEmpty = "İndirim Boş Bırakılamaz.";
        public static string ProductCannotBeEmpty = "Ürün Boş Bırakılamaz.";

        public static string IdNotFound = "Id Değeri Alınamadı.";
        
        #endregion
    }
}
