namespace GaussSolve
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GoToBtn = new System.Windows.Forms.Button();
            this.authorsBtn = new System.Windows.Forms.Button();
            this.intructionsBtn = new System.Windows.Forms.Button();
            this.HotToBtn = new System.Windows.Forms.Button();
            this.quitBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(537, 406);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // GoToBtn
            // 
            this.GoToBtn.Location = new System.Drawing.Point(306, 202);
            this.GoToBtn.Name = "GoToBtn";
            this.GoToBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GoToBtn.Size = new System.Drawing.Size(169, 30);
            this.GoToBtn.TabIndex = 1;
            this.GoToBtn.Text = "Перейти в калькулятор";
            this.GoToBtn.UseVisualStyleBackColor = true;
            this.GoToBtn.Click += new System.EventHandler(this.GoToBtn_Click);
            // 
            // authorsBtn
            // 
            this.authorsBtn.Location = new System.Drawing.Point(306, 238);
            this.authorsBtn.Name = "authorsBtn";
            this.authorsBtn.Size = new System.Drawing.Size(169, 30);
            this.authorsBtn.TabIndex = 2;
            this.authorsBtn.Text = "Об авторах";
            this.authorsBtn.UseVisualStyleBackColor = true;
            this.authorsBtn.Click += new System.EventHandler(this.authorsBtn_Click);
            // 
            // intructionsBtn
            // 
            this.intructionsBtn.Location = new System.Drawing.Point(306, 274);
            this.intructionsBtn.Name = "intructionsBtn";
            this.intructionsBtn.Size = new System.Drawing.Size(169, 30);
            this.intructionsBtn.TabIndex = 3;
            this.intructionsBtn.Text = "Инструкции";
            this.intructionsBtn.UseVisualStyleBackColor = true;
            this.intructionsBtn.Click += new System.EventHandler(this.intructionsBtn_Click);
            // 
            // HotToBtn
            // 
            this.HotToBtn.Location = new System.Drawing.Point(306, 310);
            this.HotToBtn.Name = "HotToBtn";
            this.HotToBtn.Size = new System.Drawing.Size(169, 30);
            this.HotToBtn.TabIndex = 4;
            this.HotToBtn.Text = "О методе";
            this.HotToBtn.UseVisualStyleBackColor = true;
            this.HotToBtn.Click += new System.EventHandler(this.HotToBtn_Click);
            // 
            // quitBtn
            // 
            this.quitBtn.Location = new System.Drawing.Point(306, 346);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(169, 30);
            this.quitBtn.TabIndex = 5;
            this.quitBtn.Text = "Выйти";
            this.quitBtn.UseVisualStyleBackColor = true;
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 406);
            this.ControlBox = false;
            this.Controls.Add(this.quitBtn);
            this.Controls.Add(this.HotToBtn);
            this.Controls.Add(this.intructionsBtn);
            this.Controls.Add(this.authorsBtn);
            this.Controls.Add(this.GoToBtn);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StartForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private PictureBox pictureBox1;
        private Button GoToBtn;
        private Button authorsBtn;
        private Button intructionsBtn;
        private Button HotToBtn;
        private Button quitBtn;
    }
}