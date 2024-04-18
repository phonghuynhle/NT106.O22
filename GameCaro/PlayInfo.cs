using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro
{
    public class PlayInfo
    {
        private Point point;


        public Point Point { get => point; set => point = value; }


        private int currentPlayer;

        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }


        private Image? mark;
        public Image? Mark { get => mark; set => mark = value; }

        public PlayInfo(Point point, int currentPlayer, Image mark)
        {
            this.Point = point;
            this.CurrentPlayer = currentPlayer;
            this.Mark = mark;

        }
    }
}
