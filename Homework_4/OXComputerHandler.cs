using System;
using System.Windows.Forms;

namespace Homework_4
{
    internal class OXComputerHandler
    {
        private bool first;
        private PieceType symbol, playerSymbol;

        private Timer timerComputer;

        private Board board;
        private MiniMaxer mm;
        private MainForm form;

        public OXComputerHandler(bool first, MainForm form)
        {
            this.first = first;
            this.form = form;

            symbol = first ? PieceType.O : PieceType.X;
            playerSymbol = first ? PieceType.X : PieceType.O;

            timerComputer = new Timer();
            timerComputer.Tick += new EventHandler(computerTimerTick);

            board = new Board();
            mm = new MiniMaxer(symbol);
        }

        ~OXComputerHandler()
        {
            timerComputer.Stop();
        }

        public void startTimer()
        {
            timerComputer.Interval = MainForm.random.Next(1500, 3000 + 1);
            timerComputer.Start();
        }

        private int placePiece()
        {
            int slotMove = mm.makeMove(board);
            board.makeMove(slotMove, symbol);
            return slotMove;
        }

        public void placePiecePlayer(int slot)
        {
            board.makeMove(slot, playerSymbol);
        }

        public bool isFirst()
        {
            return first;
        }

        private void computerTimerTick(object sender, EventArgs e)
        {
            timerComputer.Stop();
            int result = placePiece();
            form.processComputer(form.getButton(result));
        }
    }
}