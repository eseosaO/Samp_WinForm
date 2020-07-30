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
using static GameWinForm.Game;

namespace GameWinForm
{
    //partial class 'AddForm' to add a game. 
    public partial class AddForm : Form
    {
        private Game game;
        private Shop shop;
        private string title = null;
        private decimal price = 0;        
        private string dev = null;
        private Condition con;
        DateTime RelDt;



        /*Constructor to create an instance of AddForm*/
        public AddForm(Game game, Shop shop)
        {
            InitializeComponent();
            this.game = game;
            this.shop = shop;

            btnAdd.Enabled = false; //The Add button will be initially be disabled. 
        }

        
        /*Setup when the form is loaded*/
        private void AddForm_Load(object sender, EventArgs e)
        {
               
            cmbConsole.Items.Add("Playstation"); //Item 'playstation' is added to dropdown list 
            cmbConsole.Items.Add("Xbox"); //Item 'Xbox' is added to dropdown list 

            /*Loop to add each item fro Enum to the dropdown list*/
            foreach (var item in Enum.GetValues(typeof(Condition)))
            {
                cmbCondition.Items.Add(item);
            }
        }

        

        
        /*Event handler for the addition of a game*/
        private void btnAdd_Click(object sender, EventArgs e)
        {
            title = txtTitle.Text;
            dev = txtDev.Text;
            string cons = Enum.GetName(typeof(Condition), con);
            
            
            int index;
            index = cmbCondition.SelectedIndex;
            

            con = (Condition)Enum.Parse(typeof(Condition), index.ToString());



            try
            {
                RelDt = dateTimePicker1.Value.Date;
            }
            catch
            {
                MessageBox.Show("There must be a date", "Date Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                price = Convert.ToDecimal(txtPrice.Text);
            }
            catch
            {
                MessageBox.Show("Price must be a decimal number", "Price Format Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            if(index != -1 )
            {
                if(cmbConsole.Text == "Playstation")
                {
                    game = new PSGame(title, dev, price, RelDt, con);
                }
                else
                {
                    game = new XboxGame(title, dev, price, RelDt, con);
                }
                
            }
            shop.AddGame(game); //Add the new game to the List
            this.Close();
        }

        /*Event handler for cancelling the addition of a game*/
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        /*Event handler where all item must be complete to enable the Add button*/
        private void panelAddForm_MouseMove(object sender, MouseEventArgs e)
        {
            if( (cmbConsole.SelectedIndex > -1)
                &&(txtTitle.Text != null)
                &&(dateTimePicker1.Text != null)
                &&(txtDev.Text != null)
                &&(txtPrice.Text != null)
                &&(cmbCondition.SelectedIndex > -1)
                )
            {
                btnAdd.Enabled = true;
            }
        }


    }
}
