using System;
using System.Collections;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace adnan_tpc
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = false;  //bayrak bilgisi default olarak false ilerde anagram olup olmadığını kontrol etmek için 
            Console.WriteLine("Lütfen 1. string degeri girin=>");  // string ifade almak 
            string k = Console.ReadLine().ToLower();
            Console.WriteLine("Lütfen 2. string degeri girin=>");  // string ifade alma 
            string l = Console.ReadLine().ToLower();

            Hashtable hashtable1 = new Hashtable();  //hashtable nesneleri olusturma 
            Hashtable hashtable2 = new Hashtable();  //hashtable nesneleri olusturma 
            foreach (char i in k)
            {
                if (hashtable1.ContainsKey(i))      //stringin karakterlerini ve karakter sayıalrını hashtable yazdırma 
                {
                    hashtable1[i]=(int)hashtable1[i]+1;
                    continue;
                }
                else
                {
                    hashtable1.Add(i, 1);
                }
            }

            foreach (char i in l)               //stringin karakterlerini ve karakter sayıalrını hashtable yazdırma
            {
                if (hashtable2.ContainsKey(i))
                {
                    hashtable2[i] = (int)hashtable2[i] + 1;
                    continue;
                }
                else
                {
                    hashtable2.Add(i, 1);
                }
            }
            //2 hashtable bilgisini karsılastırma 
            foreach (char i in hashtable1.Keys) {      //1. hashtableda gezme 
                if (hashtable2.ContainsKey(i))       // 1. hashtable key degerlerini 2. hashtable da var mı yok mu kontrol etme 
                {
                    if ((int)hashtable2[i] != (int)hashtable1[i]) // varsa bu karakterin 2 hashtableda sayılarını kontrol ediyorum 
                    {
                        flag = true;    // degerler farklıysa bayragı true yapiyorum 
                        break;
                    }
                }
                else   // yoksa bayrak true yapıyorum
                {
                    flag = true;
                    break;
                }
            }


            if (flag)     // bayraga gore durum yazdırma 
            {
                Console.WriteLine("Girilen stringler anagram degildir"); //durum bilgisi 
            }
            else
            {
                Console.WriteLine("Girilen stringler anagramdir");  // durum bilgisi
            }


            foreach (DictionaryEntry entry in hashtable1)   //1. hashtable yazdırma
            {
                Console.WriteLine(entry.Key + ":" + entry.Value);
            }
            Console.WriteLine("###################################################");
            foreach (DictionaryEntry entry in hashtable2)  //2. hashtable yazdırma
            {
                Console.WriteLine(entry.Key + ":" + entry.Value);
            }
        }
    }
}