using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2 {
	public partial class Form1 : Form {
		private Board b = new Board();
		private Bitmap boardBitmap;
		private int boardWidthHeight = 400;
		private AI ai = new AI();
		private int currentPlayer = -1;
		private bool againtsAi = false;
		private bool help = true;

		public Form1() {
			InitializeComponent();
			boardWidthHeight = gameField.Width;
			gameField.Height = gameField.Width;
			b.updatePosBoard(currentPlayer);
			draw();
		}

		private void draw() {
			//Draw board
			boardBitmap = b.getBoardBitmap(boardWidthHeight);
			gameField.Image = boardBitmap;
			whiteScoreLabel.Text = "White: " + b.getScore(-1) + " points";
			blackScoreLabel.Text = "Black: " + b.getScore(1) + " points";
			if (currentPlayer == -1) {
				statusLabel.Text = "Wit aan zet";
			}else{
				statusLabel.Text = "Zwart aan zet";
			}
			if (b.NoPossibleMoves()) {
				//Remise
				statusLabel.Text = "Both are losers";
				if (b.getScore(-1) > b.getScore(1)) {
					statusLabel.Text = "White is weiner!";
				}
				if (b.getScore(1) > b.getScore(-1)) {
					statusLabel.Text = "Black is weiner!";
				}
			}
			gameField.Update();
		}

		private void gameField_Click(object sender, EventArgs e) {
			MouseEventArgs mea = (MouseEventArgs)e;
			int x = mea.X, y = mea.Y;
			int tileSize = boardWidthHeight / b.GetBoardHeight();
			x = x / tileSize; y = y / tileSize;
			if (x >= 0 && x < b.GetBoardWidth() && y >= 0 && y < b.GetBoardHeight()) {
				if (b.canPlaceTile(x, y, currentPlayer)) {
					b.placeTile(x, y, currentPlayer);
					if (againtsAi) {
						b.ClearPosBoard();
						draw();
						ai.AiMove(b, -currentPlayer, 6);
						if (help)
							b.updatePosBoard(currentPlayer);
					} else {
						if (b.canMove(-currentPlayer)) {
							currentPlayer = -currentPlayer;
						}
						if (help)
							b.updatePosBoard(currentPlayer);
					}
				}
			}
			draw();
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e) {
			againtsAi = ((CheckBox)sender).Checked;
		}

		private void button1_Click(object sender, EventArgs e) {
			int size = (int)boardSizeInput.Value;
			b.SetBoardWidth(size);
			b.SetBoardHeight(size);
			b.reset();
			if (help)
				b.updatePosBoard(currentPlayer);
			draw();
		}

		private void helpSettingInput_CheckedChanged(object sender, EventArgs e) {
			help = helpSettingInput.Checked;
			if (!help) {
				b.ClearPosBoard();
			} else {
				b.updatePosBoard(currentPlayer);
			}
			draw();
		}
	}
}
