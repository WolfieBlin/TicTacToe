using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

namespace TicTacToe
{
    public class Game
    {
        public readonly string[,] pole = new string[3, 3];
        private Random _random = new Random();
        private HashSet<string> _index;
        private int pos;
        private bool _moznaRemiza = true;
        private string _zaznam;

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

        private void VypsaniText()
        {
            for (int i = 0; i < 3; i++)
            {
                _zaznam = _zaznam + "(";
                for (int j = 0; j < 3; j++)
                {
                    _zaznam = _zaznam + pole[j, i] + " ";
                }
                _zaznam = _zaznam + ") ";
            }

            _zaznam = _zaznam + Environment.NewLine;

            _zaznam.Replace('*', '0');
            _zaznam.Replace('X', '1');
            _zaznam.Replace('O', '2');
            if (vyhra)
            {
                File.WriteAllText(@"C:\Users\ufon2\Disk Google\+++Programko\C#\TicTacToe\TicTacToe\hry.txt",_zaznam);
            }
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
                    VypsaniText();
                }
            }
            else
            {
                if (pole[x, y] != "X" && pole[x, y] != "O")
                {
                    pole[x, y] = "O";
                    _hrac = 1;
                    Vypsani();
                    VypsaniText();
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

            if (Contains("*")&& vyhra == false)
            {
                Console.WriteLine("remíza");
                vyhra = true;
            }
        }

        private bool Contains(string value)
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (pole[i,j] == value)
                    {
                        _moznaRemiza = false;
                        break;
                    }

                    _moznaRemiza = true;
                }
            }

            return _moznaRemiza;
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