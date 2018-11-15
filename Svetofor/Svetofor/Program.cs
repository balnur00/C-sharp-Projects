using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Svetofor
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.Clear();
            Console.CursorVisible = false;
            int x = 25;
            int y = 1;
            for (int i = 1; i < 6; i++) {
                ThreadStart tsR = new ThreadStart(ChangeCoR);
                Thread tR = new Thread(tsR);
                tR.Start();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(x, y);
                Console.WriteLine("***");
                Console.SetCursorPosition(x - i, y + i);
                Console.WriteLine("*****");
                Console.SetCursorPosition(x - i - 1, y + i + 1);
                Console.WriteLine("*******");
                Console.SetCursorPosition(x - i, y + i + 2);
                Console.WriteLine("*****");
                Console.SetCursorPosition(x, y + i + 3);
                Console.WriteLine("***");
                break;
            }
            for (int i = 1; i < 6; i++)
            {
                ThreadStart tsY = new ThreadStart(ChangeCoY);
                Thread tY = new Thread(tsY);
                tY.Start();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(x, y + 5);
                Console.WriteLine("***");
                Console.SetCursorPosition(x - i, y + i + 5);
                Console.WriteLine("*****");
                Console.SetCursorPosition(x - i - 1, y + i + 6);
                Console.WriteLine("*******");
                Console.SetCursorPosition(x - i, y + i + 7);
                Console.WriteLine("*****");
                Console.SetCursorPosition(x, y + i + 8);
                Console.WriteLine("***");
                break;
            }
            for (int i = 1; i < 6; i++)
            {
                ThreadStart tsG = new ThreadStart(ChangeCoG);
                Thread tG = new Thread(tsG);
                tG.Start();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(x, y + 10);
                Console.WriteLine("***");
                Console.SetCursorPosition(x - i, y + i + 10);
                Console.WriteLine("*****");
                Console.SetCursorPosition(x - i - 1, y + i + 11);
                Console.WriteLine("*******");
                Console.SetCursorPosition(x - i, y + i + 12);
                Console.WriteLine("*****");
                Console.SetCursorPosition(x, y + i + 13);
                Console.WriteLine("***");
                break;
            }
            Console.ReadKey();
        }

        private static void ChangeCoR()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(3000);
        }

        private static void ChangeCoY()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(1000);
        }

        private static void ChangeCoG()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(2000); 
        }
    }
}
