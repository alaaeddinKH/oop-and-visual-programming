using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YarisSimlation
{

    class MekanikFil : Robot
    {
        public MekanikFil(string _isim, Pist pist1, uint _yarismaciNo)
            : base(_isim, pist1, _yarismaciNo)
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
                if (a <= 4)
                {
                    if(Konum+2 > yarismaPisti.PistUzunlugu)
                    {
                        Konum = yarismaPisti.PistUzunlugu ;
                    }
                    else 
                    { Konum = Konum + 2; }
                    
                }

                else if (a == 5)
                {
                    if (Konum+3 > yarismaPisti.PistUzunlugu)
                    {
                        Konum = yarismaPisti.PistUzunlugu;
                    }
                    else
                    { Konum = Konum + 3; }
                        

                }
                else { }
            }

        }
    }
}
