using System;

namespace mis221_assignment3_lacyrich
{  
    class Program
    {
        static void Main(string[] args)
        {
            int gamesWon = 0;
            int gamesLost = 0;
            int totalCredits = 50;
            int creditsBet = 0;
            Console.ForegroundColor = ConsoleColor.DarkYellow;  //changes color to yellow
            Welcome();                                          //Welcomes user to the game
            Console.WriteLine("\nPlease enter your name");      //Lets user enter their name
            string playerName = Console.ReadLine();             //declares string playerName as userInput
            Console.Clear();                                    //clears console
            Menu(ref playerName, ref totalCredits, ref creditsBet, ref gamesWon, ref gamesLost); //starts menu of the game, which runs the application
        }

        static void Menu(ref string playerName, ref int totalCredits, ref int creditsBet, ref int gamesWon, ref int gamesLost) //main menu function that controls the game
        {
            string userInput = "";
            
            DisplayMenu(ref userInput, ref playerName, ref totalCredits, ref gamesWon, ref gamesLost); //shows menu and allows user to input their choice

            while(userInput != "5" && totalCredits > 0 && totalCredits < 300 && userInput != "8")
            {
                while(userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4") //tells user if their input is invalid and allows them to re-enter their choice
                {
                    Console.WriteLine("Invalid Choice");
                    userInput = Console.ReadLine();
                }
                if(userInput == "1" && totalCredits > 0 && totalCredits < 300)
                {
                    TheForce(ref userInput, ref playerName, ref totalCredits, ref creditsBet, ref gamesWon, ref gamesLost); //runs The Force Game
                }
                else if(userInput == "2" && totalCredits > 0 && totalCredits < 300)
                {
                    Blasters(ref userInput, ref playerName, ref totalCredits, ref creditsBet, ref gamesWon, ref gamesLost); //runs Blasters game
                }
                else if(userInput == "3" && totalCredits > 0 && totalCredits < 300)
                {
                    DagobahSwamp(ref userInput, ref playerName, ref totalCredits, ref creditsBet, ref gamesWon, ref gamesLost); //runs Dagobah Swamp Game
                }
                else if(userInput == "4")
                {
                    Scoreboard(ref playerName, ref totalCredits, ref gamesWon, ref gamesLost); //keeps track of shows user their scores and credits 
                }
                if(totalCredits <= 0 || totalCredits >= 300)
                {
                    CheckCredits(ref userInput, ref playerName, ref totalCredits, ref gamesWon, ref gamesLost); //checks to see how many credits the user has and tells them when they have won or lost
                }
                if(totalCredits > 0 && totalCredits < 300)
                {
                    DisplayMenu(ref userInput, ref playerName, ref totalCredits, ref gamesWon, ref gamesLost); //shows menu and allows user to input their choice
                }
                
            } 
        }
        static void DisplayMenu(ref string userInput, ref string playerName, ref int totalCredits, ref int gamesWon, ref int gamesLost) //displays menu to the user and lets them input their choice
        {
            CheckCredits(ref userInput, ref playerName, ref totalCredits, ref gamesWon, ref gamesLost);
            if(totalCredits >= 0 && totalCredits <= 300)
            {  
                Console.WriteLine($"        Hello {playerName}");
                Console.WriteLine("\nPlease enter your integer choice");
                Console.WriteLine("1. Play The Force\n2. Play Blasters\n3. Play Dagobah Swamp\n4. View Current Scores\n5. Exit");
                userInput = Console.ReadLine();
            }                             
        }
        public static void Scoreboard(ref string playerName, ref int totalCredits, ref int gamesWon, ref int gamesLost) // tells user how many games they have won (have 300+ credits) and how many they have lost 0 (have credits or less)
        {
            Console.Clear();
            Yoda(); //displays image of Yoda
            System.Console.WriteLine($"Hello {playerName}\n");
            System.Console.WriteLine($"Credits: {totalCredits}\n");
            Console.WriteLine("Games Won: " + gamesWon);
            Console.WriteLine("Games Lost: " + gamesLost);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        static void TheForce(ref string userInput, ref string playerName, ref int totalCredits, ref int creditsBet, ref int gamesWon, ref int gamesLost) //Runs The Force game
        {   
            CheckCredits(ref userInput, ref playerName, ref totalCredits, ref gamesWon, ref gamesLost); //checks to see how many credits the user has and tells them when they have won or lost
            TheForceDescription(); //tells user the rules of the game
            Console.WriteLine("Hit enter to play game or enter menu to return to the menu");
            userInput = Console.ReadLine();
            while(totalCredits > 0 && totalCredits < 300 && totalCredits + creditsBet > 0 && userInput.ToLower() != "menu" && userInput != "9")
            {
                Console.Clear();
                while(userInput != "9" && totalCredits + creditsBet > 0 && userInput != "8" && userInput != "5")
                {    
                    TheForceGameplay(ref userInput, ref playerName, ref totalCredits, ref creditsBet, ref gamesWon, ref gamesLost); //runs the gameplay of The Force
                    if(totalCredits > 0) //lets user play game again if they have enough credits
                    {
                        Console.Clear();
                        System.Console.WriteLine("If you would like to play again, please enter 0. Otherwise, enter 9 to return to the main menu");
                        userInput = Console.ReadLine();
                    }
                }
           }
        }
        static void Blasters(ref string userInput, ref string playerName, ref int totalCredits, ref int creditsBet, ref int gamesWon, ref int gamesLost) //runs Blasters
        {
            CheckCredits(ref userInput, ref playerName, ref totalCredits, ref gamesWon, ref gamesLost); //checks to see how many credits the user has and tells them when they have won or lost
            BlastersDescription(); //tells user the rules of the game
            Console.WriteLine("Hit enter to play game or enter menu to return to the menu");
            userInput = Console.ReadLine();
            while(totalCredits > 0 && totalCredits < 300 && totalCredits + creditsBet >= 20 && userInput.ToLower() != "menu" && userInput != "9" )
            {
                Console.Clear();
                while(userInput != "9" && totalCredits + creditsBet >= 20 && userInput != "8" && userInput != "5")
                {    
                    BlastersGameplay(ref userInput, ref playerName, ref totalCredits, ref creditsBet, ref gamesWon, ref gamesLost); //runs the gameplay of Dagobah Swamp
                    if(totalCredits >= 20) //lets user play game again if they have enough credits
                    {
                        Console.Clear();
                        System.Console.WriteLine("If you would like to play again, please enter 0. Otherwise, enter 9 to return to the main menu");
                        userInput = Console.ReadLine();
                    }
                }
            }

        }
       
        static void DagobahSwamp(ref string userInput, ref string playerName, ref int totalCredits, ref int creditsBet, ref int gamesWon, ref int gamesLost) //runs Dagobah Swamp
        {
            CheckCredits(ref userInput, ref playerName, ref totalCredits, ref gamesWon, ref gamesLost); //checks to see how many credits the user has and tells them when they have won or lost
            DagobahSwampDescripton(); //tells user the rules of the game
            Console.WriteLine("Hit enter to play game or enter menu to return to the menu");
            userInput = Console.ReadLine();
            while(totalCredits > 0 && totalCredits < 300 && totalCredits + creditsBet >= 15 && userInput.ToLower() != "menu" && userInput != "9" && userInput != "8" && userInput != "5")
            {   
                Console.Clear();
                while(userInput != "9" && totalCredits + creditsBet >= 15 && userInput != "8" && userInput != "5" )
                {   
                    DagobahSwampGameplay(ref userInput, ref playerName, ref totalCredits, ref creditsBet, ref gamesWon, ref gamesLost); //runs the gameplay of Dagobah Swamp
                    if(totalCredits >= 15) //lets user play game again if they have enough credits
                    {
                        Console.Clear();
                        System.Console.WriteLine("If you would like to play again, please enter 0. Otherwise, enter 9 to return to the main menu");
                        userInput = Console.ReadLine();
                    }
                }
            }
        }

        static void CheckCredits(ref string userInput, ref string playerName, ref int totalCredits, ref int gamesWon, ref int gamesLost) //checks to see how many credits the user has and tells them when they have won or lost
        {   if(totalCredits <= 0 || totalCredits >= 300)
            { 
                if(totalCredits <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"                        Credits: {totalCredits}\n");
                    Console.WriteLine("<(-_-)>   Lost, you have\n");
                    gamesLost++;
                    System.Console.WriteLine("Press any key to contine\n");
                    Console.ReadKey();
                }
                else if(totalCredits >= 300)
                {
                    Console.Clear();
                    Console.WriteLine($"                        Credits: {totalCredits}\n");
                    Console.WriteLine("<(-_-)>    Won, you have\n");
                    gamesWon++;
                    System.Console.WriteLine("Press any key to continue...\n");
                    Console.ReadKey();
                }
                Console.Clear();
                ResetCredits(ref userInput, ref playerName, ref totalCredits, ref gamesWon, ref gamesLost); //allows user to choose to reset their credits
            }
            else if(totalCredits > 0 && totalCredits < 300)
            {
                Console.WriteLine($"                        Credits: {totalCredits}\n");
            }

        }

        static void ResetCredits(ref string userInput, ref string playerName, ref int totalCredits, ref int gamesWon, ref int gamesLost) //allows user to choose to reset their credits
        {
            Scoreboard(ref playerName, ref totalCredits, ref gamesWon, ref gamesLost); //keeps track of shows user their scores and credits 
            System.Console.WriteLine("Enter 8 to reset credits and play again. Otherwise enter 5 to exit");
            userInput = Console.ReadLine();
            while(userInput != "8" && userInput != "5")
            {
                System.Console.WriteLine("Invalid Input");
                userInput = Console.ReadLine();
            }
            if(userInput == "8")
            {
                totalCredits = 50;
            }
            else if(userInput == "5")
            {
                Yoda(); //displays image of Yoda
                System.Console.WriteLine("\nGoodbye!\n");
            }
        }
        static void TheForceDescription() //tells user the rules of The Force
        {   
            System.Console.WriteLine("████████╗██╗░░██╗███████╗  ███████╗░█████╗░██████╗░░█████╗░███████╗");
            System.Console.WriteLine("╚══██╔══╝██║░░██║██╔════╝  ██╔════╝██╔══██╗██╔══██╗██╔══██╗██╔════╝");
            System.Console.WriteLine("░░░██║░░░███████║█████╗░░  █████╗░░██║░░██║██████╔╝██║░░╚═╝█████╗░░");
            System.Console.WriteLine("░░░██║░░░██╔══██║██╔══╝░░  ██╔══╝░░██║░░██║██╔══██╗██║░░██╗██╔══╝░░");
            System.Console.WriteLine("░░░██║░░░██║░░██║███████╗  ██║░░░░░╚█████╔╝██║░░██║╚█████╔╝███████╗");
            System.Console.WriteLine("░░░╚═╝░░░╚═╝░░╚═╝╚══════╝  ╚═╝░░░░░░╚════╝░╚═╝░░╚═╝░╚════╝░╚══════╝");
            System.Console.WriteLine("\nYoda will lay out a row of 10 cards.\nThe game begins when you are shown a random card from the deck."); 
            System.Console.WriteLine("You must then guess if the next card will be under that amount or over that amount.");
            System.Console.WriteLine("Each time you guess correctly, you move on to the next card in the row of ten.\nIf you make it through all ten, you triple your credits.");
            System.Console.WriteLine("If you make it through seven, but not all ten, you double your credits.\nIf you make it through five, but not seven, you will break even.");
            System.Console.WriteLine("If you lose before getting to five, you lose the credits you bet.\nNote: *Kings are the highest card and Aces are the lowest.*");
        }

        static void BlastersDescription() //tells user the rules of Blasters
        {
            
            System.Console.WriteLine("██████╗░██╗░░░░░░█████╗░░██████╗████████╗███████╗██████╗░░██████╗");
            System.Console.WriteLine("██╔══██╗██║░░░░░██╔══██╗██╔════╝╚══██╔══╝██╔════╝██╔══██╗██╔════╝");
            System.Console.WriteLine("██████╦╝██║░░░░░███████║╚█████╗░░░░██║░░░█████╗░░██████╔╝╚█████╗░");
            System.Console.WriteLine("██╔══██╗██║░░░░░██╔══██║░╚═══██╗░░░██║░░░██╔══╝░░██╔══██╗░╚═══██╗");
            System.Console.WriteLine("██████╦╝███████╗██║░░██║██████╔╝░░░██║░░░███████╗██║░░██║██████╔╝");
            System.Console.WriteLine("╚═════╝░╚══════╝╚═╝░░╚═╝╚═════╝░░░░╚═╝░░░╚══════╝╚═╝░░╚═╝╚═════╝░");
            System.Console.WriteLine("\nYoda will shoot lasers at you with a blaster.\nIt is your job to either dodge or deflect the laser to not get hit.");
            System.Console.WriteLine("For this game, you start off with 15 points, and each time you get hit you lose 5 points,");
            System.Console.WriteLine("each time you deflect you get 10, and each time you dodge you get 5 points.");
            System.Console.WriteLine("Dodging has a 50% chance of success and Deflecting has a 30% chance of success.");
            System.Console.WriteLine("Each time you get to decide if you want to dodge, deflect, or quit out of the game.");
            System.Console.WriteLine("To play this game, you must bet at least 20 credits.\nYou win when you get 40 points - get 20 credits. You lose when you hit 0 points.");
        }

        static void DagobahSwampDescripton() //tells user the rules of Dagobah Swamp
        {     
            System.Console.WriteLine("██████╗░░█████╗░░██████╗░░█████╗░██████╗░░█████╗░██╗░░██╗  ░██████╗░██╗░░░░░░░██╗░█████╗░███╗░░░███╗██████╗░");
            System.Console.WriteLine("██╔══██╗██╔══██╗██╔════╝░██╔══██╗██╔══██╗██╔══██╗██║░░██║  ██╔════╝░██║░░██╗░░██║██╔══██╗████╗░████║██╔══██╗");
            System.Console.WriteLine("██║░░██║███████║██║░░██╗░██║░░██║██████╦╝███████║███████║  ╚█████╗░░╚██╗████╗██╔╝███████║██╔████╔██║██████╔╝");
            System.Console.WriteLine("██║░░██║██╔══██║██║░░╚██╗██║░░██║██╔══██╗██╔══██║██╔══██║  ░╚═══██╗░░████╔═████║░██╔══██║██║╚██╔╝██║██╔═══╝░");
            System.Console.WriteLine("██████╔╝██║░░██║╚██████╔╝╚█████╔╝██████╦╝██║░░██║██║░░██║  ██████╔╝░░╚██╔╝░╚██╔╝░██║░░██║██║░╚═╝░██║██║░░░░░");
            System.Console.WriteLine("╚═════╝░╚═╝░░╚═╝░╚═════╝░░╚════╝░╚═════╝░╚═╝░░╚═╝╚═╝░░╚═╝  ╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚═╝░░░░░");
            System.Console.WriteLine("\nYou will journey through the Dagobah Swamp to find Yoda. At each twist and turn you will\nencounter obstacles and be presented with three choices."); 
            System.Console.WriteLine("Each choice has a different probability of success, which varies depending on the obstacle."); 
            System.Console.WriteLine("The goal is to survive the swamp and find where Yoda is hiding.");
            System.Console.WriteLine("You must bet at least 15 credits to play.\nIf you make it through nine trials and the final trial you find Yoda, triple your credits, and get a 100 credit bonus.");
            System.Console.WriteLine("If you make it through nine trials, but fail the final trial, you triple your credits."); 
            System.Console.WriteLine("If you make it through six to eight trials, you double your credits, if you make it through three to five obstacles you break even. You lose if you make it through less than three trials.");
        }

        static void TheForceGameplay(ref string userInput, ref string playerName, ref int totalCredits, ref int creditsBet, ref int gamesWon, ref int gamesLost) //runs the gameplay of The Force
        {
            string[] suites = new string[]{"Hearts", "Spades", "Clubs", "Diamonds"};
            string[] faces = new string[]{"Ace","2","3","4","5","6","7","8","9","10","Jack","Queen","King"};
            string[] cards = new string [52];
            int[] cardVal = new int[]{1,2,3,4,5,6,7,8,9,10,11,12,13,1,2,3,4,5,6,7,8,9,10,11,12,13,1,2,3,4,5,6,7,8,9,10,11,12,13,1,2,3,4,5,6,7,8,9,10,11,12,13};
            string[] playCards = new string[11];
            int[] playValues = new int[11];
            int cardsRight = 0;

            PayTheForce(ref userInput, ref playerName, ref totalCredits, ref creditsBet, ref gamesWon, ref gamesLost); //allows user to bet credits to play The Force
            while(creditsBet != 0)
            {
                System.Console.WriteLine("Enter > if you think the next card will be over the amount on the current card");
                System.Console.WriteLine("Enter < if you think the next card will be under the amount on the current card");
                System.Console.WriteLine("The card you previously guessed higher or lower for becomes the new current card");
                Deck(suites, faces, cards, cardVal); //Creates Deck
                GetCards(suites, faces, cards, cardVal, playCards, playValues); //Gets cards for game
                Guess(playCards, playValues, ref totalCredits, ref creditsBet, ref gamesWon, ref gamesLost, ref cardsRight); //allows user to make their guess and checks to see if it's correct
                TheForceCreditsWon(ref cardsRight, ref totalCredits, ref creditsBet, ref gamesWon, ref gamesLost); //awards user their credits
            }
        }
        static void Deck(string[] suites, string[] faces, string[] cards, int[] cardVal) //creates deck
        {
            int count = 0;
            for(int i =0; i < 4; i++)
            {
                for(int j = 0; j < 13; j++) 
                {
                    cards[count] = faces[j] + " of " + suites[i]; 
                    count++;
                }
            }
        }
        static void GetCards(string[] suites, string[] faces, string[] cards, int[] cardVal, string[] playCards, int[] playValues) //gets cards for game
        {
            Random r = new Random();
            for(int j = 0; j < 11; j++)
            {
                int rndNum = r.Next(52);
                bool cardRepeat = false;
                for(int k = 0; k < j; k++)
                {
                    if(playCards[k] == cards[rndNum])
                    {
                        j--;
                        cardRepeat = true;
                    }
                }
                if(cardRepeat == false)
                {
                    playCards[j] = cards[rndNum];
                    playValues[j] = cardVal[rndNum];
                }
            }  
        }
        static void Guess(string[] playCards, int[] playValues, ref int totalCredits, ref int creditsBet, ref int gamesWon, ref int gamesLost, ref int cardsRight) //allows user to make their guess and checks to see if it's correct
        {
            bool guess = true;
            int guessNum = 0;
            int count = 0;
            System.Console.WriteLine(playCards[0]);
            string userGuess = Console.ReadLine();
                
            while(guess != false && guessNum < 10)
            { 
                if(userGuess == ">")
                {
                    if(playValues[count] < playValues[count+1])
                    {   
                        System.Console.WriteLine($"Current Card: {playCards[count]}");
                        count++;
                        System.Console.WriteLine($"Guessed Card: {playCards[count]}");
                        guess = true;
                        guessNum++;
                        cardsRight++;
                        System.Console.WriteLine($"Correct: {cardsRight}");
                        userGuess = Console.ReadLine();
                    }
                    else if(playValues[count] >= playValues[count+1])
                    {   
                        System.Console.WriteLine($"Current Card: {playCards[count]}");
                        count++;
                        System.Console.WriteLine($"Guessed Card: {playCards[count]}");
                        guess = false;
                        System.Console.WriteLine("You guessed wrong\nPress any key to continue...");
                        Console.ReadKey();
                    
                    }
                }
                else if(userGuess =="<")
                {
                    if(playValues[count] > playValues[count+1])
                    { 
                        System.Console.WriteLine($"Current Card: {playCards[count]}");
                        count++;
                        System.Console.WriteLine($"Guessed Card: {playCards[count]}");
                        guess = true;
                        guessNum++;
                        cardsRight++;
                        System.Console.WriteLine($"Correct: {cardsRight}");
                        userGuess = Console.ReadLine();
                    }
                    else if(playValues[count] <= playValues[count+1])
                    {   
                        System.Console.WriteLine($"Current Card: {playCards[count]}");
                        count++;
                        System.Console.WriteLine($"Guessed Card: {playCards[count]}");
                        guess = false;
                        System.Console.WriteLine("You guessed wrong\nPress any key to contine");
                        Console.ReadKey();
                    }
                }
                else if(userGuess != "<" && userGuess != ">")
                {
                        System.Console.WriteLine("Invalid input");
                        userGuess = Console.ReadLine();
                } 
            } 
            Console.Clear();            
        }
        static void TheForceCreditsWon(ref int cardsRight, ref int totalCredits, ref int creditsBet, ref int gamesWon, ref int gamesLost) //awards user their credits
        {
            if(cardsRight == 10)
            {
                totalCredits = totalCredits + (creditsBet * 3);
                System.Console.WriteLine($"<(-_-)> Over, the game is. You got all 10 guesses correct");
                System.Console.WriteLine($"{creditsBet*3} credits you have won\n");        
            }
            else if(cardsRight < 10 && cardsRight  >= 7)
            {
                totalCredits = totalCredits + (creditsBet * 2);
                System.Console.WriteLine($"<(-_-)> Over, the game is. You got {cardsRight} of your guesses correct\n");
                System.Console.WriteLine($"{creditsBet*2} credits you have won\n");
            }
            else if(cardsRight  < 7 && cardsRight >= 5)
            {
                totalCredits = totalCredits + creditsBet;
                System.Console.WriteLine($"<(-_-)> Over, the game is. You got {cardsRight} of your guesses correct\n");
                System.Console.WriteLine($"{creditsBet} credits you have won\n");
            }
            else if(cardsRight < 5)
            {
                System.Console.WriteLine($"<(-_-)> Over, the game is. You got {cardsRight} of your guesses correct\n");
                System.Console.WriteLine("You lost The Force\n");
            }
            creditsBet = 0;  //resets creditsBet to zero
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();          
        }
        static void BlastersGameplay(ref string userInput, ref string playerName, ref int totalCredits, ref int creditsBet, ref int gamesWon, ref int gamesLost) //runs the gameplay of Blasters
        {
            int blastersPoints = 15;
            bool dodge = false;
            bool deflect = false;
            string blastersInput = ""; 
            PayBlasters(ref userInput, ref playerName, ref totalCredits, ref creditsBet, ref gamesWon, ref gamesLost);
            while(creditsBet != 0 && blastersPoints < 40 && blastersPoints > 0 )
            {
                Console.WriteLine("Press 1 to dodge.\nPress 2 to deflect\nPress 3 to quit");
                blastersInput = Console.ReadLine();
                while(blastersInput != "3" && blastersPoints > 0 && blastersPoints < 40)
                {
                    while(blastersInput == "1" || blastersInput == "2" && blastersPoints < 40 && blastersPoints > 0)
                    {
                        if(blastersInput == "1")
                        {
                            Dodge(ref dodge, ref blastersPoints); 
                        }
                        else if(blastersInput == "2")
                        {
                            Deflect(ref deflect, ref blastersPoints);
                        }
                        if(blastersPoints < 40 && blastersPoints > 0)
                        {
                            blastersInput = Console.ReadLine();
                        }
                    }
                    while(blastersInput != "1" && blastersInput != "2" && blastersInput != "3")
                    {
                        Console.WriteLine("Invalid Choice");
                        blastersInput = Console.ReadLine(); 
                    }    
                }
                Console.Clear(); 
                BlastersCreditsWon(ref blastersPoints, ref totalCredits, ref creditsBet);
            }   
        }
         static void Dodge(ref bool dodge, ref int blastersPoints)
        {
            DodgeChance(ref dodge);
            if(dodge == true)
            {
                blastersPoints = blastersPoints + 5;
                System.Console.WriteLine("Dodge successful");
            }
            if(dodge == false)
            {
                blastersPoints = blastersPoints - 5;
                System.Console.WriteLine("You got hit");
            }
            System.Console.WriteLine($"You have {blastersPoints} points");
        }

        static void Deflect(ref bool deflect, ref int blastersPoints)
        {
            DeflectChance(ref deflect);
            if(deflect == true)
            {
                blastersPoints = blastersPoints + 10;
                System.Console.WriteLine("Deflect successful");
            }
            if(deflect == false)
            {
                blastersPoints = blastersPoints - 5;
                System.Console.WriteLine("You got hit");
            }
            System.Console.WriteLine($"You have {blastersPoints} points");
        }
        static bool DodgeChance(ref bool dodge)
        {   
            
            Random rnd = new Random();
            int chance = rnd.Next(2);

            if(chance != 0)
            {
                dodge = true;
            }
            if(chance == 0)
            {
                dodge = false;
            }

            return dodge;

        }

        static bool DeflectChance(ref bool deflect)
        {
            
            Random rnd = new Random();
            int chance = rnd.Next(10);

            if(chance <= 2)
            {
                 deflect = true;
            }
            if(chance > 2)
            {
                deflect = false;
            }

            return deflect;

        }
        static void BlastersCreditsWon(ref int blastersPoints, ref int totalCredits, ref int creditsBet)
        {
            if(blastersPoints >= 40)
            {
                System.Console.WriteLine("<(-_-)>   Over, the game is\nWon Blasters, you have\n");
                totalCredits = totalCredits + (creditsBet * 2);
                System.Console.WriteLine($"{creditsBet} credits you have won\n");
            }
            else if(blastersPoints <= 0)
            {
                System.Console.WriteLine("<(-_-)>  Over, the games is\nLost Blasters, you have\n");
            }
            creditsBet = 0;  //resets creditsBet to zero
            System.Console.WriteLine("Press any key to continue...\n");
            Console.ReadKey();
        }
        static void DagobahSwampGameplay(ref string userInput, ref string playerName, ref int totalCredits, ref int creditsBet, ref int gamesWon, ref int gamesLost) //runs the gameplay of The Force
        {
            bool success = true;
            int passedTrials = 0;
            
            PayDagobahSwamp(ref userInput, ref playerName, ref totalCredits, ref creditsBet, ref gamesWon, ref gamesLost);
            while(creditsBet > 0 && success != false || passedTrials > 9)
           {
                while(passedTrials < 9 && success != false)
                {
                    Console.WriteLine("Enter the integer of the choice you would like to make");
                    Trial();
                    Choice(ref success, ref passedTrials);
                    if(success != false)
                    {
                        System.Console.WriteLine($"\nTrials Passed: {passedTrials}\n");
                    }
                    else
                    {
                        System.Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }
                }
                if(success != false && passedTrials == 9)
                {
                    Console.WriteLine("Enter the integer of the choice you would like to make");
                    FinalTrial();
                    Choice(ref success, ref passedTrials);
                }
                Console.Clear();
                DagobahSwampCreditsWon(ref passedTrials, ref creditsBet, ref totalCredits);
            }
            Console.ReadKey();  
        }
        static void Trial() //Randomly generates a trial for user to face
        {
            Random rnd = new Random();
            int chance = rnd.Next(9);
            if(chance <= 2)
            {
                 System.Console.WriteLine("\nYou have encountered a cliff");
                 System.Console.WriteLine("Your choices are:\n1. Force jump\n2. Use the force to move rocks\n3. Use your lightsaber to cut down a tree");
            }
            else if(chance > 2 && chance<=5)
            {
                System.Console.WriteLine("\nYou have encountered swamp creatures");
                System.Console.WriteLine("Your choices are:\n1. Attack with your lightsaber\n2. Use the force to throw rocks\n3. Force jump over them");
            }
            else if(chance > 5)
            {
                System.Console.WriteLine("\nYou have encountered swampy quicksand");
                System.Console.WriteLine("Your choices to escape are:\n1. Use the force to grab a vine\n2. Use your lightsaber to cut a vine down to you\n3. Try to force jump out");
            }
        }

        static void FinalTrial() //Generates the final trial where the user faces the boss of the game
        {
            System.Console.WriteLine("You have encountered a mysterious enemy...\n");
            DarthVader(); //displays image of Darth Vader
            System.Console.WriteLine("Darth Vader\n");
            System.Console.WriteLine("Your choices are:\n1. Attack with your lightsaber\n2. Use the force to drop rocks on him\n3. Force jump");
        }
        static void Choice(ref bool success, ref int passedTrials) //Allows user to select the option they would would like to make
        {
           string choiceInput = Console.ReadLine();
           while(choiceInput != "1" && choiceInput != "2" && choiceInput != "3")
           {
               System.Console.WriteLine("Invalid input");
                choiceInput = Console.ReadLine();
           }
           if(choiceInput == "1")
           {
               SeventyPercentChance(ref success); //seventy percent probability
           }
           else if(choiceInput == "2")
           {
               FiftyPercentChance(ref success); //fifty percent probability
           }
           else if(choiceInput == "3")
           {
               ThirtyPercentChance(ref success); //thirty percent probability
           }
           ChoiceSuccess(ref success, ref passedTrials); //checks to see if users choice was succcessful and tells them
        }

       static void ChoiceSuccess(ref bool success, ref int passedTrials) //Tells user if their choice in Dagobah Swamp was successful
       {
           if(success == true)
           {
               System.Console.WriteLine("Passed this trial, you have");
               passedTrials++;
           }
           if(success == false)
           {
               System.Console.WriteLine("Failed this trial, you have.");     
           }
       }

       static bool SeventyPercentChance(ref bool success) //70% probability of a choice being successful in Dagobah Swamp
       {
            Random rnd = new Random();
            int chance = rnd.Next(10);
            if(chance <= 6)
            {
                success = true;
            }
            if(chance > 6)
            {
                success = false;
            }

            return success;
        }

        static bool FiftyPercentChance(ref bool success) //50% probability of a choice being successful in Dagobah Swamp
       {
            Random rnd = new Random();
            int chance = rnd.Next(2);
            if(chance != 0)
            {
                success = true;
            }
            if(chance == 0)
            {
                success = false;
            }

            return success;
        }
        static bool ThirtyPercentChance(ref bool success) //30% probability of a choice being successful in Dagobah Swamp
       {
            Random rnd = new Random();
            int chance = rnd.Next(10);
            if(chance <= 2)
            {
                success = true;
            }
            if(chance > 2)
            {
                success = false;
            }

            return success;
       }

       static void DagobahSwampCreditsWon(ref int passedTrials, ref int creditsBet, ref int totalCredits) //Awards user the credits they won in Dagobah Swamp
       {
           if(passedTrials == 10)
           {
                totalCredits = totalCredits + (creditsBet * 3) + 100;
                System.Console.WriteLine("Congratulations! Passed all the trials, defeated the boss, and found Yoda you have");
                System.Console.WriteLine($"<(-_-)> Over, the game is. You passed all the trials and the final trial");
                System.Console.WriteLine($"{(creditsBet*3) + 100} credits you have won\n");
                Yoda(); //displays image of Yoda
            }
            else if(passedTrials == 9)
            {
                totalCredits = totalCredits + (creditsBet * 3);
                System.Console.WriteLine($"<(-_-)> Over, the game is. You passed {passedTrials} trials");
                System.Console.WriteLine($"{creditsBet*3} credits you have won\n");        
            }
            else if(passedTrials < 9 && passedTrials  >= 6)
            {
                totalCredits = totalCredits + (creditsBet * 2);
                System.Console.WriteLine($"<(-_-)> Over, the game is. You passed {passedTrials} trials\n");
                System.Console.WriteLine($"{creditsBet*2} credits you have won\n");
            }
            else if(passedTrials < 6 && passedTrials >= 3)
            {
                totalCredits = totalCredits + creditsBet;
                System.Console.WriteLine($"<(-_-)> Over, the game is. You passed {passedTrials} trials\n");
                System.Console.WriteLine($"{creditsBet} credits you have won\n");
            }
            else if(passedTrials < 3)
            {
                System.Console.WriteLine($"<(-_-)> Over, the game is. You passed {passedTrials} trials\n");
                System.Console.WriteLine("You lost Dagobah Swamp\n");
            }
            creditsBet = 0; //resets creditsBet to zero
            System.Console.WriteLine("Press any key to continue...");

       }
       static int PayTheForce(ref string userInput, ref string playerName, ref int totalCredits, ref int creditsBet, ref int gamesWon, ref int gamesLost) //allows user to pay to play The Force
       {
           CheckCredits(ref userInput, ref playerName, ref totalCredits, ref gamesWon, ref gamesLost); 
           if(totalCredits > 0)
           {  
                Console.WriteLine("You must bet credits to play this game. Please enter the number of credits you would like to bet");
                creditsBet = int.Parse(Console.ReadLine()); 
                while(creditsBet <= 0 || creditsBet > totalCredits)        
                {
                    if(creditsBet <= 0)
                    {
                        Console.WriteLine("You entered too few credits. Please try again");
                        creditsBet = int.Parse(Console.ReadLine());
                    }
                    else if(creditsBet > totalCredits)
                    {
                        System.Console.WriteLine("You do not have that many credits. Please enter an amount less than or equal to your total number of credits.");
                        creditsBet = int.Parse(Console.ReadLine());
                    }
                }
                BetCredits(ref totalCredits, ref creditsBet); //bets users credits
                return creditsBet;
                
           }
           else if(totalCredits == 0)
           {
               Console.WriteLine("You need more credits in order to play The Force. Please try a different game");
           }
           return totalCredits;
       }
       static int PayBlasters(ref string userInput, ref string playerName, ref int totalCredits, ref int creditsBet, ref int gamesWon, ref int gamesLost) //allows user to pay to play Blasters
       {
           CheckCredits(ref userInput, ref playerName, ref totalCredits, ref gamesWon, ref gamesLost);
           if(totalCredits >= 20)
           {
                Console.WriteLine("You must bet at least 20 credits to play this game. Please enter the number of credits you would like to bet");
                creditsBet = int.Parse(Console.ReadLine());
                while(creditsBet < 20 || creditsBet > totalCredits)        
                {
                    if(creditsBet < 20)
                    {
                        Console.WriteLine("You entered too few credits. Please try again");
                        creditsBet = int.Parse(Console.ReadLine());
                    }
                    else if(creditsBet > totalCredits)
                    {
                        System.Console.WriteLine("You do not have that many credits. Please enter an amount less than or equal to your total number of credits.");
                        creditsBet = int.Parse(Console.ReadLine());
                    }
                }
                BetCredits(ref totalCredits, ref creditsBet);
                return creditsBet;
           }
           else if(totalCredits < 20)
           {
               Console.WriteLine("You need more credits in order to play Blasters. Please try a different game");
           }
           return totalCredits;
       }
       static int PayDagobahSwamp(ref string userInput, ref string playerName, ref int totalCredits, ref int creditsBet, ref int gamesWon, ref int gamesLost)
       {
           CheckCredits(ref userInput, ref playerName, ref totalCredits, ref gamesWon, ref gamesLost);
           if(totalCredits >= 15)
           {
                Console.WriteLine("You must bet at least 15 credits to play this game. Please enter the number of credits you would like to bet");
                creditsBet = int.Parse(Console.ReadLine());
                while(creditsBet < 15 || creditsBet > totalCredits)        
                {
                    if(creditsBet < 15)
                    {
                        Console.WriteLine("You entered too few credits. Please try again");
                        creditsBet = int.Parse(Console.ReadLine());
                    }
                    else if(creditsBet > totalCredits)
                    {
                        System.Console.WriteLine("You do not have that many credits. Please enter an amount less than or equal to your total number of credits.");
                        creditsBet = int.Parse(Console.ReadLine());
                    }
                }
                BetCredits(ref totalCredits, ref creditsBet);
                return creditsBet;
            }
            else if(totalCredits < 15)
            {
                Console.WriteLine("You need more credits in order to play Dagobah Swamp. Please try a different game");
            }
            return totalCredits;
       }
       static int BetCredits(ref int totalCredits, ref int creditsBet) //tells user how many credits they bet for the current game and updates the new total credits amount
       {
           System.Console.WriteLine($"Credits Bet: {creditsBet}");
           totalCredits = totalCredits - creditsBet;
           return totalCredits;      
       }

       static void Yoda()  //displays image of yoda
        {
             Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
            System.Console.WriteLine("░▒░░░░░░░░░░░░▒▒▒▒▒▒▒▒░░░░░░░░░░░░▒▒░░░░");
            System.Console.WriteLine("░▒▒░░░░░░░░░░▒▒░░░░░░▒▒▒░░░░░░░░▒▒▒▒░░░░");
            System.Console.WriteLine("░░▒▒▒░░░░░░▒▒░▒▒▒░░▒▒▒░▒▒░░░░▒▒▒░░▒░░░░░");
            System.Console.WriteLine("░░▒░░▒▒▒░░▒▒░░░░░░░░░░░░▒▒▒▒▒░░░░▒▒░░░░░");
            System.Console.WriteLine("░░▒▒░░░▒▒▒▒░░░░▀▀░░░▀▀░░░░░░░░░░▒▒░░░░░░");
            System.Console.WriteLine("░░░▒░░░░░░░░░░░░░░▄▄░░░░░░░░░░▒▒▒░░░░░░░");
            System.Console.WriteLine("░░░░▒▒░░░░░░░░░░░░░░░░░░░░░░░▒▒░░░░░░░░░");
            System.Console.WriteLine("░░░░░▒▒▒▒░░░░░░█▄░░░▄▌░░▒▒▒▒▒▒░░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░▒▒▒▒▒░░░░▀▀▀░░░▒▒▒▒░░░░░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░░▒▒▒▒▒▒▒░░░░░▒▒▒▒▒▒▒░░░░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░░▒░░░░░▒▒▒▒▒▒░░░░░░▒▒░░░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░▒▒░░░░░░░░░░░░░░░░░░░▒░░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░▒░░░░░░░░░░░░░░░░░░░░▒░░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░▒░░░▒░░▒░░░░░░░▒░░▒░░▒░░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░▒░░░▒░░▒░░░░░░░▒░░▒░░░▒░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░▒░░░▒░░▒░░░░░░░▒░░▒░░▒▒░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░▒░░░▒░░▒░░░░░░░▒░░▒░░▒░░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░▒░░░▒░░▒░░░░░░░▒░░▒░░▒░░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░▒░░░░▒▒░░░░░░░░░▒▒░░░▒░░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░▒░░░░░░░░░░░░░░░░░░░░▒░░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░░▒░░░░░░░░░░░░░░░░░░▒░░░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░░▒░░░░░░░░░░░░░░░░░░▒░░░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░░▒░░░░░░░░░░░░░░░░░░▒░░░░░░░░░░░\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }

        static void DarthVader() //displays a picture of darth vader
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░░░░░░▒▒▒░░░░░░░▒▒▒░░░░░░░░░░░░░░");            
            System.Console.WriteLine("░░░░░░░░░░░▒▒░░░░░░░░░░░░▒▒░░░░░░░░░░░░░");            
            System.Console.WriteLine("░░░░░░░░░░▒▒░░░░░░▒░▒░░░░░▒░░░░░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░░▒░░░░░░░░▒░▒░░░░░░▒░░░░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░░▒░░░░░░░░▒░▒░░░░░░▒▒░░░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░░▒░────░░░▒░▒░────░░▒░░░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░░▒░░░░░░░░▒░▒░░░░░░░▒▒░░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░░▒░█▀▀▀▀█░░░░█▀▀▀▀█░░▒░░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░▒▒░▌░░░░█░▄▄░▌░░░░▐░░▒▒░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░▒░░▀▀▀▀▀▀████▀▀▀▀▀▀░▒░▒▒░░░░░░░░");
            System.Console.WriteLine("░░░░░░░▒░▒░░░░░░║████║░░░░░▒▒░░▒▒░░░░░░░");
            System.Console.WriteLine("░░░░░░▒▒░░▒░░░░║║║║║║║║░░░░▒░░░░▒▒░░░░░░");
            System.Console.WriteLine("░░░░░░▒░░░▒▒░░║║║║║║║║║║░░▒▒░░░░░▒░░░░░░");
            System.Console.WriteLine("░░░░░▒░░░░▒▒░║║║║║║║║║║║║░▒░░░░░░░▒░░░░░");
            System.Console.WriteLine("░░░░▒▒░░░░░▒░║║║║║║║║║║║║░▒▒░░░░░░░▒▒░░░");
            System.Console.WriteLine("░░░▒▒░░░░░░░▒░░░║║║║║║░░░░▒▒░░░░░░░░▒░░░");
            System.Console.WriteLine("░░░▒░░░░░░░░░▒▒░░░░░░░░▒▒▒░░░░░░░░░░░▒░░");
            System.Console.WriteLine("░░▒▒▒▒▒▒▒▒▒▒▒▒░▒▒▒░░░▒▒▒░░▒▒▒▒▒▒▒▒▒▒▒▒▒░");
            System.Console.WriteLine("░░░░░░░░░░░░░░▒░░░░▒▒░░░░▒░░░░░░░░░░░░░░");
            System.Console.WriteLine("░░░░░░░░░░░░░░▒░░░░░░░░░░▒░░░░░░░░░░░░░░\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }

        static void Welcome() //displays welcome
        {
            System.Console.WriteLine("░██╗░░░░░░░██╗███████╗██╗░░░░░░█████╗░░█████╗░███╗░░░███╗███████╗");
            System.Console.WriteLine("░██║░░██╗░░██║██╔════╝██║░░░░░██╔══██╗██╔══██╗████╗░████║██╔════╝");
            System.Console.WriteLine("░╚██╗████╗██╔╝█████╗░░██║░░░░░██║░░╚═╝██║░░██║██╔████╔██║█████╗░░");
            System.Console.WriteLine("░░████╔═████║░██╔══╝░░██║░░░░░██║░░██╗██║░░██║██║╚██╔╝██║██╔══╝░░");
            System.Console.WriteLine("░░╚██╔╝░╚██╔╝░███████╗███████╗╚█████╔╝╚█████╔╝██║░╚═╝░██║███████╗");
            System.Console.WriteLine("░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝░╚════╝░░╚════╝░╚═╝░░░░░╚═╝╚══════╝");
        }
    }          
}



