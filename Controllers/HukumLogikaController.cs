using Microsoft.AspNetCore.Mvc;

namespace LogikaInformatikaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HukumLogikaController : ControllerBase
    {
        // Class untuk menangkap input dari user
        public class HukumRequest
        {
            public bool P { get; set; }
            public bool Q { get; set; }
        }

        // Target Endpoint: POST /api/HukumLogika
        [HttpPost]
        public IActionResult VerifikasiHukum([FromBody] HukumRequest input)
        {
            bool p = input.P;
            bool q = input.Q;

            // 1. Hukum Identitas
            bool identitasOR = (p || false) == p;
            bool identitasAND = (p && true) == p;

            // 2. Hukum Dominasi
            bool dominasiOR = (p || true) == true;
            bool dominasiAND = (p && false) == false;

            // 3. Hukum Idempoten
            bool idempotenOR = (p || p) == p;
            bool idempotenAND = (p && p) == p;

            // 4. Hukum Negasi Ganda
            bool negasiGanda = !(!p) == p;

            // 5. Hukum De Morgan
            bool deMorganAND = !(p && q) == (!p || !q);
            bool deMorganOR = !(p || q) == (!p && !q);

            // Mengembalikan hasil verifikasi ke Swagger
            return Ok(new
            {
                Pesan = "Verifikasi Pembuktian Hukum Logika Fundamental",
                InputUser = new { Nilai_P = p, Nilai_Q = q },
                HasilVerifikasi = new
                {
                    HukumIdentitas_OR_Terbukti = identitasOR,
                    HukumIdentitas_AND_Terbukti = identitasAND,
                    HukumDominasi_OR_Terbukti = dominasiOR,
                    HukumDominasi_AND_Terbukti = dominasiAND,
                    HukumIdempoten_OR_Terbukti = idempotenOR,
                    HukumIdempoten_AND_Terbukti = idempotenAND,
                    HukumNegasiGanda_Terbukti = negasiGanda,
                    HukumDeMorgan_AND_Terbukti = deMorganAND,
                    HukumDeMorgan_OR_Terbukti = deMorganOR
                }
            });
        }
    }
}