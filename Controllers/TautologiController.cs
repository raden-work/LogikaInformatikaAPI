using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LogikaInformatikaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TautologiController : ControllerBase
    {
        // Target Endpoint: POST /api/Tautologi
        [HttpPost]
        public IActionResult AnalisisTautologi()
        {
            // Array untuk simulasi kombinasi True/False
            bool[] nilai = { true, false }; 
            
            var hasilTautologi = new List<bool>();
            var hasilKontradiksi = new List<bool>();
            var hasilContingency = new List<bool>();

            // Mengevaluasi proposisi untuk semua kombinasi P dan Q[cite: 10]
            foreach (bool p in nilai)
            {
                foreach (bool q in nilai)
                {
                    // 1. Evaluasi P ∨ (¬P)
                    hasilTautologi.Add(p || !p);

                    // 2. Evaluasi P ∧ (¬P)
                    hasilKontradiksi.Add(p && !p);

                    // 3. Evaluasi P ∧ Q
                    hasilContingency.Add(p && q);
                }
            }

            // Mengembalikan hasil analisis klasifikasi[cite: 10]
            return Ok(new
            {
                Pesan = "Analisis Tautologi, Kontradiksi, dan Contingency",
                Tautologi_P_OR_NOT_P = new
                {
                    SemuaKombinasi = hasilTautologi,
                    // Jika semua baris bernilai True, maka Tautologi[cite: 10]
                    Kesimpulan = hasilTautologi.All(x => x) ? "TAUTOLOGI (Selalu Benar)" : "Bukan Tautologi" 
                },
                Kontradiksi_P_AND_NOT_P = new
                {
                    SemuaKombinasi = hasilKontradiksi,
                    // Jika semua baris bernilai False, maka Kontradiksi[cite: 10]
                    Kesimpulan = hasilKontradiksi.All(x => !x) ? "KONTRADIKSI (Selalu Salah)" : "Bukan Kontradiksi"
                },
                Contingency_P_AND_Q = new
                {
                    SemuaKombinasi = hasilContingency,
                    // Jika ada True dan False, maka Contingency[cite: 10]
                    Kesimpulan = (hasilContingency.Contains(true) && hasilContingency.Contains(false)) ? "CONTINGENCY (Kadang Benar, Kadang Salah)" : "Bukan Contingency"
                }
            });
        }
    }
}