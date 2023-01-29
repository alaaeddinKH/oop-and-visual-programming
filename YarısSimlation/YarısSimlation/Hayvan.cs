using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YarisSimlation
{
    public abstract class Hayvan : IYarismaci
    {
        private string isim;
        protected Random rng = new Random();
        private uint yarismaciNo;
        protected Pist yarismaPisti;

        public Hayvan(string _isim, Pist pist1, uint _yarismaciNO)
        {
            Isim = _isim;
            YarismaciNo = _yarismaciNO;
            yarismaPisti = pist1;
            Konum = 0;


        }

        public string Isim
        {
            get { return isim; }

            set
            {
                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException();

                isim = value;
            }
        }
        public int Konum { set; get; }
        

        public uint YarismaciNo
        {
            get { return yarismaciNo; }
            set
            {
                if (value < 1)
                    throw new Exception();
                yarismaciNo = value;
            }
        }



        public abstract void HareketEt();
    }
}
