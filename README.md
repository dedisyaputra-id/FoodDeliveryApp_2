🍔 FoodDeliveryApp

FoodDeliveryApp adalah backend sederhana untuk layanan pemesanan makanan, dibangun menggunakan .NET 8 Web API, Entity Framework Core, dan SQL Server.

Fitur utama: manajemen produk, kategori, order, autentikasi JWT, role-based authorization, dan refresh token.

🚀 Tech Stack

.NET 8 Web API

Entity Framework Core

SQL Server

Swagger (API Documentation)

JWT Authentication & Refresh Token

Role-based Authorization (Admin & User)

📦 Fitur Saat Ini

 Tambah produk baru dengan kategori

 Lihat daftar produk

 Lihat detail produk berdasarkan ID

 Update produk

 Hapus produk

 Tambah kategori baru

 Lihat daftar kategori

 Lihat detail kategori berdasarkan ID

 Update kategori

 Hapus kategori

 Tambah order baru beserta order detailnya

 Lihat daftar order

 Lihat detail order berdasarkan ID

 Hapus order

 Register & Login menggunakan JWT

 Role-based Authorization (Admin & User)

 Refresh Token untuk menjaga session tetap aktif

🔑 Autentikasi & Otorisasi
Endpoints
Endpoint	Method	Deskripsi
/api/auth/register	POST	Registrasi user baru
/api/auth/login	POST	Login, mengembalikan JWT & Refresh Token
/api/auth/refresh-token	POST	Mendapatkan access token baru menggunakan refresh token
Contoh Response JWT Login
{
  "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "refreshToken": "c29tZS1yYW5kb20tc3RyaW5nLXJlZnJlc2g=",
  "expiresIn": 3600,
  "role": "Admin"
}

🖇️ Flow Diagram Login & Refresh Token
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

🛠️ Setup & Menjalankan Project

Clone repository:

git clone https://github.com/dedisyaputra-id/FoodDeliveryApp_2.git
cd FoodDeliveryApp


Atur koneksi database di appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=nama-server;Database=FoodDelivery;Trusted_Connection=True;Encrypt=False"
}


Jalankan migrasi untuk membuat database:

# Package Manager Console
Add-Migration InitialCreate
Update-Database


Jalankan aplikasi dan buka Swagger UI:

https://localhost:5001/swagger

📌 Contoh Request API

Get semua produk
GET /api/products

Tambah produk (Admin)
POST /api/products

Login
POST /api/auth/login

Register
POST /api/auth/register

Refresh token
POST /api/auth/refresh-token

🗺️ Roadmap

CRUD Orders lebih lengkap (update status & edit detail order)

Integrasi Payment Gateway

Deploy ke cloud (Azure / AWS / Railway)

🤝 Kontribusi

Pull request dan masukan sangat diterima.
Untuk perubahan besar, silakan buka issue terlebih dahulu.
