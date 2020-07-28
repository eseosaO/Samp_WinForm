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
        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            //Instance of Shop class;
            shop = new Shop("Game Centre");

            //Added games for the shop
            PSGame ps1 = new PSGame("Super Mario BroX", "Nintendo EAD", 15m, new DateTime(2009, 06, 25),Game.Condition.poor);
            PSGame ps2 = new PSGame("FIFA15", "Electronic Arts", 24m, new DateTime(2014, 09, 23), Game.Condition.fair);
            XboxGame X1 = new XboxGame("FIFA17", "Electronic Arts", 32m, new DateTime(2016, 09, 27), Game.Condition.good);
            XboxGame X2 = new XboxGame("NBA 2K20", "Visual Concepts", 45m, new DateTime(2019, 09, 05), Game.Condition.mint);

            shop.AddGame(ps1);
            shop.AddGame(ps2);
            shop.AddGame(X1);
            shop.AddGame(X2);

            DisplayGame();
        }

        // Method to display on the main form
        private void DisplayGame()
        {
                labelShop.Text = shop.GetShopName;
                labelCurrentGame.Text = string.Format("Viewing {0} of {1} in {2}", shop.CurrentlyViewedGame + 1, shop.NumberOfGame, shop.GetShopName);
                gameTextBox.Text = shop.DescribeCurrentGame();
            
            
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
            DisplayGame();
        }

        /*Event handler for button to display previous game item*/
        private void prevButton_Click(object sender, EventArgs e)
        {
            shop.StepToPreviousGame();
            DisplayGame();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Game game = null; //Declared game instance with no values.
            AddForm addForm = new AddForm(game, shop); //loads the add form

            if((addForm.ShowDialog()) == System.Windows.Forms.DialogResult.OK)
            {
                //shop.AddGame(game);
                shop.CurrentlyViewedGame = shop.NumberOfGame - 1;
                DisplayGame();
            }
        }
    }
}
