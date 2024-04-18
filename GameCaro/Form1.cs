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

            // đóng undo khi đã kết thúc game
            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = false;
            //

            btUndo.Enabled = false;
            btRedo.Enabled = false;

        }
        void NewGame()
        {
            pgbTime.Value = 0;
            tmTime.Stop();
            //mở undo khi new game
            undoToolStripMenuItem.Enabled = true;
            //
            redoToolStripMenuItem.Enabled = true;

            btUndo.Enabled = true;
            btRedo.Enabled = true;

            ChessBoard.BanCo();

        }
        void Quit()
        {
            this.Close();
        }
        void Undo()
        {
            ChessBoard.Undo();
            pgbTime.Value = 0;
        }
        void Redo() { ChessBoard.Redo(); }

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

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pgbTime.Value = 0;
            ChessBoard.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChessBoard.Redo();
        }

        //Tạo sự kiện khi form đóng
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
            else
            {

            }

        }
        //
        #endregion

        private void btUndo_Click(object sender, EventArgs e)
        {
            undoToolStripMenuItem_Click(sender, e);
        }

        private void btRedo_Click(object sender, EventArgs e)
        {
            redoToolStripMenuItem_Click(sender, e);
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
            //làm cho pgb chạy
            pgbTime.PerformStep();

            if (pgbTime.Value >= pgbTime.Maximum) { EndGame(); }

        }

        private void playerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChessBoard.PlayMode = 3;
            NewGame();
            ChessBoard.StartAI();
        }

        private void btPlayAI_Click(object sender, EventArgs e)
        {
            playerToolStripMenuItem1_Click(sender, e);
        }
    }
}
