using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication3
{

    class Program
    {
       
        static void Main(string[] args)
        {
            #region prev
            /*int[] values = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            string[] initLetters = { "A", "B", "C", "D", "E", "F" };
            int[] numbers = { 1, 2, 3, 4, 5, 6 };
            string[] letters = {"A1", "B1", "C1","D1","E1","F1",
                               "A2", "B2", "C2","D2","E2","F2",
                               "A3", "B3", "C3","D3","E3","F3",
                               "A4", "B4", "C4","D4","E4","F4",
                               "A5", "B5", "C5","D5","E5","F5",
                               "A6", "B6", "C6","D6","E6","F6",};
            int i = 0;
            int n = 15;
            int coins = 10;

            Dictionary<string, int> board = new Dictionary<string, int>();

            foreach (var l in letters)
            {
                board.Add(l, i);
            }*/
            #endregion prev

            Dictionary<string, int> board = new Dictionary<string, int>();
            board.Add("A", 1);
            board.Add("B", 2);
            board.Add("C", 3);
            board.Add("D", 4);
            board.Add("E", 5);
            board.Add("F", 6);

            int[,] coinArray = new int[6, 6];
            string[,] emptyArray = new string[6, 6];

            int score = 0, coinsLeft = 6;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    emptyArray[i, j] = "x";
                    coinArray[i, j] = 0;
                }
            }
            Random randCoins = new Random();
            Random rand = new Random();

            for (int i = 0; i < 6; i++)
            {
                int k = 0;
                while (k < 1)
                {
                    int j = rand.Next(0, 6);
                    coinArray[i, j] = randCoins.Next(1, 11) * 10;
                    k++;
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("!------------Welcome to My Coin, Try to find coins------------!");
            Console.ResetColor();

            int attempts = 10;
            string letter = "";
            int number;
            string choice;

            while (attempts > 0)
            {
                Console.WriteLine("Your board is:");

                showArray(board, emptyArray);

                Console.WriteLine("Press key and value: ");
                choice = Console.ReadLine();
                letter = Regex.Match(choice, @"\s").Value;
                number = Int32.Parse(Regex.Match(choice, @"\d").Value);

                int check = checkValue(board, coinArray, emptyArray, letter, number);
                if (check > 0)
                {
                    coinsLeft--;
                    score = score + check;
                }
                attempts--;
                Console.WriteLine("Your score is: " + score);
                Console.WriteLine("Attempts left: " + attempts);
                Console.WriteLine("Coins to find: " + coinsLeft);
                Console.WriteLine("-------------------------------");
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Game over!");
            Console.ResetColor();
            Console.WriteLine("Your final score is: " + score);
            Console.ResetColor();
            Console.WriteLine("Your board was: ");
            PrintBoard(board, coinArray);
            Console.ReadKey();
        }

        public static void PrintBoard(Dictionary<string, int> board, int[,] coinArray)
        {
            Console.Write(" ");
            for (int i = 0; i < 6; i++)
            {
                Console.Write("\t" + board.Values.ElementAt(i));
            }

            Console.WriteLine();
            for (int i = 0; i < 6; i++)
            {
                Console.Write(board.Keys.ElementAt(i) + "\t");
                for (int j = 0; j < 6; j++)
                {
                    if (coinArray[i, j] == 0)
                    {
                        Console.Write("x\t");
                    }
                    else
                    {
                        Console.Write(coinArray[i, j] + "\t");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void showArray(Dictionary<string, int> board, string[,] emptyArray)
        {
            Console.Write(" ");
            for (int i = 0; i < 6; i++)
            {
                Console.Write("\t"+ board.Values.ElementAt(i));
            }

            Console.WriteLine();
            for (int i = 0; i < 6; i++)
            {
                Console.Write(board.Keys.ElementAt(i) + "\t");
                for (int j = 0; j < 6; j++)
                {
                    if (emptyArray[i, j] == "x")
                    {
                        Console.Write(emptyArray[i, j] + "\t");
                    }
                    else
                    {
                        Console.Write(emptyArray[i, j] + "\t");
                    }

                }
                Console.WriteLine();
            }
        }

        public static int checkValue(Dictionary<string, int> board, int[,] coinArray, string[,] emptyArray, string s, int x)
        {

            int temp1 = 0, temp2 = 0;
            for (int i = 0; i < 6; i++)
            {
                if (board.Values.ElementAt(i) == x)
                {
                    temp1 = x - 1;
                }

                if (board.Keys.ElementAt(i) == s)
                {
                    temp2 = i;
                }
            }
            if (coinArray[temp2, temp1] != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Well Done, You Earned {0} points!", coinArray[temp2, temp1]);
                Console.ResetColor();
                emptyArray[temp2, temp1] = coinArray[temp2, temp1].ToString();
                return coinArray[temp2, temp1];
            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ooops, You Missed");
                Console.ResetColor();
                return 0;
            }
        }


    
    
    
    }
}
