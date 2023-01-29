using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YarisSimlation
{
    public class Cakal : Hayvan
    {
        public Cakal(string _isim, uint _yarismaciNO, Pist pist1)
            : base(_isim, pist1, _yarismaciNO)
        {

        }

        public override void HareketEt()
        {
            if (Konum > yarismaPisti.PistUzunlugu)
            {
                Konum = yarismaPisti.PistUzunlugu;
            }
            else
            {

                int a = rng.Next(1, 11);
                if (a <= 5)
                {
                    if (Konum+2 > yarismaPisti.PistUzunlugu)
                    {
                        Konum = yarismaPisti.PistUzunlugu ;
                    }
                    else
                    {
                        Konum = Konum + 2;
                    }

                    
                }

                else if (a == 6 || a == 10)
                {
                    if (Konum <= 3)
                        Konum = 0;
                    else
                        Konum = Konum - 4;


                }
                else if (a > 6 && a < 10)
                {
                    if (Konum+3> yarismaPisti.PistUzunlugu)
                    {
                        Konum = yarismaPisti.PistUzunlugu ;
                    }
                    else
                    {
                        Konum = Konum + 3;
                    }
                    
                }
                else { }
            }
        }
    }
}
