using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOtomasyon_BA
{
    class Malzemeler
    {
        public string _malzemeIsmi { get; private set; }

        public Malzemeler(string malzemeIsmi)
        {
            this._malzemeIsmi = malzemeIsmi;
        }
    }
}
