using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YarisSimlation
{
    public class Pist
    {
        private List<IYarismaci>[] pist;

        private int pistUzunlugu;
        public int PistUzunlugu
        {
            get { return pistUzunlugu; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException();
                pistUzunlugu = value;
            }
        }
        public Pist(int _pist)
        {
            PistUzunlugu = _pist;
            pist = new List<IYarismaci>[_pist + 1];
            for (int i = 0; i < pist.Length; i++)
            {
                pist[i] = new List<IYarismaci>(_pist + 1);
            }

        }


        public void DurumuYazdir()
        {
            for (int i = 0; i < pist.Length; i++)
            {
                for (int j = 0; j < pist[i].Count; j++)
                {
                    if (!(pist[i][j] is null))
                    {
                        Console.WriteLine(i + "::" + pist[i][j].YarismaciNo + " " + pist[i][j].Isim);
                    }

                }
            }

        }

        public List<IYarismaci> konumdakiyarismaci(int konum)
        {
            List<IYarismaci> n = new List<IYarismaci>();
            for (int i = 0; i < pist[konum].Count; i++)
            {
                if (!(pist[konum][i] is null))
                {
                    n.Add(pist[konum][i]);
                }
            }
            return n;
        }

        public void YarismciEkle(IYarismaci P1)
        {

            pist[0].Add(P1);
        }

        public void konumGuncelle()
        {


            for (int i = 0; i < pist.Length; i++)
            {

                for (int j = 0; j < pist[i].Count; j++)
                {
                    if (!(pist[i] is null))
                    {
                        //pist[i][j].HareketEt();
                        if (pist[i][j].Konum > pistUzunlugu)
                        {

                            pist[pistUzunlugu].Add(pist[i][j]);
                            pist[i].Remove(pist[i][j]);

                        }
                        else if (pist[i][j].Konum < 0)
                        {

                            pist[0].Add(pist[i][j]);
                            pist[i].Remove(pist[i][j]);
                        }
                        else
                        {
                            pist[pist[i][j].Konum].Add(pist[i][j]);
                            pist[i].Remove(pist[i][j]);
                        }
                    }

                }
            }


        }

    }
}
