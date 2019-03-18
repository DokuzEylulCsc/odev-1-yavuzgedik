using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Tegmen : Asker
    {
        protected override void Bekle()
        {
            Console.WriteLine($"{Ad} Teğmen Bekliyor.");
        }

        protected override void HaraketEt(Bolge _koordinat, double karar)
        {
            var oldBolge = Ermeydani.Harita[_koordinat.x, _koordinat.y] as Bolge;

            if (karar < 0.1)
            {
                // aşağı ilerle
                _koordinat.x++;

                var bolge = Ermeydani.Harita[_koordinat.x, _koordinat.y] as Bolge;
                if (bolge.Asker == null)
                {
                    Koordinat.x++;
                    bolge.Asker = this;
                    oldBolge.Asker = null;
                }
            }
            else if (karar >= 0.1 && karar < 0.2)
            {
                // yukarı ilerle
                _koordinat.x--;

                var bolge = Ermeydani.Harita[_koordinat.x, _koordinat.y] as Bolge;
                if (bolge.Asker == null)
                {
                    Koordinat.x--;
                    bolge.Asker = this;
                    oldBolge.Asker = null;
                }
            }
            else if (karar >= 0.2 && karar < 0.3)
            {
                // sağa ilerle
                _koordinat.y++;

                var bolge = Ermeydani.Harita[_koordinat.x, _koordinat.y] as Bolge;
                if (bolge.Asker == null)
                {
                    Koordinat.y++;
                    bolge.Asker = this;
                    oldBolge.Asker = null;
                }
            }
            else if (karar >= 0.3 && karar < 0.4)
            {
                // sola ilerle
                _koordinat.y--;

                var bolge = Ermeydani.Harita[_koordinat.x, _koordinat.y] as Bolge;
                if (bolge.Asker == null)
                {
                    Koordinat.y--;
                    bolge.Asker = this;
                    oldBolge.Asker = null;
                }
            }
            Console.WriteLine($"{Ad} Teğmen Harket Ediyor.");
        }

        protected override void AtesEt()
        {
            int[] vurusGucu = new int[3] { 10, 20, 25 };
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

        public override int KararVer(Takim _takim)
        {
            _digerTakim = _takim;
            rnd = new Random();
            double karar = rnd.NextDouble();
            var _asker = Radar();
            vurulanAsker = _asker;

            int x = -1;
            if (karar < 0.4)
            {
                HaraketEt(Koordinat, karar);
                x = 0;
            }
            else if (karar >= 0.4 && karar < 0.7)
            {
                AtesEt();
                x = 1;
            }
            else if (karar >= 0.7 && karar < 1)
            {
                Bekle();
                x = 2;
            }

            return x;
        }

        protected override Asker Radar()
        {
            var state = false;
            Asker asker = new Er();
            for (int i = Koordinat.x - 2; i < Koordinat.x + 2; i++)
            {
                if (!state)
                {
                    for (int j = Koordinat.y - 2; j < Koordinat.y + 2; j++)
                    {
                        if (!state)
                        {
                            if (i >= 0 && j >= 0)
                            {
                                for (int t = 0; t < _digerTakim.Birlik.Length; t++)
                                {
                                    if (_digerTakim.Birlik[t].Koordinat.x == i && _digerTakim.Birlik[t].Koordinat.y == j)
                                    {
                                        asker = _digerTakim.Birlik[t];
                                        state = true;
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
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            return asker;
        }
    }
}
