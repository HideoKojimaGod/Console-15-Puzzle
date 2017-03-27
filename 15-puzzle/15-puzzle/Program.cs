using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace _15_puzzle
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int[] numberedSquare = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };
            Puzzle3 game = new Puzzle3(numberedSquare);
            //try 
            //{
            //    Line.Check(numberedSquare);
            //    game = new Puzzle(numberedSquare);
            //    try
            //    {
            //        game.Shift(12);
            //    }
            //    catch (ArgumentException e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }
            //    Console.WriteLine(game);
            //}
            //catch (ArgumentException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //try
            //{
            //    Console.WriteLine(Puzzle.FromCSV("input.csv"));
            //}
            //catch (ArgumentException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            game.Shift(15);
            game.Randomize();
            Console.WriteLine(game.GetAllHistory().Count);
            var c = new ConsoleGameUI(game);
            c.Output();
            c.Input();

        }
    }
}
