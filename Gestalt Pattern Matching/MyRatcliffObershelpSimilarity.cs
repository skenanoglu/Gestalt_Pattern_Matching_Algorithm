using System;
using System.Collections.Generic;
using System.Text;

namespace Gestalt_Pattern_Matching
{

    public class MyRatcliffObershelpSimilarity
    {
        //Kullanıcının girdiği stringlerin atanacağı boş değişkenler
        private string firststring;
        private string secondstring;
        //Toplam karakter uzunluğunu tutacak olan değişken
        private int totalcharactercount;
        private int totallength;

        //Sınıfın kurucu methodu uygun değişken alacak şekilde oluşturuldu
        public MyRatcliffObershelpSimilarity(string firststring, string secondstring)
        {
            //Kurucu metoddan gelen kullanıcı girdileri bu sınıftaki private değişkenlerimize atanacak
            this.firststring = firststring;
            this.secondstring = secondstring;
            //Toplam uzunluk benzerlik formülünde bulunduğu için total değişkenine atanıyor
            int total = firststring.Length + secondstring.Length;

            totalcharactercount = total;
            this.totallength = total;
            //kullanıcı ekranına bilgi yazdırılıyor
            Console.WriteLine("Toplam karakter sayısı :" + totalcharactercount);
            CalculateSimilarity(); // İki stringin benzerliğini karşılaştıracak asıl metod kurucu metod içerisinde çağırıldı.
        }
        // Alt dize arayan metod
        public void CalculateSimilarity()
        {
            int longestsubslength = 0;
            //Döngülerde string uzunlukları kullanılacağı için değişkenlere atanıyor
            int firstindex = firststring.Length;
            int secondindex = firststring.Length;
            //En uzun alt dizenin atanacağı boş bir string değişkeni tanımlanıyor
            string longestsubs = "";

            /**  **/ 
            for (int i = 0; i < firstindex; i++) // birinci kelimenin uzunluğıu kadar döngü döner
            {
                for (int j = 1; j <= secondindex; j++) // ikinci kelime uzunluğu kadar döngü döner
                {
                    string value = firststring.Substring(i, j); // Bütün substringleri gezen algoritma.
                    bool boolean = secondstring.Contains(value); //bulunan substringin ikinci kelimede olup olmadığının kontrolü.
                    if (boolean == true) 
                    {
                        if (value.Length > longestsubslength)  // Eğer yeni substring önceki en uzun substringden uzunsa yeni substring o olacaktır.
                        {
                            longestsubslength = value.Length;
                            longestsubs = value;
                        }
                    }
                }
                secondindex--; 
                 /* içteki for her bittiğinde yani artık 2.chardan sonrasından substring arayacağımızda,
                        ikinci kelimenin uzunluğu bir kısalmıştır. */

            }
            Console.WriteLine("En uzun ortak alt dize uzunluğu :" + longestsubslength);//consola veri yazdırma işlemleri.
            Console.WriteLine("En uzun ortak alt dize stringi :" + longestsubs);

            int firstindexoflongest = firststring.IndexOf(longestsubs);// 
            int secondindexoflongest = secondstring.IndexOf(longestsubs);

            Console.WriteLine("Birinci stringde en uzun alt dizenin başladığı index :" + firstindexoflongest);
            Console.WriteLine("İkinci stringde en uzun alt dizenin başladığı index :" + secondindexoflongest);

            /* Substring metodunu amacı bir string içerisinden belli bir kısmı almaktır.
             iki girdi alır birincisi kelimenin başladığı indeksi ikincisi kaç adet char alınacağı belirtir.
             */ 
            string firstpreviousstring = firststring.Substring(0, firstindexoflongest);
            string secondpreviousstring = secondstring.Substring(0, secondindexoflongest);
            Console.WriteLine("Birinci stringde en uzun alt dizeden öncesi :" + firstpreviousstring);
            Console.WriteLine("İkinci stringde en uzun alt dizeden öncesi :" + secondpreviousstring);

            int longestlastone = firstindexoflongest + longestsubslength;
            int longestlasttwo = secondindexoflongest + longestsubslength;

            string firstnextstring = firststring.Substring(longestlastone, firstindex - longestlastone);
            string secondnextstring = secondstring.Substring(longestlasttwo, secondstring.Length - longestlasttwo);
            Console.WriteLine("Birinci stringde en uzun alt dizeden sonrası :" + firstnextstring);
            Console.WriteLine("İkinci stringde en uzun alt dizeden sonrası :" + secondnextstring);

            string firstpreviousstringNew = CharRepetitionControl(firstpreviousstring);//CharRepetitionControl metodu çağırılır.tekrar eden charları silecektir.
            string firstnextstringNew = CharRepetitionControl(firstnextstring);
            Console.WriteLine("Birinci stringde en uzun alt dizeden öncesinin aynı harflerden arındırılmış hali  :" + firstpreviousstringNew);
            Console.WriteLine("Birinci stringde en uzun alt dizeden sonrasının aynı harflerden arındırılmış hali   :" + firstnextstringNew);


            int nextsubs = 0;
            for (int i = 0; i < firstnextstringNew.Length; i++) //döngü firstnextstringNew.Length kadar dönecektir.
            {
                //birinci stringdeki en uzun substringden SONRASI ile ikinci stringdeki en uzun substringden SONRASI karşılatırılıyor.
                bool _bool = secondnextstring.Contains(firstnextstringNew[i]);
                if (_bool == true)//eğer parantez içi sağlanırsa süslü parantezler arasındaki kodlar çalışır.
                {
                    nextsubs++;//if sağlanırsa değer 1 artacaktır.
                }
            }
            int prevsubs = 0;
            for (int i = 0; i < firstpreviousstringNew.Length; i++)//döngü firstpreviousstringNew.Length kadar dönecektir.
            {
                //birinci stringdeki en uzun substringden ÖNCESİ ile ikinci stringdeki en uzun substringden ÖNCESİ karşılatırılıyor.
                bool _bool = secondpreviousstring.Contains(firstpreviousstringNew[i]);
                if (_bool == true)//eğer parantez içi sağlanırsa süslü parantezler arasındaki kodlar çalışır.
                {
                    prevsubs++;//if sağlanırsa değer 1 artacaktır.
                }
            }
                 /* Konsola bilgi amaçlı veriler bastırılıyor*/
            Console.WriteLine("En uzun ortak alt dizenin öncesinde iki cümlede ortak harf sayısı :" + prevsubs);
            Console.WriteLine("En uzun ortak alt dizenin sonrasında iki cümlede ortak harf sayısı :" + nextsubs);

            Console.WriteLine("****************************************");

            /* Alttaki satırda Gestalt Pattern Matching algoritmasına göre benzerlik ölçen algoritmanın formülü bulunmaktadır.*/
            float result = 2f * (longestsubslength + nextsubs + prevsubs) / (totallength);
            Console.WriteLine("Result : " + result); //sonucu konsola bastırır.


        }

        public static string CharRepetitionControl(string word) // Dönüş tipi string olan static bir metod.
        {
            List<char> control = new List<char>(word.Length); //Control adında boş liste oluşturulur, uzunluğu word.Length olacaktır.
            for (int i = 0; i < word.Length; i++)//0 dan kelimenin uzunluğu kadar döngü döner
            {
                if (control.Contains(word[i])==true) //Bir harfin boş listeye eklenmesini kontrol eder. eğer daha önceden ekliyse boş geçer.
                {
                  continue;//Döngünün bu kısma geldiği zaman bir tur ileri atlamasını sağlar.
                }
                control.Add(word[i]);//Listeye char ekler
            }
            var myword = new string(control.ToArray());//control.ToArray() metodu ile önce diziye çevrilir ve sonrasında string tipine dönüşüm yapılır.
            return myword;//myword kelimesi döngünün dönüş değeridir.
        }

    }
}
