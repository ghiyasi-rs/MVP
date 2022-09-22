namespace MVP
{
    partial class MVP
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BestPlayer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BestPlayerScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_MVP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(565, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Select Files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TeamName,
            this.Score,
            this.BestPlayer,
            this.BestPlayerScore});
            this.dataGridView1.Location = new System.Drawing.Point(12, 103);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(565, 188);
            this.dataGridView1.TabIndex = 1;
            // 
            // TeamName
            // 
            this.TeamName.HeaderText = "TeamName";
            this.TeamName.MinimumWidth = 6;
            this.TeamName.Name = "TeamName";
            this.TeamName.Width = 125;
            // 
            // Score
            // 
            this.Score.HeaderText = "Score";
            this.Score.MinimumWidth = 6;
            this.Score.Name = "Score";
            this.Score.Width = 125;
            // 
            // BestPlayer
            // 
            this.BestPlayer.HeaderText = "BestPlayer";
            this.BestPlayer.MinimumWidth = 6;
            this.BestPlayer.Name = "BestPlayer";
            this.BestPlayer.Width = 125;
            // 
            // BestPlayerScore
            // 
            this.BestPlayerScore.HeaderText = "BestPlayerScore";
            this.BestPlayerScore.MinimumWidth = 6;
            this.BestPlayerScore.Name = "BestPlayerScore";
            this.BestPlayerScore.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "MVP :";
           
            // 
            // lbl_MVP
            // 
            this.lbl_MVP.AutoSize = true;
            this.lbl_MVP.Location = new System.Drawing.Point(64, 70);
            this.lbl_MVP.Name = "lbl_MVP";
            this.lbl_MVP.Size = new System.Drawing.Size(0, 20);
            this.lbl_MVP.TabIndex = 3;
            // 
            // MVP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_MVP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "MVP";
            this.Text = "MVP";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn TeamName;
        private DataGridViewTextBoxColumn Score;
        private DataGridViewTextBoxColumn BestPlayer;
        private DataGridViewTextBoxColumn BestPlayerScore;
        private Label label1;
        private Label lbl_MVP;
    }
}