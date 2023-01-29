using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YarisSimlation
{
    public interface IYarismaci
    {
        string Isim { get; set; }
        int Konum { get; set; }

        uint YarismaciNo { get; set; }


        void HareketEt();
    }
}
