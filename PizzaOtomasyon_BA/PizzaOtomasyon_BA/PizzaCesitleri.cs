using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOtomasyon_BA
{
    public class PizzaCesitleri
    {
        public string _pizzaIsmi { get; private set; }
        public double _pizzaFiyat { get; private set; }

        public PizzaCesitleri(string pizzaIsmi, double pizzaFiyat)
        {
            this._pizzaIsmi = pizzaIsmi;
            this._pizzaFiyat = pizzaFiyat;
        }
    }
}
