using Microsoft.AspNetCore.Mvc;

namespace LogikaInformatikaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProposisiController : ControllerBase
    {
        // ========================================================
        // TUGAS MODUL 02: TABEL KEBENARAN
        // ========================================================
        public class ProposisiRequest
        {
            public bool P { get; set; }
            public bool Q { get; set; }
        }

        [HttpPost("tabel-kebenaran")]
        public IActionResult HitungTabelKebenaran([FromBody] ProposisiRequest input)
        {
            bool negasiP = !input.P;
            bool konjungsi = input.P && input.Q; 
            bool disjungsi = input.P || input.Q; 

            return Ok(new 
            {
                Nilai_P = input.P,
                Nilai_Q = input.Q,
                Hasil_Negasi_P_NOT = negasiP,
                Hasil_Konjungsi_AND = konjungsi,
                Hasil_Disjungsi_OR = disjungsi
            });
        }

        // ========================================================
        // TUGAS MODUL 01: DEFINISI & RUANG LINGKUP (Sistem Kredit)
        // ========================================================
        public class KreditRequest
        {
            public double Saldo { get; set; }
            public double Pendapatan { get; set; }
            public int SkorKredit { get; set; }
            public bool AdaRiwayatBuruk { get; set; }
        }

        [HttpPost("definisi-ruang-lingkup")]
        public IActionResult ProsesPengajuanKredit([FromBody] KreditRequest input)
        {
            // Logika keputusan: Setujui kredit HANYA JIKA semua kondisi terpenuhi
            bool cukupSaldo = input.Saldo > 10000000;
            bool cukupPendapatan = input.Pendapatan > 5000000;
            bool skorBaik = input.SkorKredit >= 700;
            bool tidakAdaRiwayatBuruk = !input.AdaRiwayatBuruk; // Harus False agar jadi True

            // Keputusan akhir menggunakan operator AND (&&)
            bool setujuKredit = cukupSaldo && cukupPendapatan && skorBaik && tidakAdaRiwayatBuruk;

            string statusKeputusan = setujuKredit ? "Pengajuan DISETUJUI" : "Pengajuan DITOLAK";

            return Ok(new
            {
                Pesan = "Analisis Logika Pengajuan Kredit",
                DataNasabah = input,
                HasilAnalisisSyarat = new
                {
                    SyaratSaldoTerpenuhi = cukupSaldo,
                    SyaratPendapatanTerpenuhi = cukupPendapatan,
                    SyaratSkorBaik = skorBaik,
                    SyaratRiwayatBersih = tidakAdaRiwayatBuruk
                },
                KeputusanAkhir = statusKeputusan
            });
        }
    }
}