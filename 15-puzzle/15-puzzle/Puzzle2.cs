using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_puzzle
{
    class Puzzle2 : Puzzle
    {
        public Puzzle2(params int[] numberedSquare) : base(numberedSquare)
        {  
        }
        
        public static Puzzle2 CreateRandom(int sizeOfFrame)
        {
            int[] numberedSquare = new int[sizeOfFrame * sizeOfFrame];
            for (int i = 0; i < sizeOfFrame * sizeOfFrame; i++)
                numberedSquare[i] = i;
            var randomPuzzle = new Puzzle2(numberedSquare);
            randomPuzzle.Randomize();
            return randomPuzzle;
        }
        
    }
}
