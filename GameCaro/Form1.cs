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
        void NewGame()
        {
            pgbTime.Value = 0;
            tmTime.Stop();

            ChessBoard.BanCo();

        }
        void Quit()
        {
            this.Close();
        }
        void Undo()
        {
        }
        void Redo() { }

        #region Menu
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
            pnlBanCo.Enabled = true;
        }

        private void quitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        //bai6 t?o s? ki?n khi form ?óng
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("B?n có ch?c mu?n thoát", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
            else
            {

            }

        }
        //
        #endregion

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

            if (pgbTime.Value >= pgbTime.Maximum) { EndGame(); }

        }

        
    }
}
