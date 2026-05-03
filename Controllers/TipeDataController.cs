using Microsoft.AspNetCore.Mvc;

namespace LogikaInformatikaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipeDataController : ControllerBase
    {
        // Model untuk menangkap berbagai tipe data dari user
        public class TipeDataRequest
        {
            public string Nama { get; set; } = string.Empty; // Karakter/String
            public int NIM { get; set; } // Angka Bulat
            public double IPK { get; set; } // Angka Pecahan
            public DateOnly TanggalLahir { get; set; } // Tanggal saja
            public TimeSpan JamKuliah { get; set; } // Waktu/Durasi
            public bool IsAktif { get; set; } // Boolean
        }

        [HttpPost]
        public IActionResult ProsesTipeData([FromBody] TipeDataRequest request)
        {
            // Implementasi Core Logic: Konversi dan Operasi
            
            // 1. Konversi Tipe Data
            string nimSebagaiString = request.NIM.ToString();
            
            // 2. Operasi Tipe Data (Menghitung selisih tahun)
            int tahunSekarang = DateTime.Now.Year;
            int usiaTahun = tahunSekarang - request.TanggalLahir.Year;

            // 3. String Interpolation (Menggabungkan informasi)
            string infoMahasiswa = $"Mahasiswa {request.Nama} (NIM: {request.NIM}) memiliki IPK {request.IPK}";

            // Mengembalikan hasil pemrosesan ke Swagger
            return Ok(new
            {
                Pesan = "Data Berhasil Diproses",
                DataInput = request,
                Analisis = new
                {
                    KonversiNIM = nimSebagaiString,
                    EstimasiUsia = usiaTahun,
                    RingkasanInfo = infoMahasiswa,
                    StatusSistem = request.IsAktif ? "User Aktif" : "User Non-Aktif"
                },
                WaktuServer = DateTime.Now
            });
        }
    }
}