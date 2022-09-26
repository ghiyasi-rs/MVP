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
            this.btn_MVP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_MVP = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_MVP
            // 
            this.btn_MVP.Location = new System.Drawing.Point(10, 16);
            this.btn_MVP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_MVP.Name = "btn_MVP";
            this.btn_MVP.Size = new System.Drawing.Size(494, 22);
            this.btn_MVP.TabIndex = 0;
            this.btn_MVP.Text = "Select Files";
            this.btn_MVP.UseVisualStyleBackColor = true;
            this.btn_MVP.Click += new System.EventHandler(this.btn_MVP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(10, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "MVP :";
            // 
            // lbl_MVP
            // 
            this.lbl_MVP.AutoSize = true;
            this.lbl_MVP.Location = new System.Drawing.Point(56, 52);
            this.lbl_MVP.Name = "lbl_MVP";
            this.lbl_MVP.Size = new System.Drawing.Size(0, 15);
            this.lbl_MVP.TabIndex = 3;
            // 
            // MVP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 81);
            this.Controls.Add(this.lbl_MVP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_MVP);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MVP";
            this.Text = "MVP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_MVP;
        private Label label1;
        private Label lbl_MVP;
    }
}