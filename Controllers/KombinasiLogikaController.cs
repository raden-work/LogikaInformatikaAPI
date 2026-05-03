using Microsoft.AspNetCore.Mvc;

namespace LogikaInformatikaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KombinasiLogikaController : ControllerBase
    {
        // Class untuk menangkap input 3 variabel (P, Q, R) dari user
        public class KombinasiRequest
        {
            public bool P { get; set; }
            public bool Q { get; set; }
            public bool R { get; set; }
        }

        // Target Endpoint: POST /api/KombinasiLogika
        [HttpPost]
        public IActionResult HitungKombinasi([FromBody] KombinasiRequest input)
        {
            // 1. Logika Awal: ¬(P ∧ Q)
            bool negasiKonjungsi = !(input.P && input.Q);

            // 2. Hukum De Morgan: (¬P) ∨ (¬Q)
            bool deMorganKonjungsi = !input.P || !input.Q;

            // 3. Kombinasi kompleks: (P ∧ Q) ∨ R
            bool kombinasiKompleks = (input.P && input.Q) || input.R;

            // Mengembalikan hasil analisis ke Swagger
            return Ok(new
            {
                Pesan = "Analisis Kombinasi Logika & Pembuktian Hukum De Morgan",
                InputUser = new { P = input.P, Q = input.Q, R = input.R },
                HasilAnalisis = new
                {
                    Negasi_Konjungsi = negasiKonjungsi,
                    DeMorgan_Ekivalen = deMorganKonjungsi,
                    // Sistem akan mengecek apakah nilai keduanya sama persis
                    Hukum_DeMorgan_Terbukti = (negasiKonjungsi == deMorganKonjungsi),
                    Hasil_Kombinasi_Kompleks = kombinasiKompleks
                }
            });
        }
    }
}