﻿using System;
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
        public GameForm()
        {
            InitializeComponent();
        }

        private void gameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
