using GameWinForm.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;

namespace GameWinForm
{
    /**************************************************************\
    | Partial class means part of the source code is from Form     |
    |class and part is in another class. The GameForm inherites    |
    |from Form class and extend the Form class (i.e.Functionalities| 
    |are added).                                                   |
    \**************************************************************/
    public partial class GameForm : Form 
    {
        Shop shop;
        int currentGame = 0;
        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            //Instance of Shop class;
            shop = new Shop("Game Centre");
/*
            //Added games for the shop
            PSGame ps1 = new PSGame("Super Mario BroX", "Nintendo EAD", 15m, new DateTime(2009, 06, 25),Game.Condition.poor);
            PSGame ps2 = new PSGame("FIFA15", "Electronic Arts", 24m, new DateTime(2014, 09, 23), Game.Condition.fair);
            XboxGame X1 = new XboxGame("FIFA17", "Electronic Arts", 32m, new DateTime(2016, 09, 27), Game.Condition.good);
            XboxGame X2 = new XboxGame("NBA 2K20", "Visual Concepts", 45m, new DateTime(2019, 09, 05), Game.Condition.mint);

            shop.AddGame(ps1);
            shop.AddGame(ps2);
            shop.AddGame(X1);
            shop.AddGame(X2);

            currentGame = shop.CurrentlyViewedGame;*/
            labelShop.Text = shop.GetShopName;
            DisplayGame(currentGame);
            EnableValidControls();
            
        }

        // Method to display on the main form
        private void DisplayGame(int current)
        {
                Debug.Assert(current >= 0); // To check if current index is a legal value
            if ((current < shop.NumberOfGame))
            {
                
                labelCurrentGame.Text = string.Format("Viewing {0} of {1} in {2}", shop.CurrentlyViewedGame + 1, shop.NumberOfGame, shop.GetShopName);
                gameTextBox.Text = shop.DescribeCurrentGame();
            }
            else
            {
                
                labelCurrentGame.Text = "No games to display";
            }
            
        }

        

        /* Event handler for button to close the Form*/       
        private void Close_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to exit?", "cancel",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        
        /*Event handler for button to display next game item*/
        private void nextButton_Click(object sender, EventArgs e)
        {
            shop.StepToNextGame();
            currentGame = shop.CurrentlyViewedGame;
            DisplayGame(currentGame);
           
        }

        /*Event handler for button to display previous game item*/
        private void prevButton_Click(object sender, EventArgs e)
        {
            shop.StepToPreviousGame();
            currentGame = shop.CurrentlyViewedGame;
            DisplayGame(currentGame);
           
        }

        //Event handler for adding a game to the shop list
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Game game = null; //Declared game instance with no values.
            AddForm addForm = new AddForm(game, shop); //loads the add form

            if((addForm.ShowDialog()) == System.Windows.Forms.DialogResult.OK)
            {
                shop.AddGame(game);
                currentGame = shop.NumberOfGame - 1;
               
            }
            DisplayGame(currentGame);
            EnableValidControls();
        }

        //Event handler to delete the current game when Delete button is clicked
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(shop.CurrentlyViewedGame < shop.NumberOfGame)
            {
                string currentGame = shop.CurrentGameName(shop.CurrentlyViewedGame); //variable to hold current game

                if (MessageBox.Show("Delete " + currentGame + ". Are you sure you want to delete? ","Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    DeleteCurrentGame(); ////Called method to delete the current game (See method definition below)
                }
                
            }

        }

        //Method to delete the current game 
        public void DeleteCurrentGame()
        {
            if (shop.NumberOfGame > 0)
            {
                string nameGame = shop.CurrentGameName(currentGame); //variable to hold current game
                shop.RemoveGame(currentGame); //Remove method (See definition in Shop.cs) called to remove current game 

                if (currentGame >= shop.NumberOfGame)
                {
                    if (shop.NumberOfGame > 0)
                    {
                        currentGame = shop.NumberOfGame - 1; //index value of the shop list is decreased
                    }
                    else
                    {
                        currentGame = 0; //index value remain as position zero
                    }
                }
                DisplayGame(currentGame);
                MessageBox.Show(nameGame + " deleted", "Delete Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        //Event handler to sort shop list
        private void btnSort_Click(object sender, EventArgs e)
        {
            shop.GameSort(); //Sort shop list based on the price of game (incrementing order)
            DisplayGame(currentGame);
        }

        //Event handler for when a find button is clicked 
        private void btnFind_Click(object sender, EventArgs e)
        {
            formFind finForm = new formFind(shop);//instance of the find form
            finForm.ShowDialog();//Opens the find form 
        }

        //Event handler for saving a list
        private void btnSave_Click(object sender, EventArgs e)
        {
            GameSave();
        }

        //Method for saving a game list
        private void GameSave()
        {
            //string saveFile = null;
            SaveFileDialog saveDia = new SaveFileDialog();
            saveDia.DefaultExt = "*.txt*";
            saveDia.InitialDirectory = Directory.GetCurrentDirectory();
            saveDia.Filter = "files of Game list (*.text)|*.txt";
            saveDia.FileName = "gamelist_data.txt";

            DialogResult diaR = saveDia.ShowDialog();
            string saveFile = null;
            if (diaR == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    saveFile = saveDia.FileName;
                    System.IO.FileStream sf = new System.IO.FileStream(saveFile, System.IO.FileMode.Create);
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter fBin = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    fBin.Serialize(sf, shop.GetGameForSale);
                    sf.Close();
                }
                catch (System.IO.IOException ex)
                {
                    MessageBox.Show(ex.Message, "Save File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Event handler for loading game list
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadGameList();
        }

        //Method for loading a Game List
        private void LoadGameList()
        {
            string fileName = null;
            OpenFileDialog openDia = new OpenFileDialog();
            openDia.DefaultExt = "*.txt";
            openDia.Filter = "files of Game list (text)|*.txt";
            openDia.FileName = "Game_Data.txt";
            openDia.InitialDirectory = Directory.GetCurrentDirectory();

            DialogResult DiaR = openDia.ShowDialog(); 

            if(DiaR == System.Windows.Forms.DialogResult.OK)
            {
                //To handle any failure, try-catch block is used.

                try
                {
                    fileName = openDia.FileName;
                    System.IO.FileStream fileS = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter fB = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    List<Game> restoredList = null;
                    restoredList = (List<Game>)fB.Deserialize(fileS);
                    fileS.Close();

                    //copy data across to original list

                    shop.GetGameForSale = restoredList;

                    //To view 1st game (if it exists)
                    currentGame = 0;
                    DisplayGame(currentGame);
                    EnableValidControls();
                }
                catch(System.IO.IOException ex)
                {
                    MessageBox.Show(ex.Message, "Load File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /*this method gray buttons using boolean logic*/
        private void EnableValidControls()
        {        
            prevButton.Enabled = Convert.ToBoolean(shop.GetGameForSale.Count > 1);
            nextButton.Enabled = Convert.ToBoolean(shop.GetGameForSale.Count > 1);
            btnDelete.Enabled = Convert.ToBoolean(shop.GetGameForSale.Count > 0);
        }
    }
}
