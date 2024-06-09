namespace GameCaro
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pnlBanCo = new Panel();
            pnlHinhAnh = new Panel();
            ptHinhAnh = new PictureBox();
            pnInfo = new Panel();
            tbChat = new TextBox();
            btChat = new Button();
            tbMessage = new TextBox();
            btPlayAI = new Button();
            button4 = new Button();
            btLAN = new Button();
            btRedo = new Button();
            btUndo = new Button();
            ptbIcon = new PictureBox();
            pgbTime = new ProgressBar();
            tbName = new TextBox();
            tbIP = new TextBox();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            quitGameToolStripMenuItem = new ToolStripMenuItem();
            optionToolStripMenuItem = new ToolStripMenuItem();
            playerToolStripMenuItem = new ToolStripMenuItem();
            computerToolStripMenuItem = new ToolStripMenuItem();
            lANToolStripMenuItem = new ToolStripMenuItem();
            playerToolStripMenuItem1 = new ToolStripMenuItem();
            tmTime = new System.Windows.Forms.Timer(components);
            lblPort = new Label();
            tbRoom = new TextBox();
            pnlHinhAnh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptHinhAnh).BeginInit();
            pnInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbIcon).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBanCo
            // 
            pnlBanCo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlBanCo.BorderStyle = BorderStyle.FixedSingle;
            pnlBanCo.Location = new Point(463, 75);
            pnlBanCo.Name = "pnlBanCo";
            pnlBanCo.Size = new Size(637, 889);
            pnlBanCo.TabIndex = 4;
            // 
            // pnlHinhAnh
            // 
            pnlHinhAnh.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlHinhAnh.BackgroundImageLayout = ImageLayout.Stretch;
            pnlHinhAnh.BorderStyle = BorderStyle.Fixed3D;
            pnlHinhAnh.Controls.Add(ptHinhAnh);
            pnlHinhAnh.Location = new Point(12, 75);
            pnlHinhAnh.Name = "pnlHinhAnh";
            pnlHinhAnh.Size = new Size(425, 214);
            pnlHinhAnh.TabIndex = 1;
            // 
            // ptHinhAnh
            // 
            ptHinhAnh.Image = (Image)resources.GetObject("ptHinhAnh.Image");
            ptHinhAnh.Location = new Point(-1, -2);
            ptHinhAnh.Name = "ptHinhAnh";
            ptHinhAnh.Size = new Size(424, 215);
            ptHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            ptHinhAnh.TabIndex = 0;
            ptHinhAnh.TabStop = false;
            // 
            // pnInfo
            // 
            pnInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnInfo.BorderStyle = BorderStyle.Fixed3D;
            pnInfo.Controls.Add(tbChat);
            pnInfo.Controls.Add(btChat);
            pnInfo.Controls.Add(tbMessage);
            pnInfo.Controls.Add(btPlayAI);
            pnInfo.Controls.Add(button4);
            pnInfo.Controls.Add(btLAN);
            pnInfo.Controls.Add(btRedo);
            pnInfo.Controls.Add(btUndo);
            pnInfo.Controls.Add(ptbIcon);
            pnInfo.Controls.Add(pgbTime);
            pnInfo.Controls.Add(tbName);
            pnInfo.Location = new Point(12, 314);
            pnInfo.Name = "pnInfo";
            pnInfo.Size = new Size(425, 650);
            pnInfo.TabIndex = 2;
            // 
            // tbChat
            // 
            tbChat.Location = new Point(4, 275);
            tbChat.Multiline = true;
            tbChat.Name = "tbChat";
            tbChat.ReadOnly = true;
            tbChat.Size = new Size(414, 316);
            tbChat.TabIndex = 0;
            // 
            // btChat
            // 
            btChat.Location = new Point(324, 599);
            btChat.Name = "btChat";
            btChat.Size = new Size(94, 44);
            btChat.TabIndex = 9;
            btChat.Text = "Send";
            btChat.UseVisualStyleBackColor = true;
            btChat.Click += btChat_Click;
            // 
            // tbMessage
            // 
            tbMessage.Location = new Point(3, 597);
            tbMessage.Multiline = true;
            tbMessage.Name = "tbMessage";
            tbMessage.Size = new Size(315, 46);
            tbMessage.TabIndex = 8;
            // 
            // btPlayAI
            // 
            btPlayAI.Location = new Point(284, 226);
            btPlayAI.Name = "btPlayAI";
            btPlayAI.Size = new Size(134, 32);
            btPlayAI.TabIndex = 6;
            btPlayAI.Text = "1 Player";
            btPlayAI.UseVisualStyleBackColor = true;
            btPlayAI.Click += btPlayAI_Click;
            // 
            // button4
            // 
            button4.Location = new Point(133, 226);
            button4.Name = "button4";
            button4.Size = new Size(136, 32);
            button4.TabIndex = 7;
            button4.Text = "2 Player/ Com";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // btLAN
            // 
            btLAN.Location = new Point(4, 225);
            btLAN.Name = "btLAN";
            btLAN.Size = new Size(112, 33);
            btLAN.TabIndex = 4;
            btLAN.Text = "LAN";
            btLAN.UseVisualStyleBackColor = true;
            btLAN.Click += btLAN_Click;
            // 
            // btRedo
            // 
            btRedo.Location = new Point(157, 133);
            btRedo.Name = "btRedo";
            btRedo.Size = new Size(88, 62);
            btRedo.TabIndex = 4;
            btRedo.Text = "Redo";
            btRedo.UseVisualStyleBackColor = true;
            btRedo.Click += btRedo_Click;
            // 
            // btUndo
            // 
            btUndo.Location = new Point(49, 133);
            btUndo.Name = "btUndo";
            btUndo.Size = new Size(88, 62);
            btUndo.TabIndex = 3;
            btUndo.Text = "Undo";
            btUndo.UseVisualStyleBackColor = true;
            btUndo.Click += btUndo_Click;
            // 
            // ptbIcon
            // 
            ptbIcon.Location = new Point(284, 25);
            ptbIcon.Name = "ptbIcon";
            ptbIcon.Size = new Size(134, 120);
            ptbIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbIcon.TabIndex = 2;
            ptbIcon.TabStop = false;
            // 
            // pgbTime
            // 
            pgbTime.Location = new Point(22, 77);
            pgbTime.Name = "pgbTime";
            pgbTime.Size = new Size(247, 34);
            pgbTime.TabIndex = 1;
            // 
            // tbName
            // 
            tbName.Location = new Point(22, 25);
            tbName.Name = "tbName";
            tbName.ReadOnly = true;
            tbName.Size = new Size(247, 31);
            tbName.TabIndex = 0;
            // 
            // tbIP
            // 
            tbIP.Location = new Point(63, 36);
            tbIP.Multiline = true;
            tbIP.Name = "tbIP";
            tbIP.ReadOnly = true;
            tbIP.Size = new Size(369, 33);
            tbIP.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 43);
            label1.Name = "label1";
            label1.Size = new Size(26, 20);
            label1.TabIndex = 12;
            label1.Text = "IP";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem, optionToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1112, 33);
            menuStrip1.TabIndex = 13;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, undoToolStripMenuItem, redoToolStripMenuItem, quitGameToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(73, 29);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(200, 34);
            newToolStripMenuItem.Text = "New Game";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.Size = new Size(200, 34);
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.Size = new Size(200, 34);
            redoToolStripMenuItem.Text = "Redo";
            redoToolStripMenuItem.Click += redoToolStripMenuItem_Click;
            // 
            // quitGameToolStripMenuItem
            // 
            quitGameToolStripMenuItem.Name = "quitGameToolStripMenuItem";
            quitGameToolStripMenuItem.Size = new Size(200, 34);
            quitGameToolStripMenuItem.Text = "Quit Game";
            quitGameToolStripMenuItem.Click += quitGameToolStripMenuItem_Click;
            // 
            // optionToolStripMenuItem
            // 
            optionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { playerToolStripMenuItem, playerToolStripMenuItem1 });
            optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            optionToolStripMenuItem.Size = new Size(84, 29);
            optionToolStripMenuItem.Text = "Option";
            // 
            // playerToolStripMenuItem
            // 
            playerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { computerToolStripMenuItem, lANToolStripMenuItem });
            playerToolStripMenuItem.Name = "playerToolStripMenuItem";
            playerToolStripMenuItem.Size = new Size(176, 34);
            playerToolStripMenuItem.Text = "2 Player";
            // 
            // computerToolStripMenuItem
            // 
            computerToolStripMenuItem.Name = "computerToolStripMenuItem";
            computerToolStripMenuItem.Size = new Size(209, 34);
            computerToolStripMenuItem.Text = "1 Computer";
            computerToolStripMenuItem.Click += computerToolStripMenuItem_Click;
            // 
            // lANToolStripMenuItem
            // 
            lANToolStripMenuItem.Name = "lANToolStripMenuItem";
            lANToolStripMenuItem.Size = new Size(209, 34);
            lANToolStripMenuItem.Text = "LAN";
            lANToolStripMenuItem.Click += lANToolStripMenuItem_Click;
            // 
            // playerToolStripMenuItem1
            // 
            playerToolStripMenuItem1.Name = "playerToolStripMenuItem1";
            playerToolStripMenuItem1.Size = new Size(176, 34);
            playerToolStripMenuItem1.Text = "1 Player";
            playerToolStripMenuItem1.Click += playerToolStripMenuItem1_Click;
            // 
            // tmTime
            // 
            tmTime.Tick += tmTime_Tick;
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(463, 41);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(60, 25);
            lblPort.TabIndex = 14;
            lblPort.Text = "Room";
            // 
            // tbRoom
            // 
            tbRoom.Location = new Point(534, 38);
            tbRoom.Name = "tbRoom";
            tbRoom.ReadOnly = true;
            tbRoom.Size = new Size(150, 31);
            tbRoom.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1112, 976);
            Controls.Add(tbRoom);
            Controls.Add(lblPort);
            Controls.Add(label1);
            Controls.Add(tbIP);
            Controls.Add(pnInfo);
            Controls.Add(pnlHinhAnh);
            Controls.Add(pnlBanCo);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Game Caro";
            FormClosing += Form1_FormClosing;
            Shown += Form1_Shown;
            pnlHinhAnh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ptHinhAnh).EndInit();
            pnInfo.ResumeLayout(false);
            pnInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ptbIcon).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlBanCo;
        private Panel pnlHinhAnh;
        private PictureBox ptHinhAnh;
        private Panel pnInfo;
        private Button btChat;
        private TextBox tbMessage;
        private Button btPlayAI;
        private Button button4;
        private Button btLAN;
        private Button btRedo;
        private Button btUndo;
        private PictureBox ptbIcon;
        private ProgressBar pgbTime;
        private TextBox tbName;
        private TextBox tbIP;
        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripMenuItem quitGameToolStripMenuItem;
        private ToolStripMenuItem optionToolStripMenuItem;
        private ToolStripMenuItem playerToolStripMenuItem;
        private ToolStripMenuItem computerToolStripMenuItem;
        private ToolStripMenuItem lANToolStripMenuItem;
        private ToolStripMenuItem playerToolStripMenuItem1;
        private System.Windows.Forms.Timer tmTime;
        private TextBox tbChat;
        private Label lblPort;
        private TextBox tbRoom;
    }
}
