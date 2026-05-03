using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LogikaInformatikaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProposisiMajemukController : ControllerBase
    {
        // Target Endpoint: POST /api/ProposisiMajemuk
        // Kita tidak memakai parameter input karena sistem akan meng-generate semuanya otomatis
        [HttpPost]
        public IActionResult BuatTabelKebenaranOtomatis()
        {
            int jumlahProposisi = 3; // Variabel P, Q, dan R
            int jumlahBaris = (int)Math.Pow(2, jumlahProposisi); // 2^3 = 8 baris
            
            var hasilTabel = new List<object>();

            // Perulangan untuk membuat 8 baris kombinasi T/F
            for (int i = 0; i < jumlahBaris; i++)
            {
                // Menggunakan bitwise shift untuk menghasilkan kombinasi T/F yang unik tiap barisnya
                bool p = ((i >> 2) & 1) == 1; 
                bool q = ((i >> 1) & 1) == 1; 
                bool r = ((i >> 0) & 1) == 1; 

                // Evaluasi formula: (P ∧ Q) ∨ R
                bool pAndQ = p && q;
                bool hasilAkhir = pAndQ || r;

                // Memasukkan hasil baris ini ke dalam tabel
                hasilTabel.Add(new
                {
                    Baris_Ke = i + 1,
                    Nilai_P = p,
                    Nilai_Q = q,
                    Nilai_R = r,
                    Proses_P_AND_Q = pAndQ,
                    Hasil_Akhir_Formula = hasilAkhir
                });
            }

            // Mengembalikan seluruh tabel ke Swagger
            return Ok(new
            {
                Pesan = "Generator Tabel Kebenaran Otomatis",
                Formula = "(P ∧ Q) ∨ R",
                TotalBaris = jumlahBaris,
                TabelKebenaranLengkap = hasilTabel
            });
        }
    }
}