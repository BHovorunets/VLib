using System.ComponentModel;
using System.Windows.Forms;

namespace VideoLibrary
{
    partial class DBexplorerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.AdditonClearButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.SelectButton = new System.Windows.Forms.Button();
            this.compererBox = new System.Windows.Forms.ComboBox();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.filterBox = new System.Windows.Forms.ComboBox();
            this.showTableBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(739, 247);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.showTableBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 265);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(739, 195);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control Panel";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.closeButton);
            this.groupBox2.Controls.Add(this.AdditonClearButton);
            this.groupBox2.Controls.Add(this.clearButton);
            this.groupBox2.Controls.Add(this.SelectButton);
            this.groupBox2.Controls.Add(this.compererBox);
            this.groupBox2.Controls.Add(this.filterTextBox);
            this.groupBox2.Controls.Add(this.filterBox);
            this.groupBox2.Location = new System.Drawing.Point(7, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(726, 122);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Rows";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(627, 89);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 8;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // AdditonClearButton
            // 
            this.AdditonClearButton.Location = new System.Drawing.Point(145, 89);
            this.AdditonClearButton.Name = "AdditonClearButton";
            this.AdditonClearButton.Size = new System.Drawing.Size(75, 23);
            this.AdditonClearButton.TabIndex = 7;
            this.AdditonClearButton.Text = "Clear";
            this.AdditonClearButton.UseVisualStyleBackColor = true;
            this.AdditonClearButton.Click += new System.EventHandler(this.AdditonClearButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(226, 89);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "Clear all";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(64, 89);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(75, 23);
            this.SelectButton.TabIndex = 4;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // compererBox
            // 
            this.compererBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.compererBox.FormattingEnabled = true;
            this.compererBox.Items.AddRange(new object[] {
            "=",
            "!=",
            ">",
            "<",
            ">=",
            "<=",
            "LIKE",
            "NOT LIKE"});
            this.compererBox.Location = new System.Drawing.Point(7, 50);
            this.compererBox.Name = "compererBox";
            this.compererBox.Size = new System.Drawing.Size(44, 21);
            this.compererBox.TabIndex = 5;
            this.compererBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.compererBox_MouseClick);
            // 
            // filterTextBox
            // 
            this.filterTextBox.Location = new System.Drawing.Point(57, 51);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(82, 20);
            this.filterTextBox.TabIndex = 4;
            this.filterTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.filterTextBox_MouseClick);
            this.filterTextBox.TextChanged += new System.EventHandler(this.filterTextBox_TextChanged);
            // 
            // filterBox
            // 
            this.filterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterBox.FormattingEnabled = true;
            this.filterBox.Location = new System.Drawing.Point(6, 19);
            this.filterBox.Name = "filterBox";
            this.filterBox.Size = new System.Drawing.Size(133, 21);
            this.filterBox.TabIndex = 2;
            this.filterBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.filterBox_MouseClick);
            // 
            // showTableBox
            // 
            this.showTableBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.showTableBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.showTableBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.showTableBox.FormattingEnabled = true;
            this.showTableBox.Location = new System.Drawing.Point(7, 20);
            this.showTableBox.Name = "showTableBox";
            this.showTableBox.Size = new System.Drawing.Size(163, 21);
            this.showTableBox.TabIndex = 0;
            this.showTableBox.SelectedValueChanged += new System.EventHandler(this.showTableBox_SelectedValueChanged);
            // 
            // DBexplorerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 464);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DBexplorerForm";
            this.Text = "Select and filter data from table";
            this.Load += new System.EventHandler(this.DBexplorerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private ComboBox showTableBox;
        private ComboBox filterBox;
        private GroupBox groupBox2;
        private Button SelectButton;
        private ComboBox compererBox;
        private TextBox filterTextBox;
        private Button clearButton;
        private Button AdditonClearButton;
        private Button closeButton;
    }
}