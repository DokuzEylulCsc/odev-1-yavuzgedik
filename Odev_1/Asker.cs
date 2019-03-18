using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    abstract class Asker
    {
        protected Random rnd;
        protected Asker vurulanAsker;
        protected Takim _digerTakim;

        public Asker()
        {
            rnd = new Random();
        }

        private Bolge koordinat;
        public Bolge Koordinat
        {
            get { return koordinat; }
            set { koordinat = value; }
        }

        public bool HayattaMi = true;
        public string Ad { get; set; }
        public Takim Takim { get; set; }
        public Ermeydani Ermeydani { get; set; }
        private int _saglik = 100;
        public int Saglik
        {
            get { return _saglik; }
            set
            {
                if (value < 0)
                {
                    _saglik = 0;
                }
                else
                {
                    _saglik = value;
                }
            }
        }

        //Abstract sınıfların implementasyonları çoçuk sınıflarda gerçekleştirilmelidir.
        protected abstract void HaraketEt(Bolge _koordinat, double karar);

        protected abstract void Bekle();

        protected abstract void AtesEt();

        protected abstract Asker Radar();

        public abstract int KararVer(Takim _takim);

    }
}
