using System.Collections.Specialized;
using System.Drawing;
using System.Windows.Forms;

namespace AnnualizedGUI
{
	partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.fundNameLabel = new System.Windows.Forms.Label();
            this.fundNameTextBox = new System.Windows.Forms.ComboBox();
            this.periodsLabel = new System.Windows.Forms.Label();
            this.periods_textBox = new System.Windows.Forms.TextBox();
            this.getMostRecentButton = new System.Windows.Forms.Button();
            this.currentNumSharesLabel = new System.Windows.Forms.Label();
            this.currentNumShares_TextBox = new System.Windows.Forms.TextBox();
            this.currentPriceLabel = new System.Windows.Forms.Label();
            this.currentPriceTextBox = new System.Windows.Forms.TextBox();
            this.textBoxConsole = new System.Windows.Forms.TextBox();
            this.UpdateAndGetAnnualizedButton = new System.Windows.Forms.Button();
            this.clearTextBoxButton = new System.Windows.Forms.Button();
            this.clearFieldsButton = new System.Windows.Forms.Button();
            this.consoleLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.forwardButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fundNameLabel
            // 
            this.fundNameLabel.AutoSize = true;
            this.fundNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fundNameLabel.Location = new System.Drawing.Point(260, 45);
            this.fundNameLabel.Name = "fundNameLabel";
            this.fundNameLabel.Size = new System.Drawing.Size(78, 16);
            this.fundNameLabel.TabIndex = 12;
            this.fundNameLabel.Text = "Fund Name";
            this.fundNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fundNameTextBox
            // 
            this.fundNameTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.fundNameTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.fundNameTextBox.FormattingEnabled = true;
            this.fundNameTextBox.Location = new System.Drawing.Point(344, 45);
            this.fundNameTextBox.Name = "fundNameTextBox";
            this.fundNameTextBox.Size = new System.Drawing.Size(366, 21);
            this.fundNameTextBox.TabIndex = 1;
            // 
            // periodsLabel
            // 
            this.periodsLabel.AutoSize = true;
            this.periodsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periodsLabel.Location = new System.Drawing.Point(283, 86);
            this.periodsLabel.Name = "periodsLabel";
            this.periodsLabel.Size = new System.Drawing.Size(55, 16);
            this.periodsLabel.TabIndex = 9;
            this.periodsLabel.Text = "Periods";
            this.periodsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // periods_textBox
            // 
            this.periods_textBox.Location = new System.Drawing.Point(344, 86);
            this.periods_textBox.Name = "periods_textBox";
            this.periods_textBox.Size = new System.Drawing.Size(366, 20);
            this.periods_textBox.TabIndex = 2;
            // 
            // getMostRecentButton
            // 
            this.getMostRecentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getMostRecentButton.Location = new System.Drawing.Point(797, 43);
            this.getMostRecentButton.Name = "getMostRecentButton";
            this.getMostRecentButton.Size = new System.Drawing.Size(195, 67);
            this.getMostRecentButton.TabIndex = 3;
            this.getMostRecentButton.Text = "Get Most Recent Annualized Data";
            this.getMostRecentButton.UseVisualStyleBackColor = true;
            this.getMostRecentButton.Click += new System.EventHandler(this.GetMostRecentAnnualizedData_Click);
            // 
            // currentNumSharesLabel
            // 
            this.currentNumSharesLabel.AutoSize = true;
            this.currentNumSharesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentNumSharesLabel.Location = new System.Drawing.Point(182, 131);
            this.currentNumSharesLabel.Name = "currentNumSharesLabel";
            this.currentNumSharesLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.currentNumSharesLabel.Size = new System.Drawing.Size(156, 16);
            this.currentNumSharesLabel.TabIndex = 10;
            this.currentNumSharesLabel.Text = "Current number of shares";
            this.currentNumSharesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // currentNumShares_TextBox
            // 
            this.currentNumShares_TextBox.Location = new System.Drawing.Point(344, 131);
            this.currentNumShares_TextBox.Name = "currentNumShares_TextBox";
            this.currentNumShares_TextBox.Size = new System.Drawing.Size(148, 20);
            this.currentNumShares_TextBox.TabIndex = 4;
            // 
            // currentPriceLabel
            // 
            this.currentPriceLabel.AutoSize = true;
            this.currentPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPriceLabel.Location = new System.Drawing.Point(254, 175);
            this.currentPriceLabel.Name = "currentPriceLabel";
            this.currentPriceLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.currentPriceLabel.Size = new System.Drawing.Size(84, 16);
            this.currentPriceLabel.TabIndex = 11;
            this.currentPriceLabel.Text = "Current Price";
            this.currentPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // currentPriceTextBox
            // 
            this.currentPriceTextBox.Location = new System.Drawing.Point(344, 175);
            this.currentPriceTextBox.Name = "currentPriceTextBox";
            this.currentPriceTextBox.Size = new System.Drawing.Size(148, 20);
            this.currentPriceTextBox.TabIndex = 5;
            // 
            // textBoxConsole
            // 
            this.textBoxConsole.AcceptsReturn = true;
            this.textBoxConsole.AcceptsTab = true;
            this.textBoxConsole.AllowDrop = true;
            this.textBoxConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.textBoxConsole.HideSelection = false;
            this.textBoxConsole.Location = new System.Drawing.Point(25, 268);
            this.textBoxConsole.Multiline = true;
            this.textBoxConsole.Name = "textBoxConsole";
            this.textBoxConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxConsole.Size = new System.Drawing.Size(967, 403);
            this.textBoxConsole.TabIndex = 6;
            // 
            // UpdateAndGetAnnualizedButton
            // 
            this.UpdateAndGetAnnualizedButton.AutoSize = true;
            this.UpdateAndGetAnnualizedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.UpdateAndGetAnnualizedButton.Location = new System.Drawing.Point(797, 139);
            this.UpdateAndGetAnnualizedButton.Name = "UpdateAndGetAnnualizedButton";
            this.UpdateAndGetAnnualizedButton.Size = new System.Drawing.Size(196, 48);
            this.UpdateAndGetAnnualizedButton.TabIndex = 7;
            this.UpdateAndGetAnnualizedButton.Text = "Update and Get Annualized!";
            this.UpdateAndGetAnnualizedButton.UseVisualStyleBackColor = true;
            this.UpdateAndGetAnnualizedButton.Click += new System.EventHandler(this.UpdateAndGetAnnualized_Click);
            // 
            // clearTextBoxButton
            // 
            this.clearTextBoxButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearTextBoxButton.Location = new System.Drawing.Point(25, 234);
            this.clearTextBoxButton.Name = "clearTextBoxButton";
            this.clearTextBoxButton.Size = new System.Drawing.Size(130, 27);
            this.clearTextBoxButton.TabIndex = 8;
            this.clearTextBoxButton.Text = "Clear Console";
            this.clearTextBoxButton.UseVisualStyleBackColor = true;
            this.clearTextBoxButton.Click += new System.EventHandler(this.ClearTextBox_Click);
            // 
            // clearFieldsButton
            // 
            this.clearFieldsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearFieldsButton.Location = new System.Drawing.Point(25, 201);
            this.clearFieldsButton.Name = "clearFieldsButton";
            this.clearFieldsButton.Size = new System.Drawing.Size(130, 27);
            this.clearFieldsButton.TabIndex = 13;
            this.clearFieldsButton.Text = "Clear Fields";
            this.clearFieldsButton.UseVisualStyleBackColor = true;
            this.clearFieldsButton.Click += new System.EventHandler(this.clearFieldsButton_Click);
            // 
            // consoleLabel
            // 
            this.consoleLabel.AutoSize = true;
            this.consoleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.consoleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleLabel.Location = new System.Drawing.Point(830, 243);
            this.consoleLabel.Name = "consoleLabel";
            this.consoleLabel.Size = new System.Drawing.Size(163, 22);
            this.consoleLabel.TabIndex = 14;
            this.consoleLabel.Text = "Input/Output Console";
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Image = ((System.Drawing.Image)(resources.GetObject("backButton.Image")));
            this.backButton.Location = new System.Drawing.Point(161, 225);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(46, 37);
            this.backButton.TabIndex = 15;
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // forwardButton
            // 
            this.forwardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forwardButton.Image = ((System.Drawing.Image)(resources.GetObject("forwardButton.Image")));
            this.forwardButton.Location = new System.Drawing.Point(213, 225);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(52, 37);
            this.forwardButton.TabIndex = 16;
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1027, 683);
            this.Controls.Add(this.forwardButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.consoleLabel);
            this.Controls.Add(this.clearFieldsButton);
            this.Controls.Add(this.fundNameTextBox);
            this.Controls.Add(this.getMostRecentButton);
            this.Controls.Add(this.clearTextBoxButton);
            this.Controls.Add(this.UpdateAndGetAnnualizedButton);
            this.Controls.Add(this.textBoxConsole);
            this.Controls.Add(this.periods_textBox);
            this.Controls.Add(this.periodsLabel);
            this.Controls.Add(this.currentNumSharesLabel);
            this.Controls.Add(this.currentPriceLabel);
            this.Controls.Add(this.fundNameLabel);
            this.Controls.Add(this.currentPriceTextBox);
            this.Controls.Add(this.currentNumShares_TextBox);
            this.Name = "MainWindow";
            this.Text = "Annualized!";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox currentNumShares_TextBox;
		private System.Windows.Forms.TextBox currentPriceTextBox;
		private System.Windows.Forms.Label fundNameLabel;
		private System.Windows.Forms.Label currentPriceLabel;
		private System.Windows.Forms.Label currentNumSharesLabel;
		private System.Windows.Forms.Label periodsLabel;
		private System.Windows.Forms.TextBox periods_textBox;
		private System.Windows.Forms.TextBox textBoxConsole;
		private System.Windows.Forms.Button UpdateAndGetAnnualizedButton;
		private System.Windows.Forms.Button clearTextBoxButton;
		private System.Windows.Forms.Button getMostRecentButton;
        private System.Windows.Forms.ComboBox fundNameTextBox;
        private Button clearFieldsButton;
        private Label consoleLabel;
        private Button backButton;
        private Button forwardButton;
    }
}

