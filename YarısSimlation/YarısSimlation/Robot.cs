using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YarisSimlation
{
    abstract class Robot : IYarismaci
    {
        private string isim;
        protected Random rng = new Random();
        private uint yarismaciNo;
        protected Pist yarismaPisti;

        public Robot(string _isim, Pist pist1, uint _yarismaciNo)
        {
            Isim = _isim;
            YarismaciNo = _yarismaciNo;
            Konum = 0;
            yarismaPisti = pist1;
            Bozuldu = false;

        }
        protected bool Bozuldu { get; set; }
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

        public bool YarismaciDurumu { get; set; }


        public virtual void HareketEt()
        {
            Konum = Konum + 1;
        }


    }
}
