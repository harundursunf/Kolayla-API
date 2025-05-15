
# 🧠 Kolayla API – Ders Takip Uygulaması Arka Uç

**KolaylaApi**, [Kolayla](https://github.com/harundursunf/StudyFlow) adlı ders takip ve planlama uygulamasının arka uç servisidir. Bu API, kullanıcı kimlik doğrulaması, ders planı işlemleri ve ilerleme durumu gibi verileri yönetmek için geliştirilmiştir. **ASP.NET Core 9** mimarisi üzerine kurulmuş, güvenli kimlik doğrulama için **JWT (JSON Web Token)** sistemi entegre edilmiştir.

---

## 🚀 Başlangıç

### Gereksinimler

* .NET 9 SDK
* Visual Studio 2022 veya Visual Studio Code
* SQL Server (veya SQLite gibi bir alternatif)

### Kurulum

Projeyi klonlayın:

```bash
git clone https://github.com/harundursunf/StudyFlowApi.git
cd StudyFlowApi
```

Veritabanını yapılandırın (appsettings.json içinde bağlantı dizesini güncelleyin):

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=StudyFlowDb;Trusted_Connection=True;"
}
```

Veritabanını oluşturun ve migrasyonları uygulayın:

```bash
dotnet ef database update
```

Projeyi başlatın:

```bash
dotnet run
```

API varsayılan olarak şu adreste çalışır: [https://localhost:5001](https://localhost:5001)

---

## 🔐 Kimlik Doğrulama

Uygulama, JWT tabanlı kullanıcı doğrulaması kullanmaktadır. Giriş yaptıktan sonra verilen token ile tüm korumalı endpoint'lere erişebilirsiniz.

---

## 🧩 Özellikler

* 👤 Kullanıcı kaydı ve oturum açma (JWT ile)
* 🗂️ Ders planı CRUD işlemleri
* ✅ İlerleme durumu güncelleme
* 🔐 Kimliği doğrulanmış kullanıcıya özel veri
* 🔄 Frontend ile sorunsuz iletişim için CORS yapılandırması

---

## 📁 Proje Yapısı

```
StudyFlowApi/
├── Controllers/           # API uç noktaları
├── Data/                  # Veritabanı bağlamı ve başlatıcı
├── DTOs/                  # Veri transfer nesneleri
├── Models/                # Entity modelleri
├── Services/              # İş katmanı (token, kullanıcı, ders planı)
├── Program.cs             # Uygulama giriş noktası
├── appsettings.json       # Yapılandırma dosyası
└── StudyFlowApi.csproj
```

---

## 🔗 Frontend Entegrasyonu

Bu API, [Kolayla (Frontend)](https://github.com/harundursunf/StudyFlow) uygulaması ile entegre çalışmak üzere tasarlanmıştır. API istekleri için frontend tarafında token ile birlikte `Authorization: Bearer <token>` başlığı kullanılmalıdır.

---

## 📌 Notlar

* Swagger UI entegrasyonu ile tüm endpoint'ler test edilebilir (`https://localhost:5001/swagger`)
* Veritabanı olarak varsayılan olarak SQL Server kullanılır. Dilersen başka sağlayıcılarla değiştirebilirsin.
* Katmanlı mimari uygulanmıştır (Controller, Service, Repository).

---

Derslerini takip et, planını aksatma — StudyFlowApi ile veriler güvende! 🔐
Geliştirici: [@harundursunf](https://github.com/harundursunf)

---
![image](https://github.com/user-attachments/assets/a6be732d-6761-4cc9-9a88-106f397d7ee8)
![image](https://github.com/user-attachments/assets/8a01decc-421e-4025-8ae7-43d7c69cba25)
![image](https://github.com/user-attachments/assets/3d64693d-f962-4df2-ba7d-ce0dbbc54bf4)




