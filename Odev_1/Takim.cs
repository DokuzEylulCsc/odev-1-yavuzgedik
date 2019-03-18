using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Takim
    {
        Asker[] birlik = new Asker[7];

        public Asker[] Birlik { get { return birlik; } set { birlik = value; } }

        public Bolge BaslangicBolgesi { get; set; }
        public Bolge BitisBolgesi { get; set; }

        private int _askerSayisi = 7;
        public int HayattakiAskerSayisi
        {
            get { return _askerSayisi; }
            set
            {
                _askerSayisi = value;
            }
        }

        public string Ad { get; set; }
    }
}
