using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro
{
    [Serializable]
    public class DataManager
    {
        private int command;

        public int Command { get => command; set => command = value; }


        private Point point;

        public Point Point { get => point; set => point = value; }

        private string message;
        public string Message { get => message; set => message = value; }

        public DataManager(int command, string message, Point point)
        {
            this.Command = command;
            this.Point = point;
            this.Message = message;
        }

    }
    public enum SocketCommand
    {
        SEND_POINT,
        SEND_MESSAGE,
        NEW_GAME,
        UNDO,
        REDO,
        END_GAME,
        TIME_OUT,
        QUIT,
        SEND_NAME,
    }
}

