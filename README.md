# 🍔 FoodDeliveryApp

FoodDeliveryApp adalah aplikasi backend sederhana untuk layanan pemesanan makanan.  
Saat ini project masih berfokus pada **CRUD Product** menggunakan **.NET Core Web API**, **Entity Framework Core**, dan **SQL Server**.

---

## 🚀 Tech Stack
- **.NET 8 Web API**
- **Entity Framework Core**
- **SQL Server**
- **Swagger (API Documentation)**

---

## 📦 Fitur Saat Ini
- [x] Tambah produk baru  
- [x] Lihat daftar produk  
- [x] Lihat detail produk berdasarkan ID  
- [x] Update produk  
- [x] Hapus produk  

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

📌 Contoh Request API
```bash
   - Get semua produk
   - GET /api/products

---

## 🗺️ **Roadmap**
---
 Authentication & Authorization (JWT)
 CRUD Orders
 Integrasi Payment Gateway
 Role untuk admin & user
 Deploy ke cloud (Azure / AWS / Railway)

---

🤝 Kontribusi
---
Pull request dan masukan sangat diterima.
Untuk perubahan besar, silakan buka issue terlebih dahulu.
