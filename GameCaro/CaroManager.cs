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


        #endregion

        #region Initialize
        public CaroManager(Panel chessBoard)
        {
            this.ChessBoard = chessBoard;
        }

        #endregion

        #region Method
        public void BanCo()
        {

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

                    };
                    ChessBoard.Controls.Add(btn);



                    btnold = btn;
                }
                btnold.Location = new Point(0, btnold.Location.Y + Cons.CHESS_HEIGHT);
                btnold.Width = 0;
                btnold.Height = 0;
            }
        }

        #endregion
    }
}

