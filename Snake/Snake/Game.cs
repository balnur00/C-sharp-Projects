using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Snake
{
    
    public class Game
    {
        public static int interval = 300;
        public static int boardW = 35;
        public static int boardH = 35;
       

        public Worm worm;
        public Food food;
        public Wall wall;
        public bool isAlive;

        ThreadStart ts = null;
        Thread t = null;


        public List<GameObject> g_objects = new List<GameObject>();

        public void SetupBoard()
        {
            Console.SetWindowSize(Game.boardW, Game.boardH);
            Console.SetBufferSize(Game.boardW, Game.boardH);
            Console.CursorVisible = false;
        }

        public Game()
        {
            isAlive = true;

            worm = new Worm(new Point { X = 10, Y = 10 },
                            ConsoleColor.White, '*');
            food = new Food(new Point { X = 20, Y = 10 },
                           ConsoleColor.Magenta, 'o');
            wall = new Wall(null, ConsoleColor.White, '#');

            wall.LoadLevel(1);

            g_objects.Add(worm);
            g_objects.Add(food);
            g_objects.Add(wall);
        }


        public void Start()
        {
            ts = new ThreadStart(Draw);
            t = new Thread(ts);
            t.Start();
        }

        public void Stop()
        {
            t.Abort();
        }

        public void Draw()
        {
            food.Draw();


            wall.Draw();

            while (true)
            {
                worm.Move();
                

                if (worm.body[0].Equals(food.body[0]))
                {
                    worm.body.Add(new Point { X = food.body[0].X, Y = food.body[0].Y });
                    food.body[0] = food.CreateFood(wall.body, worm.body);

                    
                }
                else
                {
                    foreach (Point p in wall.body)
                    {
                        if (p.Equals(worm.body[0]))
                        {
                            Console.Clear();
                            Console.SetCursorPosition(10, Game.boardH / 2);
                            Console.WriteLine("GAME OVER!!!");
                            isAlive = false;
                            Console.ForegroundColor = ConsoleColor.Black;

                            Stop();

                        }
                    }
                }
                
                worm.Draw();
                food.Draw();
                Thread.Sleep(Game.interval);
            }
        }

       
        public void Exit()
        {
            Console.Clear();
            Stop();

        }
        public void Process(ConsoleKeyInfo pressedButton)
        {
            switch (pressedButton.Key)
            {
                case ConsoleKey.UpArrow:
                   
                    worm.DX = 0;
                    worm.DY = -1;

                    break;
                case ConsoleKey.DownArrow:
                  
                    worm.DX = 0;
                    worm.DY = 1;
                    break;
                case ConsoleKey.LeftArrow:
                   
                    worm.DX = -1;
                    worm.DY = 0;
                    break;
                case ConsoleKey.RightArrow:
                   
                    worm.DX = 1;
                    worm.DY = 0;
                    break;
                case ConsoleKey.Escape:
                    Console.Clear();
                    t.Abort();
                    Menu menu = new Menu();
                    menu.Process();
                    break;
                
            }
        }
    }
}