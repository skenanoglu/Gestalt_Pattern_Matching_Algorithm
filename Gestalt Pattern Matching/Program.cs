using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace Gestalt_Pattern_Matching
{
    class Program
    {
        static void Main(string[] args)
        {
            //Konsol ekranına string yazdırır
            Console.Write("Birinci stringi giriniz :");
            //Klavyeden girilen string değerini isimlendirilen değişkene atar
            string firststring = Console.ReadLine();
            Console.Write("İkinci stringi giriniz :");
            string secondstring = Console.ReadLine();
            //MyRatcliffObershelpSimilarity sınıfından sample adında bir örnek oluşturuldu ve parametreler kurucu metoda gönderildi
            MyRatcliffObershelpSimilarity sample = new MyRatcliffObershelpSimilarity(firststring, secondstring);
            

        } 

    }
}
