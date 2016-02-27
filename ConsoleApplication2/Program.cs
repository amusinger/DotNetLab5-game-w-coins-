using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            int[] values = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            string[] initLetters = {"A", "B", "C","D","E","F"};
            int[] numbers = {1,2,3,4,5,6};
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
            }
            board["B1"] = 10;
            board["A3"] = 50;
            board["A6"] = 60;
            board["D1"] = 100;
            board["D3"] = 20;
            board["D4"] = 30;
            board["F1"] = 40;
            board["F3"] = 90;
            board["F6"] = 80;

            string choice;
            int point = 0;
            bool final = false;

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("!---------Welcome to My Game, Try to find as many coins as you can!---------!");
            Console.ResetColor();

            for (i = 1; i < 7; i++)
            {
                Console.Write("\t{0}", i);

            }
                Console.WriteLine("");
            foreach (var l in initLetters)
            {
                Console.WriteLine("{0}\tx\tx\tx\tx\tx\tx", l);
            }
            n = 1; 
            while (n < 16)
            {
                Console.WriteLine("Enter the key and value:");
                choice = Console.ReadLine();
                point += checkChoice(board, choice, coins, final);
                Console.WriteLine("Your score is: {0}", point);
                Console.WriteLine("Attempts left: {0}", 15-n);
                Console.WriteLine("Coins to find: {0}", coins);
                Console.WriteLine("---------------------------------------------------\n");

                n++;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Game over!");
            Console.ResetColor();
            Console.WriteLine("Final score: {0}", point);
            

        }

        private static int checkChoice(Dictionary<string, int> board, string choice, int coins, bool final)
        {
            if (board.ContainsKey(choice))
            {
                if (board[choice] != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    
                    Console.WriteLine("Well done! You earned {0}!", board[choice]);
                    Console.ResetColor();
                    coins--;
                    Dictionary<string, int> found = new Dictionary<string, int>();
                    found[choice] = board[choice];
                    if (final)
                    {
                        Console.WriteLine("Your coins were at:");
                        foreach (KeyValuePair<string, int> pair in found)
                        {
                            Console.WriteLine(pair.Key.ToString() + "-" + pair.Value.ToString());
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    
                    Console.WriteLine("Oops! Missed!");
                    Console.ResetColor();
                }
                return board[choice];
            }
            else
            {
                Console.WriteLine("Key does not exist");
                return 0;
            }
        }

     
    }
}
