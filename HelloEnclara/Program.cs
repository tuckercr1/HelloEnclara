using System;
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




        static void Main(string[] args)
        {
            string para;
            char letr;

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
            
            



            Console.ReadKey();
        }
    }
}
