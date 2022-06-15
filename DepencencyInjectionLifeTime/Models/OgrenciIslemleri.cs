namespace DepencencyInjectionLifeTime.Models
{

    // OgrenciIslemleri sınıfıdan instance alındığında diziden rasgele bir öğrenci ogrenci fieldına aktarılır....
    public class OgrenciIslemleri
    {
        string[] ogrenciler = { "Bilal", "Alper", "Emre", "Ahmet", "Recep" };


        public string ogrenci;
        public OgrenciIslemleri()
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, 5);
            ogrenci = ogrenciler[randomIndex];
        }
    }
}