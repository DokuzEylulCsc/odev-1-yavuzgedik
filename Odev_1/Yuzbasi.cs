using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Yuzbasi : Asker
    {
        public override int KararVer(Takim _takim)
        {
            _digerTakim = _takim;
            double karar = rnd.NextDouble();
            var _asker = Radar();
            vurulanAsker = _asker;

            int x = -1;
            if (karar < 0.4)
            {
                HaraketEt(Koordinat, karar);
                x = 0;
            }
            else if (karar >= 0.4 && karar < 0.8)
            {
                // ateş et
                AtesEt();
                x = 1;
            }
            else if (karar >= 0.8 && karar < 1)
            {
                Bekle();
                x = 2;
            }

            return x;
        }

        protected override Asker Radar()
        {
            Asker asker = new Er();
            for (int i = Koordinat.x - 3; i < Koordinat.x + 3; i++)
            {
                for (int j = Koordinat.y - 3; j < Koordinat.y + 3; j++)
                {
                    if (i >= 0 && j >= 0)
                    {
                        for (int t = 0; t < _digerTakim.Birlik.Length; t++)
                        {
                            if (_digerTakim.Birlik[t].Koordinat.x == i && _digerTakim.Birlik[t].Koordinat.y == j)
                            {
                                asker = _digerTakim.Birlik[t];
                                break;
                            }
                            else
                            {
                                asker = null;
                            }
                        }
                    }
                    else
                    {
                        asker = null;
                    }
                }
            }
            return asker;
        }

        protected override void AtesEt()
        {
            int[] vurusGucu = new int[3] { 15, 25, 40 };
            int sans = rnd.Next(0, 3);

            if (vurulanAsker != null)
            {
                vurulanAsker.Saglik = vurulanAsker.Saglik - vurusGucu[sans];
                if (vurulanAsker.Saglik == 0)
                {
                    _digerTakim.HayattakiAskerSayisi--;
                    vurulanAsker.HayattaMi = false;
                }

                Console.WriteLine($"{vurusGucu[sans]} vuruş yapıldı.");
            }
        }

        protected override void Bekle()
        {
            Console.WriteLine($"{Ad} Yüzbaşı Bekliyor.");
        }

        protected override void HaraketEt(Bolge _koordinat, double karar)
        {
            
            int x = _koordinat.x;
            int y = _koordinat.y;

            var bolge = Ermeydani.Harita[x, y] as Bolge;

            if(bolge.Asker == null)
            {
                if (karar < 0.05)
                {
                    // aşağı ilerle
                    Koordinat.y--;
                }
                else if (karar >= 0.05 && karar < 0.1)
                {
                    // yukarı ilerle
                    Koordinat.y++;
                }
                else if (karar >= 0.1 && karar < 0.15)
                {
                    // sağa ilerle
                    Koordinat.x++;
                }
                else if (karar >= 0.15 && karar < 0.2)
                {
                    // sola ilerle
                    Koordinat.x--;
                }
                else if (karar >= 0.2 && karar < 0.25)
                {
                    // sağ çapraz yukarı ilerle
                    Koordinat.x++;
                    Koordinat.y++;
                }
                else if (karar >= 0.25 && karar < 0.3)
                {
                    // sağ çapraz aşağı ilerle
                    Koordinat.x++;
                    Koordinat.y--;
                }
                else if (karar >= 0.3 && karar < 0.35)
                {
                    // sol çapraz yukarı ilerle
                    Koordinat.x--;
                    Koordinat.y++;
                }
                else if (karar >= 0.35 && karar < 0.4)
                {
                    // sol çapraz aşağı ilerle
                    Koordinat.x--;
                    Koordinat.y--;
                }


                Koordinat = _koordinat;
                Console.WriteLine($"{Ad} Yüzbaşı Harket Ediyor.");
            }
            else
            {
                Console.WriteLine($"{Ad} Yüzbaşı Harket Edemiyor. {x},{y} dolu");
            }
        }
    }
}
