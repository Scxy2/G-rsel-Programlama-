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
            bool flag = false; // bayrak bilgisi 
            Console.WriteLine("Lütfen bir string deger girin"); // string karakter alma 
            string k = Console.ReadLine().ToLower();

            Hashtable hashtable = new Hashtable();  // hashtable nesnesi olusturma 

            foreach (char i in k)    // girilen stringin karakter bilgisini ve sayisini kaytetme 
            {
                if (hashtable.ContainsKey(i))
                {
                    flag = true;
                    continue;
                }
                else
                {
                    hashtable.Add(i, i);
                }
            }

            if (flag)  // bayrak bilgisine göre  bir stringin aynı veya farklı karakterlerden olustugunu yazdırma 
            {
                Console.WriteLine("Girilen string ayni karakter iceriyor"); // durum bilgisi 
            }
            else
            {
                Console.WriteLine("Girilen string farkli karakterlerden olusuyor");  //durum bilgisi 
            }

            foreach (DictionaryEntry entry in hashtable)  //hashtable yazdırma 
            {
               Console.WriteLine(entry.Key + ":" + entry.Value);
            }
        }
    }
}