using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro
{
    public partial class EnterName : Form
    {
        public EnterName()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void btPlay_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbName.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên", "Thông báo");
                    return;
                }
                if (tbRoom.Text=="")
                {
                    MessageBox.Show("Bạn chưa nhập số phòng", "Thông báo");
                    return;
                }

                Form1 gameCaro = new Form1();
                gameCaro.GameMode = 0;
                gameCaro.Room = int.Parse(tbRoom.Text);
                gameCaro.GetName = tbName.Text;
                gameCaro.Show();
            }
            catch
            {
            }

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            tbName.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
