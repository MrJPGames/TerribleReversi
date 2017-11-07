using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2 {
	class AI {
		Random rnd = new Random();

		public void AiMove(Board b, int col, int depth) {
			int bestScore = -10000;
			bool canMove=false;
			Board newBoard = new Board();
			Board bestBoard = new Board();
			for (int i=0; i<b.GetBoardWidth(); i++) {
				for (int j=0; j<b.GetBoardHeight(); j++) {
					if (b.canPlaceTile(i,j, col)) {
						canMove = true;
						newBoard.clone(b); //Make a clone of the starting board (before AI move)
						newBoard.placeTile(i, j, col); //Make a valid move
						int ret = minMax(newBoard, -col, depth-1); //Get return from minmax for this move
						if (ret > bestScore || ret == bestScore && rnd.Next(0,1) == 1) {
							bestScore = ret;
							bestBoard.clone(newBoard);
						}
					}
				}
			}
			if (canMove)
				b.clone(bestBoard);
		}

		public int minMax(Board b, int col, int depth) {
			if (depth <= 0 || ( !b.canMove(col) && !b.canMove(-col) ))
				return b.getScore(col);
			int bestScore = -10000;
			Board newBoard = new Board();
			for (int i = 0; i < b.GetBoardWidth(); i++) {
				for (int j = 0; j < b.GetBoardHeight(); j++) {
					if (b.canPlaceTile(i, j, col)) {
						newBoard.clone(b); //Make a clone of the starting board (before AI move)
						newBoard.placeTile(i, j, col); //Make a valid move
						int ret = minMax(newBoard, -col, depth-1); //Get return from minmax for this move
						if (ret > bestScore || ret == bestScore && rnd.Next(0, 1) == 1) {
							bestScore = ret;
						}
					}
				}
			}
			return bestScore;
		}

		/*public Board AiMove(Board b, int col) {
			int[] bestPos = { -1, -1 };
			int bestScore = -1000;
			Board nBoard = new Board();
			for (int i = 0; i < 7; i++) {
				for (int j = 0; j < 7; j++) {
					if (b.canPlaceTile(i, j, col)) {
						nBoard.clone(b);
						nBoard.placeTile(i, j, col);
						int ret = minMax(nBoard, -col, 3);
						if (ret > bestScore) {
							bestScore = ret;
							bestPos[0] = i;
							bestPos[1] = j;
						}
					}
				}
			}
			if (bestPos[0] != -1)
				b.placeTile(bestPos[0], bestPos[1], col);
			return b;
		}

		private int minMax(Board b, int col, int depth) {
			Board newBoard = new Board();
			if (depth <= 0) {
				return b.getAiScore(col);
			}
			int bestScore = -1000;
			for (int i=0; i<7; i++) {
				for (int j=0; j<7; j++) {
					if (b.canPlaceTile(i, j, col)) {
						newBoard.clone(b);
						newBoard.placeTile(i, j, col);
						int ret = minMax(newBoard, -col, depth - 1);
						if (ret > bestScore)
							bestScore = ret;
					}
				}
			}
			return bestScore;
		}
		*/
	}
}
