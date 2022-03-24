using Models;
using System.ComponentModel.DataAnnotations;
using BL;

namespace UI;

public class MainMenu
{
    public void Start()
    {
        bool exit = true;
        
        do
        {
            Console.WriteLine("**************************************");
            Console.WriteLine("* Hail and Welcome to The D&D Store! *");
            Console.WriteLine("**************************************\n");
            Console.WriteLine("Be thou an (o)verlord or an (a)dventurer? o/a or x to exit");

            string? input = Console.ReadLine();

            switch(input)
            {
                case "o": 
                    IsOverlord();
                break;
                case "a": break;
                case "x": 
                Console.WriteLine("Fare thee well!");
                    exit = false;
                break;
                default:
                    Console.WriteLine("Thy input is invalid. Try again!");
                break;
            }
        } while(exit == true);
    }
    private void IsOverlord() 
    {

        string[,] overlordInfo = new string[3, 2];
        overlordInfo = PasswordInfo.returnStuff();

        Console.WriteLine("Greetings Master! Please enter thy name:");
        string? input = Console.ReadLine();

        if (input == "BobtheBeholder" || input == "TheDemogorgon" || input == "Minsc")
        {
            Console.WriteLine("Pardon me, Master. I humbly beg thy credentials:");
            string? checkCredentials = Console.ReadLine();

            if (input == "BobtheBeholder" && checkCredentials == "EyeCanSeeYou11")
            {
                Console.WriteLine("Welcome Master!");
            }
        }



        // switch(input)
        // {
        //     case 
        // }


    }
    private void IsCustomer()
    {

    }
}



