﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_puzzle
{
    interface IPlayable
    {
        void Shift(int value);
        void Randomize();
        bool IsFinished();
        int SizeOfFrame { get; }
        int this[int x, int y] { get; }
    }
}
