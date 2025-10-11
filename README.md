# 🍽️ **SignalR Restoran – .NET Core ile QR Kodlu Gerçek Zamanlı Sipariş Yönetimi**

## 🏗️ **Proje Mimarisi – 6 Katmanlı Temiz Mimari**
Uygulama, **SOLID** ve **Clean Code** prensipleri doğrultusunda katmanlı bir yapı üzerine inşa edilmiştir.  
Her katman, yalnızca kendi sorumluluk alanındaki görevleri üstlenmektedir.

---

### 🧠 **Business Katmanı**
- Tüm iş kuralları, validasyonlar ve özel senaryolar burada tanımlanmıştır.  
- Servis arayüzleri ile bağımlılıklar minimuma indirilmiştir.  
- CRUD işlemleri ve özel iş mantıkları burada yürütülür.

### 💾 **Data Access Katmanı**
- Veritabanı işlemleri **Entity Framework Core** ile gerçekleştirilmiştir.  
- **Repository Pattern** yapısı kullanılmıştır.  
- **LINQ** sorguları ile listeleme ve filtreleme işlemleri optimize edilmiştir.

### 📦 **DTO Katmanı**
- Katmanlar arası veri aktarımında kullanılan sadeleştirilmiş veri modelleridir.  
- Performans artışı ve veri güvenliği sağlar.

### 🧱 **Entity Katmanı**
- Sistemdeki ana varlık sınıfları bu katmanda yer alır.  
  Örneğin: `Product`, `Category`, `Order`, `Reservation` vb.

### 🔗 **API Katmanı**
- Tüm veri işlemleri **RESTful API** yapısı üzerinden gerçekleştirilir.  
- **Swagger** ile uç noktalar test edilebilir.  
- API sadece kontrollü erişim sağlar; doğrudan veri tabanı erişimi yoktur.

### 🌐 **Web UI Katmanı**
- Kullanıcı arayüzü **Razor Pages**, **AJAX**, **jQuery** ve **SignalR** ile geliştirilmiştir.  
- Gerçek zamanlı, mobil uyumlu ve kullanıcı dostu bir arayüz sunar.

---

## ⚙️ **Kullanılan Teknolojiler**
- ASP.NET Core Web API  
- Entity Framework Core  
- SignalR  
- Fluent Validation  
- ASP.NET Core Identity (AppUser ile genişletilmiş)  
- MailKit (Gerçek mail gönderimi)  
- QR Code Generator  
- RapidAPI (TastyAPI Entegrasyonu)  
- Swagger  
- LINQ  
- AJAX & JavaScript  

---

## 🔄 **SignalR ile Gerçek Zamanlı Özellikler**

### 🔔 **Rezervasyon Bildirimi**
- Her 5 saniyede bir yeni rezervasyon kontrolü yapılır.  
- Yeni kayıt varsa kullanıcıya anlık bildirim gönderilir.

### 🛎️ **Masa Durumu Takibi**
- Masaların “Boş” veya “Dolu” durumu anlık olarak renk değişimiyle görüntülenir.  
- Masa durumu değiştiğinde tüm istemcilere canlı olarak yansıtılır.

### 💬 **Anlık Mesajlaşma**
- Kullanıcılar arası sohbet, `chat.js` dosyası aracılığıyla canlı şekilde yapılabilir.

### 📊 **Dinamik İstatistikler**
- Kategori başına ürün sayısı  
- En yüksek ve en düşük fiyatlı ürün  
- Ortalama ürün fiyatı  
- Aktif ve toplam sipariş sayısı  
- Son sipariş tutarı  
> Tüm veriler **SignalR** aracılığıyla sayfa yenilemeden güncellenir.

---

## 🌍 **Harita & Navigasyon**
- **Google Maps API** entegrasyonu sayesinde restoran konumu harita üzerinde gösterilir.  
- Kullanıcılar haritadan restoran yol tarifini görüntüleyebilir.

---

## 🔐 **Oturum & Güvenlik Yönetimi**
- **ASP.NET Identity** kullanılarak kullanıcı kimlik doğrulama sistemi kurulmuştur.  
- `AppUser` sınıfı genişletilerek ek kullanıcı bilgileri eklenmiştir (Ad, Soyad vb.).  
- Kimlik doğrulama ve rol bazlı yetkilendirme aktif olarak kullanılmaktadır.  
- Oluşturulan tablolar:  
  - `AspNetUsers`  
  - `AspNetRoles`  
  - `AspNetUserRoles`  
  - `AspNetUserClaims`  
  - `AspNetRoleClaims`  
  - `AspNetUserLogins`  
  - `AspNetUserTokens`

---

## ✉️ **Mail İşlemleri (MailKit)**
- Google API Key üzerinden gerçek mail gönderimi yapılabilmektedir.  
- Rezervasyon ve şifre yenileme gibi durumlarda otomatik mail gönderimi mümkündür.

---

## ⚠️ **Özel Hata Sayfaları**
- 404 gibi geçersiz sayfa isteklerinde kullanıcıyı yönlendiren modern bir hata sayfası tasarlanmıştır.  
- Kullanıcı deneyimi göz önüne alınarak rehberlik sağlayan yönlendirmeler eklenmiştir.

---

