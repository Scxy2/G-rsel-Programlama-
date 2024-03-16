using System;
using System.Collections;
using System.Collections.Specialized;
using System.Reflection.Metadata.Ecma335;

namespace adnan_tpc
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Bursa = { "Nilüfer", "GemliK", "Kestel","Mudanya","Osmangazi" };  // sehir bilgileri s
            string[] Trabzon = { "Sürmene", "Arakli", "Of", "Arsin", "Yomra" };
            string[] Sakarya = { "Adapazari", "Akyazi", "Ferizli", "Hendek", "Ferizli" };

            Hashtable hashtable = new Hashtable();  // hashtable nesnesi olusturma

            hashtable.Add("bursa", Bursa); // hashtable ekleme yapma s
            hashtable.Add("trabzon", Trabzon);
            hashtable.Add("sakarya", Sakarya);

            while (true)  // döngü icinde değer alma ve kontrol etme 
            {
                Console.WriteLine("\nLütfen bir şehir ismi giriniz (Cikmak için q basin)=> "); //sehir ismi alma 
                string k = Console.ReadLine();

                if (k == "q" || k== "Q")  // q veya Q döngüden cıkar 
                {
                    Console.WriteLine("Program sonlanidirldi!!!"); //durum bilgisi 
                    break;
                }
                else if (hashtable.ContainsKey(k.ToLower())) // girilen sehir ismi hashtableda var mı yok mu 
                {
                    Console.WriteLine("Istenen şehir var=>>>"); // durum bilgisi 
                    foreach (string s in (string[])hashtable[k.ToLower()]) { // sehirin ilcelerini yazdırma 
                        Console.Write(s+"   ");
                    }
                }
                else
                {
                    Console.WriteLine("Girilen deger hashtable'de yok veya gecersiz deger!!!!"); // durum bilgisi 
                } 

            }
        }
    }
}

