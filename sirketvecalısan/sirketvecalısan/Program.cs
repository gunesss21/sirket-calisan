using System;
using System.Collections.Generic;

// Temel Çalışan Sınıfı: Her çalışanın genel özelliklerini ve işlevlerini temsil eder
public abstract class Calisan
{
    public string Ad { get; private set; }  // Çalışanın adı
    public string Rol { get; private set; } // Çalışanın rolü

    // Çalışan yapıcısı
    public Calisan(string ad, string rol)
    {
        Ad = ad;
        Rol = rol;
    }

    // Çalışanların bağımsız işlevi: Her çalışanın gerçekleştirebileceği farklı işlevler
    public abstract void IsYap();

    // Çalışanın bilgilerini yazdırma metodu
    public override string ToString()
    {
        return $"{Ad} ({Rol})";
    }
}

// Yazılım Geliştirici Çalışan Sınıfı: Bu sınıf, Yazılım Geliştirici çalışanın işlevselliğini temsil eder
public class YazilimGelistirici : Calisan
{
    public YazilimGelistirici(string ad) : base(ad, "Yazılım Geliştirici") { }

    // Yazılım geliştiricinin gerçekleştirdiği işlev
    public override void IsYap()
    {
        Console.WriteLine($"{Ad} yazılım geliştirme işleri yapıyor.");
    }
}

// Muhasebeci Çalışan Sınıfı: Bu sınıf, Muhasebeci çalışanın işlevselliğini temsil eder
public class Muhasebeci : Calisan
{
    public Muhasebeci(string ad) : base(ad, "Muhasebeci") { }

    // Muhasebecinin gerçekleştirdiği işlev
    public override void IsYap()
    {
        Console.WriteLine($"{Ad} muhasebe işleri yapıyor.");
    }
}

// Şirket Sınıfı: Şirketin özelliklerini ve çalışanları yöneten sınıf
public class Sirket
{
    public string SirketAdi { get; private set; } // Şirketin adı
    public List<Calisan> Calisanlar { get; private set; } // Çalışanların listesi

    // Şirket yapıcısı
    public Sirket(string sirketAdi)
    {
        SirketAdi = sirketAdi;
        Calisanlar = new List<Calisan>();
    }

    // Çalışan ekleme metodu
    public void CalisanEkle(Calisan calisan)
    {
        Calisanlar.Add(calisan);
        Console.WriteLine($"{calisan.Ad} şirkete eklendi.");
    }

    // Şirketin tüm çalışanlarını gösterme metodu
    public void CalisanlariGoster()
    {
        Console.WriteLine($"Şirket: {SirketAdi}");
        foreach (var calisan in Calisanlar)
        {
            Console.WriteLine(calisan);
        }
    }

    // Şirketin tüm çalışanlarının bağımsız olarak iş yapmasını sağlama
    public void IsYap()
    {
        foreach (var calisan in Calisanlar)
        {
            calisan.IsYap();
        }
    }
}

// Program sınıfı: Uygulamanın ana giriş noktası
public class Program
{
    public static void Main(string[] args)
    {
        // Şirket oluşturuluyor
        var sirket = new Sirket("ABC Teknoloji");

        // Çalışanlar oluşturuluyor
        var yazilimGelistirici1 = new YazilimGelistirici("Ahmet");
        var yazilimGelistirici2 = new YazilimGelistirici("Mehmet");
        var muhasebeci = new Muhasebeci("Zeynep");

        // Çalışanlar şirkete ekleniyor
        sirket.CalisanEkle(yazilimGelistirici1);
        sirket.CalisanEkle(yazilimGelistirici2);
        sirket.CalisanEkle(muhasebeci);

        // Çalışanlar ve roller görüntüleniyor
        sirket.CalisanlariGoster();

        // Çalışanlar bağımsız olarak iş yapıyor
        sirket.IsYap();
    }
}
