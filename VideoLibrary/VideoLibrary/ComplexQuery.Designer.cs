namespace VideoLibrary
{
    partial class ComplexQueryForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Page1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MoviesComBox = new System.Windows.Forms.ComboBox();
            this.Page2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.Page1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Page1);
            this.tabControl1.Controls.Add(this.Page2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(703, 393);
            this.tabControl1.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Page1.Controls.Add(this.dataGridView1);
            this.Page1.Controls.Add(this.MoviesComBox);
            this.Page1.Location = new System.Drawing.Point(4, 22);
            this.Page1.Name = "Page1";
            this.Page1.Padding = new System.Windows.Forms.Padding(3);
            this.Page1.Size = new System.Drawing.Size(695, 367);
            this.Page1.TabIndex = 0;
            this.Page1.Text = "Movies";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 111);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(644, 210);
            this.dataGridView1.TabIndex = 1;
            // 
            // MoviesComBox
            // 
            this.MoviesComBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MoviesComBox.FormattingEnabled = true;
            this.MoviesComBox.Location = new System.Drawing.Point(28, 52);
            this.MoviesComBox.Name = "MoviesComBox";
            this.MoviesComBox.Size = new System.Drawing.Size(121, 21);
            this.MoviesComBox.TabIndex = 0;
            this.MoviesComBox.SelectedIndexChanged += new System.EventHandler(this.MoviesComBox_SelectedIndexChanged);
            // 
            // Page2
            // 
            this.Page2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Page2.Location = new System.Drawing.Point(4, 22);
            this.Page2.Name = "Page2";
            this.Page2.Padding = new System.Windows.Forms.Padding(3);
            this.Page2.Size = new System.Drawing.Size(695, 367);
            this.Page2.TabIndex = 1;
            this.Page2.Text = "Actors";
            // 
            // ComplexQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 476);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ComplexQueryForm";
            this.Text = "Complex Query Form";
            this.Load += new System.EventHandler(this.ComplexQueryForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Page1;
        private System.Windows.Forms.TabPage Page2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox MoviesComBox;
    }
}