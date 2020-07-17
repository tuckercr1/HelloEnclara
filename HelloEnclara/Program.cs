using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEnclara
{
    class Program
    {
        private string paragraph; // The user will input a paragraph
        private char letter = ' '; // The user will optionally input a letter to search for words
        private string[] sentences; // The sentences of the paragraph
        private string[] words; // The words in the paragraph
        private int palaWords; // The number of palindrome words
        private int palaSents; // The number of palindrome sentences

        public Program(string para) // Constructor for if the user does not input a letter
        {
            paragraph = para; 
        }

        public string getPara() // Getter for paragraph
        {
            return paragraph;
        }

        public void setLetr(char letr) // Setter for letter
        {
            letter = letr;
        }

        public char getLetr() // Getter for letter
        {
            return letter;
        }

        public int getPalaWords() // Returns number of palindrome words
        {
            return palaWords;
        }

        public int getPalaSents() // Returns number of palindrome sentences
        {
            return palaSents;
        }

        private void setWords(string paragraph) // Split the paragraph into words
        {
            words = paragraph.Split();
        }

        private void sortWords() // Sorts words in alphabetical order
        {
            Array.Sort(words);
        }

        public void countWords() // Counts the unique instances of the words in the paragraph
        {
            sortWords();
            //int numberOfElements = words.Distinct().Count();
            //Console.WriteLine(numberOfElements);

            Console.WriteLine(words[0]);
            for(int i = 1; i < words.Length; i++)
            {
                if((words[i].ToLower() != words[i - 1].ToLower()) && (i != words.Length))
                {
                    Console.WriteLine(words[i]);
                }
            } 
        }
        public void printWords() // Delete this method later
        {
            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine(words[i]);
            }
        }

        public void parseParagraph() // Search through the paragraph to find palindrome words and sentences
        {
            setWords(paragraph);
            sentences = Regex.Split(paragraph, @"(?<=[\.!\?])\s+");
            for (int i = 0; i < sentences.Length; i++)
            {
                if (checkWord(checkPalaSent(sentences[i])))
                {
                    //Console.WriteLine("yes the sentence '" + sentences[i] + "' is a palindrome.");
                    palaSents++;
                }
            }
            for (int j = 0; j < words.Length; j++)
            {
                if (checkWord(checkPalaSent(words[j])))
                {
                    //Console.WriteLine("yes the word '" + words[j] + "' is a palindrome.");
                    palaWords++;
                }
            }
        }

        public string checkPalaSent(string sentence) // This will check sentence to determine if it is a palindrome
        {
            Regex delimeters = new Regex("[;,.!?\t\r ]|[\n]{2}");// This is a list of delimeters to search for to remove
            string newSent = delimeters.Replace(sentence, ""); // This will make all letters lowercase and search for characters to remove
            //Console.WriteLine("newSent = " + newSent); // Test to see if newSent is formatted properly
            return newSent;
        }

        // This code comes from https://www.dotnetperls.com/palindrome
        public Boolean checkWord(string word) // Checks to determine if a word is a palindrome by comparing opposing letters against eachother.
        {
            int min = 0;  // Lowest position in a character array
            int max = word.Length - 1; // Highest position in a character array.
            while (true)
            {
                if (min > max) // If the lower position is larger than the higher position, then the letters of the word have been traversed and it is a palindrome
                {
                    return true;
                }
                char lower = word[min];
                char upper = word[max];
                if (char.ToLower(lower) != char.ToLower(upper)) // If alower character does not equal an upper character then the word is not a palindrome
                {
                    return false;
                }
                min++;
                max--;
            }
        }

        

        static void Main(string[] args)
        {
            // The user will be prompted to input a paragraph.
            string para;
            Console.WriteLine("Please type a paragraph: ");
            para = Console.ReadLine();
            Program p = new Program(para.Replace("Mr.", "Mr").Replace("Mrs.", "Mrs").Replace("Ms.", "Ms")); // Constructor for making the paragraph reading Program

            // This loop will allow the user to inut a search letter.
            Console.WriteLine();
            Console.WriteLine("Would you like to input a search letter? y/n");
            while (true)
            {
                string yn = Console.ReadLine(); 
                if (yn == "y") // If the user wants to input a search letter
                {
                    Console.WriteLine("You selected yes. Please input the search letter.");
                    p.setLetr(Console.ReadKey().KeyChar);
                    Console.WriteLine();
                    break;
                }
                if (yn == "n") // If the user does not want to input a search letter
                {
                    break;
                }
                Console.WriteLine("Please select y/n");
            }

            Console.WriteLine();

            // If the user chose a search letter then it will be displayed
            if (p.getLetr() == ' ')
            {

            }
            else
            {
                Console.WriteLine("The search letter is: " + p.getLetr());
            }

            p.parseParagraph();
            Console.WriteLine("Number of palindrome words: " + p.getPalaWords());
            Console.WriteLine("Number of palindrome sentences: " + p.getPalaSents());
            p.countWords();

            //Console.WriteLine("paragraph length is: " + p.getPara().Length); Test to make sure \n is not counted as a character
            Console.ReadKey();
        }
    }
}
