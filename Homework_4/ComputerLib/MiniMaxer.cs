using System;

namespace Homework_4
{
    internal class MiniMaxer
    {
        private static readonly PieceType[] piece = new PieceType[2] { PieceType.X, PieceType.O };

        private int symbol, bestMove;

        public MiniMaxer(PieceType symbol)
        {
            for (int i = 0; i < piece.Length; ++i)
            {
                if (symbol == piece[i])
                {
                    this.symbol = i;
                    break;
                }
            }
        }

        public int makeMove(Board board)
        {
            bestMove = 0;
            int score = miniMax(board, symbol, 9);
            // Console.Write("[最小化最大演算法] 分數 : " + score);
            return bestMove;
        }

        private int miniMax(Board board, int turn, int depth)
        {
            int winner = board.determineWinner();
            if (winner != -1)
            {
                if (winner == turn)
                {
                    return 1;
                }
                else if (winner == (turn ^ 1))
                {
                    return -1;
                }
                return 0;
            }
            int alpha = int.MinValue; // 最小
            foreach (int move in board.legalMove())
            {
                int score = Math.Max(alpha, -miniMax(board.clone(move, piece[turn]), turn ^ 1, depth - 1)); // 修剪
                if (score > alpha && depth == 9)
                {
                    bestMove = move;
                }
                alpha = score;
            }
            return alpha;
        }
    }
}