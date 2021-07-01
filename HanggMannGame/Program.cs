using System;
using System.IO;
using System.Text.RegularExpressions;

namespace HanggMannGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program Start\n");

            string path = @"C:\Users\zglina\Desktop\DominikRzeczy\Motorolla Challange\countries_and_capitals.txt"; //path to file
            Random rNumber = new Random();
            int index = rNumber.Next(183); //generating and assigning random number, so we can later use it to chose randome country - capital / line
            string capital;
            string country;
            int lifePoints = 5;
            int win = 0;
            int loseLifeCounter = 0;
            string[] score;
            int scorePoints = 0;

            string[] lines = File.ReadAllLines(path); //saving txt to string 

            Console.WriteLine(lines[index]); //displaying first argument of array - checking if it's okey
            string word = lines[index]; //saving one line of string array to other string so i can be easily separated below
            string[] separated = word.Split('|'); //splitting line so
            country = separated[0]; //assigning part of string to variable
            country = country.Trim(); //removing spaces from country
            capital = separated[1]; //assigning part of string to variable
            capital = capital.Trim(); //removing spaces from capital

            string blankCapital = capital; //creating string with same lenght as capital string - so it can be use in guessing game
            char[] blankCapitalCharArray = blankCapital.ToCharArray();


            //blankCapital = Regex.Replace(capital, "[^0-9 ]","_");

            Console.WriteLine(country);
            Console.WriteLine(capital);
            Console.Write(blankCapital);
            Console.WriteLine(blankCapitalCharArray);

            //pętla do zamiany na '_'
            for (int i = 0; i < capital.Length; i++)
            {
                if (capital[i] == ' ')
                {
                    blankCapitalCharArray[i] = ' ';
                }
                else
                {
                    blankCapitalCharArray[i] = '_';
                }

            }
            //koniec pętli zamiany
            Console.WriteLine("KONIEC PETLI");
            Console.WriteLine(blankCapitalCharArray);

            Console.WriteLine("Czy chcesz grać w grę? \nWciśnij Y - by grać\nWciśnij cokolwiek - by wyłączyć program");

            string playOrNot = Console.ReadLine();
            
            playOrNot = playOrNot.ToUpper();

            Console.WriteLine(playOrNot);
            Console.ReadKey();

            
            while (playOrNot == "Y") //pętla do trwania gry -------------------
            {
                //seting new parameters
                win = 0;
                lifePoints = 5;
                rNumber = new Random();
                index = rNumber.Next(183);
                word = lines[index]; //saving one line of string array to other string so i can be easily separated below
                separated = word.Split('|'); //splitting line so
                country = separated[0]; //assigning part of string to variable
                country = country.Trim(); //removing spaces from country
                capital = separated[1]; //assigning part of string to variable
                capital = capital.Trim(); //removing spaces from capital
                int wordLetter = 0;

                string guessWord;
                char guessLetter;

                blankCapital = capital; //creating string with same lenght as capital string - so it can be use in guessing game
                blankCapitalCharArray = blankCapital.ToCharArray();
                char[] CappitalInCharArray = blankCapital.ToCharArray();

                //blankWord = blan

                for (int i = 0; i < capital.Length; i++)
                {
                    if (capital[i] == ' ')
                    {
                        blankCapitalCharArray[i] = ' ';
                    }
                    else
                    {
                        blankCapitalCharArray[i] = '_';
                    }
                }    
                    //ending setting new parameters

                Console.Clear();
                Console.WriteLine("Przechodzisz do gry. Wciśnij Przycisk by kontynuować... ");
                Console.ReadKey();
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");

                while (lifePoints > 0 || win == 1) //pętla danej rozgrywki ***********************
                {

                    Console.Write("TEST TEST - CAPITAL =  ");
                    Console.WriteLine(blankCapital);
                    loseLifeCounter = 0;
                    Console.WriteLine("\n Points: "+scorePoints);
                    Console.WriteLine(" *** Life Points = " + lifePoints + " ***");
                    Console.Write("Słowo do odganięcia: ");
                    Console.Write(blankCapitalCharArray); Console.WriteLine(" <- Guess this word");
                    if(lifePoints <=2)
                    {
                        Console.WriteLine("Hint! This is the capital of: " + country);
                    }

                    Console.WriteLine("\nIf you want to guess whole word - press '0' \nIf you want to guess whole word press other number\n");
                    wordLetter = Convert.ToInt32(Console.ReadLine());

                    if(wordLetter==0) //guessing whole word
                    {
                        Console.WriteLine("Write word! Remember about spaces!");
                        guessWord = Console.ReadLine();

                        if (guessWord == blankCapital)
                        {
                            Console.WriteLine("YOU GUESSED THE WORD! YOU WIN! ");
                            win = 1;

                        }
                        else
                        {
                            Console.WriteLine(" WRONG ANSWER ! You lose 2 Life Points !");
                            lifePoints = lifePoints-2;
                        }


                    }
                    else //guessing single letter
                    {
                        Console.Write("Write only single letter! ");
                        guessLetter = Convert.ToChar(Console.Read());
                        
                        for (int o=0; o!= CappitalInCharArray.Length;o++)
                        {
                             if(guessLetter == CappitalInCharArray[o])
                            {
                                blankCapitalCharArray[o] = guessLetter;
                                loseLifeCounter = loseLifeCounter +1;
                            }
                        }

                        if(loseLifeCounter==0)
                        {
                            lifePoints = lifePoints-1;
                            Console.WriteLine("Letter was not present in word! You lose 1 life point!");

                        }

                        if (blankCapital == Convert.ToString(blankCapitalCharArray))
                        {
                            Console.WriteLine("YOU GUESSED THE WORD! YOU WIN!");
                        }


                    }

                    if(lifePoints<=0)
                    {
                        Console.WriteLine("You lost all you life Points :(\nYou Lose");
                    }


                    if (win == 1)
                    {
                        scorePoints = scorePoints + 200;
                    }

                    Console.WriteLine("Press Key to Continue...");
                    Console.ReadKey();
                    Console.Clear();


                }





                //Exit or Restart Game
                Console.WriteLine("Do you want to continue \nPress Y - to play the game\nPress anyother button - to end program");//
                playOrNot = Console.ReadLine();
                playOrNot = playOrNot.ToUpper();

                if (playOrNot == "Y")
                    Console.WriteLine("You will play again!");
                else
                    Console.WriteLine("Goodbye!");
                
                Console.WriteLine("Press something to continue...");
                Console.ReadLine();
                //End of Exit or Restart Game
            }




            Console.WriteLine("Do you want to save your score? Write 'Yes' if yes or anything else if not");
            string saveScore = Console.ReadLine();
            saveScore = saveScore.ToUpper();
            if(saveScore=="YES")
            {
                Console.Write("Write your nickname: ");
                string nickName = Console.ReadLine();
                Console.WriteLine("\nWrite your City: ");
                string city = Console.ReadLine();

            }    




            Console.WriteLine("\nProgram End");
            Console.ReadLine();
        }



    }
}


