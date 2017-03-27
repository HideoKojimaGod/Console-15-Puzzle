﻿using System;
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
            Console.WriteLine(Puzzle as Puzzle);
        }
    }
}
