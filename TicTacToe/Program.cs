using System;

namespace TicTacToe
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      var game = new Game();

      while (game.vyhra == false)
      {
        switch (game._hrac)
        {
          case 1:
            game.TahneClovek();
            break;
          case 2:
            game.TahneAI();
            break;
        }
      }
    }
  }
}