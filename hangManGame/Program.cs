using System.Collections.Generic;
using System;
using static System.Random;
using System.Text;
using System.Diagnostics;
using System.Runtime.CompilerServices;
namespace hangManGame
{
    internal class Program
    {
        private static void printHangMan(int wrong)
        {
            if(wrong==0)
            {
                Console.WriteLine("\n*---*");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   === ");

            }
            else if(wrong==1)
            {
                Console.WriteLine("\n*---*");
                Console.WriteLine("O   |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   === ");
            }

            else if (wrong == 2)
            {
                Console.WriteLine("\n*---*");
                Console.WriteLine("O   |");
                Console.WriteLine("|   |");
                Console.WriteLine("    |");
                Console.WriteLine("   === ");
            }

            else if (wrong == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|  |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }

            else if (wrong == 4)
            {
                Console.WriteLine("\n+---*+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("    |");
                Console.WriteLine("   === ");
            }

            else if (wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\   |");
                Console.WriteLine("/   |");
                Console.WriteLine("   === ");
            }

            else if (wrong == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("   === ");
            }
        }
        private static int printWord( List<char>guessedLetters, String randomWord)
        {
            int counter = 0;
            int rightLetters = 0;
            Console.Write("\r\n");
            foreach (char c in randomWord)
            {
                if(guessedLetters.Contains(c))
                {
                    Console.Write(c + " ");
                    rightLetters++;
                }
                else
                { 
                    Console.Write(" "); 
                }
                counter++;
                
            }
            return rightLetters;
        }

        private static void printLine(String randomWord)
        {
            Console.WriteLine("\r");
            foreach(char c in randomWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Welcome to  the case sensitive game HANGMAN :)");
            Console.WriteLine("---------------------------------------------\n");

            Random random = new Random();
            List<String> wordDictionary = new List<String> { "Sunflower", "Grateful", "peaches", "Boastful", "tyme", "Visual", "Money" };
            int index = random.Next(wordDictionary.Count);
            String randomWord = wordDictionary[index];

            foreach (char v in randomWord)
            {
                Console.Write("_ ");
            }

            int lengthOfWordToGuess = randomWord.Length;
            int amountOftimesWrong = 0;
            List<char> currentLettersGuessed = new List<char>();
            int currentLettersRight = 0;

           while(amountOftimesWrong != 6 && currentLettersRight != lengthOfWordToGuess) 
            { 
                Console.Write("\n Letter guessed so far: ");
                foreach(char letter in currentLettersGuessed)
                {
                    Console.Write(letter + " ");
                }
                //prompt for user input
                Console.Write("\r\nGuess a letter: ");
                char letterGuessed = Console.ReadLine()[0];
                //check if letter has been guessed
                if(currentLettersGuessed.Contains(letterGuessed))
                {
                    Console.WriteLine("You have already guessed this letter");
                    printHangMan(amountOftimesWrong);
                    currentLettersRight = printWord(currentLettersGuessed, randomWord);
                    printLine(randomWord);
                }
                else
                {
                    //check if letter is in the word
                    bool right = false;
                    for (int i = 0; i < randomWord.Length; i++)
                    { 
                        if (letterGuessed == randomWord[i]) { right = true; } 
                    }
                        

                    if(right) 
                        { 
                            printHangMan(amountOftimesWrong); 
                            currentLettersGuessed.Add(letterGuessed);
                            currentLettersRight=printWord(currentLettersGuessed, randomWord);
                            Console.Write("\r\n");
                            printLine(randomWord);
                        }
                        else
                        {
                            amountOftimesWrong++;
                            currentLettersGuessed.Add(letterGuessed);
                            printHangMan(amountOftimesWrong);
                            currentLettersRight = printWord(currentLettersGuessed, randomWord);
                            Console.Write("\r\n");
                            printLine(randomWord);
                        }
                    }
                }
            Console.WriteLine("\r\nThanks for playing GAME IS OVER");
            }

        }
    
}
