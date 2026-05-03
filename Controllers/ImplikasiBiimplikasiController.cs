using Microsoft.AspNetCore.Mvc;

namespace LogikaInformatikaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImplikasiBiimplikasiController : ControllerBase
    {
        // Class untuk menangkap input P dan Q dari user
        public class ImplikasiRequest
        {
            public bool P { get; set; }
            public bool Q { get; set; }
        }

        // Target Endpoint: POST /api/ImplikasiBiimplikasi
        [HttpPost]
        public IActionResult HitungImplikasi([FromBody] ImplikasiRequest input)
        {
            // 1. Implikasi: P → Q (Setara dengan ¬P ∨ Q)
            // Bernilai salah HANYA jika P benar dan Q salah
            bool implikasi = !input.P || input.Q;

            // 2. Biimplikasi: P ↔ Q
            // Bernilai benar jika P dan Q nilainya sama
            bool biimplikasi = input.P == input.Q;

            // 3. Variasi Implikasi
            bool konvers = !input.Q || input.P;        // Q → P
            bool invers = input.P || !input.Q;         // ¬P → ¬Q
            bool kontrapositif = input.Q || !input.P;  // ¬Q → ¬P

            // Mengembalikan hasil analisis ke Swagger
            return Ok(new
            {
                Pesan = "Analisis Implikasi, Biimplikasi, dan Variasinya",
                InputUser = new { P = input.P, Q = input.Q },
                HasilAnalisis = new
                {
                    Hasil_Implikasi = implikasi,
                    Hasil_Biimplikasi = biimplikasi,
                    Hasil_Konvers = konvers,
                    Hasil_Invers = invers,
                    Hasil_Kontrapositif = kontrapositif,
                    
                    // Sistem membuktikan Implikasi ≡ Kontrapositif
                    Pembuktian_Implikasi_SamaDengan_Kontrapositif = (implikasi == kontrapositif)
                }
            });
        }
    }
}