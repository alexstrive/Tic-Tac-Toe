using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicZero;

namespace TicZero
{
	public partial class MainForm : Form
	{
		public Button[] btnArray = new Button[9];

		public MainForm()
		{
			InitializeComponent();

			btnArray[0] = btn1;
			btnArray[1] = btn2;
			btnArray[2] = btn3;
			btnArray[3] = btn4;
			btnArray[4] = btn5;
			btnArray[5] = btn6;
			btnArray[6] = btn7;
			btnArray[7] = btn8;
			btnArray[8] = btn9;
		}

		// this method need for control resualt of click
		private String PutResualt()
		{
			if (GlobalVar._TURN % 2 == 0)
			{
				return "O";
			}
			else
			{
				return "X";
			}
		}

		private bool ChangeTurn()
		{
			GlobalVar._TURN++;
			return true;
		}

		private void UpdateTurn()
		{
			if (GlobalVar._TURN % 2 == 0)
			{
				turn.Text = "Ход зеленых";
				turn.ForeColor = Color.Green;
			}
			else
			{
				turn.Text = "Ход красных";
				turn.ForeColor = Color.Maroon;
			}
		}

		private void BtnClick(object sender, EventArgs e)
		{
			Button btnClicked = (Button)sender;

			if (btnClicked.Text != "X" && btnClicked.Text != "O" && !GlobalVar._ISVICTORY)
			{
				String resualt = PutResualt();

				btnClicked.Text = resualt;

				if (resualt == "X")
				{
					btnClicked.BackColor = Color.Red;
					btnClicked.ForeColor = Color.Maroon;
					btnClicked.FlatAppearance.BorderColor = Color.DarkRed;
				}
				else
				{
					btnClicked.BackColor = Color.Green;
					btnClicked.ForeColor = Color.GreenYellow;
					btnClicked.FlatAppearance.BorderColor = Color.GreenYellow;
				}
				
				ChangeTurn();
				UpdateTurn();

				if (CheckVictory())
				{
					string whoVictory = "";
					if (GlobalVar._TURN % 2 == 0)
					{
						whoVictory = "красные";
					}
					else
					{
						whoVictory = "зеленые";
					}

					DialogResult dlgChoose = MessageBox.Show("Победили " + whoVictory + "\nПерезапустить игру?", "Победа", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

					if (dlgChoose == DialogResult.Yes)
					{
						Restart();
					}
				}
			}
			
		}

		private bool CheckVictory()
		{
			string text1 = btn1.Text;
			string text2 = btn2.Text;
			string text3 = btn3.Text;
			string text4 = btn4.Text;
			string text5 = btn5.Text;
			string text6 = btn6.Text;
			string text7 = btn7.Text;
			string text8 = btn8.Text;
			string text9 = btn9.Text;

			// check on victory first line
				 if (text1 == text2 && text2 == text3 && (text1 == "X" || text1 == "O"))
			{
				GlobalVar._ISVICTORY = true;
				return true;
			}
			// check on victory first collumn
			else if (text1 == text4 && text4 == text7 && (text1 == "X" || text1 == "O"))
			{
				GlobalVar._ISVICTORY = true;
				return true;
			}
			// check on victory middle line
			else if (text4 == text5 && text5 == text6 && (text4 == "X" || text4 == "O"))
			{
				GlobalVar._ISVICTORY = true;
				return true;
			}
			// check on victory middle collumn
			else if (text2 == text5 && text5 == text8 && (text2 == "X" || text2 == "O"))
			{
				GlobalVar._ISVICTORY = true;
				return true;
			}
			// check on victory last line
			else if (text7 == text8 && text8 == text9 && (text7 == "X" || text7 == "O"))
			{
				GlobalVar._ISVICTORY = true;
				return true;
			}
			// check on victory last collumn
			else if (text3 == text6 && text6 == text9 && (text3 == "X" || text3 == "O"))
			{
				GlobalVar._ISVICTORY = true;
				return true;
			}
			// check on victory LeftTop-RightBottom diagonal
			else if (text1 == text5 && text5 == text9 && (text1 == "X" || text1 == "O"))
			{
				GlobalVar._ISVICTORY = true;
				return true;
			}
			// check on victory LeftBottom-RightTop diagonal
			else if (text3 == text5 && text5 == text7 && (text3 == "X" || text3 == "O"))
			{
				GlobalVar._ISVICTORY = true;
				return true;
			}
			else
			{
				return false;
			}
		}

		private void btnRestart_Click(object sender, EventArgs e)
		{
			Restart();
		}

		private void ResetButton(Button btn)
		{
			btn.BackColor = Color.White;
			btn.FlatAppearance.BorderColor = Color.Silver;
			btn.Text = "";
		}

		private void Restart()
		{
			GlobalVar._TURN = 1;
			GlobalVar._ISVICTORY = false;

			turn.Text = "Ход красных";
			turn.ForeColor = Color.Maroon;

			foreach (Button btnTmp in btnArray)
			{
				ResetButton(btnTmp);
			}
		}
	}
}
