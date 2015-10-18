using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOtomasyon_BA
{
    public class Ebatlar
    {
        public string _ebatIsmi { get; private set; }
        public double _ebatFiyatCarpani { get; private set; }

        public Ebatlar(string ebatIsmi, double ebatFiyatCarpani)
        {
            this._ebatFiyatCarpani = ebatFiyatCarpani;
            this._ebatIsmi = ebatIsmi;
        }

    }
}
