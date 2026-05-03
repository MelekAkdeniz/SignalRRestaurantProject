# 🍽️ SignalR & .NET 8 Restaurant QR Order Management System

[![Framework](https://img.shields.io/badge/Framework-.NET%208-blueviolet)](https://dotnet.microsoft.com/)
[![Database](https://img.shields.io/badge/Database-SQL%20Server-red)](https://www.microsoft.com/en-us/sql-server/)
[![RealTime](https://img.shields.io/badge/Real--Time-SignalR-orange)](https://dotnet.microsoft.com/apps/aspnet/signalr)

Bu proje, modern restoranların dijitalleşme sürecine katkı sağlamak amacıyla geliştirilmiş, **gerçek zamanlı (real-time)** veri akışına sahip bir **QR Kod Tabanlı Sipariş Yönetim Sistemi**dir.

---

## 🧐 Proje Hakkında

Sistem, müşterilerin masalarındaki QR kodları okutarak menüye erişmesini, sipariş vermesini ve bu siparişlerin restoran paneline anlık (SignalR ile) düşmesini sağlar. Sadece bir sipariş uygulaması değil, aynı zamanda kapsamlı bir işletme yönetim paneli sunar.

### ✨ Öne Çıkan Özellikler

- **📱 Müşteri Deneyimi:** - QR kod ile anında dijital menü erişimi.
  - Kategori bazlı filtreleme ve dinamik ürün arama.
  - Hızlı sepet yönetimi ve sipariş tamamlama.
- **🖥️ Yönetim Paneli (Admin):**
  - **SignalR** ile anlık masa durumu ve yeni sipariş bildirimleri.
  - Ürün, kategori, öne çıkanlar ve indirimli ürünlerin yönetimi.
  - Rezervasyon ve iletişim mesajları takibi.
- **📊 İstatistikler:** Toplam sipariş, kasa durumu ve aktif masa sayılarını içeren dashboard.
- **📧 Bildirim Sistemi:** MailKit entegrasyonu ile SMTP üzerinden otomatik bilgilendirme e-postaları.

---

## 🛠️ Teknik Yığın (Tech Stack)

Proje, kurumsal standartlara uygun olarak **N-Tier (Katmanlı) Mimari** üzerine inşa edilmiştir.

- **Backend:** .NET 8 Web API & MVC
- **Database:** MS SQL Server & Entity Framework Core
- **Real-Time:** ASP.NET Core SignalR
- **Architecture:** Repository Pattern, Unit of Work
- **Dönüştürücüler:** AutoMapper (DTO yönetimi için)
- **Frontend:** HTML5, CSS3, Bootstrap, JavaScript, JQuery
- **Diğer:** MailKit (SMTP), API Consume işlemleri

---

## 📂 Klasör Yapısı (N-Tier Architecture)

```text
├── SignalR.EntityLayer      # Veritabanı tabloları (Entities)
├── SignalR.DataAccessLayer  # Context, Migrations ve Repositories
├── SignalR.BusinessLayer    # İş kuralları ve Servisler
├── SignalR.DtoLayer         # Veri Transfer Nesneleri
├── SignalR.WebUI            # Kullanıcı arayüzü ve SignalR Client
```

---

## 📧 Mail Sistemi

Bu projede SMTP üzerinden e-posta gönderim özelliği bulunmaktadır.

⚠️ Güvenlik nedeniyle:
- Email bilgileri repository içerisinde yer almamaktadır  
- Kullanıcıların kendi `appsettings.json` dosyasını oluşturması gerekir

---

## ⚙️ Kurulum ve Yapılandırma

Projeyi yerel ortamınızda ayağa kaldırmak için aşağıdaki adımları sırasıyla uygulayınız:

### 1. Projeyi Klonlayın
Öncelikle projeyi bilgisayarınıza indirin:
```bash
git clone [https://github.com/MelekAkdeniz/SignalRRestaurantProject.git](https://github.com/MelekAkdeniz/SignalRRestaurantProject.git)
```
### 2. Veritabanı Bağlantısı (ConnectionString)
SignalR.WebUI projesi içerisindeki `appsettings.json` dosyasını açın. DefaultConnection alanını kendi yerel SQL Server bilgilerinize göre güncelleyin:
```JSON
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=SignalRRestaurantDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```
### 3. E-posta Yapılandırması (SMTP)
Proje içindeki iletişim ve bildirim formlarının çalışabilmesi için `appsettings.json` dosyasındaki mail ayarlarını kendi bilgilerinizle doldurun:
```JSON
"EmailSettings": {
  "Email": "your-email@gmail.com",
  "Password": "your-app-password"
}
```
### 4. Migration ve Veritabanı Oluşturma
Veritabanı tablolarını ve şemasını oluşturmak için Visual Studio'da Package Manager Console ekranını açın ve şu komutu çalıştırın:
Not: Default Project olarak SignalR.DataAccessLayer katmanının seçili olduğundan emin olun.
```PowerShell
Update-Database
```
---

## 🎯 Projenin Amacı ve Kazanımlar

-SignalR kullanarak gerçek zamanlı uygulamalar geliştirme deneyimi.
-Katmanlı Mimari prensiplerini gerçek bir projede uygulama.
-API Consume yöntemleri ile modern web geliştirme süreçlerini öğrenme.
-Asenkron programlama (async/await) ve DTO kullanımını pekiştirme.

---

## 🔐 Güvenlik Notu
-Hassas bilgiler (email, şifre, API key) repoya dahil edilmemiştir.
-Kullanıcıların kendi ortamına göre yapılandırması gerekmektedir.

---

⭐ Not
Bu proje eğitim ve portfolyo amacıyla geliştirilmiştir.


