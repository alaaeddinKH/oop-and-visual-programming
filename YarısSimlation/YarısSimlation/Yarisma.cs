using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace YarisSimlation
{
   class Yarisma
    {
        public int p=1;
        public string avlayan="";
        DeveKusu paraliz;
        public List<IYarismaci> yarismacilar;
        public Pist yarismaPisti;


        public void sifirla()
        {
            p = 1;
            avlayan = "";
            foreach (var eleman in yarismacilar)
                eleman.Konum = 0;
            foreach (var eleman in yarismacilar) //Pistteki konumlari guncellemek yeni kullanmak icin
            {
                yarismaPisti.konumGuncelle();
            }
            //devekusu olan yarismaci isaretleyecek ve ondan paralizeinin deheri degistirebiliriz
            foreach (var eleman in yarismacilar)//paralize edilmis devekusu tekrar calistirabilmek icin
            {

                if (eleman is DeveKusu)
                {
                    paraliz = (DeveKusu)eleman;
                    paraliz.paralize = false;
                }

            }
        }

        public int maxKonum()
        {
            int max = yarismacilar[0].Konum;
            for(int i=0;i<yarismacilar.Count;i++)
            {
                if (max < yarismacilar[i].Konum)
                    max = yarismacilar[i].Konum;
            }
            return max;
        }
        public void Baslat()
        {
            
            /*foreach (var eleman in yarismacilar)// konumlari sifirla yarisma yeni kullanmak icin
                eleman.Konum = 0;*/
           
            do
            {
                foreach (var eleman in yarismacilar)
                    if (eleman.Konum >= 45)
                        break;
                foreach (var eleman in yarismacilar)
                    eleman.HareketEt();

                    foreach (var eleman in yarismacilar)
                    {
                    yarismaPisti.konumGuncelle();
                    }
                 for (int j = 0; j < yarismacilar.Count; j++)//ozel durumlar
                 {
                     var b = yarismacilar[j];
                     for (int i = j + 1; i < yarismacilar.Count; i++)
                     {
                         if (b.Konum == yarismacilar[i].Konum)
                         {
                             if (b is Cakal && yarismacilar[i] is DeveKusu)
                             {
                                 Random r1 = new Random();
                                 if (r1.Next(1, 101) <= 50)
                                 {
                                     paraliz = (DeveKusu)yarismacilar[i];
                                     paraliz.paralize = true;
                                    p = 0;
                                    avlayan = "Cakal";
                                }
                             }
                             else if ((b is DeveKusu && yarismacilar[i] is Cakal))
                             {
                                 Random r1 = new Random();
                                 if (r1.Next(1, 101) > 50)
                                 {
                                     paraliz = (DeveKusu)b;
                                     paraliz.paralize = true;
                                    p = 0;
                                    avlayan = "Cakal";
                                }

                             }
                             else if (b is MekanikFil && yarismacilar[i] is DeveKusu)
                             {
                                 Random r1 = new Random();
                                 if (r1.Next(1, 6) == 3)
                                 {
                                     paraliz = (DeveKusu)yarismacilar[i];
                                     paraliz.paralize = true;
                                    p = 0;
                                    avlayan = "Mekanik fil";
                                }

                             }
                             else if (b is DeveKusu && yarismacilar[i] is MekanikFil)
                             {
                                 Random r1 = new Random();
                                 if (r1.Next(1, 6) == 3)
                                 {
                                     paraliz = (DeveKusu)b;
                                     paraliz.paralize = true;
                                    p = 0;
                                    avlayan = "Mekanik fil";
                                }

                             }
                             else if (b is SalyanBot && yarismacilar[i] is Hayvan)
                             {
                                 Random r1 = new Random();
                                 if (r1.Next(1, 5) == 2)
                                 {
                                     if(yarismacilar[i].Konum>0)
                                         yarismacilar[i].Konum--;
                                    foreach (var eleman in yarismacilar)
                                    {
                                        yarismaPisti.konumGuncelle();
                                    }
                                }

                             }
                             else if (b is Hayvan && yarismacilar[i] is SalyanBot)
                             {
                                 Random r1 = new Random();
                                 if (r1.Next(1, 5) == 2)
                                 {
                                    if (b.Konum > 0)
                                        if(b is DeveKusu)
                                        {
                                            if(paraliz.paralize==true)
                                            {

                                            }
                                            else
                                            {
                                                b.Konum--;
                                            }
                                        }
                                        else
                                        {
                                            b.Konum--;
                                        }
                                        
                                    foreach (var eleman in yarismacilar)
                                    {
                                        yarismaPisti.konumGuncelle();
                                    }
                                }

                             }
                         }
                     }

                 }
                foreach (var eleman in yarismacilar)
                    if (eleman.Konum >= 45)
                        break;
                        
                Thread.Sleep(275);
                break;
            } while (true);
        }
        public void KonumlariYazdir()
        {
            yarismaPisti.DurumuYazdir();            
        }
        public Yarisma(string yarismaciDosyasiYolu,int pistuzunlugu)
        {
            var pist1 = new Pist(pistuzunlugu);
            yarismaPisti = pist1;
            string a;
            yarismacilar = new List<IYarismaci>(pistuzunlugu + 1);
             
            StreamReader sr = new StreamReader(yarismaciDosyasiYolu);
            
            
            for (int i=0;i< pistuzunlugu;i++)
            {
                
                a = sr.ReadLine();
                if (a == null)
                    break;
                
                var j = a.Split(' ',' ');
                if (j[2] == "CAKAL" || j[2] == "Cakal" || j[2] == "cakal")
                {
                    Hayvan y = new Cakal(j[1], Convert.ToUInt32(j[0]),pist1);
                    yarismacilar.Add(y);
                    pist1.YarismciEkle(y);
                }
                else if (j[2] == "MEKANIKFIL" || j[2] == "MekanikFil" || j[2] == "mekanikfil" || j[2] == "Mekanikfil")
                {
                    Robot y = new MekanikFil(j[1], pist1, Convert.ToUInt32(j[0]));
                    yarismacilar.Add(y);
                    pist1.YarismciEkle(y);
                }
                else if (j[2] == "SALYANBOT" || j[2] == "salyanbot" || j[2] == "SalyanBot" || j[2] == "Salyanbot")
                {
                    Robot y = new SalyanBot(j[1], pist1, Convert.ToUInt32(j[0]));
                    yarismacilar.Add(y);
                    pist1.YarismciEkle(y);
                }
                else if (j[2] == "DeveKusu" || j[2] == "DEVEKUSU" || j[2] == "Devekusu" || j[2] == "devekusu")
                {
                    Hayvan y = new DeveKusu(j[1], pist1, Convert.ToUInt32(j[0]));
                    yarismacilar.Add(y);
                    pist1.YarismciEkle(y);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }

            }
            sr.Close();
        }
    }
}
