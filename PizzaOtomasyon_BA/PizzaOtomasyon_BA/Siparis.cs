using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOtomasyon_BA
{
    class Siparis
    {
        public string _sEbat { get; set; }
        public string _sPizzaIsmi { get; set; }
        public string _sKenarCesidi { get; set; }
        public List<Malzemeler> _sMalzemeler { get; set; }
        public double _sTutar { get; set; }

        private string malzeme;
        public override string ToString()
        {
            for (int i = 0; i < _sMalzemeler.Count; i++)
            {
                malzeme = malzeme + "," + _sMalzemeler[i]._malzemeIsmi.ToString();
            }
            return _sEbat + " " + _sPizzaIsmi + " " + _sKenarCesidi + " " + malzeme + " " + _sTutar;
        }
    }
}
