using System.Net.NetworkInformation;
using System.Net.Sockets;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace GameCaro
{
    public partial class Form1 : Form
    {

        #region Properties

        CaroManager ChessBoard;
        string PlayerName;
        string getName;
        LANManager socket;

        public string GetName { get => getName; set => getName = value; }

        #endregion
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            ChessBoard = new CaroManager(pnlBanCo, tbName, ptbIcon);



            ChessBoard.EndedGame += ChessBoard_EndedGame;
            ChessBoard.PlayerMarked += ChessBoard_PlayerMarked;

            pgbTime.Step = Cons.WAITING_TIME_STEP;
            pgbTime.Maximum = Cons.WAITING_TIME_TIME;


            tmTime.Interval = Cons.WAITING_TIME_INTERVAL;

            socket = new LANManager();
            tbChat.Text = "";

            NewGame();


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
        void Redo()
        { ChessBoard.Redo(); }

        #region Menu
        //New Game
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
            if (ChessBoard.PlayMode == 1)
            {
                try
                {
                    socket.Send(new DataManager((int)SocketCommand.NEW_GAME, "", new Point()));
                }
                catch { }
            }
            pnlBanCo.Enabled = true;
        }
        //QuitGame
        private void quitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }
        //Undo
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pgbTime.Value = 0;
            ChessBoard.Undo();

            if (ChessBoard.PlayMode == 1)
                socket.Send(new DataManager((int)SocketCommand.UNDO, "", new Point()));
        }
        //Redo
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChessBoard.Redo();

            if (ChessBoard.PlayMode == 1)
                socket.Send(new DataManager((int)SocketCommand.REDO, "", new Point()));
        }
        #endregion


        #region Option

        //Chơi kết nối mạng LAN
        private void lANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChessBoard.PlayMode = 1;
            NewGame();
            tbChat.Clear();
            socket.IP = tbIP.Text;

            if (!socket.ConnectServer())
            {
                socket.IsServer = true;
                pnlBanCo.Enabled = true;
                socket.CreateServer();

                Player player = new Player(getName, Image.FromFile(Application.StartupPath + "\\Resources\\kytuX.jpg"));
                ChessBoard.Player[0] = player;
                tbName.Text = player.Name;

                MessageBox.Show("Bạn đang là Server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                socket.IsServer = false;
                pnlBanCo.Enabled = false;
                tbName.Text = "";
                Listen();
                //Client bắt đầu lắng nghe từ server 
                socket.Send(new DataManager((int)SocketCommand.SEND_NAME, getName, new Point()));
                //Gửi tên đến server
                Player player = new Player(getName, Image.FromFile(Application.StartupPath + "\\Resources\\kytuO.jpg"));
                ChessBoard.Player[1] = player;

                MessageBox.Show("Kết nối thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            btChat.Enabled = true;
        }

        //2 người chơi trên cùng 1 máy
        private void computerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ChessBoard.PlayMode == 1)
            {
                try
                {
                    socket.Send(new DataManager((int)SocketCommand.QUIT, "", new Point()));
                }
                catch { }

                socket.CloseConnect();
                MessageBox.Show("Đã ngắt kết nối mạng LAN", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ChessBoard.PlayMode = 2;
            NewGame();
        }
        // Chơi với máy
        private void playerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ChessBoard.PlayMode == 1)
            {
                if (ChessBoard.PlayMode == 1)
                {
                    try
                    {
                        socket.Send(new DataManager((int)SocketCommand.QUIT, "", new Point()));
                    }
                    catch { }

                    socket.CloseConnect();
                    MessageBox.Show("Đã ngắt kết nối mạng LAN", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            ChessBoard.PlayMode = 3;
            NewGame();
            tbChat.Clear();
            ChessBoard.StartAI();
        }
        #endregion


        #region Button
        private void btUndo_Click(object sender, EventArgs e)
        {
            undoToolStripMenuItem_Click(sender, e);
        }

        private void btRedo_Click(object sender, EventArgs e)
        {
            redoToolStripMenuItem_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            computerToolStripMenuItem_Click(sender, e);
        }



        private void btPlayAI_Click(object sender, EventArgs e)
        {
            playerToolStripMenuItem1_Click(sender, e);
        }

        private void btLAN_Click(object sender, EventArgs e)
        {
            lANToolStripMenuItem_Click(sender, e);
        }
        #endregion


        //Chat giữa 2 người chơi trên LAN
        private void btChat_Click(object sender, EventArgs e)
        {
            if (ChessBoard.PlayMode != 1)
                return;

            PlayerName = ChessBoard.Player[socket.IsServer ? 0 : 1].Name;
            if (tbMessage.Text == "")
                return;

            tbChat.Text += "- " + PlayerName + ": " + tbMessage.Text + "\r\n";

            socket.Send(new DataManager((int)SocketCommand.SEND_MESSAGE, "- " + PlayerName + ": " + tbMessage.Text + "\r\n", new Point()));
            //Sẽ gửi đoạn tin đoán cùng với tên người chơi
            tbMessage.Text = "";
            Listen();//Sau đó tiếp tục lắng nghe
        }

        //Tạo sự kiện khi form đóng
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
            else
            {
                try
                {
                    socket.Send(new DataManager((int)SocketCommand.QUIT, "", new Point()));
                }
                catch { }

            }

        }

        private void ChessBoard_PlayerMarked(object sender, ButtonClickEvent e)
        {
            tmTime.Start();

            pgbTime.Value = 0;

            if (ChessBoard.PlayMode == 1)
            {
                try
                {
                    pnlBanCo.Enabled = false;
                    socket.Send(new DataManager((int)SocketCommand.SEND_POINT, "", e.ClickedPoint));

                    undoToolStripMenuItem.Enabled = false;
                    redoToolStripMenuItem.Enabled = false;

                    btUndo.Enabled = false;
                    btRedo.Enabled = false;

                    Listen();
                }
                catch
                {
                    EndGame();
                    MessageBox.Show("Không có kết nối nào", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void ChessBoard_EndedGame(object? sender, EventArgs e)
        {
            int Win_lose = ChessBoard.CurrentPlayer == 1 ? 0 : 1;
            PlayerName = ChessBoard.Player[Win_lose].Name;
            EndGame();

            if (ChessBoard.PlayMode == 1)
                socket.Send(new DataManager((int)SocketCommand.END_GAME, "", new Point()));

        }

        private void tmTime_Tick(object sender, EventArgs e)
        {
            //làm cho pgb chạy
            pgbTime.PerformStep();

            if (pgbTime.Value >= pgbTime.Maximum)
            {

                EndGame();
                if (ChessBoard.PlayMode == 1)
                    socket.Send(new DataManager((int)SocketCommand.TIME_OUT, "", new Point()));

            }

        }


        //Lấy địa chỉ IP hiển thị lên textbox
        private void Form1_Shown(object sender, EventArgs e)
        {
            tbIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211)?.ToString();

            if (string.IsNullOrEmpty(tbIP.Text))
            {
                tbIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet)?.ToString();
            }

        }

        void Listen()
        {
            Thread ListenThread = new Thread(() =>
            {
                try
                {
                    DataManager data = (DataManager)socket.Receive();
                    ProcessData(data);
                }
                catch { }
            });

            ListenThread.IsBackground = true;
            ListenThread.Start();
        }
        private void ProcessData(DataManager data)
        {


            PlayerName = ChessBoard.Player[ChessBoard.CurrentPlayer == 1 ? 0 : 1].Name;
            switch (data.Command)
            {
                case (int)SocketCommand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        NewGame();
                        pnlBanCo.Enabled = false;
                    }
                    ));

                    break;
                case (int)SocketCommand.SEND_POINT:
                    this.Invoke((MethodInvoker)(() =>
                    {


                        pgbTime.Value = 0;
                        pnlBanCo.Enabled = true;
                        tmTime.Start();
                        ChessBoard.OtherPlayerMark(data.Point);
                        undoToolStripMenuItem.Enabled = true;
                        redoToolStripMenuItem.Enabled = true;

                        btUndo.Enabled = true;
                        btRedo.Enabled = true;
                    }
                    ));
                    break;
                case (int)SocketCommand.SEND_MESSAGE:
                    //tbChat.Text = data.Message;
                    WriteTextSafe(data.Message, tbChat);
                    break;
                case (int)SocketCommand.UNDO:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        pgbTime.Value = 0;
                        Undo();
                    }));
                    break;
                case (int)SocketCommand.REDO:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        ChessBoard.Redo();

                    }));
                    break;
                case (int)SocketCommand.END_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        EndGame();
                        MessageBox.Show(PlayerName + " đã chiến thắng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                    break;
                case (int)SocketCommand.TIME_OUT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        EndGame();
                        MessageBox.Show("Hết giờ rồi !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                    break;
                case (int)SocketCommand.QUIT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        tmTime.Stop();
                        EndGame();

                        ChessBoard.PlayMode = 2;
                        socket.CloseConnect();

                        MessageBox.Show("Người chơi đã thoát", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                    break;
                case (int)SocketCommand.SEND_NAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        if (socket.IsServer)
                        {
                            pnlBanCo.Enabled = true;
                            Player player = new Player(data.Message, Image.FromFile(Application.StartupPath + "\\Resources\\kytuO.jpg"));
                            ChessBoard.Player[1] = player;
                            socket.Send(new DataManager((int)SocketCommand.SEND_NAME, getName, new Point()));
                           
                        }
                        else
                        {
                            Player player = new Player(data.Message, Image.FromFile(Application.StartupPath + "\\Resources\\kytuX.jpg"));
                            ChessBoard.Player[0] = player;
                            tbName.Text = player.Name;
                        }
                        Listen();
                        btChat.Enabled = true;
                    }));
                    break;
                default:
                    break;
            }
            Listen();
        }
        private delegate void SafeCallDelegate(string text, Control obj);
        private void WriteTextSafe(string text, Control control)
        {
            if (control.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteTextSafe);
                control.Invoke(d, new object[] { text, control });
            }
            else
            {
                ((TextBox)control).Text += text;
            }
        }

    }
}
