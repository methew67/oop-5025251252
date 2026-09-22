// File ini berisi TODO -- lihat SOAL.md untuk kontrak lengkap tiap level.
// Bagian bertanda TODO(Level N) adalah tugas kalian; kode lain sudah
// disediakan. Jangan mengubah nama/tipe yang sudah ada kecuali TODO
// memintanya secara eksplisit.

using System;

namespace Pertemuan04;

public class AkunAnggota
{
    public const int MaksPinjaman = 3;

    public string NomorAnggota { get; }

    // TODO(Level 9): Nama hanya boleh diisi saat objek dibuat (ganti set -> init). 
    // Denda TIDAK boleh diubah dari luar kelas sama sekali (setter private).
    public string Nama { get; init; } = "";
    public int Denda { get; private set; }

    // TODO(Level 10): JumlahPinjamanAktif hanya boleh diubah dari dalam kelas (setter private).
    public int JumlahPinjamanAktif { get; private set; }

    public AkunAnggota(string nomorAnggota)
    {
        // TODO(Level 9): nomorAnggota null/kosong/spasi -> ArgumentException
        if (string.IsNullOrWhiteSpace(nomorAnggota))
        {
            throw new ArgumentException("Nomor anggota tidak boleh null atau kosong.", nameof(nomorAnggota));
        }
        NomorAnggota = nomorAnggota;
    }

    public void TambahDenda(int rupiah)
    {
        // TODO(Level 9): rupiah <= 0 -> ArgumentOutOfRangeException
        if (rupiah <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(rupiah), "Nominal denda harus lebih dari 0.");
        }
        Denda += rupiah;
    }

    public int BayarDenda(int rupiah)
    {
        // TODO(Level 9): rupiah <= 0 -> ArgumentOutOfRangeException
        if (rupiah <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(rupiah), "Nominal pembayaran harus lebih dari 0.");
        }
        
        // rupiah > Denda -> InvalidOperationException
        if (rupiah > Denda)
        {
            throw new InvalidOperationException("Nominal pembayaran tidak boleh melebihi denda yang ada.");
        }
        
        Denda -= rupiah;
        return Denda;
    }

    // TODO(Level 10): pencatatannya lewat method internal (bukan public)
    internal void CatatPinjam()
    {
        JumlahPinjamanAktif++;
    }

    internal void CatatKembali()
    {
        // turunkan JumlahPinjamanAktif satu (tidak boleh di bawah 0)
        if (JumlahPinjamanAktif > 0)
        {
            JumlahPinjamanAktif--;
        }
    }
}