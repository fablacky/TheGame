using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class Hand
    {
        public List<int> Cards { get; set; }
        private Deck _deck { get; set; }

        public Hand(Deck deck)
        {
            Cards = new List<int>();
            _deck = deck;
            Cards.AddRange(_deck.Draw(7));
        }

        public bool SetCard(int cardValue, Stack s)
        {
            if (Cards.Contains(cardValue))
            {
                if (s.SetCardOnStack(cardValue))
                   if (Cards.Remove(cardValue))
                        Cards.Add(_deck.Draw(1).First());
                return true;
            }
            return false;
        }

        public string PrintHand()
        {
            string res = string.Empty;
            Cards.Sort();
            foreach (var item in Cards)
            {
                res += item.ToString() + " ";
            }
            return res;
        }

        public bool ValueIsInHand(int value)
        {
            return Cards.Contains(value);
        }
    }
}
