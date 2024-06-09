namespace GameCaro
{
    partial class EnterName
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnterName));
            tbName = new TextBox();
            btPlay = new Button();
            btXoa = new Button();
            label1 = new Label();
            tbRoom = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // tbName
            // 
            tbName.Anchor = AnchorStyles.None;
            tbName.Location = new Point(121, 64);
            tbName.Name = "tbName";
            tbName.Size = new Size(305, 31);
            tbName.TabIndex = 0;
            // 
            // btPlay
            // 
            btPlay.Anchor = AnchorStyles.None;
            btPlay.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btPlay.Location = new Point(314, 194);
            btPlay.Name = "btPlay";
            btPlay.Size = new Size(112, 34);
            btPlay.TabIndex = 1;
            btPlay.Text = "Play";
            btPlay.UseVisualStyleBackColor = true;
            btPlay.Click += btPlay_Click;
            // 
            // btXoa
            // 
            btXoa.Anchor = AnchorStyles.None;
            btXoa.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btXoa.Location = new Point(180, 194);
            btXoa.Name = "btXoa";
            btXoa.Size = new Size(112, 34);
            btXoa.TabIndex = 2;
            btXoa.Text = "Cancel";
            btXoa.UseVisualStyleBackColor = true;
            btXoa.Click += btXoa_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(16, 61);
            label1.Name = "label1";
            label1.Size = new Size(82, 32);
            label1.TabIndex = 3;
            label1.Text = "Name";
            label1.Click += label1_Click;
            // 
            // tbRoom
            // 
            tbRoom.Anchor = AnchorStyles.None;
            tbRoom.Location = new Point(121, 130);
            tbRoom.Name = "tbRoom";
            tbRoom.Size = new Size(305, 31);
            tbRoom.TabIndex = 0;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(14, 130);
            label2.Name = "label2";
            label2.Size = new Size(84, 32);
            label2.TabIndex = 3;
            label2.Text = "Room";
            label2.Click += label1_Click;
            // 
            // EnterName
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(491, 282);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btXoa);
            Controls.Add(btPlay);
            Controls.Add(tbRoom);
            Controls.Add(tbName);
            DoubleBuffered = true;
            Name = "EnterName";
            Text = "EnterName";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbName;
        private Button btPlay;
        private Button btXoa;
        private Label label1;
        private TextBox tbRoom;
        private Label label2;
    }
}