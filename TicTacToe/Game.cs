using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

namespace TicTacToe
{
    public class Game
    {
        public readonly string[,] pole = new string[3, 3];
        private Random _random = new Random();

        private int _hrac;
        private string _vitez;
        public bool vyhra;
        private int _x;
        private int _y;

        public Game()
        {
            _hrac = _random.Next(1, 3);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    pole[i, j] = "*";
                }
            }

            Vypsani();
        }

        //X = 1   O = 2
        public void Move(int x, int y)
        {
            if (_hrac == 1)
            {
                if (pole[x, y] != "X" && pole[x, y] != "O")
                {
                    pole[x, y] = "X";
                    _hrac = 2;
                    Vypsani();
                }
            }
            else
            {
                if (pole[x, y] != "X" && pole[x, y] != "O")
                {
                    pole[x, y] = "O";
                    _hrac = 1;
                    Vypsani();
                }
            }
        }

        private void Vypsani()
        {
            Console.WriteLine("  1 2 3");
            Console.WriteLine("1 {0} {1} {2}", pole[0, 0], pole[0, 1], pole[0, 2]);
            Console.WriteLine("2 {0} {1} {2}", pole[1, 0], pole[1, 1], pole[1, 2]);
            Console.WriteLine("3 {0} {1} {2}", pole[2, 0], pole[2, 1], pole[2, 2]);
            Vyhra();
        }

        private void Vyhra()
        {
            for (int i = 0; i < 3; i++)
            {
                if (pole[i, 0] != "*" && pole[i, 0] == pole[i, 1] && pole[i, 1] == pole[i, 2])
                {
                    _vitez = pole[i, 0];
                    vyhra = true;
                    break;
                }

                if (pole[0, i] != "*" && pole[0, i] == pole[1, i] && pole[1, i] == pole[2, i])
                {
                    _vitez = pole[0, i];
                    vyhra = true;
                    break;
                }

                if (pole[0, 0] != "*" && pole[0, 0] == pole[1, 1] && pole[1, 1] == pole[2, 2])
                {
                    _vitez = pole[1, 1];
                    vyhra = true;
                    break;
                }

                if (pole[0, 2] != "*" && pole[0, 2] == pole[1, 1] && pole[1, 1] == pole[2, 0])
                {
                    _vitez = pole[1, 1];
                    vyhra = true;
                    break;
                }
            }

            if (vyhra)
            {
                Console.WriteLine("Vyhrál hráč " + _vitez);
            }
        }

        private void TahneClovek()
        {
            var souradnice = Console.ReadLine();

            _x = Convert.ToInt32(souradnice[1].ToString()) - 1;
            _y = Convert.ToInt32(souradnice[0].ToString()) - 1;

            Move(_x, _y);
        }

        private void TahneAI()
        {
            Move(_random.Next(0, 3), _random.Next(0, 3));
        }

        public void Run()
        {
            while (vyhra == false)
            {
                switch (_hrac)
                {
                    case 1:
                        TahneClovek();
                        break;
                    case 2:
                        TahneAI();
                        break;
                }
            }
        }

    }
}