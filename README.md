# **HelloEnclara**
### **Christopher Tucker**
### TL;DR
This is a C# program that will accept a paragraph as an input and display the number of palindrome words, palindrome sentences, unique words, and list all words that contain a letter input by the user. To run it, clone the repo into VS code and click "Start" or press "F5". When prompted, input a paragraph and optionally input a letter to use to search for words containing that letter.
### What Is HelloEnclara?
HelloEnclara is a C# solution written for a coding assessment. The solution was completed using VS code 2019 community edition. To run the solution, copy the repo url and clone it to your VS code IDE. From there, either press the "Start" button or press "F5".


### What does it do?
It was required to take in a paragraph as an input and perform the following actions:
- 1. Give the number of palindrome words.
- 2. Give the number of palindrome sentences.
- 3. List the unique words of a paragraph with the count of the word instance.
- 4. Let the user also input a letter at some point and list all words containing that letter.
##### What's a Palindrome?
A ***palindrome*** is a word or phrase that is spelled the same forwards and backwards. For example, the word "civic" or the phrase "Was it a car or a cat I saw?" and they typically ignore punctuation.
### How Are The Tasks Accomplished?
- 1. Give the number of palindrome words. :heavy_check_mark:
- 2. Give the number of palindrome sentences. :heavy_check_mark:

The input paragraph is parsed by the **parseParagraph()** method and separated into sentences, then sentences into words. Each sentence has its delimiting characters removed by the **checkPalStr(string str)** method and is then compressed into a singular string. For example, "Mr. Owl ate my metal worm" becomes "MrOwlatemymetalworm". This new "word sentence", as well as the individual words from the original paragraph, get passed to the method **checkWord(string word)** to determine whether or not they are a palindrome.

Pictured below are the **parseParagraph()** and **checkPalStr(string str)** methods.
![alt text](https://github.com/tuckercr1/HelloEnclara/blob/master/photos/parseParagraph%20%2B%20checkPalStr.png)


- 3. List the unique words of a paragraph with the count of the word instance. :heavy_check_mark:

Counting the instance of unique words is handled by the **countWords()** method. Words with different capitalizations are not considered unique. For example, "helloworld", "Helloworld", and "HelloWorld" will all be considered the same word, so the word count for "helloworld" would be 3.


Pictured below is the **countWords()** method.
![alt text](https://github.com/tuckercr1/HelloEnclara/blob/master/photos/countWords.png)


- 4. Let the user also input a letter at some point and list all words containing that letter. :heavy_check_mark:

The user is able to input a letter to list all words that contain that letter. The **searchWords()** method will search through the paragraph words to find any words that contain the input letter. Again, words with different capitalizations are the same word, so if a paragraph contained "goodbye" and "GOODBYE" and one inputs the letter "g", then "goodbye" will be listed once.

Pictured below is the **searchWords()** method.
![alt text](https://github.com/tuckercr1/HelloEnclara/blob/master/photos/searchWords.png)


### Sample Outputs
Sample output of "helloworld", "HelloWorld", and "HELLOWORLD" with "h" input as the search letter.
![alt text](https://github.com/tuckercr1/HelloEnclara/blob/master/photos/Sample%201.png)

Sample output of "Mr. Owl ate my metal worm." with "m" input as the search letter.
![alt text](https://github.com/tuckercr1/HelloEnclara/blob/master/photos/Sample%202%20(1).png)


![alt text](https://github.com/tuckercr1/HelloEnclara/blob/master/photos/Sample%202%20(2).png)


Bibliography
- 1. Allen, S., 2020. C# Palindrome Method: Words And Sentences. [online] Dotnetperls.com. Available at: <https://www.dotnetperls.com/palindrome> [Accessed 17 July 2020].
