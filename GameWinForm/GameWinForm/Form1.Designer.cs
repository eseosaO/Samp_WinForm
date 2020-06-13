namespace GameWinForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gameTextBox = new System.Windows.Forms.TextBox();
            this.nextButton = new System.Windows.Forms.Button();
            this.prevButton = new System.Windows.Forms.Button();
            this.labelCurrentGame = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTextBox
            // 
            this.gameTextBox.Location = new System.Drawing.Point(64, 102);
            this.gameTextBox.Multiline = true;
            this.gameTextBox.Name = "gameTextBox";
            this.gameTextBox.Size = new System.Drawing.Size(464, 189);
            this.gameTextBox.TabIndex = 0;
            this.gameTextBox.TextChanged += new System.EventHandler(this.gameTextBox_TextChanged);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(64, 358);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(111, 44);
            this.nextButton.TabIndex = 1;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            // 
            // prevButton
            // 
            this.prevButton.Location = new System.Drawing.Point(211, 358);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(119, 44);
            this.prevButton.TabIndex = 2;
            this.prevButton.Text = "Previous";
            this.prevButton.UseVisualStyleBackColor = true;
            // 
            // labelCurrentGame
            // 
            this.labelCurrentGame.AutoSize = true;
            this.labelCurrentGame.Location = new System.Drawing.Point(77, 55);
            this.labelCurrentGame.Name = "labelCurrentGame";
            this.labelCurrentGame.Size = new System.Drawing.Size(51, 20);
            this.labelCurrentGame.TabIndex = 3;
            this.labelCurrentGame.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 450);
            this.Controls.Add(this.labelCurrentGame);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.gameTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox gameTextBox;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Label labelCurrentGame;
    }
}

