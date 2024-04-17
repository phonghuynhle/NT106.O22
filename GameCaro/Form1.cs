namespace GameCaro
{
    public partial class Form1 : Form
    {

        #region Properties

        CaroManager ChessBoard;

        #endregion
        public Form1()
        {
            InitializeComponent();

            ChessBoard = new CaroManager(pnlBanCo, tbName, ptbIcon);

            ChessBoard.BanCo();
        }
    }
}
