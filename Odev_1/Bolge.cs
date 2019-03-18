using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Bolge
    {
        private int _x = 0;
        private int _y = 0;
        public int x
        {
            get { return _x; }
            set
            {
                if( value < 0)
                {
                    _x = 0;
                }
                else if (value > 15)
                {
                    _x = 15;
                }
                else
                {
                    _x = value;
                }
            }
        }
        public int y
        {
            get { return _y; }
            set
            {
                if (value < 0)
                {
                    _y = 0;
                }
                else if (value > 15)
                {
                    _y = 15;
                }
                else
                {
                    _y = value;
                }
            }
        }
        public Asker Asker { get; set; }

    }
}
