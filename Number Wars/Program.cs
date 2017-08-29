using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Card:IComparable<Card>
{
    public Card(int number, string letter)
    {
        this.Number = number;
        this.Letter = letter;
    }

    public int Number { get; }
    public string Letter { get; }

    public int CompareTo(Card other)
    {
        var result = other.Number.CompareTo(this.Number);
        if(result != 0) { return result; }
        return other.Letter.CompareTo(this.Letter);
    }
}

public class Program
{
    public static void Main()
    {
        Queue<Card> player1 = new Queue<Card>();
        Queue<Card> player2 = new Queue<Card>();

        var first = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        ReadCards(player1, first);

        var second = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        ReadCards(player2, second);
      

        int turns = 0;
        while (turns < 1000000 && (player1.Count > 0 && player2.Count > 0))
        {
            ++turns;
            var currantCardPlayer1 = player1.Dequeue();
            var currantCardPlayer2 = player2.Dequeue();

            if (currantCardPlayer1.Number > currantCardPlayer2.Number)
            {
                player1.Enqueue(currantCardPlayer1);
                player1.Enqueue(currantCardPlayer2);
            }
            else if (currantCardPlayer1.Number < currantCardPlayer2.Number)
            {
                player2.Enqueue(currantCardPlayer2);
                player2.Enqueue(currantCardPlayer1);
            }
            else// war
            {
                bool hasWinner = false;
                string alphabet = "abcdefghijklmnopqrstuvwxyz";
                List<Card> warDack = new List<Card>();
                warDack.Add(currantCardPlayer1);
                warDack.Add(currantCardPlayer2);

                while (hasWinner == false && (player1.Count > 0 && player2.Count > 0))
                {
                    var player1WarDack = player1.Take(3);
                    warDack.AddRange(player1WarDack);
                    var cards1 = player1WarDack.Select(i => i.Letter).ToArray();

                    var player2WarDack = player2.Take(3);
                    warDack.AddRange(player2WarDack);
                    var cards2 = player2WarDack.Select(i => i.Letter).ToArray();

                    int sum1 = 0, sum2 = 0;
                    sum1 = GetSum(alphabet, cards1, sum1);
                    sum2 = GetSum(alphabet, cards2, sum2);

                    ThrowThreeOrLessCards(player1, cards1);
                    ThrowThreeOrLessCards(player2, cards2);
                    
                    //check for winner
                    if (sum1 != sum2)
                    {
                        warDack.Sort();
                        var winner = sum1 > sum2 ? player1 : player2;
                        for (int i = 0; i < warDack.Count(); i++)
                        {
                            winner.Enqueue(warDack[i]);
                        }
                        hasWinner = true;
                    }
                }
            }
        }

        if (player1.Count != player2.Count)
        {
            Console.WriteLine("{0} player wins after {1} turns", player1.Count > player2.Count ? "First" : "Second", turns);
        }
        else { Console.WriteLine("Draw after {0} turns", turns); }

    }

    private static void ThrowThreeOrLessCards(Queue<Card> playerDack, string[] cards)
    {
        for (int i = 0; i < cards.Count(); i++)
        {
            playerDack.Dequeue();
        }
    }

    private static int GetSum(string alphabet, string[] cards, int sum)
    {
        for (int i = 0; i < cards.Length; i++)
        {
            sum += (alphabet.IndexOf(cards[i])) + 1;
        }

        return sum;
    }

    private static void ReadCards(Queue<Card> playerDack, string[] first)
    {
        for (int i = 0; i < first.Length; i++)
        {
            int number = int.Parse(first[i].Substring(0, first[i].Length - 1));
            string letter = (first[i].Last()).ToString();

            playerDack.Enqueue(new Card(number, letter));
        }
    }
}

