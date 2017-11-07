using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2 {
	class Board { 
		private int boardWidth = 8, boardHeight = 8;
		private const int minBoardWidth = 3, minBoardHeight = 3;
		private int[,] board;
		private int[,] boardWeight;
		private int[,] posBoard;

		private int[] offsetXY = {10, 50};

		public void clone(Board b) {
			boardWidth = b.GetBoardWidth();
			boardHeight = b.GetBoardHeight();
			reset();
			for (int i=0; i<boardWidth; i++) {
				for (int j=0; j<boardHeight; j++) {
					board[i, j] = b.board[i,j];
				}
			}
		}

		public Board() {
			reset();
		}

		public void reset() {
			board = new int[boardWidth, boardHeight];
			posBoard = new int[boardWidth, boardHeight];
			boardWeight = new int[boardWidth, boardHeight];

			//Create position value board dynamically
			for (int i = 0; i < boardWidth; i++) {
				for (int j = 0; j < boardHeight; j++) {
					//Default (worth 1 "point")
					boardWeight[i,j] = 1;
				}
			}
			//Sides (worth 5 points)
			for (int i=0; i < boardWidth; i++) {
				boardWeight[i, 0] = 5;
				boardWeight[i, boardHeight - 1] = 5;
			}
			for (int j=0; j < boardHeight; j++) {
				boardWeight[0, j] = 5;
				boardWeight[boardWidth - 1, j] = 5;
			}
			//Corners (worth 50 "points")
			boardWeight[0, 0] = 50;
			boardWeight[0, boardHeight - 1] = 50;
			boardWeight[boardWidth - 1, 0] = 50;
			boardWeight[boardWidth - 1, boardHeight - 1] = 50;
			//Set around corners (worth -10 "points")
			boardWeight[1, 0] = -10;
			boardWeight[1, 1] = -10;
			boardWeight[0, 1] = -10;

			boardWeight[0, boardHeight-2] = -10;
			boardWeight[1, boardHeight-2] = -10;
			boardWeight[1, boardHeight-1] = -10;

			boardWeight[boardWidth - 2, 0] = -10;
			boardWeight[boardWidth - 2, 1] = -10;
			boardWeight[boardWidth - 1, 1] = -10;

			boardWeight[boardWidth - 1, boardHeight - 2] = -10;
			boardWeight[boardWidth - 2, boardHeight - 2] = -10;
			boardWeight[boardWidth - 2, boardHeight - 1] = -10;


			int x=boardWidth/2-1, y = boardHeight/2-1;
			board[x,   y  ] =  1;
			board[x,   y+1] = -1;
			board[x+1, y  ] = -1;
			board[x+1, y+1] =  1;
		}

		private bool inBounds(int x, int y) {
			if (x >= 0 && x < boardWidth && y >= 0 && y < boardHeight) 
				return true;
			return false;
		}

		public bool canPlaceTile(int x, int y, int col) {
			if (board[x,y] != 0) {
				return false;
			}
			//Go through all 8 directions
			/*And yes it will do dX=0 and dY=0 but this will always result in a non valid conclusion with i=1 
			 *because the field is already checked to be 0 and ith 0 for dX and dY you will always be
			 *checking an empty field which does not meet the requirments of the while statement
			 */
			for (int dX = -1; dX <= 1; dX++) {
				for (int dY = -1; dY <= 1; dY++) {
					int i = 1;
					while (inBounds(x+dX*i, y+dY*i) && board[x+dX*i, y+dY*i] == -col) //Continue in direction until a tile not from the other player is found
						i++;
					if (i == 1) //If it's the first one this cannot be a match
						continue;
					if (inBounds(x + dX * i, y + dY * i) && board[x+dX*i, y+dY*i] == col) //If the last one in a line ofter other's is your own this is a valid move!
						return true;
				}
			}
			return false;
		}

		public void placeTile(int x, int y, int col) {
			board[x, y] = col;
			//Almost same as checkValidPlace code
			for (int dX = -1; dX <= 1; dX++) {
				for (int dY = -1; dY <= 1; dY++) {
					int i = 1;
					while (inBounds(x + dX * i, y + dY * i) && board[x + dX * i, y + dY * i] == -col)
						i++;
					if (i == 1) 
						continue;
					if (inBounds(x + dX * i, y + dY * i) && board[x + dX * i, y + dY * i] == col) {
						i = 1;
						while (inBounds(x + dX * i, y + dY * i) && board[x + dX * i, y + dY * i] == -col) {
							board[x + dX * i, y + dY * i] = col;
							i++;
						}
					}
				}
			}
		}

		public void updatePosBoard(int col) {
			for (int i = 0; i < boardWidth; i++) {
				for (int j = 0; j < boardHeight; j++) {
					posBoard[i, j] = 0;
					if (canPlaceTile(i, j, col)) {
						posBoard[i, j] = col;
					}
				}
			}
		}

		public bool canMove(int col) {
			for (int i = 0; i < boardWidth; i++) {
				for (int j = 0; j < boardHeight; j++) {
					if (canPlaceTile(i, j, col)) {
						return true;
					}
				}
			}
			return false;
		}

		public Bitmap getBoardBitmap(int widthHeight) {
			int tileWidthHeight = ((int)(double)widthHeight / boardWidth);
			Bitmap bitmap = new Bitmap(widthHeight+1, widthHeight+1);
			Graphics g = Graphics.FromImage(bitmap);
			for (int i = 0; i < boardHeight; i++) {
				for (int j = 0; j < boardWidth; j++) {
					if (j % 2 == 0 && !(i % 2 == 0)) {
						g.FillRectangle(Brushes.Green, j*tileWidthHeight, i * tileWidthHeight, tileWidthHeight, tileWidthHeight);
					} else if (j % 2 == 0) {
						g.FillRectangle(Brushes.DarkGreen, j * tileWidthHeight, i * tileWidthHeight, tileWidthHeight, tileWidthHeight);
					} else if (j%2 == 1 && !(i % 2 == 0)){
						g.FillRectangle(Brushes.DarkGreen, j * tileWidthHeight, i * tileWidthHeight, tileWidthHeight, tileWidthHeight);
					} else {
						g.FillRectangle(Brushes.Green, j * tileWidthHeight, i * tileWidthHeight, tileWidthHeight, tileWidthHeight);

					}
				}
			}
			for (int i = 0; i < boardWidth; i++) {
				for (int j = 0; j < boardHeight; j++) {
					if (board[i, j] != 0) {
						SolidBrush col = new SolidBrush(Color.Pink); //If incorrect a pink circle is drawn
						switch (board[i, j]) {
							case -1:
								col = new SolidBrush(Color.White);
								break;
							case 1:
								col = new SolidBrush(Color.Black);
								break;
						}
						g.FillEllipse(col, 1 + i * tileWidthHeight, 1 + j * tileWidthHeight, tileWidthHeight-2, tileWidthHeight-2);
					} else if (posBoard[i, j] != 0) {
						switch (posBoard[i, j]) {
							case -1:
								g.FillEllipse(new SolidBrush(Color.White), tileWidthHeight / 2 - tileWidthHeight / 8 + i * tileWidthHeight, tileWidthHeight / 2 - tileWidthHeight / 8 + j * tileWidthHeight, tileWidthHeight / 4, tileWidthHeight / 4);
								break;
							case 1:
								g.FillEllipse(new SolidBrush(Color.Black), tileWidthHeight / 2 - tileWidthHeight / 8 + i * tileWidthHeight, tileWidthHeight / 2 - tileWidthHeight / 8 + j * tileWidthHeight, tileWidthHeight / 4, tileWidthHeight / 4);
								break;
						}
						
					}
				}
			}
			return bitmap;
		}

		public int getScore(int col) {
			int score = 0;
			for (int i=0; i<boardWidth; i++) {
				for (int j=0; j<boardHeight; j++) {
					if (board[i, j] == col)
						score++;
				}
			}
			return score;
		}

		public int getAiScore(int col) {
			int score = 0;
			for (int i = 0; i < boardWidth; i++) {
				for (int j = 0; j < boardHeight; j++) {
					if (board[i, j] == col)
						score += boardWeight[i, j];
					else if (board[i, j] == -col)
						score -= boardWeight[i, j];
				}
			}
			return score;
		}

		public int GetBoardWidth() {
			return boardWidth;
		}
		public int GetBoardHeight() {
			return boardHeight;
		}
		public void SetBoardWidth(int size) {
			boardWidth = size;
			if (boardWidth < minBoardWidth) {
				boardWidth = minBoardWidth;
			}
		}
		public void SetBoardHeight(int size) {
			boardHeight = size;
			if (boardHeight < minBoardHeight) {
				boardHeight = minBoardHeight;
			}
		}
		public void ClearPosBoard() {
			posBoard = new int[boardWidth, boardHeight];
		}
		public bool NoPossibleMoves() {
			for (int x=0; x < boardWidth; x++) {
				for (int y = 0; y < boardHeight; y++) {
					if (canPlaceTile(x, y, -1) || canPlaceTile(x, y, 1))
						return false;
				}
			}
			return true;
		}
	}
}
