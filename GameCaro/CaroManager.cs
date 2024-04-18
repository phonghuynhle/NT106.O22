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

        private event EventHandler<ButtonClickEvent> playerMarked;
        public event EventHandler<ButtonClickEvent> PlayerMarked
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
        private Stack<PlayInfo> playUndo;

        public Stack<PlayInfo> PlayUndo { get => playUndo; set => playUndo = value; }

        private Stack<PlayInfo> playRedo;
        public Stack<PlayInfo> PlayRedo { get => playRedo; set => playRedo = value; }

        

        private int playMode = 0;
        public int PlayMode { get => playMode; set => playMode = value; }

        private bool IsAI = false;



        #endregion

        #region Initialize
        public CaroManager(Panel chessBoard, TextBox playerName, PictureBox mark)
        {
            this.ChessBoard = chessBoard;
            this.PlayerName = playerName;
            this.PlayerMark = mark;

            this.CurrentPlayer = 0;
            // thêm tên và hình ảnh người chơi
            this.Player = new List<Player>()
            {
                new Player("Player1", Image.FromFile(Application.StartupPath + "\\Resources\\KytuX.jpg")),
                new Player("Player2", Image.FromFile(Application.StartupPath + "\\Resources\\KytuO.jpg")),

            };
            //
          
        }

        #endregion

        #region Method
        public void BanCo()
        {
            ChessBoard.Enabled = true;
            ChessBoard.Controls.Clear();

            //
            PlayUndo = new Stack<PlayInfo>();
            PlayRedo = new Stack<PlayInfo>();
            //

            CurrentPlayer = 0;

            ChangePlayer();

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
                    


                    
                    btn.Click += btn_Click;
                    
                    //thêm tất cả button vào 
                    Matrix[i].Add(btn);
                    //
                    ChessBoard.Controls.Add(btn);

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

            //thêm bước đi vào 
            PlayUndo.Push(new PlayInfo(GetChessPoint(btn), CurrentPlayer, btn.BackgroundImage));
            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
            PlayRedo.Clear();

            //

            ChangePlayer();

            if (playerMarked != null)
            {
                playerMarked(this,new ButtonClickEvent(GetChessPoint(btn)));
            }

            if (isEndGame(btn))
            {
                EndGame();
            }

            if (!(IsAI) && playMode == 3)
                StartAI();

            IsAI = false;



        }
        //chuyển đổi tên và ký tự 
        private void Mark(Button btn)
        {
            btn.BackgroundImage = Player[CurrentPlayer].Mark;   

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

        #region Undo_Redo
        public bool Undo()  
        {
            if (playUndo.Count <= 0)
                return false;


            PlayInfo oldPoint = PlayUndo.Peek();
            CurrentPlayer = oldPoint.CurrentPlayer == 1 ? 0 : 1;
            bool isUndo1 = UndoAStep();
            bool isUndo2 = UndoAStep();
            return isUndo1 && isUndo2;
        }

        private bool UndoAStep()
        {
            if (playUndo.Count <= 0)
                return false;

            PlayInfo oldPoint = PlayUndo.Pop();
            PlayRedo.Push(oldPoint);

            Button btn = Matrix[oldPoint.Point.Y][oldPoint.Point.X];

            btn.BackgroundImage = null;

            if (playUndo.Count <= 0)
            {

                CurrentPlayer = 0;
            }
            else
            {
                oldPoint = PlayUndo.Peek();

            }
            ChangePlayer();
            return true;
        }
        public bool Redo()
        {
            if (PlayRedo.Count <= 0)
                return false;

            PlayInfo OldPos = PlayRedo.Peek();
            CurrentPlayer = OldPos.CurrentPlayer;


            bool IsRedo1 = RedoAStep();
            bool IsRedo2 = RedoAStep();

            return IsRedo1 && IsRedo2;
        }

        private bool RedoAStep()
        {
            if (PlayRedo.Count <= 0)
                return false;

            PlayInfo OldPos = PlayRedo.Pop();
            PlayUndo.Push(OldPos);

            Button btn = Matrix[OldPos.Point.Y][OldPos.Point.X];
            btn.BackgroundImage = OldPos.Mark;

            if (PlayRedo.Count <= 0)
                CurrentPlayer = OldPos.CurrentPlayer == 1 ? 0 : 1;
            else
                OldPos = PlayRedo.Peek();

            ChangePlayer();

            return true;
        }
        #endregion


        #region 1 player
        private long[] ArrAttackScore = new long[7] { 0, 64, 4096, 262144, 16777216, 1073741824, 68719476736 };
        private long[] ArrDefenseScore = new long[7] { 0, 8, 512, 32768, 2097152, 134217728, 8589934592 };

        #region Calculate attack score
        private long AttackHorizontal(int CurrRow, int CurrCol)
        {
            long TotalScore = 0;
            int ComCells = 0;
            int ManCells = 0;

            // Duyệt từ trên xuống
            for (int Count = 1; Count < 6 && CurrRow + Count < Cons.CHESS_BOARD_ROW; Count++)
            {
                if (Matrix[CurrRow + Count][CurrCol].BackgroundImage == Player[0].Mark)
                    ComCells += 1;
                else if (Matrix[CurrRow + Count][CurrCol].BackgroundImage == Player[1].Mark)
                {
                    ManCells += 1;
                    break;
                }
                else
                    break;
            }

            // Duyệt từ dưới lên
            for (int Count = 1; Count < 6 && CurrRow - Count >= 0; Count++)
            {
                if (Matrix[CurrRow - Count][CurrCol].BackgroundImage == Player[0].Mark)
                    ComCells += 1;
                else if (Matrix[CurrRow - Count][CurrCol].BackgroundImage == Player[1].Mark)
                {
                    ManCells += 1;
                    break;
                }
                else
                    break;
            }

            if (ManCells == 2)
                return 0;

            /* Nếu ManCells == 1 => bị chặn 1 đầu => lấy điểm phòng ngự tại vị trí này nhưng 
            nên cộng thêm 1 để tăng phòng ngự cho máy cảnh giác hơn vì đã bị chặn 1 đầu */

            TotalScore -= ArrDefenseScore[ManCells + 1];
            TotalScore += ArrAttackScore[ComCells];

            return TotalScore;
        }

        private long AttackVertical(int CurrRow, int CurrCol)
        {
            long TotalScore = 0;
            int ComCells = 0;
            int ManCells = 0;

            // Duyệt từ trái sang phải
            for (int Count = 1; Count < 6 && CurrCol + Count < Cons.CHESS_BOARD_COL; Count++)
            {
                if (Matrix[CurrRow][CurrCol + Count].BackgroundImage == Player[0].Mark)
                    ComCells += 1;
                else if (Matrix[CurrRow][CurrCol + Count].BackgroundImage == Player[1].Mark)
                {
                    ManCells += 1;
                    break;
                }
                else
                    break;
            }

            // Duyệt từ phải sang trái
            for (int Count = 1; Count < 6 && CurrCol - Count >= 0; Count++)
            {
                if (Matrix[CurrRow][CurrCol - Count].BackgroundImage == Player[0].Mark)
                    ComCells += 1;
                else if (Matrix[CurrRow][CurrCol - Count].BackgroundImage == Player[1].Mark)
                {
                    ManCells += 1;
                    break;
                }
                else
                    break;
            }

            if (ManCells == 2)
                return 0;

            /* Nếu ManCells == 1 => bị chặn 1 đầu => lấy điểm phòng ngự tại vị trí này nhưng 
            nên cộng thêm 1 để tăng phòng ngự cho máy cảnh giác hơn vì đã bị chặn 1 đầu */

            TotalScore -= ArrDefenseScore[ManCells + 1];
            TotalScore += ArrAttackScore[ComCells];

            return TotalScore;
        }

        private long AttackMainDiag(int CurrRow, int CurrCol)
        {
            long TotalScore = 0;
            int ComCells = 0;
            int ManCells = 0;

            // Duyệt trái trên
            for (int Count = 1; Count < 6 && CurrCol + Count < Cons.CHESS_BOARD_COL && CurrRow + Count < Cons.CHESS_BOARD_ROW; Count++)
            {
                if (Matrix[CurrRow + Count][CurrCol + Count].BackgroundImage == Player[0].Mark)
                    ComCells += 1;
                else if (Matrix[CurrRow + Count][CurrCol + Count].BackgroundImage == Player[1].Mark)
                {
                    ManCells += 1;
                    break;
                }
                else
                    break;
            }

            // Duyệt phải dưới
            for (int Count = 1; Count < 6 && CurrCol - Count >= 0 && CurrRow - Count >= 0; Count++)
            {
                if (Matrix[CurrRow - Count][CurrCol - Count].BackgroundImage == Player[0].Mark)
                    ComCells += 1;
                else if (Matrix[CurrRow - Count][CurrCol - Count].BackgroundImage == Player[1].Mark)
                {
                    ManCells += 1;
                    break;
                }
                else
                    break;
            }

            if (ManCells == 2)
                return 0;

            /* Nếu ManCells == 1 => bị chặn 1 đầu => lấy điểm phòng ngự tại vị trí này nhưng 
            nên cộng thêm 1 để tăng phòng ngự cho máy cảnh giác hơn vì đã bị chặn 1 đầu */

            TotalScore -= ArrDefenseScore[ManCells + 1];
            TotalScore += ArrAttackScore[ComCells];

            return TotalScore;
        }

        private long AttackExtraDiag(int CurrRow, int CurrCol)
        {
            long TotalScore = 0;
            int ComCells = 0;
            int ManCells = 0;

            // Duyệt phải trên
            for (int Count = 1; Count < 6 && CurrCol + Count < Cons.CHESS_BOARD_COL && CurrRow - Count >= 0; Count++)
            {
                if (Matrix[CurrRow - Count][CurrCol + Count].BackgroundImage == Player[0].Mark)
                    ComCells += 1;
                else if (Matrix[CurrRow - Count][CurrCol + Count].BackgroundImage == Player[1].Mark)
                {
                    ManCells += 1;
                    break;
                }
                else
                    break;
            }

            // Duyệt trái dưới
            for (int Count = 1; Count < 6 && CurrCol - Count >= 0 && CurrRow + Count < Cons.CHESS_BOARD_ROW; Count++)
            {
                if (Matrix[CurrRow + Count][CurrCol - Count].BackgroundImage == Player[0].Mark)
                    ComCells += 1;
                else if (Matrix[CurrRow + Count][CurrCol - Count].BackgroundImage == Player[1].Mark)
                {
                    ManCells += 1;
                    break;
                }
                else
                    break;
            }

            if (ManCells == 2)
                return 0;

            /* Nếu ManCells == 1 => bị chặn 1 đầu => lấy điểm phòng ngự tại vị trí này nhưng 
            nên cộng thêm 1 để tăng phòng ngự cho máy cảnh giác hơn vì đã bị chặn 1 đầu */

            TotalScore -= ArrDefenseScore[ManCells + 1];
            TotalScore += ArrAttackScore[ComCells];

            return TotalScore;
        }
        #endregion

        #region Calculate defense score
        private long DefenseHorizontal(int CurrRow, int CurrCol)
        {
            long TotalScore = 0;
            int ComCells = 0;
            int ManCells = 0;

            // Duyệt từ trên xuống
            for (int Count = 1; Count < 6 && CurrRow + Count < Cons.CHESS_BOARD_ROW; Count++)
            {
                if (Matrix[CurrRow + Count][CurrCol].BackgroundImage == Player[0].Mark)
                {
                    ComCells += 1;
                    break;
                }
                else if (Matrix[CurrRow + Count][CurrCol].BackgroundImage == Player[1].Mark)
                    ManCells += 1;
                else
                    break;
            }

            // Duyệt từ dưới lên
            for (int Count = 1; Count < 6 && CurrRow - Count >= 0; Count++)
            {
                if (Matrix[CurrRow - Count][CurrCol].BackgroundImage == Player[0].Mark)
                {
                    ComCells += 1;
                    break;
                }
                else if (Matrix[CurrRow - Count][CurrCol].BackgroundImage == Player[1].Mark)
                    ManCells += 1;
                else
                    break;
            }

            if (ComCells == 2)
                return 0;

            TotalScore += ArrDefenseScore[ManCells];

            return TotalScore;
        }

        private long DefenseVertical(int CurrRow, int CurrCol)
        {
            long TotalScore = 0;
            int ComCells = 0;
            int ManCells = 0;

            // Duyệt từ trái sang phải
            for (int Count = 1; Count < 6 && CurrCol + Count < Cons.CHESS_BOARD_COL; Count++)
            {
                if (Matrix[CurrRow][CurrCol + Count].BackgroundImage == Player[0].Mark)
                {
                    ComCells += 1;
                    break;
                }
                else if (Matrix[CurrRow][CurrCol + Count].BackgroundImage == Player[1].Mark)
                    ManCells += 1;
                else
                    break;
            }

            // Duyệt từ phải sang trái
            for (int Count = 1; Count < 6 && CurrCol - Count >= 0; Count++)
            {
                if (Matrix[CurrRow][CurrCol - Count].BackgroundImage == Player[0].Mark)
                {
                    ComCells += 1;
                    break;
                }
                else if (Matrix[CurrRow][CurrCol - Count].BackgroundImage == Player[1].Mark)
                    ManCells += 1;
                else
                    break;
            }

            if (ComCells == 2)
                return 0;

            TotalScore += ArrDefenseScore[ManCells];

            return TotalScore;
        }

        private long DefenseMainDiag(int CurrRow, int CurrCol)
        {
            long TotalScore = 0;
            int ComCells = 0;
            int ManCells = 0;

            // Duyệt trái trên
            for (int Count = 1; Count < 6 && CurrCol + Count < Cons.CHESS_BOARD_COL && CurrRow + Count < Cons.CHESS_BOARD_ROW; Count++)
            {
                if (Matrix[CurrRow + Count][CurrCol + Count].BackgroundImage == Player[0].Mark)
                {
                    ComCells += 1;
                    break;
                }
                else if (Matrix[CurrRow + Count][CurrCol + Count].BackgroundImage == Player[1].Mark)
                    ManCells += 1;
                else
                    break;
            }

            // Duyệt phải dưới
            for (int Count = 1; Count < 6 && CurrCol - Count >= 0 && CurrRow - Count >= 0; Count++)
            {
                if (Matrix[CurrRow - Count][CurrCol - Count].BackgroundImage == Player[0].Mark)
                {
                    ComCells += 1;
                    break;
                }
                else if (Matrix[CurrRow - Count][CurrCol - Count].BackgroundImage == Player[1].Mark)
                    ManCells += 1;
                else
                    break;
            }

            if (ComCells == 2)
                return 0;

            TotalScore += ArrDefenseScore[ManCells];

            return TotalScore;
        }

        private long DefenseExtraDiag(int CurrRow, int CurrCol)
        {
            long TotalScore = 0;
            int ComCells = 0;
            int ManCells = 0;

            // Duyệt phải trên
            for (int Count = 1; Count < 6 && CurrCol + Count < Cons.CHESS_BOARD_COL && CurrRow - Count >= 0; Count++)
            {
                if (Matrix[CurrRow - Count][CurrCol + Count].BackgroundImage == Player[0].Mark)
                {
                    ComCells += 1;
                    break;
                }
                else if (Matrix[CurrRow - Count][CurrCol + Count].BackgroundImage == Player[1].Mark)
                    ManCells += 1;
                else
                    break;
            }

            // Duyệt trái dưới
            for (int Count = 1; Count < 6 && CurrCol - Count >= 0 && CurrRow + Count < Cons.CHESS_BOARD_ROW; Count++)
            {
                if (Matrix[CurrRow + Count][CurrCol - Count].BackgroundImage == Player[0].Mark)
                {
                    ComCells += 1;
                    break;
                }
                else if (Matrix[CurrRow + Count][CurrCol - Count].BackgroundImage == Player[1].Mark)
                    ManCells += 1;
                else
                    break;
            }

            if (ComCells == 2)
                return 0;

            TotalScore += ArrDefenseScore[ManCells];

            return TotalScore;
        }
        #endregion

        private Point FindAiPos()
        {
            Point AiPos = new Point();
            long MaxScore = 0;

            for (int i = 0; i < Cons.CHESS_BOARD_ROW; i++)
            {
                for (int j = 0; j < Cons.CHESS_BOARD_COL; j++)
                {
                    if (Matrix[i][j].BackgroundImage == null)
                    {
                        long AttackScore = AttackHorizontal(i, j) + AttackVertical(i, j) + AttackMainDiag(i, j) + AttackExtraDiag(i, j);
                        long DefenseScore = DefenseHorizontal(i, j) + DefenseVertical(i, j) + DefenseMainDiag(i, j) + DefenseExtraDiag(i, j);
                        long TempScore = AttackScore > DefenseScore ? AttackScore : DefenseScore;

                        if (MaxScore < TempScore)
                        {
                            MaxScore = TempScore;
                            AiPos = new Point(i, j);
                        }
                    }
                }
            }

            return AiPos;
        }

        public void StartAI()
        {
            IsAI = true;

            if (PlayUndo.Count == 0) // mới bắt đầu thì cho máy đánh trước
                Matrix[Cons.CHESS_BOARD_ROW / 4][Cons.CHESS_BOARD_COL / 4].PerformClick();
            else
            {
                Point AiPos = FindAiPos();
                Matrix[AiPos.X][AiPos.Y].PerformClick();
            }
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

