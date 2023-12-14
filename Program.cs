using System;
using System.Text.RegularExpressions;

namespace Workspace
{    
    internal class Kontrol
    {
        //Girilen string'in numara olmayan karekteri varsa false döndüren fonksiyon
        internal bool TamamenNumerik(string dize)
        {
            bool kontrol = false;
            foreach(char eleman in dize)
            {
                if(Char.IsNumber(eleman))
                {
                    kontrol = true;
                }
                else
                {
                    kontrol = false;
                    break;
                }
            }
            
            return kontrol;
        }

        //Girilen string'in harf olmayan karekteri varsa false döndüren fonksiyon
        internal bool TamamenAlfabetik(string dize)
        {
            bool kontrol = false;
            foreach(char eleman in dize)
            {
                if(Char.IsLetter(eleman))
                {
                    kontrol = true;
                    break;
                }
                else
                {
                    kontrol = false;
                    break;
                }
            }
            
            return kontrol;
        }

        //Girilen string'in alfanumerik olmayan karekteri varsa false döndüren fonksiyon
        internal bool TamamenAlfanmuerik(string dize)
        {
            bool kontrol = false;
            foreach(char eleman in dize)
            {
                if(char.IsLetter(eleman) || char.IsNumber(eleman))
                {
                    kontrol = true;
                }
                else
                {
                    kontrol = false;
                    break;
                }
            }

            return kontrol;
        }

        //Girilen string'in ozelkarekter olmayan karekteri varsa false döndüren fonksiyon
        internal bool TamamenOzelKarekter(string dize)
        {
            bool kontrol = false;
            foreach(char eleman in dize)
            {
                if(Char.IsSymbol(eleman))
                {
                    kontrol = true;
                }
                else
                {
                    kontrol = false;
                    break;
                }

                return kontrol;
            }
            
            return kontrol;
        }
    }

    internal class Kullanici
    {
        internal string id;
        internal string sifre;
        internal string mail;
        internal string telefon_no;
        internal string isim;

        Kontrol kontrolcu = new Kontrol();

        internal void idOlustur(string id)
        {
            if(id.Length > 4 && id.Length <21)
            {
                if(kontrolcu.TamamenAlfabetik(id.Substring(0,1)))
                {
                    if(kontrolcu.TamamenAlfanmuerik(id))
                    {
                        this.id = id;
                        Console.WriteLine("ID'niz Atanmistir");
                    }
                    else
                    {
                        Console.WriteLine("ID'nin Icinde Alfabetik veya Numerik Olmayan Karekter Var");
                    }
                }
                else
                {
                    Console.WriteLine("ID'nin ilk harfi alfabetik degil");
                }
            }
            else
            {
                Console.WriteLine("ID'nin boyutu istenen aralikta degil");
            }
        }

        internal void sifreOlustur(string sifre)
        {
            if(sifre.Length > 7 && sifre.Length<21)
            {
                foreach(char eleman in sifre)
                {
                    bool buyukH = false;
                    bool kucukH = false;
                    bool rakamsaldeger = false;
                    bool boslukdegeri = false;

                    if(Char.IsUpper(eleman) && buyukH == false) 
                    {
                        buyukH = true;
                    }

                    if(Char.IsLower(eleman) && kucukH == false)
                    {
                        kucukH = true;
                    }

                    if(Char.IsNumber(eleman) && rakamsaldeger == false)
                    {
                        rakamsaldeger = true;
                    }

                    if(char.IsWhiteSpace(eleman) && boslukdegeri == false)
                    {
                        boslukdegeri = true;
                    }



                }
            }
        }

        internal void mailOlustur(string mail)
        {
            char[] mail_harfler = mail.ToCharArray();
            if(!Char.IsSymbol(mail_harfler[0]))
            {
                char at = '@';
                bool atK = false;
                foreach(char eleman in mail_harfler)
                {
                    if(eleman == at)
                    {
                        atK = true;
                        break;
                    }
                }

                if(atK == true)
                {
                    Console.WriteLine("Mail atandı");
                    this.mail = mail;   
                }
                else
                {
                    Console.WriteLine("Mail '@' işareti içermelidir");
                }

                
            }
            else
            {
                Console.WriteLine("Mail özel karekterle başlayamaz");
            }
        }

        internal void telefon_noOlustur(string telefon_no)
        {
            if(telefon_no.Length == 12)
            {
                char[] telefon_no_harfler = telefon_no.ToCharArray();
                foreach(char eleman in telefon_no_harfler)
                {

                }

            }
        }

        internal void isimOlustur(string isim)
        {
            char[] isim_harfler = isim.ToCharArray();
            if(Char.IsLetter(isim_harfler[0]))
            {
                bool ozelK = false;
                foreach(char eleman in isim_harfler)
                {
                    if(char.IsSymbol(eleman))
                    {
                        ozelK = true;
                        break;
                    }
                }

                if(ozelK == false)
                {
                    Console.WriteLine("Isim Atandi");
                    this.isim = isim;
                }
                else
                {
                    Console.WriteLine("Isim ozel karekter iceremez");
                }
            }
            else
            {
                Console.WriteLine("Isim harf ile baslamalidir");
            }
        }
    }

    internal class Yonetici : Kullanici
    {

    }

    internal class Satici : Kullanici
    {

    }

    internal class Müsteri : Kullanici
    {

    }
    

    internal class Program
    {
        internal static void Main()
        {
            while(true)
            {
                Kullanici kc = new Kullanici();
                Console.Write("ID: ");
                string mar = Console.ReadLine();
                kc.idOlustur(mar);
                Console.WriteLine(kc.id);
                Console.Write("\n");
            }



        }
    }
}
