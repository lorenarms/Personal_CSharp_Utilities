//============================================================================
// Name        : Password Calculator
// Author      : Lawrence Artl III
// Version     : 1.1.0
// Copyright   : Copyright © August 10, 2021
// Description : Input a string privately
//============================================================================

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using passwordcalc.engines;



namespace passwordcalc
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //variables
            int[] passwordCharacterSets = { 0, 0, 0, 0 };
            var passwordCharacterProperties = (characters: "special characters", numbers: "numbers", upperletters: "letters", lowerletters: "letters");
            int[] numOfEachCharacterInPassword = { 0, 0, 0, 0 }; //array for totals of character sets
            int totalCharactersInPassword = 0;

            //start program

            Console.WriteLine("Password Calculator, Ver 1.01");

            string password = Privacy.TypePW();

            PwDeconstruct(passwordCharacterSets, numOfEachCharacterInPassword, password); //passes passwordCharacterSets by ref automatically for arrays
            for (int i = 0; i < 4; i++)
            {
                totalCharactersInPassword += numOfEachCharacterInPassword[i];
            }
            
            double combinations = PasswordCombinations(totalCharactersInPassword, password); //stores the total number of possible combinations based on 
                                                                                //character sets used and password length
            {
                if (passwordCharacterSets[0] == 1)      //use these functions to modify the output of the password information sentence
                { passwordCharacterProperties.characters = "special character"; }
                if (passwordCharacterSets[1] == 1)
                { passwordCharacterProperties.numbers = "number"; }
                if (passwordCharacterSets[2] == 1)
                { passwordCharacterProperties.upperletters = "letter"; }
                if (passwordCharacterSets[3] == 1)
                { passwordCharacterProperties.lowerletters = "letter"; }
            }
            Paragraph output = new Paragraph();     //create paragraph object

            string paragraph = "Your password is " + password.Length + " character(s) long, and contains " + passwordCharacterSets[0] + " " + passwordCharacterProperties.characters + ", " + passwordCharacterSets[1] + " " + passwordCharacterProperties.numbers +
                ", " + passwordCharacterSets[2] + " uppercase " + passwordCharacterProperties.upperletters + ", and " + passwordCharacterSets[3] + " lowercase " + passwordCharacterProperties.lowerletters + ".";


            Console.WriteLine("\n\nPASSWORD INFORMATION:");
            Paragraph.Wrap(paragraph);  //wrap paragraph object
            
            Console.WriteLine("\nPress 'ENTER' to test..."); Console.ReadLine();
            TestPW(password, combinations);
            Console.WriteLine("\nPress 'ENTER' to Exit."); Console.ReadLine();

        }
        

        
        static void PwDeconstruct(int[] passwordCharacterSets, int[] numOfEachCharacterInPassword, string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                ;
                if (password[i].Equals('A'))
                {
                    passwordCharacterSets[0]++; numOfEachCharacterInPassword[0] = 30;
                }      //counts characters
                else if (password[i].Equals('B'))
                {
                    passwordCharacterSets[1]++; numOfEachCharacterInPassword[1] = 10;
                }     //counts numbers
                else if (password[i].Equals('C'))
                {
                    passwordCharacterSets[2]++; numOfEachCharacterInPassword[2] = 26;
                }     //counts uppercase letters
                else if (password[i].Equals('D'))
                {
                    passwordCharacterSets[3]++; numOfEachCharacterInPassword[3] = 26;
                }     //counts lowercase letters
            }

        }
        static double PasswordCombinations(int totalCharactersInPassword, string password)
        {
            double combinations = (Math.Pow(totalCharactersInPassword, password.Length));
            return combinations;
        }
        static void PasswordSuggestions()
        {
            //suggest ways to make the password stronger based on length and characters used
        }
        
       

        static void TestPW(String password, double combinations)
        {
            //double seconds, minutes, hours, days, years;

            int roundUnit = 0;                          //how many units to round by
            String timeUnits = "";                      //for use with string at the end
            int factor = 0;                             //to tell string which unit to print
            Double timeTotal = 0.0;                     //total amount of time it takes to crack
            timeTotal = combinations / 10000000000;     //10000 computers working in cloud service trying 1,000,000 pw's a second
                                                        //number of seconds it would take

            if (timeTotal > 60)                         //determine how long the time really is
            {
                timeTotal = timeTotal / 60; factor++;    //1
                if (timeTotal > 60)
                {
                    timeTotal = timeTotal / 60; factor++;   //2
                    if (timeTotal > 24)
                    {
                        timeTotal = timeTotal / 24; factor++;   //3
                        if (timeTotal > 365)
                        {
                            timeTotal = timeTotal / 365;    factor++;   //4
                        }
                    }
                }

            }
            switch (factor)                         //determine which units to display for the password crack time
            {
                case 0:
                    timeUnits = "seconds";  roundUnit = 6;  break;
                case 1:
                    timeUnits = "minutes";  roundUnit = 2;  break;
                case 2:
                    timeUnits = "hours";    roundUnit = 1;  break;
                case 3:
                    timeUnits = "days"; roundUnit = 1;  break;
                case 4:
                    timeUnits = "years";    roundUnit = 0;  break;
                default:
                    timeUnits = "null"; break;
            }

            timeTotal = Math.Round(timeTotal, roundUnit);
            string readableTime = timeTotal.ToString("N0");
            string readableCombinations = combinations.ToString("N0"); 


            Console.WriteLine("Your password has the following structure: " + password);

            
            string phrase = "Based on it's structure, a computer would have to test " + readableCombinations + " combinations of characters " +
                "in order to Brute Force your password. This would take a cloud-network of 10,000 computers, trying " +
                "1 million passwords per second, about " + readableTime + " " + timeUnits + ".";

            Paragraph.Wrap(phrase);
            
            
            
            Console.Write("");
        }

    }
}

