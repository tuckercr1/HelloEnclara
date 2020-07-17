// Christopher Tucker
// 17JUL2020

using System;
using System.Text.RegularExpressions;
using System.Linq;


namespace HelloEnclara
{
    class Paragraph
    {
        private string paragraph; // The user will input a paragraph
        private char letter = ' '; // The user will optionally input a letter to search for words
        private string[] sentences; // The sentences of the paragraph
        private string[] words; // The words in the paragraph
        private int palWords; // The number of palindrome words
        private int palSents; // The number of palindrome sentences



        public Paragraph(string para) // Constructor
        {
            paragraph = para; 
        }



        public void setLetr(char letr) // Setter for letter
        {
            letter = letr;
        }



        public int getPalWords() // Returns number of palindrome words
        {
            return palWords;
        }



        public int getPalSents() // Returns number of palindrome sentences
        {
            return palSents;
        }



        private void setWords(string paragraph) // Split the paragraph into words
        {
            Regex delimeters = new Regex("[/;,.!?\t\r ]|[\n]{2}");
            words = paragraph.Split();
            for(int i = 0; i < words.Length; i++)
            {
                words[i] = delimeters.Replace(words[i], "");
            }
        }



        private void sortWords() // Sorts words in alphabetical order
        {
            Array.Sort(words);
        }



        public void countWords() // Counts the unique instances of the words in the paragraph
        {
            var result = words.GroupBy(a => a.ToLower()).Select(x => new { key = x.Key, val = x.Count() });
            Console.WriteLine("{0,-10}   {1,-10}", "Word", "Count");
            foreach (var item in result)
            {
                Console.WriteLine("{0,-10}   {1,-10}", item.key, item.val);
            }
        }
        


        public void searchWords() // Searches for words with the designated letter.
        {
            int i = 0;
            var result = words.GroupBy(a => a).Select(x => new { key = x.Key, val = x.Count() }); // Groups the words based on their count
            Console.WriteLine();
            Console.WriteLine("Searching for words that contain '" + letter + "'");
            foreach (var item in result) // Iterate through the words to check for the user specified letter
            {

                // This statement searches for the letter whether it's uppercase or lowercase
                if (item.key.ToString().Contains(letter.ToString().ToLower())) 
                {
                    Console.WriteLine("{0,-10}", item.key);
                    i = 1;
                }
            }
            if(i == 0) // If no words with the letter are found
            {
                Console.WriteLine("No words contain the character '" + letter + "'");
            }
        }



        public void parseParagraph() // Search through the paragraph to find palindrome words and sentences
        {
            setWords(paragraph); // Fills the words array with words from the paragraph
            sortWords(); // Sorts the words into alphabetical order
            sentences = Regex.Split(paragraph, @"(?<=[\.!\?])\s+"); // Splits the paragraph into sentences
            for (int i = 0; i < sentences.Length; i++)
            {
                if (checkWord(checkPalSent(sentences[i])))
                {
                    //Console.WriteLine("yes the sentence '" + sentences[i] + "' is a palindrome.");
                    palSents++;
                }
            }
            for (int j = 0; j < words.Length; j++)
            {
                if (checkWord(checkPalSent(words[j])))
                {
                    //Console.WriteLine("yes the word '" + words[j] + "' is a palindrome.");
                    palWords++;
                }
            }
        }



        private string checkPalSent(string sentence) // This will check sentence to determine if it is a palindrome
        {
            Regex delimeters = new Regex("[;,.!?\t\r ]|[\n]{2}");// This is a list of delimeters to search for to remove
            string newSent = delimeters.Replace(sentence, ""); // This will search for characters to remove
            //Console.WriteLine("newSent = " + newSent); // Test to see if newSent is formatted properly
            return newSent;
        }



        // This code is adapted from:
        // Allen, S. (n.d.). C# Palindrome Method: Words and Sentences. Retrieved July 17, 2020, from https://www.dotnetperls.com/palindrome
        public Boolean checkWord(string word) // Checks to determine if a word is a palindrome by comparing opposing letters against eachother.
        {
            int bottom = 0;  // Lowest position in a character array
            int top = word.Length - 1; // Highest position in a character array.
            while (true)
            {
                if (bottom > top) // If the lower bottom is larger than the top position, then the letters of the word have been traversed and it is a palindrome
                {
                    return true;
                }
                char lower = word[bottom];
                char upper = word[top];
                if (char.ToLower(lower) != char.ToLower(upper)) // If a lower character does not equal an upper character then the word is not a palindrome
                {
                    return false;
                }
                bottom++;
                top--;
            }
        }



        static void Main(string[] args)
        {
            while (true)
            {
                // The user will be prompted to input a paragraph.
                string para;
                Console.WriteLine("Please type a paragraph: ");
                para = Console.ReadLine();
                Paragraph p = new Paragraph(para.Replace("Mr.", "Mr").Replace("Mrs.", "Mrs").Replace("Ms.", "Ms").Replace("Jr.", "Jr").Replace("Dr.", "Dr")); // Replaced some typical titles
                Console.WriteLine();

                // Parse the paragraph and print the results
                p.parseParagraph();
                Console.WriteLine("{0,-23} {1,3}", "Palindrome words: ", p.getPalWords());
                Console.WriteLine("{0,-23} {1,3}", "Palindrome sentences: ", p.getPalSents());
                Console.WriteLine();
                p.countWords(); // Counts and prints the number of unique word instances

                // This loop will allow the user to inut a search letter.
                Console.WriteLine();
                Console.WriteLine("Input a search character? y/n");
                while (true)
                {
                    Start:
                    char yn = Console.ReadKey().KeyChar;
                    if((yn != 'n') && (yn != 'y'))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Input a search character? y/n");
                        goto Start;
                    }

                    if (yn == 'y') // If the user wants to input a search letter
                    {
                        while (true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Enter search character.");
                            p.setLetr(Console.ReadKey().KeyChar);
                            Console.WriteLine();
                            
                            // Serach for words with the letter
                            p.searchWords();
                            Console.WriteLine();
                            Console.WriteLine("Search for another character? y/n"); // Ask if user wants to search anoter letter
                            Retype:
                            yn = Console.ReadKey().KeyChar;

                            if((yn != 'y') && (yn != 'n'))
                            {
                                Console.WriteLine();
                                Console.WriteLine("Search for another character? y/n");
                                goto Retype; // If user does not select 'y' or 'n'
                            }

                            if (yn == 'n')
                            {
                                break;
                            }
                        }
                    }

                    if (yn == 'n') // If the user does not want to input a search letter
                    {
                        break;
                    }
                }

                // This will allow the user to input a new paragraph
                Console.WriteLine();
                retype:
                Console.WriteLine("Press 'y' to type another paragraph or 'x' to exit");
                char x = Console.ReadKey().KeyChar;
                if(x == 'y')
                {
                    Console.WriteLine();
                }
                
                if ((x != 'x') && (x != 'y')) 
                {
                    Console.WriteLine();
                    goto retype; // If the user does not selext 'x' or 'y'
                }

                if (x == 'x') // If the user wants to exit
                {
                    break;
                }
            }
        }
    }
}