## 🛡️ **Yetkilendirme & Erişim Kontrolü**
- Giriş yapmamış kullanıcılar otomatik olarak login ekranına yönlendirilir.  
- Yönetici paneline yalnızca gerekli role sahip kullanıcılar erişebilir.

---

## 📦 **Ek Özellikler**
- 📱 **QR Kod Üretimi:** Masalar ve menüler için özel QR kod oluşturma.  
- 🌐 **RapidAPI Tasty Entegrasyonu:** Dünya mutfağına ait yemek tarifleri ve videolar.  
- 🔄 **Trigger Kullanımı:** Sipariş durumlarına göre özel aksiyonlar.  
- ⚙️ **AJAX İşlemleri:** Ürün işlemleri anlık ve sayfa yenilemeden yapılır.  
- 🧩 **Fluent Validation:** Eksik form alanları için kullanıcı uyarı sistemi.

---

## 👤 **Kullanıcı Arayüzünde Yapılabilenler**
- Menü inceleme, rezervasyon oluşturma  
- Masa seçerek sipariş verme ve ödeme işlemleri  
- Restoran konumuna ve iletişim bilgilerine erişim

---

## 🧭 **Yönetici Paneli Özellikleri**
- **Dashboard:** Anlık masa durumu, aktif sipariş sayısı, toplam sipariş, boş masa sayısı gibi veriler SignalR ile canlı olarak gösterilir.  
- **Bildirimler:** Yeni rezervasyon ve sipariş bildirimleri anlık olarak gelir.  
- **CRUD İşlemleri:** Kategori, Ürün, İndirim, Sosyal Medya, Hakkımda, Mail ve Bildirim modüllerinde tüm işlemler yapılabilir.  
- **İstatistikler:** Fiyat, kategori, sipariş gibi tüm analizler anlık olarak güncellenir.  
- **QR Kod Üretimi:** Masalar için dinamik QR kod oluşturma.  
- **Profil Ayarları:** Yönetici kişisel bilgilerini güncelleyebilir.

---

## 🖼️ **Proje Görüntüleri**

<img width="1919" height="941" alt="UISlider" src="https://github.com/user-attachments/assets/ffc159cc-289e-4cc4-87ba-9550cda5f1ce" />
<img width="1917" height="943" alt="UIDiscount" src="https://github.com/user-attachments/assets/6e56fa9b-6a50-4e5f-897e-a42d5cfb6f12" />
<img width="1919" height="944" alt="UIProducts" src="https://github.com/user-attachments/assets/c64f5e78-ba3e-4126-9e70-3ec023e7386b" />
<img width="1919" height="941" alt="UIAbout" src="https://github.com/user-attachments/assets/dac9002f-eeff-475d-858b-235fe572c937" />
<img width="1919" height="941" alt="UIContact" src="https://github.com/user-attachments/assets/643f2f2f-cd5c-4e48-96ea-94f76008d523" />
<img width="1919" height="945" alt="UITestimonail" src="https://github.com/user-attachments/assets/1706f7ec-7a01-4df8-aac2-65f4be6bc8c0" />
<img width="1917" height="941" alt="UIRecipes " src="https://github.com/user-attachments/assets/7d03b3ad-cc86-4a62-98ff-078d7d204ce2" />
<img width="1919" height="943" alt="UIBasket" src="https://github.com/user-attachments/assets/3c25803e-4211-45aa-a588-0c48cb0e39bc" />
<img width="1902" height="941" alt="adminLiveMessages" src="https://github.com/user-attachments/assets/17ec391c-24ed-4e9a-a0ed-77113403b175" />
<img width="1919" height="931" alt="adminLogin" src="https://github.com/user-attachments/assets/0904993e-a442-419f-96f5-2dab5253372b" />
<img width="1918" height="944" alt="adminAbout" src="https://github.com/user-attachments/assets/2b5b1bc1-a736-4b26-a6ea-4d6b9eb34769" />
<img width="1919" height="945" alt="adminCustomerManage" src="https://github.com/user-attachments/assets/47684eff-a137-4694-9b9b-915e4a058d81" />
<img width="1919" height="944" alt="adminProduct" src="https://github.com/user-attachments/assets/3e026b94-d46a-4fd0-83b9-c6d3900189e0" />
<img width="1918" height="938" alt="adminStatistic" src="https://github.com/user-attachments/assets/cb0a9eef-ebc7-47f2-9752-7d942a52d137" />
<img width="1919" height="945" alt="adminCustomerManage" src="https://github.com/user-attachments/assets/cb3ddcc5-8ec8-41bc-b4b2-03070ca00277" />
<img width="1919" height="942" alt="adminQrCode" src="https://github.com/user-attachments/assets/883b39fd-8cf9-4123-abbf-83e8eed56587" />
<img width="1919" height="882" alt="adminTableStatus" src="https://github.com/user-attachments/assets/b7a6c23b-bb19-49bd-bc68-5a74d918f40a" />
<img width="1918" height="945" alt="adminStats2" src="https://github.com/user-attachments/assets/a2994e6b-df68-4785-a328-97a51c027248" />
<img width="1302" height="553" alt="mail" src="https://github.com/user-attachments/assets/56f33f4a-53b2-4ff9-9d27-83b657c68cd4" />
<img width="1919" height="940" alt="adminTables" src="https://github.com/user-attachments/assets/daf8bbb9-cac9-4669-ac40-73fd114e11ac" />


---
