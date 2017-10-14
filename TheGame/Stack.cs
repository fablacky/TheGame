using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class Stack
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
            if (CanBeSet(value))
                CurrentValue = value;
            return CurrentValue == value;            
        }

        public bool CanBeSet(int value)
        {
            if (Direction == Direction.Ascending)
                return (CurrentValue < value || CurrentValue - 10 == value);
            else
                return (CurrentValue > value || CurrentValue + 10 == value);
        }
    }

    public enum Direction
    {
        Ascending,
        Discending
    }

}
