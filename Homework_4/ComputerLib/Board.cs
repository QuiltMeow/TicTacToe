using System.Collections;

namespace Homework_4
{
    internal class Board
    {
        private readonly PieceType[] board;

        public Board()
        {
            board = new PieceType[9];
            for (int i = 0; i < board.Length; ++i)
            {
                board[i] = PieceType.EMPTY;
            }
        }

        public int determineWinner()
        {
            if (checkWin(PieceType.X))
            {
                return 0;
            }
            else if (checkWin(PieceType.O))
            {
                return 1;
            }
            int numMove = 0;
            foreach (PieceType piece in board)
            {
                if (piece != PieceType.EMPTY)
                {
                    ++numMove;
                }
            }
            return numMove == 9 ? 2 : -1;
        }

        public bool makeMove(int move, PieceType piece)
        {
            if (board[move] == PieceType.EMPTY && piece != PieceType.EMPTY)
            {
                board[move] = piece;
                return true;
            }
            return false;
        }

        public bool checkWin(PieceType piece)
        {
            if (board[4] == piece)
            {
                if ((board[0] == piece && board[8] == piece) || (board[6] == piece && board[2] == piece) || (board[3] == piece && board[5] == piece) || (board[1] == piece && board[7] == piece))
                {
                    return true;
                }
            }
            if (board[0] == piece)
            {
                if ((board[1] == piece && board[2] == piece) || (board[3] == piece && board[6] == piece))
                {
                    return true;
                }
            }
            if (board[8] == piece)
            {
                if ((board[6] == piece && board[7] == piece) || (board[2] == piece && board[5] == piece))
                {
                    return true;
                }
            }
            return false;
        }

        public IList legalMove()
        {
            IList move = new ArrayList(9);
            for (int i = 0; i < board.Length; ++i)
            {
                if (board[i] == PieceType.EMPTY)
                {
                    move.Add(i);
                }
            }
            return move;
        }

        public Board clone(int move, PieceType piece)
        {
            Board copy = new Board();
            for (int i = 0; i < board.Length; ++i)
            {
                copy.makeMove(i, board[i]);
            }
            copy.makeMove(move, piece);
            return copy;
        }
    }
}