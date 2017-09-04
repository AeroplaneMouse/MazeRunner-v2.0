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
            this.btn_load = new System.Windows.Forms.Button();
            this.btn_solve = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txt_x = new System.Windows.Forms.TextBox();
            this.txt_y = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(8, 27);
            this.btn_load.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(143, 44);
            this.btn_load.TabIndex = 0;
            this.btn_load.Text = "Load";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // btn_solve
            // 
            this.btn_solve.Location = new System.Drawing.Point(155, 27);
            this.btn_solve.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_solve.Name = "btn_solve";
            this.btn_solve.Size = new System.Drawing.Size(143, 44);
            this.btn_solve.TabIndex = 1;
            this.btn_solve.Text = "Solve";
            this.btn_solve.UseVisualStyleBackColor = true;
            this.btn_solve.Click += new System.EventHandler(this.btn_solve_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(8, 8);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(636, 15);
            this.progressBar1.TabIndex = 2;
            // 
            // txt_x
            // 
            this.txt_x.Location = new System.Drawing.Point(8, 90);
            this.txt_x.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_x.Name = "txt_x";
            this.txt_x.Size = new System.Drawing.Size(55, 20);
            this.txt_x.TabIndex = 3;
            // 
            // txt_y
            // 
            this.txt_y.Location = new System.Drawing.Point(8, 111);
            this.txt_y.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_y.Name = "txt_y";
            this.txt_y.Size = new System.Drawing.Size(55, 20);
            this.txt_y.TabIndex = 4;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(8, 132);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(636, 474);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 614);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.txt_y);
            this.Controls.Add(this.txt_x);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_solve);
            this.Controls.Add(this.btn_load);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Main";
            this.Text = "Maze Runner v2.0";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Button btn_solve;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txt_x;
        private System.Windows.Forms.TextBox txt_y;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}

