using System.Net.Sockets;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace GameCaro
{
    public partial class Form1 : Form
    {

        #region Properties

        CaroManager ChessBoard;
        string PlayerName;

        #endregion
        public Form1()
        {
            InitializeComponent();

            ChessBoard = new CaroManager(pnlBanCo, tbName, ptbIcon);

            

            //bai5 

            ChessBoard.EndedGame += ChessBoard_EndedGame;
            ChessBoard.PlayerMarked += ChessBoard_PlayerMarked;
              
            pgbTime.Step = Cons.WAITING_TIME_STEP;
            pgbTime.Maximum = Cons.WAITING_TIME_TIME;

            //pgbTime.Value = 0;

            tmTime.Interval = Cons.WAITING_TIME_INTERVAL;
            

            ChessBoard.BanCo();
            
        }

        void EndGame()
        {
            tmTime.Stop();
            pnlBanCo.Enabled = false;

        }

        private void ChessBoard_PlayerMarked(object sender, EventArgs e)
        {
            tmTime.Start();
            pgbTime.Value = 0;
        }

        private void ChessBoard_EndedGame(object? sender, EventArgs e)
        { 
            EndGame();

        }

        private void tmTime_Tick(object sender, EventArgs e)
        {
            //làm cho pgb ch?y
            pgbTime.PerformStep();

            if(pgbTime.Value>=pgbTime.Maximum) { EndGame(); }

        }
    }
}
