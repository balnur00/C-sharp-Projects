using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            int index = 0;
            string[] num = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            while (true)
            {
                if (index == 12)
                {
                    index = 0;
                }
                for (int i = 0; i < num.Length; ++i)
                {
                    if(index == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    Console.SetCursorPosition(i+5, i);
                    Console.WriteLine(num[i]);
                }
                index++;
                Thread.Sleep(1000);
            }
        }
    }
}
