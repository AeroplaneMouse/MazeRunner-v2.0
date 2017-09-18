namespace MazeRunner_v2._0
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btn_load = new System.Windows.Forms.Button();
            this.btn_solve = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btn_slowMode = new System.Windows.Forms.Button();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.btn_clearLog = new System.Windows.Forms.Button();
            this.btn_closeForm = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_load
            // 
            this.btn_load.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btn_load.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btn_load.FlatAppearance.BorderSize = 0;
            this.btn_load.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_load.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_load.Location = new System.Drawing.Point(16, 85);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(75, 77);
            this.btn_load.TabIndex = 0;
            this.btn_load.Text = "Load";
            this.btn_load.UseVisualStyleBackColor = false;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // btn_solve
            // 
            this.btn_solve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btn_solve.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btn_solve.FlatAppearance.BorderSize = 0;
            this.btn_solve.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_solve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_solve.Location = new System.Drawing.Point(98, 85);
            this.btn_solve.Name = "btn_solve";
            this.btn_solve.Size = new System.Drawing.Size(75, 77);
            this.btn_solve.TabIndex = 1;
            this.btn_solve.Text = "Solve";
            this.btn_solve.UseVisualStyleBackColor = false;
            this.btn_solve.Click += new System.EventHandler(this.btn_solve_Click);
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.progressBar.Location = new System.Drawing.Point(0, 51);
            this.progressBar.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1050, 15);
            this.progressBar.TabIndex = 2;
            // 
            // btn_slowMode
            // 
            this.btn_slowMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btn_slowMode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btn_slowMode.FlatAppearance.BorderSize = 0;
            this.btn_slowMode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_slowMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_slowMode.ForeColor = System.Drawing.Color.Red;
            this.btn_slowMode.Location = new System.Drawing.Point(178, 85);
            this.btn_slowMode.Margin = new System.Windows.Forms.Padding(0);
            this.btn_slowMode.Name = "btn_slowMode";
            this.btn_slowMode.Size = new System.Drawing.Size(75, 77);
            this.btn_slowMode.TabIndex = 6;
            this.btn_slowMode.Text = "Slow mode";
            this.btn_slowMode.UseVisualStyleBackColor = false;
            this.btn_slowMode.Click += new System.EventHandler(this.btn_slowMode_Click);
            // 
            // txt_log
            // 
            this.txt_log.Location = new System.Drawing.Point(662, 85);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_log.Size = new System.Drawing.Size(376, 153);
            this.txt_log.TabIndex = 7;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.progressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workCompleted);
            // 
            // btn_clearLog
            // 
            this.btn_clearLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btn_clearLog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btn_clearLog.FlatAppearance.BorderSize = 0;
            this.btn_clearLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_clearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clearLog.Location = new System.Drawing.Point(256, 85);
            this.btn_clearLog.Name = "btn_clearLog";
            this.btn_clearLog.Size = new System.Drawing.Size(75, 77);
            this.btn_clearLog.TabIndex = 9;
            this.btn_clearLog.Text = "Clear log";
            this.btn_clearLog.UseVisualStyleBackColor = false;
            this.btn_clearLog.Click += new System.EventHandler(this.btn_clearLog_Click);
            // 
            // btn_closeForm
            // 
            this.btn_closeForm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btn_closeForm.FlatAppearance.BorderSize = 0;
            this.btn_closeForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_closeForm.ForeColor = System.Drawing.Color.White;
            this.btn_closeForm.Image = global::MazeRunner_v2._0.Properties.Resources.close_icon;
            this.btn_closeForm.Location = new System.Drawing.Point(1016, 0);
            this.btn_closeForm.Margin = new System.Windows.Forms.Padding(0);
            this.btn_closeForm.Name = "btn_closeForm";
            this.btn_closeForm.Size = new System.Drawing.Size(34, 35);
            this.btn_closeForm.TabIndex = 8;
            this.btn_closeForm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_closeForm.UseVisualStyleBackColor = true;
            this.btn_closeForm.Click += new System.EventHandler(this.btn_closeForm_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(16, 254);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(636, 474);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(1050, 1077);
            this.Controls.Add(this.btn_clearLog);
            this.Controls.Add(this.btn_closeForm);
            this.Controls.Add(this.txt_log);
            this.Controls.Add(this.btn_slowMode);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btn_solve);
            this.Controls.Add(this.btn_load);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maze Runner v2.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Button btn_solve;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btn_slowMode;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.Button btn_closeForm;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button btn_clearLog;
    }
}

