using AnnualizeLibrary;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnnualizedGUI
{
	public partial class MainWindow : Form
	{
		
		[Flags]
		enum InputErrors : short
		{
			None = 0,
			FundNotFound = 1,
			PeriodsFormat = 2,
			NumberOfSharesFormat = 4,
			SharePriceFormat = 8,
			TransacHistoryNotEntered = 16,
			FundNameNotEntered = 32
		};

		private Stack<string> backHistoryStack;
		private Stack<string> forwardHistoryStack;

		public MainWindow()
		{
			InitializeComponent();
			Directory.CreateDirectory(TsvUpdater.dataDirectory);
			fundNameTextBox.Items.AddRange(GetSavedFundNames());
			backHistoryStack = new Stack<string>();
			forwardHistoryStack = new Stack<string>();
		}

		private void MainWindow_Load(object sender, EventArgs e)
		{
			ToolTip toolTip = new ToolTip();

			toolTip.ShowAlways = true;
			toolTip.AutoPopDelay = 10000;

			toolTip.SetToolTip(currentPriceLabel, "Ex: 10.14");
			toolTip.SetToolTip(currentPriceTextBox, "Ex: 10.14");
			toolTip.SetToolTip(currentNumSharesLabel, "Ex: 102.12");
			toolTip.SetToolTip(currentNumShares_TextBox, "Ex: 102.12");
			toolTip.SetToolTip(periodsLabel, "Ex: 30 60 180 365");
			toolTip.SetToolTip(periods_textBox, "Ex: 30 60 180 365");
			toolTip.SetToolTip(getMostRecentButton, "Gets annualized data based on previously supplied data.\n" +
				"Requires Fund Name. Period(s) may be supplied or default periods will be applied (30, 60, 180, 365, and max)");
			toolTip.SetToolTip(UpdateAndGetAnnualizedButton, "Updates transaction history and provides annualized data.\n" +
				"Requires all fields populated (Periods may be left empty to use default values of 30, 60, 180, 365, and max),\n" +
				"as well as a transaction history copied to the console.");
			toolTip.SetToolTip(backButton, "Moves backwards into console history");
			toolTip.SetToolTip(forwardButton, "Moves forward in console history");
			toolTip.SetToolTip(consoleLabel, "Input : Transaction Histories - Output : Annualized ROR");
		}

		private void GetMostRecentAnnualizedData_Click(object sender, EventArgs e)
		{
			// Input Formatting Errors

			InputErrors errorFlags = InputErrors.None;
			if (!IsPeriodsFormatValid(periods_textBox.Text))
			{
				errorFlags |= InputErrors.PeriodsFormat;
			}
			if (!IsFundNameValid(fundNameTextBox.Text))
			{
				errorFlags |= InputErrors.FundNotFound;
			}
			
			if (errorFlags > 0)
			{
				showInputErrorMessage(errorFlags);
				return;
			}

			// Regular Processing

			Annualizer annualizer = new Annualizer();
			annualizer.FundName = fundNameTextBox.Text.Trim();
			
			int[] periods = GetPeriods();
			string tsvFilePath = TsvUpdater.GetTsvFilePath(annualizer.FundName);

			using (StreamReader reader = new StreamReader(tsvFilePath))
			{
				reader.ReadLine();       // first field names
				string presentData = reader.ReadLine();				
				string[] f = presentData.Split(new char[] { ' ', '\t' },
							StringSplitOptions.RemoveEmptyEntries);

				annualizer.PresentPrice = double.Parse(f[0]);
				annualizer.PresentNumberOfShares = double.Parse(f[1]);
				annualizer.FinalDate = new DateTime(
							int.Parse(f[2]), int.Parse(f[3]), int.Parse(f[4]));				
			}

			try
			{
				textBoxConsole.Text = annualizer.getCustom(tsvFilePath, periods);
			}
			catch 
			{
				textBoxConsole.Text = "Couldn't calculate annualized rate for: " + Path.GetFileName(tsvFilePath);
				textBoxConsole.AppendText(Environment.NewLine + Environment.NewLine);
				textBoxConsole.AppendText("Check error logs");
				//MessageBox.Show("Problem processing data", "Error",
				//MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

				
			annualizer.ResetFundFields();

			// push the nex console content to the history stack
			backHistoryStack.Push(textBoxConsole.Text);

			return;

		}

		private void UpdateAndGetAnnualized_Click(object sender, EventArgs e)
		{
			// Input Format Errors
			InputErrors errorFlags = InputErrors.None;

			if (String.IsNullOrWhiteSpace(fundNameTextBox.Text))
			{
				errorFlags |= InputErrors.FundNameNotEntered;
			}
			if (!IsPeriodsFormatValid(periods_textBox.Text))
			{
				errorFlags |= InputErrors.PeriodsFormat;
			}
			if (!IsNumSharesFormatValid(currentNumShares_TextBox.Text))
			{
				errorFlags |= InputErrors.NumberOfSharesFormat;
			}
			if (!IsPriceFormatValid(currentPriceTextBox.Text))
			{
				errorFlags |= InputErrors.SharePriceFormat;
			}
			if (String.IsNullOrWhiteSpace(textBoxConsole.Text))
			{
				errorFlags |= InputErrors.TransacHistoryNotEntered;
			}

			if (errorFlags > 0)
			{
				showInputErrorMessage(errorFlags);
				return;
			}

			// Regular processing

			// push the console content to the history stack without checking its validity
			backHistoryStack.Push(textBoxConsole.Text);

			var now = DateTime.Now;
			Annualizer annualizer = new Annualizer();
			annualizer.FinalDate = now;
			annualizer.FundName = fundNameTextBox.Text.Trim();
			annualizer.PresentNumberOfShares = double.Parse(currentNumShares_TextBox.Text);
			annualizer.PresentPrice = double.Parse(currentPriceTextBox.Text.Replace("$", string.Empty));
			
			int[] periods = GetPeriods();

			string tsvFilePath = TsvUpdater.GetTsvFilePath(annualizer.FundName);
			
			var sr = new StringReader(textBoxConsole.Text);

			if (TsvUpdater.BMO(
				sr, 
				tsvFilePath, 
				annualizer.PresentPrice, 
				annualizer.PresentNumberOfShares,
				now.Year,
				now.Month,
				now.Day))
			{
				try
				{
					textBoxConsole.Text = annualizer.getCustom(tsvFilePath, periods);
				}
				catch
				{
					textBoxConsole.Text = "Couldn't calculate annualized rate" + Path.GetFileName(tsvFilePath);
					textBoxConsole.AppendText(Environment.NewLine + Environment.NewLine);
					textBoxConsole.AppendText("Check error logs");
				}
					
				annualizer.ResetFundFields();
			}
			else
			{
				textBoxConsole.Text = "Couldn't create/update data file: " + tsvFilePath + 
					Environment.NewLine + Environment.NewLine +
					"\n\nCheck error logs";

			}
				
			sr.Close();

			UpdateFundNameList();

			// push the nex console content to the history stack
			backHistoryStack.Push(textBoxConsole.Text);
		}

		private void ClearTextBox_Click(object sender, EventArgs e)
		{
			textBoxConsole.ResetText();
		}

		private int[] GetPeriods()
		{
			int[] periods;

			// default values
			if (string.IsNullOrWhiteSpace(periods_textBox.Text))
			{
				periods = new int[] { 30, 60, 180, 365, 10000 };
			}
			else
			{
				string[] periods_text = periods_textBox.Text.Split(new string[] { "\t", " " },
				StringSplitOptions.RemoveEmptyEntries);
				periods = Array.ConvertAll<string, int>(periods_text, int.Parse);
			}

			return periods;
		}

		private string[] GetSavedFundNames()
		{
			Directory.CreateDirectory(TsvUpdater.dataDirectory);
			string[] files = Directory.GetFiles(TsvUpdater.dataDirectory, "*.tsv");
			for (int i = 0; i < files.Length; ++i)
			{
				files[i] = GetFundNameFromPath(files[i]);
			}
			return files;
		}

		private string GetFundNameFromPath(string filePath)
		{
			int extensionLength = 4; // .tsv
			string fileName = Path.GetFileName(filePath);
			int nameLength = fileName.Length - extensionLength;
			string fundName = fileName.Substring(0, nameLength);
			return Regex.Replace(fundName, "_", " ");
		}

		private void UpdateFundNameList()
		{
			fundNameTextBox.Items.Clear();
			fundNameTextBox.Items.AddRange(GetSavedFundNames());			
		}

		private bool IsFundNameValid(string fundName)
		{
			return GetSavedFundNames().Contains(fundName);
		}
		
		private bool IsPeriodsFormatValid(string entry)
		{
			// empty string is valid since default values will be used
			if (String.IsNullOrWhiteSpace(entry))
			{
				return true;
			}
			
			entry = entry.Trim();
			string pattern = @"^[0-9]+(\s+[0-9]+)*$"; // ex: 23  23 45  32
			return Regex.IsMatch(entry, pattern);
		}

		private bool IsNumSharesFormatValid(string entry)
		{
			entry = entry.Trim();
			string pattern = @"^[0-9]+(\.[0-9]+)?$"; // ex: 123.2134
			return Regex.IsMatch(entry, pattern);
		}

		private bool IsPriceFormatValid(string entry)
		{
			entry = entry.Trim();
			string pattern = @"^[0-9]+(\.[0-9]+)?$"; // ex: 123.2134
			return Regex.IsMatch(entry, pattern);
		}

		private void showInputErrorMessage(InputErrors errorFlags)
		{
			StringBuilder message = new StringBuilder();

			if (errorFlags.HasFlag(InputErrors.FundNameNotEntered))
			{
				message.Append("- No fund name was entered.\n\n");
			}
			if (errorFlags.HasFlag(InputErrors.FundNotFound))
			{
				message.Append("- Fund not found.\n\n");
			}
			if (errorFlags.HasFlag(InputErrors.PeriodsFormat))
			{
				message.Append("- Wrong format for periods. Ex: \"30 60 180 365\"\n\n");
			}
			if (errorFlags.HasFlag(InputErrors.NumberOfSharesFormat))
			{
				message.Append("- Wrong format for current number of shares. Ex: \"123.1234\"\n\n");
			}
			if (errorFlags.HasFlag(InputErrors.SharePriceFormat))
			{
				message.Append("- Wrong format for current share price. Ex: \"10.14\"\n\n");
			}
			if (errorFlags.HasFlag(InputErrors.TransacHistoryNotEntered))
			{
				message.Append("- No transaction history was copied to the console.\n\n");
			}
			


			MessageBox.Show(message.ToString(), "Input Formatting Problem",
			MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void clearFieldsButton_Click(object sender, EventArgs e)
		{
			fundNameTextBox.Text = string.Empty;
			periods_textBox.Text = string.Empty;
			currentNumShares_TextBox.Text = string.Empty;
			currentPriceTextBox.Text = string.Empty;
		}

		private void backButton_Click(object sender, EventArgs e)
		{
			if (backHistoryStack.Count() > 1)
			{
				forwardHistoryStack.Push(backHistoryStack.Pop());
				textBoxConsole.Text = backHistoryStack.Peek();
			}			
		}

		private void forwardButton_Click(object sender, EventArgs e)
		{
			if (forwardHistoryStack.Count() > 0)
			{
				backHistoryStack.Push(forwardHistoryStack.Pop());
				textBoxConsole.Text = backHistoryStack.Peek();
			}				
		}
	}
}
