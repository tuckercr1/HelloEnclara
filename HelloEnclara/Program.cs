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

        public int getPalaWords()
        {
            return palaWords;
        }

        public void parsePara() // Turn the paragraph into individual sentences
        {
            sentences = Regex.Split(paragraph, @"(?<=[\.!\?])\s+");
            for (int i = 0; i < sentences.Length; i++)
            {
                //Console.WriteLine("[" + i + "] " + sentences[i]);
                checkPalaWord(sentences[i]);
            }
        }

        public void checkPalaSent(string sentence) // This will check sentence to determine if it is a palindrome.
        {

        }

        public void checkPalaWord(string sentence) // This will check a sentence to determine if there are palindrome words.
        {
            char[] delimiterChars = { ' ', ',', '.', ':','?', '!', '\t', '\n' }; // delimeters
            string[] words = sentence.Split(delimiterChars); // Place each word into an array
            foreach (var word in words)
            {
                if(word != null)
                {
                    string reverse = "";
                    for (int i = word.Length - 1; i >= 0; i--)
                    {
                        reverse += word[i].ToString();
                    }
                    if (reverse == word)
                    {
                        System.Console.WriteLine($"{word}"); // Used for printing/testing to make sure palindromes were detected
                    }
                }
                
            }
        }

        static void Main(string[] args)
        {
            string para;

            // The user will be prompted to input a paragraph.
            Console.WriteLine("Please type a paragraph: ");
            para = Console.ReadLine();
            Program p = new Program(para); // Constructor for making the paragraph reading Program
            
            // This loop will allow the user to inut a search letter.
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
            Console.WriteLine("Paragraph is: " + p.getPara());
            if (p.getLetr() == ' ')
            {

            }
            else
            {
                Console.WriteLine("The search letter is: " + p.getLetr());
            }

            p.parsePara();
            Console.WriteLine("Number of palindromes is: " + p.getPalaWords());


            Console.ReadKey();
        }
    }
}
