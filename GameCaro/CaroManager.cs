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


        //tạo ra cái list lồng trong list
        private List<List<Button>> matrix;
        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }

        private event EventHandler playerMarked;
        public event EventHandler PlayerMarked
        {
            add
            {
                playerMarked += value;
            }
            remove
            {
                playerMarked -= value;
            }
        }

        private event EventHandler endedGame;
        public event EventHandler EndedGame
        {
            add
            {
                endedGame += value;
            }
            remove
            {
                endedGame -= value;
            }
        }



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
            ChessBoard.Enabled = true;


            Matrix = new List<List<Button>>();

            Button btnold = new Button() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i < Cons.CHESS_BOARD_ROW; i++)
            {

                //tạo mảng mới lưu lại
                Matrix.Add(new List<Button>());

                for (int j = 0; j < Cons.CHESS_BOARD_COL; j++)
                {
                    Button btn = new Button()
                    {
                        Width = Cons.CHESS_WIDTH,
                        Height = Cons.CHESS_HEIGHT,
                        Location = new Point(btnold.Location.X + btnold.Width, btnold.Location.Y),

                        //đổ hình vào button
                        BackgroundImageLayout = ImageLayout.Stretch,

                        //tạo tag để lưu lại các text đang nằm ở hàng nào 
                        Tag = i.ToString()
                        //

                    };
                    ChessBoard.Controls.Add(btn);


                    
                    btn.Click += btn_Click;
                    
                    //thêm tất cả button vào 
                    Matrix[i].Add(btn);
                    //

                    btnold = btn;
                }
                btnold.Location = new Point(0, btnold.Location.Y + Cons.CHESS_HEIGHT);
                btnold.Width = 0;
                btnold.Height = 0;
            }
        }

        private Point GetChessPoint(Button btn)
        {

            int vertical = Convert.ToInt32(btn.Tag);
            int horizontal = Matrix[vertical].IndexOf(btn);

            Point point = new Point(horizontal, vertical);

            return point;
        }

        //click đánh 
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.BackgroundImage != null)
            {
                return;
            }

            Mark(btn);

            ChangePlayer();

            if (playerMarked != null)
            {
                playerMarked(this, new EventArgs());
            }

            if (isEndGame(btn))
            {
                EndGame();
            }



        }
        //chuyển đổi tên và ký tự 
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

        public void EndGame()
        {

            if (endedGame != null)
            {
                endedGame(this, new EventArgs());
            }

        }

        #region Win_Close

        //kiểm tra kết thúc game theo hàng dọc, ngang , chéo
        private bool isEndGame(Button btn)
        {
            return isEndGameHorizontal(btn) || isEndGameVertical(btn) || isEndGameDiagonal(btn) || isEndSub(btn);
        }

        private bool isEndGameHorizontal(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countLeft = 0;
            for (int i = point.X; i >= 0; i--)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countLeft++;
                }
                else
                    break;
            }
            int countRight = 0;
            for (int i = point.X + 1; i < Cons.CHESS_BOARD_COL; i++)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countRight++;
                }
                else
                    break;
            }



            return countLeft + countRight == 5;
        }
        private bool isEndGameVertical(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countTop = 0;
            for (int i = point.Y; i >= 0; i--)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }
            int countBottom = 0;
            for (int i = point.Y + 1; i < Cons.CHESS_BOARD_ROW; i++)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }



            return countTop + countBottom == 5;
        }
        private bool isEndGameDiagonal(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countTop = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y - i < 0)
                    break;
                if (Matrix[point.Y - i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }
            int countBottom = 0;
            for (int i = 1; i <= Cons.CHESS_BOARD_COL - point.X; i++)
            {
                if (point.Y + i >= Cons.CHESS_BOARD_ROW || point.X + i >= Cons.CHESS_BOARD_COL)
                    break;
                if (Matrix[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }



            return countTop + countBottom == 5;
        }

        private bool isEndSub(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countTop = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X + i > Cons.CHESS_BOARD_COL || point.Y - i < 0)
                    break;
                if (Matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }
            int countBottom = 0;
            for (int i = 1; i <= Cons.CHESS_BOARD_COL - point.X; i++)
            {
                if (point.Y + i >= Cons.CHESS_BOARD_ROW || point.X + i < 0)
                    break;

                if (Matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }



            return countTop + countBottom == 5;
        }

        #endregion



        
        #endregion
    }
    public class ButtonClickEvent : EventArgs
    {
        private Point clickedPoint;

        public Point ClickedPoint { get => clickedPoint; set => clickedPoint = value; }

        public ButtonClickEvent(Point point)
        {
            this.ClickedPoint = point;
        }
    }
}

