using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    class Stack
    {
        public Direction Direction { get; set; }
        public int CurrentValue { get; set; }
        public Stack(Direction dir)
        {
            Direction = dir;
            if (dir.Equals(Direction.Ascending))
                CurrentValue = 1;
            else
                CurrentValue = 100;
        }

        public bool SetCardOnStack(int value)
        {
            if (Direction == Direction.Ascending && CurrentValue < value)
                CurrentValue = value;
            else if (Direction == Direction.Discending && CurrentValue > value)
                CurrentValue = value;
            else
                return false;
            return true;                
        }
    }

    enum Direction
    {
        Ascending,
        Discending
    }

}
