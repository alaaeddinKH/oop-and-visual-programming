using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YarisSimlation
{
    class DeveKusu : Hayvan
    {

        public DeveKusu(string _isim, Pist pist1, uint _yarismaciNO)
            : base(_isim, pist1, _yarismaciNO)
        {
            paralize = false;
        }
        public bool paralize { set; get; }

        public override void HareketEt()
        {

            if (Konum > yarismaPisti.PistUzunlugu)
            {
                Konum = yarismaPisti.PistUzunlugu;
            }
            else if (Konum<0)
            {
                Konum = 0;
            }
            else if (paralize == false)
            {

                int a = rng.Next(1, 101);
                if (a <= 50)//kosma
                {
                    if (Konum+3 > yarismaPisti.PistUzunlugu)
                    {
                        Konum = yarismaPisti.PistUzunlugu;
                    }
                    else
                    {
                        Konum = Konum + 3;
                    }
                    
                }

                else if (a > 50 && a <= 70)//hizli kosma
                {
                    if (Konum+6 > yarismaPisti.PistUzunlugu)
                    {
                        Konum = yarismaPisti.PistUzunlugu;
                    }
                    else
                    {
                        Konum = Konum + 6;
                    }
                    
                }
                else if (a > 70 && a <= 100)//geri
                {
                    if (Konum <= 3)
                    {
                        Konum = 0;
                    }
                    else
                    {
                        Konum = Konum - 4;

                    }
                        
                    //
                }
                else { }
            }

        }
    }
}
