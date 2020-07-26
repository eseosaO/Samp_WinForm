using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWinForm.Classes
{
    /*The Shop class has a list to store both PS games and Xbox games*/
    public class Shop 
    {
        //Attributes
        private string shopName; //variable to hold shop name
        private List<Game> gamesForSale; //declared List to hold the games available for sale
        private int currentlyViewedGame = 0; //index variable for the position in the list
        
        //Constructor
        public Shop(string shopName)
        {
            this.shopName = shopName;  //the shop name is initialize with the given name as parameter 
            gamesForSale = new List<Game>();  //create the list object for storing the available games
        }

        //Get Methods
        public string GetShopName //This method returns the name of the shop
        {
            get { return shopName; } 
        }

        public int CurrentlyViewedGame //this method returns the current index position of the game in the list 
        {
            get { return currentlyViewedGame; }
        }  
         
        public int NumberOfGame //This returns the number of available games in the list 
        {
            get { return gamesForSale.Count; }
        }

        //class methods
        public string DescribeCurrentGame() //This method gives the description of the current viewed game
        {
            string description;

            if(NumberOfGame > 0)
            {
                description = gamesForSale[currentlyViewedGame].Description();
            }
            else
            {
                description = "No available game in stock";
            }
            return description;
        }

        public bool IsNextGame() //Mehtod to check if there is a next game item in the list
        {
            if(currentlyViewedGame < gamesForSale.Count - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void StepToNextGame() //Method to move next position of the list for an available game
        {
            if (IsNextGame())
            {
                currentlyViewedGame++;
            }
        }

        public bool IsPreviousGame() //Method to check if there is a previous game in the list
        {
            if(currentlyViewedGame > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void StepToPreviousGame() //Method to move next position of the list for an available game
        {
            if (IsPreviousGame())
            {
                currentlyViewedGame--;
            }
        }

        public void AddGame(Game game) //Method to add a new game to the list
        {
            gamesForSale.Add(game);
        }

        private void legaliseCurrentlyViewedGame()
        {
            if(CurrentlyViewedGame > (gamesForSale.Count - 1))
            {
                /*This ensures that the index position of the game doesn't go down to -1*/
                currentlyViewedGame = gamesForSale.Count - 1;
                if (CurrentlyViewedGame < 0)
                {
                    currentlyViewedGame = 0; //ensure that the index position of the game viewed is legal or 0 
                }
            }
        }

        public void RemoveGame(int index) //Method to remove a game at a given position in the list
        {
            if(index < gamesForSale.Count)
            {
                gamesForSale.RemoveAt(index);
            }
            //To ensure that index position is either 0 or value pointing to an existing position
            legaliseCurrentlyViewedGame();
        }





    }
}
