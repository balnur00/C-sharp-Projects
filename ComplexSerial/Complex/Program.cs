using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Complex
{
    class Program
    {
        static void s(Complex a,Complex b){
            Complex c = a + b;
            FileStream fs = new FileStream("data.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            xs.Serialize(fs,c);
            fs.Close();
         }
        static Complex ds()
        {
            FileStream fs = new FileStream("data.xml", FileMode.Open, FileAccess.Read);
            Complex sum = new Complex();
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            sum = xs.Deserialize(fs) as Complex;
            fs.Close();
            return sum;

        }
        static void Main(string[] args)
        {
            Complex a = new Complex(3, 4);
            Complex b = new Complex(2, 1);

            // Complex sum = a + b;

            //catch (Exception e) { Console.WriteLine(e.ToString()); }
            //finally { fs.Close(); }

            s(a,b);
            Console.WriteLine(ds());
            Console.ReadKey();

            //Console.WriteLine("The sum of the two complex numbers: {0}", sum);
        }
    }
}
