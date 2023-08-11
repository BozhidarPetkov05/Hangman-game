

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***********************************************");
            Console.WriteLine("Welcome to the game!");
            Console.WriteLine("Do you want to play? y/n");
            int player1wins = 0;
            int player2wins = 0;
            int player1streak = 0;
            int player2streak = 0;
            int player1best = 0;
            int player2best = 0;


            int totalGames = 0;
            char firstInput = char.Parse(Console.ReadLine());
            while (true)
            {
                if (firstInput == 'n')
                {
                    break;
                }
                else if (firstInput == 'y')
                {
                    Console.WriteLine("Player 1, write a word!");
                    List<char> chars = new List<char>();
                    List<char> unfound = new List<char>();

                    string word = "";

                    while (true)
                    {
                        var key = Console.ReadKey();
                        if (key.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                        word += key.KeyChar;
                    }
                    Console.WriteLine("Player 2, try to guess the word!");

                    for (int i = 0; i < word.Length; i++)
                    {
                        char current = word[i];
                        chars.Add(current);
                    }
                    unfound.Add(chars[0]);
                    for (int i = 1; i < word.Length - 1; i++)
                    {
                        unfound.Add('_');
                    }
                    unfound.Add(chars[word.Length - 1]);
                    for (int i = 1; i < chars.Count - 1; i++)
                    {
                        if (chars[i] == chars[0])
                        {
                            unfound.RemoveAt(i);
                            unfound.Insert(i, chars[0]);
                        }
                        if (chars[i] == chars[word.Length - 1])
                        {
                            unfound.RemoveAt(i);
                            unfound.Insert(i, chars[word.Length - 1]);
                        }
                    }
                    Console.Write(string.Join(" ", unfound));
                    Console.WriteLine("");

                    bool isFound = false;
                    int fails = 0;
                    int tries = 0;
                    string command = "";
                    while (true)
                    {
                        var input = Console.ReadKey();
                        if (input.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                        command += input.KeyChar;
                    }
                    while (isFound == false)
                    {

                        tries++;
                        if (command.Length > 1)
                        {
                            if (command == word)
                            {
                                isFound = true;
                                break;
                            }
                            else
                            {
                                fails++;
                            }
                        }
                        bool isContained = false;

                        if (command.Length == 1)
                        {
                            for (int i = 0; i < unfound.Count; i++)
                            {
                                char currentChar = char.Parse(command);
                                if (unfound[i] == currentChar)
                                {
                                    isContained = true;
                                    break;
                                }
                            }
                            if (isContained == false)
                            {
                                char current = char.Parse(command);

                                int changes = 0;
                                for (int j = 0; j < chars.Count; j++)
                                {
                                    if (chars[j] == current)
                                    {
                                        unfound.RemoveAt(j);
                                        unfound.Insert(j, current);
                                        changes++;
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                if (changes == 0)
                                {
                                    fails++;
                                    Console.WriteLine($"The letter {command} was not the right one");

                                }
                                else
                                {
                                    Console.WriteLine($"The letter {command} was the right one");
                                }

                                if (fails >= 10)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine($"The letter {command} is already in the word, try another letter!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You can type only one letter at a time or you can type the word if you think it is the right one!");
                        }
                        string word1 = string.Join("", chars);
                        string word2 = string.Join("", unfound);
                        if (word1 == word2)
                        {
                            isFound = true;
                            break;
                        }
                        Console.Write(string.Join(" ", unfound));
                        Console.WriteLine("");
                        command = "";
                        while (true)
                        {
                            var input = Console.ReadKey();
                            if (input.Key == ConsoleKey.Enter)
                            {
                                break;
                            }
                            command += input.KeyChar;
                        }
                    }
                    totalGames++;
                    if (isFound == true)
                    {
                        player2wins++;
                        player2streak++;
                        player1streak = 0;

                        Console.WriteLine("Congratulations!!!");
                        Console.WriteLine($"You found the word in {tries} tries");
                        Console.WriteLine($"The word was \"{word}\"");
                        Console.WriteLine("");
                        Console.WriteLine($"Total games played {totalGames}");

                        if (player2streak > player2best)
                        {
                            player2best = player2streak;
                        }
                    }
                    else
                    {
                        player1wins++;
                        player1streak++;
                        player2streak = 0;

                        Console.WriteLine("You did not find the word");
                        Console.WriteLine($"The word was \"{word}\"");
                        Console.WriteLine("");
                        Console.WriteLine($"Total games played {totalGames}");

                        if (player1streak > player1best)
                        {
                            player1best = player1streak;
                        }

                    }
                    Console.WriteLine("Do you want to play again? y/n");
                    firstInput = char.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Please, answer with \"y\" or \"n\"");
                    firstInput = char.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine($"Total games played: {totalGames}");
            Console.WriteLine($"Player 1 best streak {player1best}");
            Console.WriteLine($"Player 2 best streak {player2best}");
            if (player1wins > player2wins)
            {
                Console.WriteLine("Player 1 wins the overall game!");
                Console.WriteLine("Player 1 -------- Player 2");
                Console.WriteLine($"    {player1wins}    --------    {player2wins}");
            }
            else if (player1wins < player2wins)
            {
                Console.WriteLine("Player 2 wins the overall game!");
                Console.WriteLine("Player 1 -------- Player 2");
                Console.WriteLine($"    {player1wins}    --------    {player2wins}");
            }
            else if (player1wins == player2wins)
            {
                if (totalGames > 0)
                {
                    Console.WriteLine("Draw!");
                    Console.WriteLine("Player 1 -------- Player 2");
                    Console.WriteLine($"    {player1wins}    --------    {player2wins}");
                }
            }
            if (totalGames > 0)
            {
                Console.WriteLine("Thank you for playing!");
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Goodbye!");
            }
            Console.WriteLine("***********************************************");
        }
    }
}