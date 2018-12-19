using System;
using System.Runtime.InteropServices;

namespace TicTacToe
{
    public class RandomAI
    {
        Random random = new Random();
        private int _x;
        private int _y;

        public void Move()
        {
            _x = random.Next(0, 2);
            _y = random.Next(0, 2);
            
        }

    }
}