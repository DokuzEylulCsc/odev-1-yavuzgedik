using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Program
    {
        /*
          Örnek olması açısında iskelet kod hazır olarak verilmiştir. İmplementasyonunuz bunun üzerinden gerçekleştiriniz.
         */

        static void GameOver()
        {
            Console.WriteLine("Oyun Bitti.");
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();

            // Meydan oluşturuldu.
            Ermeydani meydan = new Ermeydani();
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    meydan.Harita[i,j] = new Bolge{ x = i, y = j, Asker = null };
                }
            }

            #region TAKIMLAR
            // Takımlar oluşturuldu. (Eşit, Adeletli İki Takım)
            Takim maviTakim = new Takim();
            Asker[] maviBirlik = new Asker[7];
            maviTakim.Ad = "Mavi Takım";
            maviTakim.BaslangicBolgesi = new Bolge { x = 0, y = 0 };
            maviTakim.BitisBolgesi = new Bolge { x = 4, y = 4 };
            for (int i = 0; i < maviBirlik.Length; i++)
            {
                bool state = false;
                while (!state)
                {
                    int _x = rnd.Next(maviTakim.BaslangicBolgesi.x, maviTakim.BitisBolgesi.x + 1);
                    int _y = rnd.Next(maviTakim.BaslangicBolgesi.x, maviTakim.BitisBolgesi.y + 1);

                    if (meydan.Harita[_x, _y].Asker == null)
                    {
                        if (i < 4)
                        {
                            Er _er = new Er();
                            _er.Takim = maviTakim;
                            _er.Ermeydani = meydan;
                            _er.Ad = " ME" + i + " ";
                            _er.Koordinat = new Bolge { x = _x, y = _y, Asker = _er };
                            meydan.Harita[_x, _y].Asker = _er;

                            maviBirlik[i] = _er;
                        }
                        else if (i >= 4 && i < 6)
                        {
                            Tegmen _tegmen = new Tegmen();
                            _tegmen.Takim = maviTakim;
                            _tegmen.Ermeydani = meydan;
                            _tegmen.Ad = " MT" + i + " ";
                            _tegmen.Koordinat = new Bolge { x = _x, y = _y, Asker = _tegmen };
                            meydan.Harita[_x, _y].Asker = _tegmen;
                            maviBirlik[i] = _tegmen;
                        }
                        else
                        {
                            Yuzbasi _yuzbasi = new Yuzbasi();
                            _yuzbasi.Takim = maviTakim;
                            _yuzbasi.Ermeydani = meydan;
                            _yuzbasi.Ad = " MY" + i + " ";
                            _yuzbasi.Koordinat = new Bolge { x = _x, y = _y, Asker = _yuzbasi };
                            meydan.Harita[_x, _y].Asker = _yuzbasi;
                            maviBirlik[i] = _yuzbasi;
                        }
                        state = true;
                    }
                }
            }
            maviTakim.Birlik = maviBirlik;

            Takim kirmiziTakim = new Takim();
            Asker[] kirmiziBirlik = new Asker[7];
            kirmiziTakim.Ad = "Kırmızı Takım";
            kirmiziTakim.BaslangicBolgesi = new Bolge { x = 11, y = 11 };
            kirmiziTakim.BitisBolgesi = new Bolge { x = 15, y = 15 };
            for (int i = 0; i < kirmiziBirlik.Length; i++)
            {
                bool state = false;
                while (!state)
                {
                    int _x = rnd.Next(kirmiziTakim.BaslangicBolgesi.x, kirmiziTakim.BitisBolgesi.x + 1);
                    int _y = rnd.Next(kirmiziTakim.BaslangicBolgesi.y, kirmiziTakim.BitisBolgesi.y + 1);

                    if (meydan.Harita[_x, _y].Asker == null)
                    {
                        if (i < 4)
                        {
                            Er _er = new Er();
                            _er.Takim = kirmiziTakim;
                            _er.Ermeydani = meydan;
                            _er.Ad = " KE" + i + " ";
                            _er.Koordinat = new Bolge { x = _x, y = _y, Asker = _er };
                            meydan.Harita[_x, _y].Asker = _er;
                            kirmiziBirlik[i] = _er;
                        }
                        else if (i >= 4 && i < 6)
                        {
                            Tegmen _tegmen = new Tegmen();
                            _tegmen.Takim = kirmiziTakim;
                            _tegmen.Ermeydani = meydan;
                            _tegmen.Ad = " KT" + i + " ";
                            _tegmen.Koordinat = new Bolge { x = _x, y = _y, Asker = _tegmen };
                            meydan.Harita[_x, _y].Asker = _tegmen;
                            kirmiziBirlik[i] = _tegmen;
                        }
                        else
                        {
                            Yuzbasi _yuzbasi = new Yuzbasi();
                            _yuzbasi.Takim = kirmiziTakim;
                            _yuzbasi.Ermeydani = meydan;
                            _yuzbasi.Ad = " KY" + i + " ";
                            _yuzbasi.Koordinat = new Bolge { x = _x, y = _y, Asker = _yuzbasi };
                            meydan.Harita[_x, _y].Asker = _yuzbasi;
                            kirmiziBirlik[i] = _yuzbasi;
                        }
                        state = true;
                    }
                }
            }
            kirmiziTakim.Birlik = kirmiziBirlik;
            #endregion

            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    if (meydan.Harita[i, j].Asker != null)
                    {
                        Console.Write(meydan.Harita[i, j].Asker.Ad);
                    }
                    else
                    {
                        Console.Write(" ___ ");
                    }
                }
                Console.WriteLine();
            }


            bool gameState = true;
            while (gameState)
            {
                // Mavi Takim Siradaki Asker
                bool maviState = false;
                while (!maviState)
                {
                    int maviTakimSiradakiAsker = rnd.Next(0, maviTakim.Birlik.Length);

                    if (maviTakim.Birlik[maviTakimSiradakiAsker].HayattaMi)
                    {
                        maviState = true;
                        int x = maviTakim.Birlik[maviTakimSiradakiAsker].KararVer(kirmiziTakim);

                        if (x == 0)
                        {
                            for (int i = 0; i < 16; i++)
                            {
                                for (int j = 0; j < 16; j++)
                                {
                                    if (meydan.Harita[i, j].Asker != null)
                                    {
                                        Console.Write(meydan.Harita[i, j].Asker.Ad);
                                    }
                                    else
                                    {
                                        Console.Write(" ___ ");
                                    }
                                }
                                Console.WriteLine();
                            }
                            Console.WriteLine("Press Enter");
                            Console.ReadKey();
                        }

                        if (kirmiziTakim.HayattakiAskerSayisi == 0)
                        {
                            GameOver();
                            gameState = false;
                        }
                    }
                }

                // Kirmizi Takim Siradaki Asker
                bool kirmiziState = false;
                while (!kirmiziState)
                {
                    int kirmiziTakimSiradakiAsker = rnd.Next(0, kirmiziTakim.Birlik.Length);

                    if (kirmiziTakim.Birlik[kirmiziTakimSiradakiAsker].HayattaMi)
                    {
                        kirmiziState = true;
                        int x = kirmiziTakim.Birlik[kirmiziTakimSiradakiAsker].KararVer(maviTakim);

                        if (x == 0)
                        {
                            for (int i = 0; i < 16; i++)
                            {
                                for (int j = 0; j < 16; j++)
                                {
                                    if (meydan.Harita[i, j].Asker != null)
                                    {
                                        Console.Write(meydan.Harita[i, j].Asker.Ad);
                                    }
                                    else
                                    {
                                        Console.Write(" ___ ");
                                    }
                                }
                                Console.WriteLine();
                            }

                            Console.WriteLine("Press Enter");
                            Console.ReadKey();
                        }

                        if (maviTakim.HayattakiAskerSayisi == 0)
                        {
                            GameOver();
                            gameState = false;
                        }
                    }
                }
            }
        }
    }
}