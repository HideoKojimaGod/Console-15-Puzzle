using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_puzzle
{
    class ConsoleGameUI
    {
        public IPlayable Puzzle;
        public ConsoleGameUI(IPlayable Puzzle)
        {
            this.Puzzle = Puzzle;
        }
        public void Input()
        {
            int value = Convert.ToInt32(Console.ReadLine());
            Puzzle.Shift(value);
        }
        public void Output()
        {
            string output = "";
            for (int i = 0; i < Puzzle.SizeOfFrame; i++)
            {
                for (int j = 0; j < Puzzle.SizeOfFrame; j++)
                {
                    output += Puzzle[i, j] + "   ";
                }
                output += "\n";
            }
            Console.WriteLine(output); 
            //Console.WriteLine(Puzzle);
        }
        public void StartGame()
        {
            while(true)
            {
                Output();
                Input(); 
            }
        }
    }
}
