using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _15_puzzle
{
    class Puzzle : IPlayable
    {
        private int[,] frame;
        public readonly int SizeOfFrame;
        protected Dictionary<int, Position> positions;
        public Puzzle(params int[] numberedSquare)
        {
            positions = new Dictionary<int,Position>();
            SizeOfFrame = Convert.ToInt32(Math.Sqrt(numberedSquare.Count()));
            frame = new int[SizeOfFrame, SizeOfFrame];
            for (int i = 0; i < SizeOfFrame; i++)
            {
                for (int j = 0; j < SizeOfFrame; j++)
                {
                    int value = numberedSquare[i * SizeOfFrame + j];
                    frame[i,j] = value;
                    positions.Add(value, new Position(i, j));
                }
            }
        }
        public int this[int x, int y]
        {
            get
            {
                return frame[x,y];
            }
            protected set
            {
                frame[x,y] = value;
            }
        }
        public Position GetLocation(int value)
        {       
           return positions[value];   
        }
        public virtual void Shift(int value)
        { 
            if (positions[value] - positions[0] == 1)
            {
                Position positionZero = positions[0];
                this[positions[0].X , positions[0].Y] = value;
                this[positions[value].X , positions[value].Y] = 0;
                positions[0] = positions[value];
                positions[value] = positionZero;
            }
            else throw new ArgumentException("Невозможно передвинуть фишку");
        }
        public static Puzzle FromCSV(string file)
        {
            string[] data = File.ReadAllLines(file);
            List<int> convertedData = new List<int>();
            for (int i = 0; i < data.Count(); i++)
            {
                for (int j = 0; j < data[i].Split(';').Count(); j++)
                {
                    convertedData.Add(Convert.ToInt32(data[i].Split(';')[j]));
                }
            }
            Line.Check(convertedData.ToArray<int>());
            return new Puzzle(convertedData.ToArray<int>());
        }
        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < SizeOfFrame; i++)
            {
                for (int j = 0; j < SizeOfFrame; j++)
                {
                    output += this[i, j] + "   ";
                }
                output += "\n";
            }
            return output;
        }
        protected List<int> CheckVarinatsOfReplace()
        {
            var variants = new List<int>();
            if (GetLocation(0).X != SizeOfFrame - 1)
                variants.Add(this[GetLocation(0).X + 1, GetLocation(0).Y]);
            if (GetLocation(0).X != 0)
                variants.Add(this[GetLocation(0).X - 1, GetLocation(0).Y]);
            if (GetLocation(0).Y != SizeOfFrame - 1)
                variants.Add(this[GetLocation(0).X, GetLocation(0).Y + 1]);
            if (GetLocation(0).Y != 0)
                variants.Add(this[GetLocation(0).X, GetLocation(0).Y - 1]);
            return variants;
        }
        public virtual void Randomize()
        {
            var n = SizeOfFrame * SizeOfFrame;
            var rand = new Random();
            for (int i = 0; i < n; i++)
            {
                var variants = CheckVarinatsOfReplace();
                Shift(variants[rand.Next(variants.Count - 1)]);
            }
        }

        public bool IsFinished()
        {
            for (int i = 0; i < SizeOfFrame; i++)
            {
                for (int j = 0; j < SizeOfFrame; j++)
                {
                    if (i == SizeOfFrame - 1 && j == SizeOfFrame - 1 && this[i, j] == 0)
                        continue;
                    else if (this[i, j] == i * SizeOfFrame + j + 1 && (i != SizeOfFrame - 1 || j != SizeOfFrame - 1))
                        continue;
                    else return false;
                }
            }
            return true;
        }
    }
}
