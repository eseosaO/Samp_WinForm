using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWinForm.Classes
{
    //[Serializable()] //Serializable implies that this class can be written to disk
    /*****************************************************************************\
    | Developed By Dr Eseosa Oshodin                                              |
    |The Shop class has a list to store both PS games and Xbox games              |
    \*****************************************************************************/
    
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
            set { shopName = value; }
        }

        public List<Game> GetGameForSale
        {
            get { return gamesForSale; }
            set { gamesForSale = value; }
        }

        public int CurrentlyViewedGame //this method returns the current index position of the game in the list 
        {
            get { return currentlyViewedGame; }
            set { currentlyViewedGame = value; }
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
        //Method to retrieve current game title.
        public string CurrentGameName(int index)
        {
            string GameTitle = gamesForSale[currentlyViewedGame].GetTitle;
            return GameTitle;
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
            else if(gamesForSale.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("There is no Game to view. Please add games."); 
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("There is no more Game to view. Please click previous Button.");
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
            else if(gamesForSale.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("There is no Game to view. Please add games.");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("There is no previous Game to view.");
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
                legaliseCurrentlyViewedGame();
            }
            //To ensure that index position is either 0 or value pointing to an existing position
            
        }

        /*Method to sort Games*/
        public void GameSort()
        {
            gamesForSale.Sort(); //List of games sorted in incrementing order
        }

        /*Method to find a game*/
        public List<Game> FindGame(string game)
        {
            List<Game> Result = new List<Game>(); // A list used to store results from search

            for(int i = 0; i < gamesForSale.Count; i++)
            {
                if (GetGameForSale[i].GetTitle.ToLower().Contains(game.ToLower()))
                {
                    Result.Add(gamesForSale[i]);
                }
            }

            return Result;
        }




    }
}
