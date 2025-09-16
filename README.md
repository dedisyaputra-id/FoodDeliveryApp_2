# 🍔 FoodDeliveryApp

FoodDeliveryApp adalah aplikasi backend sederhana untuk layanan pemesanan makanan.  
Techstack yang digunakan adalah **.NET Core Web API**, **Entity Framework Core**, dan **SQL Server**.

---

## 🚀 Tech Stack
- **.NET 8 Web API**
- **Entity Framework Core**
- **SQL Server**
- **Swagger (API Documentation)**

---

## 📦 Fitur Saat Ini
- [x] Tambah produk baru dengan kategori
- [x] Lihat daftar produk  
- [x] Lihat detail produk berdasarkan ID  
- [x] Update produk  
- [x] Hapus produk
- [x] Tambah kategori baru
- [x] Lihat daftar kategori
- [x] Lihat daftar kategori berdasarkan ID
- [x] Update kategori
- [x] Hapus kategori
- [x] Tambah order baru beserta order detailnya
- [x] Lihat daftar order
- [x] Lihat daftar order berdasarkan ID
- [x] Hapus Order
- [x] Register & Login menggunakan JWT
- [x] Role-based Authorization (Admin & User)
- [x] Refresh Token untuk menjaga session tetap aktif

---
## Contoh Response JWT Login
```bash
{
  "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "refreshToken": "c29tZS1yYW5kb20tc3RyaW5nLXJlZnJlc2g=",
  "expiresIn": 3600,
  "role": "Admin"
}
```
---
## 🖇️ Flow Diagram Login & Refresh Token
``` bash
flowchart TD
    A[User Login] -->|POST /login| B[Server Verifies Credentials]
    B --> C{Valid?}
    C -->|Yes| D[Server Returns JWT Access Token & Refresh Token]
    C -->|No| E[Return Error]
    F[Access Protected API] -->|Send JWT| G[Server Validates JWT]
    G -->|Valid| H[Return Data]
    G -->|Expired| I[Use Refresh Token]
    I -->|POST /refresh-token| J[Server Issues New JWT]
    J --> H
```
---
## 🛠️ Setup & Menjalankan Project

1. Clone repository ini:
   ```bash
   git clone https://github.com/dedisyaputra-id/FoodDeliveryApp_2.git
   cd FoodDeliveryApp
2. Atur koneksi database di appsettings.json:
   ```bash
   "ConnectionStrings": {
     "DefaultConnection": "Server=nama-server;Database=FoodDelivery;Trusted_Connection=True;Encrypt=False"
   }
3. Jalankan migrasi untuk membuat database:
   ```bash
   - Buka Packgae Manager Console di Visual Studio
   - Ketik Add-Migration namamigration
   - Setelah success ketik update-database
4. Buka swagger ui sesuai dengan portnya, contoh https://localhost:5001/swagger

---

## 📌 Contoh Request API
   - Get semua produk
   - GET /api/Products
   - POST /api/Products/Save
   - POST /api/Auth/Login
   - POST /api/Auth/Register
   - POST /api/Auth/Refreshtoken

## 🗺️ Roadmap
- CRUD Orders lebih lengkap (update status & edit detail order)
- Integrasi Payment Gateway
- Deploy ke cloud (Azure / AWS / Railway)

🤝 Kontribusi
---
Pull request dan masukan sangat diterima.
Untuk perubahan besar, silakan buka issue terlebih dahulu. perbarui readme saya, sekarang sudah bisa login dan register menggunakan mekanisme jwt, sudah ada role untuk admin dan user 
