using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    public class Complex
    {
        public Complex()
        {

        }
        public int a, b;
        public Complex(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            int k = c1.a + c2.a;
            int q = c1.b + c2.b;
            return new Complex(k, q);
        }

        public override string ToString()
        {
            return (String.Format("{0} + {1}i", a, b));
        }


    }
}
