using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEnclara
{
    class Program
    {
        private string paragraph; // The user will input a paragraph.
        private string letter; // The user will optionally input a letter to search for words.

        public Program(string para) // Constructor for if the user does not input a letter
        {
            paragraph = para; 
        }

        public Program(string para, string letr) // Constructor for if the user inputs a letter
        {
            paragraph = para;
            letter = letr;
        }

        static void Main(string[] args)
        {

        }
    }
}
