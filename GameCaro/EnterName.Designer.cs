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
            SuspendLayout();
            // 
            // tbName
            // 
            tbName.Anchor = AnchorStyles.None;
            tbName.Location = new Point(71, 103);
            tbName.Name = "tbName";
            tbName.Size = new Size(409, 31);
            tbName.TabIndex = 0;

            // 
            // btPlay
            // 
            btPlay.Anchor = AnchorStyles.None;
            btPlay.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btPlay.Location = new Point(368, 151);
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
            btXoa.Location = new Point(227, 151);
            btXoa.Name = "btXoa";
            btXoa.Size = new Size(112, 34);
            btXoa.TabIndex = 2;
            btXoa.Text = "Xóa";
            btXoa.UseVisualStyleBackColor = true;
            btXoa.Click += btXoa_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(144, 49);
            label1.Name = "label1";
            label1.Size = new Size(258, 32);
            label1.TabIndex = 3;
            label1.Text = "Nhập tên để bắt đầu";
            label1.Click += label1_Click;
            // 
            // EnterName
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(570, 241);
            Controls.Add(label1);
            Controls.Add(btXoa);
            Controls.Add(btPlay);
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
    }
}