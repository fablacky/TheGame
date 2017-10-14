﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class Engine
    {
        public void Start()
        {
            List<Stack> stacks = new List<Stack>();
            SituationEsit currentSituation = SituationEsit.KeepGoing;
            Stack s1 = new Stack(Direction.Ascending);
            Stack s2 = new Stack(Direction.Ascending);
            Stack s3 = new Stack(Direction.Discending);
            Stack s4 = new Stack(Direction.Discending);
            stacks.Add(s1); stacks.Add(s2); stacks.Add(s3); stacks.Add(s4);
            var deck = new Deck();
            deck.Shuffle();
            var mano = new Hand(deck);
            int value;
            while (true)
            {
                do
                {
                    do
                    {
                        Console.Clear();
                        DrawTable(stacks);
                        Console.WriteLine(mano.PrintHand());
                        Console.WriteLine("Che carta metti?");
                        value = int.Parse(Console.ReadLine());
                    } while (!mano.ValueIsInHand(value));
                    Console.WriteLine("Su quale stack?");
                    int stack = int.Parse(Console.ReadLine());
                    var consideredStack = (stack == 1) ? s1 : (stack == 2) ? s2 : (stack == 3) ? s3 : s4;
                    mano.SetCard(value, consideredStack);
                } while ((currentSituation = CheckSituation(stacks, mano)) == SituationEsit.KeepGoing);
                if (currentSituation == SituationEsit.Lost)
                {
                    Console.Clear();
                    Console.WriteLine("YOU LOSE");
                    Console.Read();
                }
            }
        }




        public void DrawTable(List<Stack> s)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("{0}{1}", "#1".PadLeft(6), "#2".PadLeft(25));
            Console.WriteLine(" ---------\t\t ---------");
            Console.WriteLine("|         |\t\t|         |");
            Console.WriteLine("|         |\t\t|         |");
            Console.WriteLine("|         |\t\t|         |");
            Console.WriteLine("|    {0}|\t\t|    {1}|", s[0].CurrentValue.ToString().PadRight(5), s[1].CurrentValue.ToString().PadRight(5));
            Console.WriteLine("|         |\t\t|         |");
            Console.WriteLine("|         |\t\t|         |");
            Console.WriteLine("|         |\t\t|         |");
            Console.WriteLine(" ----------\t\t ---------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("{0}{1}", "#3".PadLeft(6), "#4".PadLeft(25));
            Console.WriteLine(" ---------\t\t ---------");
            Console.WriteLine("|         |\t\t|         |");
            Console.WriteLine("|         |\t\t|         |");
            Console.WriteLine("|         |\t\t|         |");
            Console.WriteLine("|   {0}|\t\t|   {1}|", s[2].CurrentValue.ToString().PadRight(6), s[3].CurrentValue.ToString().PadRight(6));
            Console.WriteLine("|         |\t\t|         |");
            Console.WriteLine("|         |\t\t|         |");
            Console.WriteLine("|         |\t\t|         |");
            Console.WriteLine(" ---------\t\t ---------");
            Console.WriteLine();
            Console.WriteLine();
        }

        public SituationEsit CheckSituation(List<Stack> s, Hand h)
        {
            if (h.Cards.Count == 0)
                return SituationEsit.Won;

            int options = 0;
            foreach (Stack currentStack in s)
                foreach (int card in h.Cards)
                {
                    if (currentStack.CanBeSet(card))
                        options++;
                }
            return (options == 0) ? SituationEsit.Lost : SituationEsit.KeepGoing;
        }

        public enum SituationEsit
        {
            KeepGoing,
            Lost,
            Won
        }
    }
}