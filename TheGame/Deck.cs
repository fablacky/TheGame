using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class Deck
    {
        List<int> Cards;

        public Deck()
        {
            Cards = new List<int>();
            for (int n = 2; n < 100; n++)
                Cards.Add(n);
        }

        public void Shuffle()
        {
            Random rand = new Random();
            Cards = Cards.OrderBy(c => rand.Next()).ToList();
        }

        public List<int> Draw(int count)
        {
            var result = Cards.Take(count).ToList();
            Cards.RemoveRange(0, count);
            return result;
        }
    }
}
