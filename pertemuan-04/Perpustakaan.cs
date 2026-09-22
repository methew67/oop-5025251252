// File ini berisi TODO -- lihat SOAL.md untuk kontrak lengkap tiap level.
// Bagian bertanda TODO(Level N) adalah tugas kalian; kode lain sudah
// disediakan. Jangan mengubah nama/tipe yang sudah ada kecuali TODO
// memintanya secara eksplisit.

using System;
using System.Collections.Generic;

namespace Pertemuan04;

public class Perpustakaan
{
    // TODO(Level 7): Simpan daftar di field PRIVATE (List<Buku>) dan ekspos 
    // DaftarBuku sebagai properti read-only bertipe IReadOnlyList<Buku>.
    private List<Buku> _daftarBuku = new List<Buku>();
    
    public IReadOnlyList<Buku> DaftarBuku 
    { 
        get { return _daftarBuku.AsReadOnly(); } 
    }

    public int JumlahJudul => DaftarBuku.Count;

    public void Tambah(Buku buku)
    {
        // TODO(Level 7): buku null -> ArgumentNullException
        if (buku == null)
        {
            throw new ArgumentNullException(nameof(buku), "Buku tidak boleh null.");
        }

        // ISBN yang sudah ada di koleksi -> InvalidOperationException
        if (Cari(buku.Isbn) != null)
        {
            throw new InvalidOperationException("Buku dengan ISBN ini sudah ada di perpustakaan.");
        }

        // Selain itu tambahkan ke koleksi
        _daftarBuku.Add(buku);
    }

    public Buku? Cari(string isbn)
    {
        // TODO(Level 7): kembalikan buku dengan Isbn yang sama persis, atau null
        foreach (Buku buku in _daftarBuku)
        {
            if (buku.Isbn == isbn)
            {
                return buku;
            }
        }
        return null;
    }

    public void PinjamBuku(string isbn, AkunAnggota akun)
    {
        // TODO(Level 10): "Tell, don't ask"
        if (akun == null)
        {
            throw new ArgumentNullException(nameof(akun), "Akun tidak boleh null.");
        }

        Buku? buku = Cari(isbn);
        if (buku == null)
        {
            throw new ArgumentException("Buku tidak ditemukan.", nameof(isbn));
        }

        if (akun.Denda > 0)
        {
            throw new InvalidOperationException("Anggota masih memiliki tanggungan denda.");
        }

        if (akun.JumlahPinjamanAktif >= AkunAnggota.MaksPinjaman)
        {
            throw new InvalidOperationException("Batas maksimal peminjaman telah tercapai.");
        }

        buku.Pinjam();
        akun.CatatPinjam();
    }

    public void KembalikanBuku(string isbn, AkunAnggota akun)
    {
        // TODO(Level 10)
        if (akun == null)
        {
            throw new ArgumentNullException(nameof(akun), "Akun tidak boleh null.");
        }

        Buku? buku = Cari(isbn);
        if (buku == null)
        {
            throw new ArgumentException("Buku tidak ditemukan.", nameof(isbn));
        }

        if (akun.JumlahPinjamanAktif == 0)
        {
            throw new InvalidOperationException("Anggota tidak sedang meminjam buku apapun.");
        }

        buku.Kembalikan();
        akun.CatatKembali();
    }
}