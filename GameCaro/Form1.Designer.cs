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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pnlBanCo = new Panel();
            pnlHinhAnh = new Panel();
            ptHinhAnh = new PictureBox();
            pnInfo = new Panel();
            btChat = new Button();
            tbMessage = new TextBox();
            tbChat = new TextBox();
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
            pnlBanCo.Location = new Point(370, 60);
            pnlBanCo.Margin = new Padding(2, 2, 2, 2);
            pnlBanCo.Name = "pnlBanCo";
            pnlBanCo.Size = new Size(510, 712);
            pnlBanCo.TabIndex = 4;
            // 
            // pnlHinhAnh
            // 
            pnlHinhAnh.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlHinhAnh.BackgroundImageLayout = ImageLayout.Stretch;
            pnlHinhAnh.BorderStyle = BorderStyle.Fixed3D;
            pnlHinhAnh.Controls.Add(ptHinhAnh);
            pnlHinhAnh.Location = new Point(10, 60);
            pnlHinhAnh.Margin = new Padding(2, 2, 2, 2);
            pnlHinhAnh.Name = "pnlHinhAnh";
            pnlHinhAnh.Size = new Size(341, 172);
            pnlHinhAnh.TabIndex = 1;
            // 
            // ptHinhAnh
            // 
            ptHinhAnh.BackgroundImage = (Image)resources.GetObject("ptHinhAnh.BackgroundImage");
            ptHinhAnh.BackgroundImageLayout = ImageLayout.Stretch;
            ptHinhAnh.Location = new Point(-1, -2);
            ptHinhAnh.Margin = new Padding(2, 2, 2, 2);
            ptHinhAnh.Name = "ptHinhAnh";
            ptHinhAnh.Size = new Size(339, 172);
            ptHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            ptHinhAnh.TabIndex = 0;
            ptHinhAnh.TabStop = false;
            // 
            // pnInfo
            // 
            pnInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnInfo.BorderStyle = BorderStyle.Fixed3D;
            pnInfo.Controls.Add(btChat);
            pnInfo.Controls.Add(tbMessage);
            pnInfo.Controls.Add(tbChat);
            pnInfo.Controls.Add(btPlayAI);
            pnInfo.Controls.Add(button4);
            pnInfo.Controls.Add(btLAN);
            pnInfo.Controls.Add(btRedo);
            pnInfo.Controls.Add(btUndo);
            pnInfo.Controls.Add(ptbIcon);
            pnInfo.Controls.Add(pgbTime);
            pnInfo.Controls.Add(tbName);
            pnInfo.Location = new Point(10, 251);
            pnInfo.Margin = new Padding(2, 2, 2, 2);
            pnInfo.Name = "pnInfo";
            pnInfo.Size = new Size(341, 521);
            pnInfo.TabIndex = 2;
            // 
            // btChat
            // 
            btChat.Location = new Point(259, 479);
            btChat.Margin = new Padding(2, 2, 2, 2);
            btChat.Name = "btChat";
            btChat.Size = new Size(75, 35);
            btChat.TabIndex = 9;
            btChat.Text = "Send";
            btChat.UseVisualStyleBackColor = true;
            // 
            // tbMessage
            // 
            tbMessage.Location = new Point(2, 478);
            tbMessage.Margin = new Padding(2, 2, 2, 2);
            tbMessage.Multiline = true;
            tbMessage.Name = "tbMessage";
            tbMessage.Size = new Size(253, 38);
            tbMessage.TabIndex = 8;
            // 
            // tbChat
            // 
            tbChat.BackColor = SystemColors.Control;
            tbChat.Location = new Point(2, 211);
            tbChat.Margin = new Padding(2, 2, 2, 2);
            tbChat.Multiline = true;
            tbChat.Name = "tbChat";
            tbChat.ScrollBars = ScrollBars.Vertical;
            tbChat.Size = new Size(333, 250);
            tbChat.TabIndex = 7;
            // 
            // btPlayAI
            // 
            btPlayAI.Location = new Point(227, 181);
            btPlayAI.Margin = new Padding(2, 2, 2, 2);
            btPlayAI.Name = "btPlayAI";
            btPlayAI.Size = new Size(107, 26);
            btPlayAI.TabIndex = 6;
            btPlayAI.Text = "1 Player";
            btPlayAI.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(106, 181);
            button4.Margin = new Padding(2, 2, 2, 2);
            button4.Name = "button4";
            button4.Size = new Size(109, 26);
            button4.TabIndex = 7;
            button4.Text = "2 Player/ Com";
            button4.UseVisualStyleBackColor = true;
            // 
            // btLAN
            // 
            btLAN.Location = new Point(3, 180);
            btLAN.Margin = new Padding(2, 2, 2, 2);
            btLAN.Name = "btLAN";
            btLAN.Size = new Size(90, 26);
            btLAN.TabIndex = 4;
            btLAN.Text = "LAN";
            btLAN.UseVisualStyleBackColor = true;
            // 
            // btRedo
            // 
            btRedo.Location = new Point(126, 106);
            btRedo.Margin = new Padding(2, 2, 2, 2);
            btRedo.Name = "btRedo";
            btRedo.Size = new Size(70, 50);
            btRedo.TabIndex = 4;
            btRedo.Text = "Redo";
            btRedo.UseVisualStyleBackColor = true;
            // 
            // btUndo
            // 
            btUndo.Location = new Point(39, 106);
            btUndo.Margin = new Padding(2, 2, 2, 2);
            btUndo.Name = "btUndo";
            btUndo.Size = new Size(70, 50);
            btUndo.TabIndex = 3;
            btUndo.Text = "Undo";
            btUndo.UseVisualStyleBackColor = true;
            // 
            // ptbIcon
            // 
            ptbIcon.Location = new Point(227, 20);
            ptbIcon.Margin = new Padding(2, 2, 2, 2);
            ptbIcon.Name = "ptbIcon";
            ptbIcon.Size = new Size(107, 96);
            ptbIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbIcon.TabIndex = 2;
            ptbIcon.TabStop = false;
            // 
            // pgbTime
            // 
            pgbTime.Location = new Point(18, 62);
            pgbTime.Margin = new Padding(2, 2, 2, 2);
            pgbTime.Name = "pgbTime";
            pgbTime.Size = new Size(198, 27);
            pgbTime.TabIndex = 1;
            // 
            // tbName
            // 
            tbName.Location = new Point(18, 20);
            tbName.Margin = new Padding(2, 2, 2, 2);
            tbName.Name = "tbName";
            tbName.Size = new Size(198, 27);
            tbName.TabIndex = 0;
            // 
            // tbIP
            // 
            tbIP.Location = new Point(50, 29);
            tbIP.Margin = new Padding(2, 2, 2, 2);
            tbIP.Multiline = true;
            tbIP.Name = "tbIP";
            tbIP.Size = new Size(296, 27);
            tbIP.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 34);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(22, 17);
            label1.TabIndex = 12;
            label1.Text = "IP";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem, optionToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(890, 28);
            menuStrip1.TabIndex = 13;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, undoToolStripMenuItem, redoToolStripMenuItem, quitGameToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(60, 24);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(165, 26);
            newToolStripMenuItem.Text = "New Game";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.Size = new Size(165, 26);
            undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.Size = new Size(165, 26);
            redoToolStripMenuItem.Text = "Redo";
            // 
            // quitGameToolStripMenuItem
            // 
            quitGameToolStripMenuItem.Name = "quitGameToolStripMenuItem";
            quitGameToolStripMenuItem.Size = new Size(165, 26);
            quitGameToolStripMenuItem.Text = "Quit Game";
            // 
            // optionToolStripMenuItem
            // 
            optionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { playerToolStripMenuItem, playerToolStripMenuItem1 });
            optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            optionToolStripMenuItem.Size = new Size(69, 24);
            optionToolStripMenuItem.Text = "Option";
            // 
            // playerToolStripMenuItem
            // 
            playerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { computerToolStripMenuItem, lANToolStripMenuItem });
            playerToolStripMenuItem.Name = "playerToolStripMenuItem";
            playerToolStripMenuItem.Size = new Size(144, 26);
            playerToolStripMenuItem.Text = "2 Player";
            // 
            // computerToolStripMenuItem
            // 
            computerToolStripMenuItem.Name = "computerToolStripMenuItem";
            computerToolStripMenuItem.Size = new Size(170, 26);
            computerToolStripMenuItem.Text = "1 Computer";
            // 
            // lANToolStripMenuItem
            // 
            lANToolStripMenuItem.Name = "lANToolStripMenuItem";
            lANToolStripMenuItem.Size = new Size(170, 26);
            lANToolStripMenuItem.Text = "LAN";
            // 
            // playerToolStripMenuItem1
            // 
            playerToolStripMenuItem1.Name = "playerToolStripMenuItem1";
            playerToolStripMenuItem1.Size = new Size(144, 26);
            playerToolStripMenuItem1.Text = "1 Player";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(890, 781);
            Controls.Add(label1);
            Controls.Add(tbIP);
            Controls.Add(pnInfo);
            Controls.Add(pnlHinhAnh);
            Controls.Add(pnlBanCo);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            Text = "Game Caro";
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
        private TextBox tbChat;
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
    }
}
