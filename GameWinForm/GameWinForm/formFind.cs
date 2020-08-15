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
    public partial class formFind : Form
    {
        Shop shop;
        List<Game> findResult;
        public formFind(Shop shop)
        {
            InitializeComponent();
            this.shop = shop;
            Findbtn.Enabled = txtFind.Text != ""; //Enables the find button when the textbox is clicked.
        }

        private void formFind_Load(object sender, EventArgs e)
        {
           
        }

        //Event handler when the find button is clicked
        private void Findbtn_Click(object sender, EventArgs e)
        {
            findResult = shop.FindGame(txtFind.Text.ToString());//search list will access the shop
            txtResult.Text = findResult[0].Description();
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close(); //Closes or cancels the find dialog
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            Findbtn.Enabled = txtFind.Text != "";//enables the button when the textbox is filled. 
        }
    }
}
