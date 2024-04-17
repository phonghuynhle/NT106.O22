using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro
{
    public class CaroManager
    {
        #region Properties


        private Panel chessBoard;
        public Panel ChessBoard
        {
            get { return chessBoard; }
            set { chessBoard = value; }
        }

        private List<Player> player;
        public List<Player> Player { get => player; set => player = value; }

        private int currentPlayer;
        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }


        private TextBox playerName;

        public TextBox PlayerName { get => playerName; set => playerName = value; }


        private PictureBox playerMark;
        public PictureBox PlayerMark { get => playerMark; set => playerMark = value; }



        #endregion

        #region Initialize
        public CaroManager(Panel chessBoard, TextBox playerName, PictureBox mark)
        {
            this.ChessBoard = chessBoard;
            this.PlayerName = playerName;
            this.PlayerMark = mark;

            this.CurrentPlayer = 0;
            //bai3 thêm tên và hình ảnh người chơi
            this.Player = new List<Player>()
            {
                new Player("Player1", Image.FromFile(Application.StartupPath + "\\Resources\\KytuX.jpg")),
                new Player("Player2", Image.FromFile(Application.StartupPath + "\\Resources\\KytuO.jpg")),

            };
            //
            ChangePlayer();
        }

        #endregion

        #region Method
        public void BanCo()
        {
            ChangePlayer();

            Button btnold = new Button() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i < Cons.CHESS_BOARD_ROW; i++)
            {
                for (int j = 0; j < Cons.CHESS_BOARD_COL; j++)
                {
                    Button btn = new Button()
                    {
                        Width = Cons.CHESS_WIDTH,
                        Height = Cons.CHESS_HEIGHT,
                        Location = new Point(btnold.Location.X + btnold.Width, btnold.Location.Y),

                        //đổ hình vào button
                        BackgroundImageLayout = ImageLayout.Stretch,

                    };
                    ChessBoard.Controls.Add(btn);


                    //bai3
                    btn.Click += btn_Click;
                    //

                    btnold = btn;
                }
                btnold.Location = new Point(0, btnold.Location.Y + Cons.CHESS_HEIGHT);
                btnold.Width = 0;
                btnold.Height = 0;
            }
        }

        //bai3 click đánh 
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.BackgroundImage != null)
            {
                return;
            }

            Mark(btn);

            ChangePlayer();


        }
        //bai3 chuyển đổi tên và ký tự 
        private void Mark(Button btn)
        {
            btn.BackgroundImage = Player[CurrentPlayer].Mark;   

            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;


        }

        private void ChangePlayer()
        {
            PlayerName.Text = Player[CurrentPlayer].Name;

            PlayerMark.Image = Player[CurrentPlayer].Mark;
        }

        #endregion
    }
}

